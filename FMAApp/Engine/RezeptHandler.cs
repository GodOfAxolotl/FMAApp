using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FMAApp
{
    public static class RezeptHandler
    {
        public static List<Rezept> rezepte { get; set; }

        public static void setup()
        {
            rezepte = new List<Rezept>();
        }


        //Neues Rezept + Rezeptfenster
        public static void addRecipe(String name)
        {
            rezepte.Add(new Rezept(name));
        }


        public static void deleteAt(int idx)
        {
            rezepte.RemoveAt(idx);
            Rezept.staticIndex--;
        }

        public static void deleteAllRecipe()
        {
            rezepte.Clear();
            Rezept.staticIndex = 0;
        }
        //Delete Methoden die die statische Indexierung Auflösen

        public static void deleteIng(int ingRec, int ingidx)
        {
            rezepte[ingRec].neuesRezept.RemoveAt(ingidx);
        }
        



    }
}
