using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Navisworks.Api;

namespace LearningNavisworksAPI.AddinDockPane
{
    public partial class UCSearchModelItem : UserControl
    {
        /// <summary>
        /// Search object
        /// </summary>
        public Search Search { get; set; } = new Search();



        public UCSearchModelItem()
        {
            InitializeComponent();
        }


        /// <summary>
        /// if it get resized then the dock will be resized too (DocStyle.Fill)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            this.Dock = DockStyle.Fill;
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            
            var parseResult = int.TryParse(textBoxElementId.Text, out int elementId);
            if (!parseResult)
            {
                MessageBox.Show("ElementID is not an integer number");
                return;
            }

            // selection to search
            Search.Selection.SelectAll();

            // create the search condition
            var searchCondition = SearchCondition.HasPropertyByDisplayName("Element", "Id").EqualValue(new VariantData(elementId));

            // add the condition to the search
            Search.SearchConditions.Add(searchCondition);

            // collect ModelItem if found
            var modelItem = Search.FindFirst(Autodesk.Navisworks.Api.Application.ActiveDocument, false);
            

            if (modelItem != null)
            {
                Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Clear();
                Autodesk.Navisworks.Api.Application.ActiveDocument.CurrentSelection.Add(modelItem);
            }

        }
    }
}
