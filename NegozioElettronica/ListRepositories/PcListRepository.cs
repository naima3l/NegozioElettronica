using NegozioElettronica.Entities;
using NegozioElettronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.ListRepositories
{
    class PcListRepository : IPcDbManager
    {
        public static List<Pc> pcs = new List<Pc>()
        {
            new Pc("Lenovo","Yoga",25,Pc.EnumOperatingSystem.Windows,true, null),
            new Pc("Mac","11",5,Pc.EnumOperatingSystem.Mac,false, null),
            new Pc("Dell","xxx",21,Pc.EnumOperatingSystem.Linux,true, null),
            new Pc("Dell","xxy",1,Pc.EnumOperatingSystem.Windows,false, null)
        };

        public void Delete(Pc pc)
        {
            pcs.Remove(pc);
        }

        public List<Pc> Fetch()
        {
            return pcs;
        }

        public Pc GetById(int? id)
        {
            return pcs.Find(m => m.Id == id);
        }

        public void Insert(Pc pc)
        {
            pcs.Add(pc);
        }

        public void Update(Pc pc)
        {
            Insert(pc);
        }
    }
}
