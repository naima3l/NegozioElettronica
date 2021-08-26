using NegozioElettronica.Entities;
using NegozioElettronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.ListRepositories
{
    class TvListRepository : ITvDbManager
    {
        public static List<Tv> tvs = new List<Tv>()
        {
            new Tv("Lg","Smile",10,42,null),
            new Tv("Samsung","newx",16,50,null),
            new Tv("Telefunken","Rex",1,48,null)
        };

        public void Delete(Tv tv)
        {
            tvs.Remove(tv);
        }

        public List<Tv> Fetch()
        {
            return tvs;
        }

        public Tv GetById(int? id)
        {
            return tvs.Find(m => m.Id == id);
        }

        public void Insert(Tv tv)
        {
            tvs.Add(tv);
        }

        public void Update(Tv tv)
        {
            Insert(tv);
        }
    }
}
