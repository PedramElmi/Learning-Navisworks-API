using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Interop.ComApi;
using Autodesk.Navisworks.Api.ComApi;

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

        public InwOpState10 DocumentCOM { get; set; } = ComApiBridge.State;

        public UCCustomProperty()
        {
            InitializeComponent();
        }

        private void buttonCreateProperty_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{textBoxCategoryName.Text}{Environment.NewLine}{textBoxPropertyName.Text}{Environment.NewLine}{textBoxPropertyValue.Text}");

            if (ActiveDocument.CurrentSelection.SelectedItems.Count > 0)
            {

                foreach (var modelItem in ActiveDocument.CurrentSelection.SelectedItems)
                {

                    // conver ModelItem to COM Path
                    InwOaPath comModelItem = ComApiBridge.ToInwOaPath(modelItem);

                    // get ModelItem's PropertyCategoryCollection
                    var comPropertyCategoryCollection = DocumentCOM.GetGUIPropertyNode(comModelItem, true) as InwGUIPropertyNode2;

                    // create a new category (PropertyDataCollection)
                    var newCategory = DocumentCOM.ObjectFactory(nwEObjectType.eObjectType_nwOaPropertyVec,null,null) as InwOaPropertyVec;

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

                    // add CategoryData to ModelItem's CategoryDataCollection
                    comPropertyCategoryCollection.SetUserDefined(0, textBoxCategoryName.Text, textBoxCategoryName.Text + "_InternalName", newCategory);



                }

            }

        }
    }
}
