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
    public partial class UCProperties : UserControl
    {
        #region Properties
        /// <summary>
        /// The ActiveDocumnet from Autodesk.Navisworks.Api.Application.ActiveDocument
        /// </summary>
        private Document ActiveDocument { get => Autodesk.Navisworks.Api.Application.ActiveDocument; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor and Subscribe for the needed events
        /// </summary>
        public UCProperties()
        {
            InitializeComponent();


            ActiveDocument.CurrentSelection.Changed += this.CurrentSelection_Changed;
            Autodesk.Navisworks.Api.Application.ActiveDocumentChanged += this.CurrentSelection_Changed;

        }
        #endregion
        
        #region Methods
        /// <summary>
        /// Updates the current selection properties showing in the text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentSelection_Changed(object sender, EventArgs e)
        {
            // Pause or no active document check
            if (checkBoxPause.Checked || ActiveDocument == null)
            {
                return;
            }

            // clear the output text box
            textBoxOutput.Clear();

            // create result as list and add to it later on
            var result = new List<string>();



            // Collection of ModelItems
            foreach (var item in ActiveDocument.CurrentSelection.SelectedItems)
            {
                // the ModelItem DisplayName
                result.Add(item.DisplayName);

                // Property Categories
                foreach (var category in item.PropertyCategories)
                {

                    result.Add($"\t{category.DisplayName}");

                    foreach (var property in category.Properties)
                    {
                        result.Add($"\t\t{property.DisplayName}> {GetPropertyValue(property)}");
                    }

                }

                result.Add(Environment.NewLine);

            }

            // updating the text in the text box
            textBoxOutput.Text = string.Join(Environment.NewLine, result);

        }

        /// <summary>
        /// Helper method to Get Property Value with Navisworks method or ToString() method
        /// </summary>
        /// <param name="property">DataProperty that has propperty.Value.ToDisplayString()</param>
        /// <returns>the property value as string</returns>
        private string GetPropertyValue(Autodesk.Navisworks.Api.DataProperty property)
        {
            return property.Value.IsDisplayString ? property.Value.ToDisplayString() : property.Value.ToString() ;
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

        /// <summary>
        /// Find The searched ModelItems and Select it in Navisworks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFind_Click(object sender, EventArgs e)
        {

            // Query with System.Linq for getting the searched ModelItems
            var querySearchResult = from selectedmodelItem in ActiveDocument.CurrentSelection.SelectedItems
                                    from modelItem in selectedmodelItem.DescendantsAndSelf
                                    let modelItemFoundedByCategory = modelItem.PropertyCategories.FindCategoryByDisplayName(textBoxCategoryName.Text)
                                    where modelItemFoundedByCategory != null
                                    && modelItemFoundedByCategory.Properties.FindPropertyByDisplayName(textBoxPropertyName.Text) != null
                                    && GetPropertyValue(modelItemFoundedByCategory.Properties.FindPropertyByDisplayName(textBoxPropertyName.Text)) == textBoxPropertyValue.Text
                                    select modelItem;


            // Finish Query and store it in a list
            var searchResult = new List<ModelItem>(querySearchResult);


            ActiveDocument.CurrentSelection.Clear();

            ActiveDocument.CurrentSelection.AddRange(searchResult);

            labelCountResult.Text = searchResult.Count.ToString();

        }

        /// <summary>
        /// Create a saved selection set based on the current selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateSavedSet_Click(object sender, EventArgs e)
        {
            // the file name that sets will be stored inside of it
            var fileName = "Pedram Selection Sets";

            // the GUID of the set (it is used for the display name of the saved set)
            var setName = Guid.NewGuid().ToString();


            try
            {

                // create a set with current selected items
                var set = new SelectionSet(ActiveDocument.CurrentSelection.SelectedItems) { DisplayName = setName };
                var set2 = new SelectionSet();
                

                CreatePedramSelectionSet(fileName, setName, set);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
            }


        }

        /// <summary>
        /// Create a search and then store it on a saved search set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateSavedSearch_Click(object sender, EventArgs e)
        {
            // the file name that sets will be stored inside of it
            var fileName = "Pedram Search Sets";

            // the GUID of the set (it is used for the display name of the saved set)
            var setName = Guid.NewGuid().ToString();


            try
            {

                // create a search
                var search = new Search() { Locations = SearchLocations.DescendantsAndSelf };

                // make the search to search in all of the active document (not just the current selection)
                search.Selection.SelectAll();

                // have the search condition Category and Property Display name then Equals to the prop's value
                var searchCondition = SearchCondition.HasPropertyByDisplayName(
                    textBoxCategoryName.Text, textBoxPropertyName.Text).EqualValue(
                    VariantData.FromDisplayString(textBoxPropertyValue.Text));

                // adding the search condition above to the search
                search.SearchConditions.Add(searchCondition);

                // create a selection set based on the search
                var set = new SelectionSet(search) { DisplayName = setName };


                CreatePedramSelectionSet(fileName, setName, set);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Create the Selection set in the active document in the specified folder
        /// </summary>
        /// <param name="fileName">The folder name that will be created in the set</param>
        /// <param name="setName">The name of the set that is being saved</param>
        /// <param name="selectionSet">the selection set ready to be in the active document</param>
        private void CreatePedramSelectionSet(string fileName, string setName, SelectionSet selectionSet)
        {
            try
            {
                // search for the folder index (-1: not existed)
                var indexOfSelectionSet = ActiveDocument.SelectionSets.Value.IndexOfDisplayName(fileName);

                // create the set folder if it's not already exist
                if (indexOfSelectionSet == -1)
                {
                    ActiveDocument.SelectionSets.AddCopy(new FolderItem() { DisplayName = fileName });
                }

                // adding the selection set to active doc so it can be seen
                ActiveDocument.SelectionSets.AddCopy(selectionSet);

                // the folder object
                var setFolder = ActiveDocument.SelectionSets.Value[ActiveDocument.SelectionSets.Value.IndexOfDisplayName(fileName)] as FolderItem;

                // the set object
                var ns = ActiveDocument.SelectionSets.Value[ActiveDocument.SelectionSets.Value.IndexOfDisplayName(setName)];

                // moving the set object from the big parent to the specified folder
                ActiveDocument.SelectionSets.Move(
                    ns.Parent,
                    ActiveDocument.SelectionSets.Value.IndexOfDisplayName(setName),
                    setFolder,
                    0);

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        private void buttonSaveXmlData_Click(object sender, EventArgs e)
        {

            // will be added later

        }
    }
}
