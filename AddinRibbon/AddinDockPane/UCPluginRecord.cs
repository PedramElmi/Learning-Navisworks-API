using System;
using System.Text;
using System.Windows.Forms;

namespace LearningNavisworksAPI.AddinDockPane
{
    public partial class UCPluginRecord : UserControl
    {
        public UCPluginRecord()
        {
            InitializeComponent();
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            this.Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder pluginsData = IteratePlugins();
            textBox1.Text = pluginsData.ToString();
        }

        static public StringBuilder IteratePlugins()
        {
            var plugins = new StringBuilder();

            //iterate the plugins and display a list in a message box
            if (Autodesk.Navisworks.Api.Application.Plugins != null &&
               Autodesk.Navisworks.Api.Application.Plugins.PluginRecords != null)
            {
                foreach (Autodesk.Navisworks.Api.Plugins.PluginRecord pr in
                   Autodesk.Navisworks.Api.Application.Plugins.PluginRecords)
                {
                    //Append the plugin Information
                    plugins.Append("Id = ");
                    plugins.Append(pr.Id);
                    plugins.Append($"{Environment.NewLine}\tType = ");
                    plugins.Append(pr.GetType().ToString());
                    plugins.Append($"{Environment.NewLine}\tDeveloperId = ");
                    plugins.Append(pr.DeveloperId);
                    plugins.Append($"{Environment.NewLine}\tDisplayName = ");
                    plugins.Append(pr.DisplayName);
                    plugins.Append($"{Environment.NewLine}\tIsEnabled = ");
                    plugins.Append(pr.IsEnabled);
                    plugins.Append($"{Environment.NewLine}\tIsLoaded = ");
                    plugins.Append(pr.IsLoaded);
                    plugins.Append($"{Environment.NewLine}\tName = ");
                    plugins.Append(pr.Name);
                    plugins.Append($"{Environment.NewLine}\tPluginOptions = ");
                    plugins.Append(pr.PluginOptions.ToString());
                    plugins.Append($"{Environment.NewLine}\tToolTip = ");
                    plugins.Append(pr.ToolTip);

                    plugins.AppendLine();
                }

                

            }

            return plugins;
        }
    }
}
