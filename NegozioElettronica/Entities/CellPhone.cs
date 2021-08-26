using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Entities
{
    class CellPhone : Product
    {
        public int Memory { get; set; }

        public CellPhone()
        { }

        public CellPhone(string brand, string model, int quantity, int memory, int? id)
            :base(brand, model, quantity, id)
        {
            Memory = memory;
        }

        public override string Print()
        {
            return $"Cellulare -> {base.Print()}, Memoria in GB : {Memory} ";
        }
    }
}
