using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FMAApp
{
    public class Rezept : BaseNotificationClass
    {
        public List<Zutat> neuesRezept { get; set; }
        public string name { get; private set; }
        public RecipeCreationWindow RecipeWindow;

        public static int staticIndex = 0;
        public int internalIndex;

        Window initalSender;

        public Rezept(string name, Window sender)
        {
            neuesRezept = new List<Zutat>();
            this.name = name;
            initalSender = sender;
            internalIndex = staticIndex;
            staticIndex++;

            instantiateWindow(sender);
            Console.WriteLine($"{internalIndex} internal, {staticIndex}, external");
        }


        private void instantiateWindow(Window sender)
        {
            RecipeWindow = new RecipeCreationWindow(internalIndex);
            RecipeWindow.Show();

            OnPropertyChanged(nameof(neuesRezept));
        }

        //was machen Sachen?
        private void instantiateWindow(Window sender, int idx)
        {
            RecipeWindow = new RecipeCreationWindow(idx);
            RecipeWindow.Show();

            OnPropertyChanged(nameof(neuesRezept));
        }

        public void showWindow()
        {
            instantiateWindow(initalSender);

        }

        public void showWindow(int idx)
        {
            instantiateWindow(initalSender, idx);

        }

        public void addIngredient(string name, int amount)
        {
            neuesRezept.Add(new Zutat(name, amount));
            RecipeWindow.pullIngridientList(neuesRezept);

            OnPropertyChanged(nameof(neuesRezept));
        }

        public void deleteIngredient(int index)
        {
            neuesRezept.RemoveAt(index);
        }
        public override string ToString()
        {
            return name;
        }
    }
}
