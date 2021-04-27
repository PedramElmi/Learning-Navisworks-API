using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Navisworks.Api.Plugins;

namespace LearningNavisworksAPI.AddinDockPane
{
    [Plugin(name: "FirstDockPanePlugin", developerId: "PDEL", DisplayName = "Pedram First Tool Panel")]
    [DockPanePlugin(preferredWidth: 400, preferredHeight: 600, AutoScroll = false,FixedSize = true, MinimumHeight = 500, MinimumWidth = 200)]
    class FirstDockPanePlugin : DockPanePlugin
    {
        
        public TabControl myTabControl = new TabControl();


        /// <summary>
        /// Create control pane using UCUpdate user control
        /// </summary>
        /// <returns></returns>
        public override Control CreateControlPane()
        {

            myTabControl.ParentChanged += this.SetDockStyle_ParentChanged;

            var tabPage1 = new TabPage("Update");
            tabPage1.Controls.Add(new UCUpdate());
            myTabControl.TabPages.Add(tabPage1);

            var tabPage2 = new TabPage("Properties");
            tabPage2.Controls.Add(new UCProperties());
            myTabControl.TabPages.Add(tabPage2);

            var tabPage3 = new TabPage("PluginRecord");
            tabPage3.Controls.Add(new UCPluginRecord());
            myTabControl.TabPages.Add(tabPage3);

            var tabPage4 = new TabPage("LoadPlugin");
            tabPage4.Controls.Add(new UCLoadPlugin());
            myTabControl.TabPages.Add(tabPage4);

            var tabPage5 = new TabPage("TinyClashDetection");
            tabPage5.Controls.Add(new UCTinyClashDetection());
            myTabControl.TabPages.Add(tabPage5);

            var tabPage6 = new TabPage("Search");
            tabPage6.Controls.Add(new UCSearchModelItem());
            myTabControl.TabPages.Add(tabPage6);

            return myTabControl;
            
        }

        /// <summary>
        /// Set the tab dock-style to be fill when the parent is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDockStyle_ParentChanged(object sender, EventArgs e)
        {
            try
            {
                var tc = sender as TabControl;
                tc.Dock = DockStyle.Fill;

            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message}{Environment.NewLine}Event: {e}");
            }
        }

        /// <summary>
        /// Destroy the control pane
        /// </summary>
        /// <param name="pane"></param>
        public override void DestroyControlPane(Control pane)
        {
            try
            {
                
                pane?.Dispose();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
    }
}