using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMAApp
{
    public class Zutat
    {
        public string ingredient { get; set; }
        public int idx { get; set; }
        public int menge { get; set; }

        public Zutat(string ingredient, int idx, int menge)
        {
            this.ingredient = ingredient;
            this.idx = idx;
            this.menge = menge;
        }

        public override string ToString()
        {
            return ingredient;
        }
    }
}
