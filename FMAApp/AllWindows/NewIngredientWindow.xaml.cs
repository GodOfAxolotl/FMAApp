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
    public partial class NewIngredientWindow : Window
    {
        int index;
        public NewIngredientWindow(int index)
        {
            InitializeComponent();
            this.index = index;
            var bc = new BrushConverter();
            this.Background = (Brush)bc.ConvertFrom(Globals.backgroundColor);
        }

        //Dem verantwortlichen Rezept wird eine Zutat hinzugefügt, den Index des Rezeptes kennt es seit Initialisierung
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            RezeptHandler.rezepte[index].addIngredient(ingredientNameTextBox.Text, (int)amountSlider.Value);
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
