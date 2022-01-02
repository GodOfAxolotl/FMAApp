using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

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
            try
            {
                rezepte.RemoveAt(idx);
                Rezept.staticIndex--;
            } catch(Exception ex)
            {
                
            }
        }


        public static string ConvertToJson()
        {
            List<Rezept> clonedList = new List<Rezept>(rezepte);
            foreach(var c in clonedList)
            {
                c.RecipeWindow = null;
            }
            return JsonConvert.SerializeObject(clonedList, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }
        public static void deleteAllRecipe()
        {
            rezepte.Clear();
            Rezept.staticIndex = 0;
        }
        //Delete Methoden die die statische Indexierung Auflösen

        public static void deleteIng(int ingRec, int ingidx)
        {
            rezepte[ingRec].zutatenliste.RemoveAt(ingidx);
        }
        



    }
}
