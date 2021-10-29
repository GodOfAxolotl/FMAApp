using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMAApp
{
    public class Rezept
    {
        private List<Zutat> neuesRezept;
        public string name { get; private set; }
        public Rezept(string name)
        {
            neuesRezept = new List<Zutat>();
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
