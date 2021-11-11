using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public partial class RecipeCreationWindow : Window
    {
        int idx;
        public ObservableCollection<Zutat> ingList { get; set; }


        public RecipeCreationWindow(int idx)
        {
            InitializeComponent();
            ingList = new ObservableCollection<Zutat>();
            this.idx = idx;
            DataContext = this;

            var bc = new BrushConverter();
            this.Background = (Brush)bc.ConvertFrom(Globals.backgroundColor);
        }


        private void NeueZutatBtn_Click(object sender, RoutedEventArgs e)
        {
            NewIngredientWindow newIngredientWindow = new NewIngredientWindow(idx);
            newIngredientWindow.Owner = this;
            newIngredientWindow.Show();
        }

        //Zieht sich die Zutatenliste aus der Klasse, die die Methode aufruft. Schlechter Name für eine Schlechte Methode
        public void pullIngridientList(List<Zutat> listtopull)
        {
            ingList.Clear();
            foreach (Zutat ing in listtopull)
            {
                ingList.Add(ing);
            }
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
