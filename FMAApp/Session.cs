﻿using System;
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
            rezepte.Add(new Rezept("test"));
        }

        public void loop(object sender, EventArgs e)
        {
            update();
        }

        private void update()
        {
            OnPropertyChanged(nameof(rezepte));
        }

        public  void addNewRecepie(string name)
        {
            rezepte.Add(new Rezept(name));
        }

    }
}
