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

        private List<string> _cardridges;
        public List<string> cardridges
        {
            get
            {
                List<string> editedList = new List<string>();
                foreach(var s in ContainerHandler.cardridges)
                {
                    if(!string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s))
                    {
                        editedList.Add(s);
                    } 
                }
                return editedList;
            }
            set
            {
                _cardridges = value;
            }
        }


        public NewIngredientWindow(int index)
        {
            InitializeComponent();
            
            _cardridges = new List<string>();
            cardridges = new List<string>();
            pullListOfCardridges();
            this.index = index;
            var bc = new BrushConverter();
            this.Background = (Brush)bc.ConvertFrom(Globals.backgroundColor);
            DataContext = this;
            this.Tag = "child";

        }

        private void pullListOfCardridges()
        {
            cardridges.Clear();
            for(int i = 0; i < 8; i++)
            {
                cardridges.Add(ContainerHandler.cardridges[i]);
            }
        }

        //Dem verantwortlichen Rezept wird eine Zutat hinzugefügt, den Index des Rezeptes kennt es seit Initialisierung
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IngredientPicker.SelectedIndex != -1)
            {
                RezeptHandler.rezepte[index].addIngredient(ContainerHandler.cardridges[IngredientPicker.SelectedIndex], IngredientPicker.SelectedIndex, (int)amountSlider.Value);
            } else
            {
                MessageBox.Show("Auswahl darf nicht leer sein!", "Falsche Auswahl", MessageBoxButton.OK);
                return;
            }
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
