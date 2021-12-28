using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMAApp
{
    public class Zutat
    {
        private string _ingredient;
        public string ingredient
        {
            get
            {
                return _ingredient;
            }
            set
            {
                _ingredient = value;
            }
        }

        private int _menge;
        public int menge
        {
            get
            {
                return _menge;
            }
            set
            {
                _menge = value;
            }
        }

        private int _idx;
        public int idx
        {
            get; set;
        }

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
