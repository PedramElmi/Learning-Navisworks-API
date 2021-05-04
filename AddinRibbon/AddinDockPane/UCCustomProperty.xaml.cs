using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.ComApi;
using Autodesk.Navisworks.Api.Interop.ComApi;
using System.Windows;
using System.Windows.Controls;

namespace LearningNavisworksAPI.AddinDockPane
{
    /// <summary>
    /// Interaction logic for UCCustomProperty.xaml
    /// </summary>
    public partial class UCCustomProperty : UserControl
    {

        /// <summary>
        /// current doc in .NET
        /// </summary>
        public Document ActiveDocument { get; set; } = Autodesk.Navisworks.Api.Application.ActiveDocument;

        /// <summary>
        /// current doc in COM
        /// </summary>
        public InwOpState10 DocumentCOM { get; set; } = ComApiBridge.State;

        public UCCustomProperty()
        {
            InitializeComponent();
        }

        private void buttonCreateProperty_Click(object sender, RoutedEventArgs e)
        {

            if (ActiveDocument.CurrentSelection.SelectedItems.Count > 0)
            {

                foreach (ModelItem modelItem in ActiveDocument.CurrentSelection.SelectedItems)
                {

                    // convert ModelItem to COM Path
                    var comModelItem = ComApiBridge.ToInwOaPath(modelItem);

                    // get ModelItem's PropertyCategoryCollection object
                    var comPropertyCategoryCollection = DocumentCOM.GetGUIPropertyNode(comModelItem, true) as InwGUIPropertyNode2;

                    // get ModelItem's PropertyCategoryCollection data
                    InwGUIAttributesColl comPropertyCollection = comPropertyCategoryCollection.GUIAttributes();

                    //
                    bool foundMatchCategory = false;

                    // loop PropertyCategory
                    foreach (InwGUIAttribute2 propertyCategory in comPropertyCollection)
                    {

                        // if category's name match
                        if (propertyCategory.UserDefined && propertyCategory.ClassUserName == textBoxCategoryName.Text)
                        {
                            // found a category
                            foundMatchCategory = true;

                            // overwritten existing PropertyCategory with newly created PropertyCategory (existing + new)
                            // ndx = “0” is to create new PropertyCategory, “1” is to overwrite existing PropertyCategory
                            comPropertyCategoryCollection.SetUserDefined(
                                ndx: 1,
                                textBoxCategoryName.Text,
                                textBoxCategoryName.Text + "_InternalName",
                                AddNewPropertyToNewOrExistingCategory(propertyCategory));

                            if (foundMatchCategory)
                            {
                                break;
                            }

                        }

                    }

                    if (!foundMatchCategory)
                    {
                        // create a new category (PropertyDataCollection)
                        var newCategory = DocumentCOM.ObjectFactory(nwEObjectType.eObjectType_nwOaPropertyVec, null, null) as InwOaPropertyVec;

                        // create a new propertydata and add to category
                        // create a new property (PropertyData)
                        var newProperty = DocumentCOM.ObjectFactory(nwEObjectType.eObjectType_nwOaProperty, null, null) as InwOaProperty;

                        // set PropertyName
                        newProperty.name = textBoxPropertyName.Text + "_InternalName";

                        // set PropertyDisplayName
                        newProperty.UserName = textBoxPropertyName.Text;

                        // set PropertyValue
                        newProperty.value = textBoxPropertyValue.Text;

                        // add PropertyData to Category
                        newCategory.Properties().Add(newProperty);

                        comPropertyCategoryCollection.SetUserDefined(
                                    0,
                                    textBoxCategoryName.Text,
                                    textBoxCategoryName.Text + "_InternalName",
                                    newCategory);
                    }

                }

            }

        }

        private InwOaPropertyVec AddNewPropertyToNewOrExistingCategory(InwGUIAttribute2 propertyCategory)
        {
            // create a new category (PropertyDataCollection)
            var newCategory = DocumentCOM.ObjectFactory(nwEObjectType.eObjectType_nwOaPropertyVec, null, null) as InwOaPropertyVec;


            // retrieve existing PropertyData (name & value) and add to category
            foreach (InwOaProperty property in propertyCategory.Properties())
            {

                // create a new property (PropertyData)
                var existingProperty = DocumentCOM.ObjectFactory(nwEObjectType.eObjectType_nwOaProperty, null, null) as InwOaProperty;

                // set property name
                existingProperty.name = property.name;

                // set property display name
                existingProperty.UserName = property.UserName;

                // set property value
                existingProperty.value = property.value;

                // add to category
                newCategory.Properties().Add(existingProperty);

            }


            // create a new propertydata and add to category
            // create a new property (PropertyData)
            var newProperty = DocumentCOM.ObjectFactory(nwEObjectType.eObjectType_nwOaProperty, null, null) as InwOaProperty;

            // set PropertyName
            newProperty.name = textBoxPropertyName.Text + "_InternalName";

            // set PropertyDisplayName
            newProperty.UserName = textBoxPropertyName.Text;

            // set PropertyValue
            newProperty.value = textBoxPropertyValue.Text;

            // add PropertyData to Category
            newCategory.Properties().Add(newProperty);

            return newCategory;
        }
    }
}
