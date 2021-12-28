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

        notifier updater = new notifier();


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

        private void RezeptSpeichenBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoescheZutatBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ingList.RemoveAt(IngredientCollection.SelectedIndex);
                pushIngridientList();
            } catch(Exception ex)
            {

            }
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

        //Schiebt die Liste in die übergreifende Rezeptverwaltung um Änderungen von hieraus permanent zu machena
        public void pushIngridientList()
        {
            RezeptHandler.rezepte[idx].neuesRezept.Clear();
            foreach(var ing in ingList)
            {
                RezeptHandler.rezepte[idx].neuesRezept.Add(ing);
            }

        }
    }

    public class notifier : BaseNotificationClass
    {
        public notifier()
        {

        }

        public void notifyOfChange(object o)
        {
            OnPropertyChanged(nameof(o));
        }
    }
}
