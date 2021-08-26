using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Entities
{
    class Pc : Product
    {
        public EnumOperatingSystem OperatingSystem { get; set; }
        public bool TouchScreen { get; set; }

        public Pc()
        { }

        public Pc(string brand, string model, int quantity, EnumOperatingSystem operatingSystem, bool touchScreen, int? id)
           : base(brand, model, quantity, id)
        {
            OperatingSystem = operatingSystem;
            TouchScreen = touchScreen;
        }

        public override string Print()
        {
            return $"Pc -> {base.Print()}, Sistema operativo : {OperatingSystem}, Touchscreen : {TouchScreen} ";
        }

        public enum EnumOperatingSystem
        {
            Windows = 1,
            Mac = 2,
            Linux = 3
        }
    }
}
