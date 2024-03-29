﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace FMAApp
{
    /*
     TODO: Rezepte durchparsen wenn änderungen an den Containern gemacht werden, alle Rezepte Löschen
     */
    public partial class MainWindow : Window
    {
        public Session session;

        public MainWindow()
        {
            InitializeComponent();
            RezeptHandler.setup();
            ContainerHandler.setup();
            session = new Session();
            this.DataContext = session;

            var bc = new BrushConverter();
            this.Background = (Brush)bc.ConvertFrom(Globals.backgroundColor);
            this.Tag = "parent";

            box1Content.Text = "Igel";
            box2Content.Text = "Wasser";
            box3Content.Text = "Chlor";
            box4Content.Text = "Tomate";
            box5Content.Text = "Apfel";
            box6Content.Text = "Edelstahl";
            box7Content.Text = "Zitronenmelisse";
            box8Content.Text = "Premium Wodka";

            applyContainers();

        }

        //Klick auf den Neuen Rezept Knopf --> Fenster zur erstellung eines Rezept öffnen, Besitzer festlegen und Anzeigen
        private void NeuesRezeptBtn_Click(object sender, RoutedEventArgs e)
        {
            NewRecipeWindow newRecipeWindow = new NewRecipeWindow();
            newRecipeWindow.Owner = this;
            newRecipeWindow.updateEvent += session.loop;
            //Der updateEvent Eventhandler sorgt dafür, dass bei der erstellung des Rezeptes, die Werte einmal mit dem ViewModel synchronisiert werden
            newRecipeWindow.Show();
        }

        private void RezeptBearbeitenBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RezeptHandler.rezepte[RezeptCollection.SelectedIndex].showWindow(RezeptCollection.SelectedIndex);
            } catch(ArgumentOutOfRangeException ex)
            {
                RezeptCollection.SelectedIndex = -1;
            }
            //TODO: Anzeige glitcht, die Zutaten sind da, werden aber erst nach dem hinzufügen einer neuen angezeigt
        }

        private void RezeptLöschenBtn_Click(object sender, RoutedEventArgs e)
        {
            RezeptHandler.rezepte[RezeptCollection.SelectedIndex].RecipeWindow.Close();
            RezeptHandler.deleteAt(RezeptCollection.SelectedIndex);
            session.loop(this, EventArgs.Empty);
            //TODO: Rezept am ausgewählten Index Löschen, alle Indexe der Rezepte müssen aufrücken
        }

        private void AllesLöschenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Sind Sie sicher, dass Sie alle \nRezepte unwiederruflich löschen wollen?", "Löschen?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                RezeptHandler.deleteAllRecipe();
                session.loop(this, EventArgs.Empty);
                RezeptCollection.SelectedIndex = -1;

                foreach (Window item in App.Current.Windows)
                {
                    if (item != this)
                        item.Close();
                }
            }

        }

        private void SpeichernAufDiskBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wähle die zu überschreibende .alk Datei auf \n" +
                            "der Card oder erstelle eine neue .alk Datei \n" +
                            "(leere Datei mit Endung .alk)", "Speichern", MessageBoxButton.OK, MessageBoxImage.Information);

            var fileContent = string.Empty;
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "ALK files (*.alk)|*.alk|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                if(filePath.StartsWith("."))
                {
                    MessageBox.Show("Could not save file at " + filePath, "no yay", MessageBoxButton.OK);
                    openFileDialog = null;
                    return;
                }
                
            } else
            {
                MessageBox.Show("Could not save file", "no yay", MessageBoxButton.OK);
                openFileDialog = null;
                return;
            }

            string[] file = new string[5]; //convert_RezeptListeNachString();
            file[0] = "{\n";
            file[1] = "\"Container\" : " + ContainerHandler.ConvertToJson();
            file[1] += ",";
            file[3] = "\"Rezepte\" : " + RezeptHandler.ConvertToJson();
            file[4] = "}";
            save_file(file, filePath);
            MessageBox.Show("Saved file at: " + filePath, "yay", MessageBoxButton.OK);

            //TODO: Listen in Textdatei umwandeln
        }

        private bool save_file(string[] text, string path)
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter(path))
                {
                    foreach (string line in text)
                        outputFile.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save file!");
                return false;
            }

            return true;
            
        }

        private void applyContainerButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Dieser Vorgang löscht alle ihre vorherigen Rezepte. \nSind Sie sicher, dass alle Felder fehlerfrei sind?", "Zutaten anwenden", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                applyContainers();

                RezeptHandler.deleteAllRecipe();
                session.loop(this, EventArgs.Empty);
                RezeptCollection.SelectedIndex = -1;

                foreach (Window item in App.Current.Windows)
                {
                    if (item != this)
                        item.Close();
                }
            }
        }

        private void applyContainers()
        {
            ContainerHandler.cardridges[0] = box1Content.Text;
            ContainerHandler.cardridges[1] = box2Content.Text;
            ContainerHandler.cardridges[2] = box3Content.Text;
            ContainerHandler.cardridges[3] = box4Content.Text;
            ContainerHandler.cardridges[4] = box5Content.Text;
            ContainerHandler.cardridges[5] = box6Content.Text;
            ContainerHandler.cardridges[6] = box7Content.Text;
            ContainerHandler.cardridges[7] = box8Content.Text;
        }
    }
}


/*Icon - Allows you to define the icon of the window, which is usually shown in the upper left corner, to the left of the window title.

ResizeMode - This controls whether and how the end-user can resize your window. The default is CanResize, which allows the user to resize the window like any other window, either by using the maximize/minimize buttons or by dragging one of the edges. CanMinimize will allow the user to minimize the window, but not to maximize it or drag it bigger or smaller. NoResize is the strictest one, where the maximize and minimize buttons are removed and the window can't be dragged bigger or smaller.

ShowInTaskbar - The default is true, but if you set it to false, your window won't be represented in the Windows taskbar. Useful for non-primary windows or for applications that should minimize to the tray.

SizeToContent - Decide if the Window should resize itself to automatically fit its content. The default is Manual, which means that the window doesn't automatically resize. Other options are Width, Height and WidthAndHeight, and each of them will automatically adjust the window size horizontally, vertically or both.

Topmost - The default is false, but if set to true, your Window will stay on top of other windows unless minimized. Only useful for special situations.

WindowStartupLocation - Controls the initial position of your window. The default is Manual, which means that the window will be initially positioned according to the Top and Left properties of your window. Other options are CenterOwner, which will position the window in the center of it's owner window, and CenterScreen, which will position the window in the center of the screen.

WindowState - Controls the initial window state. It can be either Normal, Maximized or Minimized. The default is Normal, which is what you should use unless you want your window to start either maximized or minimized.*/
