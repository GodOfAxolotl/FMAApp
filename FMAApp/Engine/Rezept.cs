using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace FMAApp
{
    public class Rezept
    {

        public string name { get; private set; }
        public List<Zutat> zutatenliste { get; set; }
        public static int staticIndex = 0;
        public int internalIndex;
        public RecipeCreationWindow RecipeWindow;


        public Rezept(string name)
        {
            zutatenliste = new List<Zutat>();
            this.name = name;
            internalIndex = staticIndex;
            staticIndex++;
            instantiateWindow();
        }

        private void instantiateWindow()
        {
            RecipeWindow = new RecipeCreationWindow(internalIndex);
            RecipeWindow.Show();
            RecipeWindow.pullIngridientList(zutatenliste);
        }

        //was machen Sachen?
        //Überladung zur öffnung eines bereizt indizierten Rezeptes
        private void instantiateWindow(int idx)
        {
            RecipeWindow = new RecipeCreationWindow(idx);
            RecipeWindow.Show();
            RecipeWindow.pullIngridientList(zutatenliste);
        }

        public void showWindow()
        {
            instantiateWindow();
        }

        public void showWindow(int idx)
        {
            instantiateWindow(idx);

        }

        public void addIngredient(string name, int idx, int amount)
        {
            zutatenliste.Add(new Zutat(name, idx, amount));
            RecipeWindow.pullIngridientList(zutatenliste); //Synchro mit der View

        }

        public void deleteIngredient(int index)
        {
            zutatenliste.RemoveAt(index);
        }
        public override string ToString()
        {
            return name;
        }
    }
}
