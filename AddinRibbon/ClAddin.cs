using System.Windows.Forms;
using Autodesk.Navisworks.Api.Plugins;

namespace LearningNavisworksAPI
{

    [Plugin("LearningNavisworksAPI", "PDEL", DisplayName = "Learning Navisworks API")]
    [RibbonLayout("AddinRibbon.xaml")]
    [RibbonTab("ID_CustomTab_1", DisplayName = "Pedram's Stuff")]
    [Command("ID_Button_1", Icon = "1_16.png", LargeIcon = "1_32.png", ToolTip = "First DockPane Using WinForm")]
    [Command("ID_Button_2", ToolTip = "Second DockPane Using WPF")]
    public class ClAddin : CommandHandlerPlugin
    {
        /// <summary>
        /// when a button is clicked in the Ribbon then this will be called
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override int ExecuteCommand(string name, params string[] parameters)
        {

            switch (name)
            {
                case "ID_Button_1":
                    if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                    {
                        var pluginRecord = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("FirstDockPanePlugin.PDEL");

                        if (pluginRecord is DockPanePluginRecord && PluginRecord.IsEnabled)
                        {
                            var dockPane = (pluginRecord.LoadedPlugin ?? pluginRecord.LoadPlugin()) as DockPanePlugin;

                            dockPane.ActivatePane();
                        }
                    }
                    break;

                case "ID_Button_2":
                    if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                    {
                        var pluginRecord = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("SecondDockPanePlugin.PDEL");

                        if (pluginRecord is DockPanePluginRecord && PluginRecord.IsEnabled)
                        {
                            var dockPane = (pluginRecord.LoadedPlugin ?? pluginRecord.LoadPlugin()) as DockPanePlugin;

                            dockPane.ActivatePane();

                        }
                    }
                    break;

                default:
                    MessageBox.Show("WTF");
                    break;


            }
            

            return 0;
        }



    }

}
