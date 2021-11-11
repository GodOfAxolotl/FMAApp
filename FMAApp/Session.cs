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

        DispatcherTimer timer = new DispatcherTimer();
        public Session()
        {
            rezepte = new ObservableCollection<Rezept>();
        }

        public void loop(object sender, EventArgs e)
        {
            rezepte.Clear();
            foreach(Rezept rezept in RezeptHandler.rezepte)
            {
                rezepte.Add(rezept);
            }
            update();
        }

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
