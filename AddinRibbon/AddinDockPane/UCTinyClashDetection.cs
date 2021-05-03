using Autodesk.Navisworks.Api;
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
    public partial class UCTinyClashDetection : UserControl
    {
        /// <summary>
        /// current active document
        /// </summary>
        private Document ActiveDocument { get; } = Autodesk.Navisworks.Api.Application.ActiveDocument;

        /// <summary>
        /// Itesms that have intersection with selected items
        /// </summary>
        private ModelItemCollection IntersectedItems { get; set; } = new ModelItemCollection();

        /// <summary>
        /// Selected Items
        /// </summary>
        private ModelItemCollection SelectedItems { get; set; }

        /// <summary>
        /// other items in the active document
        /// </summary>
        public ModelItemCollection OtherItems { get; set; } = new ModelItemCollection();

        /// <summary>
        /// The Constructor
        /// </summary>
        public UCTinyClashDetection()
        {
            InitializeComponent();
        }


        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            this.Dock = DockStyle.Fill;
        }

        // get descendants from model item
        public IEnumerable<ModelItem> GetGeometryModelItems(Model model)
        {
            // collect all descendants geometric items from a model

            var output = from item in model.RootItem.Descendants
                         where item.HasGeometry
                         select item;

            return output;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // model items collection-1
            ModelItemCollection modelItemCollection = new ModelItemCollection();
            // get current selected items
            this.SelectedItems = new ModelItemCollection(ActiveDocument.CurrentSelection.SelectedItems);

            // each model
            foreach (Model model in ActiveDocument.Models)
            {
                // collect all items from the mode1
                // add to model item collection-1
                modelItemCollection.AddRange(GetGeometryModelItems(model));
            }

            var intersectedItems = from item1 in modelItemCollection
                                   from item2 in this.SelectedItems
                                   let box1 = item1.BoundingBox(true)
                                   let box2 = item2.BoundingBox(true)
                                   where box1.Intersects(box2)
                                   select item1;



            this.IntersectedItems.CopyFrom(intersectedItems);

            // Transparency of other items
            // clear OtherItems
            this.OtherItems.Clear();
            // add selected items
            OtherItems.AddRange(SelectedItems);
            // add intersected items
            OtherItems.AddRange(intersectedItems);
            // invert the items!
            OtherItems.Invert(ActiveDocument);
            
            
            // change the color of model item collection-2 items 
            ActiveDocument.Models.OverrideTemporaryColor(intersectedItems, Autodesk.Navisworks.Api.Color.Red);
            ActiveDocument.Models.OverrideTemporaryColor(this.SelectedItems, Autodesk.Navisworks.Api.Color.Green);
            // Make other Items transparent
            ActiveDocument.Models.OverrideTemporaryTransparency(OtherItems, transparency: 0.9);

            // enable the reset button
            button2.Enabled = true;
            button1.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // reset color and transparency
            ActiveDocument.Models.ResetTemporaryMaterials(this.SelectedItems);
            ActiveDocument.Models.ResetTemporaryMaterials(this.IntersectedItems);
            ActiveDocument.Models.ResetTemporaryMaterials(this.OtherItems);

            // disable the reset button
            button2.Enabled = false;
            button1.Enabled = true;
        }
    }
}
