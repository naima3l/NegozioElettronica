using NegozioElettronica.ADORepositories;
using NegozioElettronica.Entities;
using NegozioElettronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.ListRepositories
{
    class ProductListRepository : IProductDbManager<Product>
    {
        static List<Product> products = new List<Product>();

        //public static CellPhoneListRepository cr = new CellPhoneListRepository();
        //public static PcListRepository pr = new PcListRepository();
        //public static TvListRepository tr = new TvListRepository();

        public static CellPhoneADORepository cr = new CellPhoneADORepository();
        public static PcADORepository pr = new PcADORepository();
        public static TvADORepository tr = new TvADORepository();

        public List<Product> Fetch()
        {
            List<CellPhone> cellPhones = cr.Fetch();
            List<Pc> pcs = pr.Fetch();
            List<Tv> tvs = tr.Fetch();

            products.AddRange(cellPhones);
            products.AddRange(pcs);
            products.AddRange(tvs);

            return products;
        }
    }
}
