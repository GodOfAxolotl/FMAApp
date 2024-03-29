﻿using System;
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
        public event EventHandler updateEvent; //Event zur Synchronisierung des Rezeptnamens mit dem ViewModel, welches das Rezept initialisiert 


        public NewRecipeWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(NewRecepie_Loaded);

            var bc = new BrushConverter();
            this.Background = (Brush)bc.ConvertFrom(Globals.backgroundColor);

            this.Tag = "child";
        } 

        //Methode zum ABrufen des Eventhandlers
        protected void OnUpdateEvent()
        {
            if(this.updateEvent != null)
                this.updateEvent(this, EventArgs.Empty);
        }

        //Keine Ahnung ehrlichgesagt, ist trotzdem wichtig
        void NewRecepie_Loaded(object sender, RoutedEventArgs e)
        {
            this.OnUpdateEvent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Rezept im RezeptHandler hinzufügen und VM über die Änderung informieren- Ist das die best practice? Auf keinen Fall. Aber ist es eine good practice? Wahrscheinlich nicht.
        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != "" && NameTextBox.Text.Length < 30)
            {
                RezeptHandler.addRecipe(NameTextBox.Text);
                OnUpdateEvent();
                Close();
            } else
            {
                MessageBox.Show("Text muss zwischen 1 und 30 Zeichen lang sein", "Warnung", MessageBoxButton.OK);
                NameTextBox.Text = "";
            }
        }
    }
}
