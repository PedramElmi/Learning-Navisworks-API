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
    [DockPanePlugin(preferredWidth: 600, preferredHeight: 350, AutoScroll = false, FixedSize = true, MinimumHeight = 350, MinimumWidth = 600)]
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


            //return the ElementHost
            return elementHost;
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
