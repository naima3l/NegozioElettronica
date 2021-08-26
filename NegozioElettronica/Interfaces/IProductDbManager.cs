using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Interfaces
{
    interface IProductDbManager<T>
    {
        public List<T> Fetch();
    }
}
