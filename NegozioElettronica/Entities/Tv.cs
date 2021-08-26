using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Entities
{
    class Tv : Product
    {
        public int Inches { get; set; }

        public Tv()
        { }

        public Tv(string brand, string model, int quantity, int inches, int? id)
           :base(brand, model, quantity, id)
        {
            Inches = inches;
        }

        public override string Print()
        {
            return $"Tv -> {base.Print()}, Pollici : {Inches} ";
        }
    }
}
