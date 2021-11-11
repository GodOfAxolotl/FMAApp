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
    /// Interaktionslogik für NewRecipeWindow.xaml
    /// </summary>
    public partial class NewRecipeWindow : Window
    {
        public event EventHandler updateEvent;
        public NewRecipeWindow()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(NewRecepie_Loaded);

            var bc = new BrushConverter();
            this.Background = (Brush)bc.ConvertFrom(Globals.backgroundColor);
        } 

        protected void OnUpdateEvent()
        {
            if(this.updateEvent != null)
                this.updateEvent(this, EventArgs.Empty);
        }

        void NewRecepie_Loaded(object sender, RoutedEventArgs e)
        {
            this.OnUpdateEvent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            RezeptHandler.addRecepie(NameTextBox.Text, this);
            OnUpdateEvent();
            Close();
        }
    }
}
