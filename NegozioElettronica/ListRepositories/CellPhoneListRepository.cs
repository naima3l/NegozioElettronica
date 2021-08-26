using NegozioElettronica.Entities;
using NegozioElettronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.ListRepositories
{
    class CellPhoneListRepository : ICellPhoneDbManager
    {
        public static List<CellPhone> cellPhones = new List<CellPhone>()
        {
            new CellPhone("Samsung","s10",19,20,null),
            new CellPhone("IPhone","x",15,16,null),
            new CellPhone("Huawei","P40",9,128,null),
            new CellPhone("Motorola","zFlip",6,56,null)
        };

        public void Delete(CellPhone cellPhone)
        {
            cellPhones.Remove(cellPhone);
        }

        public List<CellPhone> Fetch()
        {
            return cellPhones;
        }

        public CellPhone GetById(int? id)
        {
            return cellPhones.Find(m => m.Id == id);
        }

        public void Insert(CellPhone cellPhone)
        {
            cellPhones.Add(cellPhone);
        }

        public void Update(CellPhone cellPhone)
        {
            Insert(cellPhone);
        }
    }
}
