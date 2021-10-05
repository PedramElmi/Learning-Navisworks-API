using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningNavisworksAPI.AddinDockPane
{
    /// <summary>
    /// this is my user control for the duckpane plugin
    /// </summary>
    public partial class UCUpdate : UserControl
    {
        #region fields

        private Timer updateTimer = new Timer { Enabled = true, Interval = 1000 };

        private List<FileInfo> listInfo = new List<FileInfo>();

        #endregion

        #region Properties

        public Timer UpdateTimer
        {
            get { return updateTimer; }
            set { updateTimer = value; }
        }

        /// <summary>
        /// List of Navisworks file models
        /// </summary>
        public List<FileInfo> ListInfo
        {
            get { return listInfo; }
            set { listInfo = value; }
        }

        #endregion

        #region Constructor
        public UCUpdate()
        {
            InitializeComponent();
            

            UpdateTimer.Tick += this.UpdateTimer_Tick;


            Autodesk.Navisworks.Api.Application.ActiveDocumentChanged += this.CleanListInfo_ActiveDocumentChanged;

        }

        /// <summary>
        /// Clears ListInfo when ActiveDocumentChanged Event happens.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CleanListInfo_ActiveDocumentChanged(object sender, EventArgs e)
        {
            ListInfo.Clear();
        }

        /// <summary>
        /// checks for the updated files (models)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            // pause button is checked then no need to check for an update
            if (CheckBoxPause.Checked)
            {
                return;
            }

            // the active document on the navisworks
            var activeDocument = Autodesk.Navisworks.Api.Application.ActiveDocument;

            // if there is no active document on the navisworks then no need to update
            if (activeDocument == null)
            {
                return;
            }

            // loop each model and do the update
            foreach (var model in activeDocument.Models)
            {
                if (model is null)
                {
                    return;
                }
                // having the current model file object
                var currentInfo = new FileInfo(model.SourceFileName);

                // if the model is already in the list then this is the model if not then this is null.
                var lastInfo = ListInfo.FirstOrDefault(i => i.FullName == currentInfo.FullName);

                // if the model is not null then do the update else just add the model to the list.
                if (lastInfo != null)
                {
                    var time = Math.Abs((lastInfo.LastWriteTime - currentInfo.LastWriteTime).TotalSeconds);

                    if (time > 1)
                    {
                        ListInfo.Remove(lastInfo);
                        ListInfo.Add(currentInfo);

                        textBoxLog.AppendText($"{currentInfo.Name} was updated!{Environment.NewLine}");

                        if (CheckBoxAutoUpdate.Checked)
                        {
                            UpdateModel();
                        }
                        else
                        {
                            ButtonUpdate.Enabled = true;
                        }

                    }

                }
                else
                {
                    ListInfo.Add(currentInfo);
                }

            }




        }

        /// <summary>
        /// Updates the active document running in Navisworks (all of models)
        /// </summary>
        private void UpdateModel()
        {
            // make plug-in smart when update is running
            ButtonUpdate.Enabled = false;

            // updates the model
            Autodesk.Navisworks.Api.Application.ActiveDocument.UpdateFiles();

            // print in text-box log
            textBoxLog.AppendText($"The active document was updated!{Environment.NewLine}");
        }
        #endregion

        #region Methods
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            Dock = DockStyle.Fill;
        }

        private void ButtonUpdate_MouseUp(object sender, MouseEventArgs e)
        {

            UpdateModel();

        }
        #endregion
    }
}
