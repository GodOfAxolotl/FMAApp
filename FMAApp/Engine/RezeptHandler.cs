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


        public static void addRecepie(String name, Window sender)
        {
            rezepte.Add(new Rezept(name, sender));
        }




    }
}
