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
    /// Interaktionslogik für RecipeCreationWindow.xaml
    /// </summary>
    public partial class RecipeCreationWindow : Window
    {

        public int rezeptID;
        public RecipeCreationWindow()
        {
            InitializeComponent();
            var bc = new BrushConverter();
            this.Background = (Brush)bc.ConvertFrom(Globals.backgroundColor);
            DataContext = this;
        }

        private void NeueZutatBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.zutatFensterÖffnen();
        }

        private void BearbeitenZutatBtn_Click(object sender, RoutedEventArgs e)
        {
            //Index auslesen, Zutat ändern
        }

        private void RezeptSpeichenBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Rezeptklasse erstellen, Zutaten zu Rezept konvertieren, an Session weiterleiten
        }

        private void AbbrechenBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
            
        }
    }
}
