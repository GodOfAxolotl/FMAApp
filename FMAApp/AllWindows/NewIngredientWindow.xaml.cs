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
using System.Windows.Shapes;

namespace FMAApp
{
    /// <summary>
    /// Interaktionslogik für NewIngredientWindow.xaml
    /// </summary>
    public partial class NewIngredientWindow : Window
    {
        public NewIngredientWindow()
        {
            InitializeComponent();
            var bc = new BrushConverter();
            this.Background = (Brush)bc.ConvertFrom(Globals.backgroundColor);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Session.rezepte[0].addIngredient(ingredientNameTextBox.Text, 1);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
