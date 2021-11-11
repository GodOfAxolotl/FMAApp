using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FMAApp
{
    public class Session : BaseNotificationClass
    {
        public ObservableCollection<Rezept> rezepte { get; set; }


        public Session()
        {
            rezepte = new ObservableCollection<Rezept>();
        }


        //Methode zur Synchronisierung der Rezeptliste, die die View für das Bindung nutzt und der Sammlung des Models. Do not Touch, it works
        public void loop(object sender, EventArgs e)
        {
            rezepte.Clear();
            foreach(Rezept rezept in RezeptHandler.rezepte)
            {
                rezepte.Add(rezept);
            }
            update();
        }

        //Unwichtig, soll Sachen zum aufwecken der GUI enthalten
        private void update()
        {
            OnPropertyChanged(nameof(rezepte));
        }

    }

    public static class Globals
    {
        public static string btnColor1 = "#8E9AAF";
        public static string btnColor2 = "#757F91";

        public static string backgroundColor = "#E6E4EE";

    }
}
