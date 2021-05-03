using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Autodesk.Navisworks.Api.Plugins;

namespace LearningNavisworksAPI.AddinDockPane
{

    [Plugin(name: "SecondDockPanePlugin", developerId: "PDEL", DisplayName = "Pedram Second Tool Panel")]
    [DockPanePlugin(preferredWidth: 350, preferredHeight: 150, AutoScroll = false, FixedSize = false, MinimumHeight = 150, MinimumWidth = 250)]
    class SecondDockPanePlugin : DockPanePlugin
    {

        public override Control CreateControlPane()
        {
            //create an ElementHost
            ElementHost elementHost = new ElementHost
            {

                //assign the control
                AutoSize = true,
                Child = new UCCustomProperty()

            };

            elementHost.CreateControl();

            elementHost.ParentChanged += this.ElementHost_ParentChanged;


            //return the ElementHost
            return elementHost;
        }

        /// <summary>
        /// Resizing DockPane implies resizing WPF-based ElementHost
        /// </summary>
        /// <param name="sender">ElementHost</param>
        /// <param name="e"></param>
        private void ElementHost_ParentChanged(object sender, EventArgs e)
        {
            if (sender is ElementHost elementHost)
            {
                elementHost.Dock = DockStyle.Fill;
            }
        }

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
