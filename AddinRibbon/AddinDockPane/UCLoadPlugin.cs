using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningNavisworksAPI.AddinDockPane
{
    public partial class UCLoadPlugin : UserControl
    {
        public UCLoadPlugin()
        {
            InitializeComponent();
        }


        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// currently working. not complete.
        /// </summary>
        private void LoadPlugin()
        {
            ////the name of the plug-in which is to be loaded dynamically
            //string pluginNameToLoad = "NWAPI_HelloWorld_AddInTab.ADSK";

            //// plug-in record
            //PluginRecord dotest = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin(pluginNameToLoad);


            //if (dotest != null)
            //    // the plug-in binary has been loaded. exit.
            //    MessageBox.Show("the plug-in " + pluginNameToLoad + " has been loaded!");
            //else
            //    // load the plug-in binary from full file path name
            //    Autodesk.Navisworks.Api.Application.Plugins.AddPluginAssembly(
            //                 @"<Plugin Binary Path>\Lab-02.dll");

            //// get the plug-in record.
            //PluginRecord otherPluginRecord =
            //    Autodesk.Navisworks.Api.Application.Plugins.
            //                        FindPlugin(pluginNameToLoad);
            //if (otherPluginRecord != null)
            //{
            //    if (!otherPluginRecord.IsLoaded)
            //    {
            //        //if not loaded, load the plug-in
            //        otherPluginRecord.LoadPlugin();

            //        ////call Execute method if it is an AddInPlugin
            //        string[] pa = { "dummy" };
            //        int returnV = Autodesk.Navisworks.Api.Application.Plugins.ExecuteAddInPlugin(pluginNameToLoad, pa);

            //        //or call one method of the plug-in
            //        //get the plug-in of the record
            //        Plugin otherplugin = otherPluginRecord.LoadedPlugin;

            //        //since we do not know the type of the other plug-in,
            //        //use InvokeMember
            //        string[] pa = { "dummy" };
            //        otherplugin.GetType().InvokeMember("myMethod",System.Reflection.BindingFlags.InvokeMethod,null, otherplugin, pa);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Something is wrong! did not loaded.");
            //}


            //var models = Autodesk.Navisworks.Api.Application.ActiveDocument.Models.First;

        }
    }
}
