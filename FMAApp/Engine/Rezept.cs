using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMAApp
{
    public class Rezept
    {
        public ObservableCollection<Zutat> neuesRezept { get; set; }
        public string name { get; private set; }
        public Rezept(string name)
        {
            neuesRezept = new ObservableCollection<Zutat>();
            this.name = name;
        }

        public void addIngredient(string name, int amount)
        {
            neuesRezept.Add(new Zutat(name, amount));
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
