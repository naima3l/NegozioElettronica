using NegozioElettronica.ADORepositories;
using NegozioElettronica.Entities;
using NegozioElettronica.ListRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NegozioElettronica.Entities.Pc;

namespace NegozioElettronica
{
    class ShopManager
    {
        public static ProductListRepository pr = new ProductListRepository();
        //public static CellPhoneListRepository cr = new CellPhoneListRepository();
        //public static PcListRepository pcr = new PcListRepository();
        //public static TvListRepository tr = new TvListRepository();

        //ado
        public static CellPhoneADORepository cr = new CellPhoneADORepository();
        public static PcADORepository pcr = new PcADORepository();
        public static TvADORepository tr = new TvADORepository();

        internal static void ShowProducts()
        {
            List<Product> products = pr.Fetch();

            foreach(var x in products)
            {
                Console.WriteLine(x.Print());
            }
        }

        internal static void ShowCellPhones()
        {
            List<CellPhone> cellPhones = cr.Fetch();

            foreach(var x in cellPhones)
            {
                Console.WriteLine(x.Print());
            }
        }

        internal static void ShowPcs()
        {
            List<Pc> pcs = pcr.Fetch();

            foreach (var x in pcs)
            {
                Console.WriteLine(x.Print());
            }
        }

        internal static void ShowTvs()
        {
            List<Tv> tvs = tr.Fetch();

            foreach (var x in tvs)
            {
                Console.WriteLine(x.Print());
            }
        }

        internal static void InsertProduct()
        {
            int chosenProduct;
            bool isInt;

            do
            {
                Console.WriteLine("Che prodotto vuoi inserire?");
                Console.WriteLine("Premi 1 per inserire un cellulare");
                Console.WriteLine("Premi 2 per inserire un pc");
                Console.WriteLine("Premi 3 per inserire una tv");

                isInt = int.TryParse(Console.ReadLine(), out chosenProduct);

            } while (!isInt || chosenProduct <= 0 || chosenProduct >= 4);

            switch (chosenProduct)
            {
                case 1:
                    CellPhone cellPhone = CellPhoneData();
                    cr.Insert(cellPhone);
                    break;
                case 2:
                    Pc pc = PcData();
                    pcr.Insert(pc);
                    break;
                case 3:
                    Tv tv = TvData();
                    tr.Insert(tv);
                    break;
            }

        }

        private static Tv TvData()
        {
            Product product = ProductData();
            Tv tv = new Tv();
            tv.Brand = product.Brand;
            tv.Model = product.Model;
            tv.Quantity = product.Quantity;

            int inches;
            bool isInt;

            do
            {
                Console.WriteLine("Inserisci i pollici");
                isInt = int.TryParse(Console.ReadLine(), out inches);
            } while (!isInt);
            tv.Inches = inches;

            return tv;
        }

        private static Pc PcData()
        {
            Product product = ProductData();
            Pc pc = new Pc();
            pc.Brand = product.Brand;
            pc.Model = product.Model;
            pc.Quantity = product.Quantity;

            int so;
            int touch;
            bool isInt;

            do
            {
                Console.WriteLine("Inserisci il sistema operativo : 1. Windows, 2. Mac, 3. Linux");
                isInt = int.TryParse(Console.ReadLine(), out so);
            } while (!isInt);
            pc.OperatingSystem = (EnumOperatingSystem)so;

            do
            {
                Console.WriteLine("E' touchscreen? 0 -> no, 1 -> sì :");
                int t;
                isInt = int.TryParse(Console.ReadLine(), out touch);
            } while (!isInt);
            pc.TouchScreen = Convert.ToBoolean(touch);

            return pc;
        }

        private static CellPhone CellPhoneData()
        {
            Product product = ProductData();
            CellPhone cellPhone = new CellPhone();
            cellPhone.Brand = product.Brand;
            cellPhone.Model = product.Model;
            cellPhone.Quantity = product.Quantity;

            int memory;
            bool isInt;

            do
            {
                Console.WriteLine("Inserisci la memoria");
                isInt = int.TryParse(Console.ReadLine(), out memory);
            } while (!isInt);
            cellPhone.Memory = memory;

            return cellPhone;
        }

        internal static void TvsByInches(int inches)
        {
            List<Tv> tvs = tr.Fetch();
            var tvInches = tvs.Where(u => u.Inches == inches);

            if (tvInches.Count() == 0)
            {
                Console.WriteLine($"Non esiste nessuna tv con {inches} pollici");
            }
            else
            {
                foreach (var x in tvInches)
                {
                    Console.WriteLine(x.Print());
                }
            }
        }

        internal static void PcsByOperatingSystem(EnumOperatingSystem so)
        {
            List<Pc> pcs = pcr.Fetch();
            var pcSO = pcs.Where(u => u.OperatingSystem == so);

            if(pcSO.Count() == 0)
            {
                Console.WriteLine($"Non esiste nessun pc con sistema operativo {so}");
            }
            else
            {
                foreach (var x in pcSO)
                {
                    Console.WriteLine(x.Print());
                }
            }
        }

        internal static void CellPhonesByMemory(int memory)
        {
            List<CellPhone> cellPhones = cr.Fetch();
            var cellPhonesMemory = cellPhones.Where(u => u.Memory > memory);
            if(cellPhonesMemory.Count() == 0)
            {
                Console.WriteLine($"Non esiste nessun cellulare con memoria superiore a {memory}");
            }
            else
            {
                foreach(var x in cellPhonesMemory)
                {
                    Console.WriteLine(x.Print());
                }
            }
        }

        private static Product ProductData()
        {
            Product product = new Product();

            Console.WriteLine("Inserisci la marca");
            product.Brand = Console.ReadLine();

            Console.WriteLine("Inserisci il modello");
            product.Model = Console.ReadLine();

            product.Quantity = 1;

            return product;
        }

        internal static void UpdateProduct()
        {
            int chosenProduct;
            bool isInt;

            do
            {
                Console.WriteLine("Che prodotto vuoi modificare?");
                Console.WriteLine("Premi 1 per inserire un cellulare");
                Console.WriteLine("Premi 2 per inserire un pc");
                Console.WriteLine("Premi 3 per inserire una tv");

                isInt = int.TryParse(Console.ReadLine(), out chosenProduct);

            } while (!isInt || chosenProduct <= 0 || chosenProduct >= 4);

            switch (chosenProduct)
            {
                case 1:
                    CellPhone cellPhoneChosen = ChooseCellPhone();
                    if(cellPhoneChosen.Id == null)
                    {
                        cr.Delete(cellPhoneChosen);
                    }

                    CellPhone cellPhone = ChangeCellPhoneData(cellPhoneChosen);
                    cr.Update(cellPhone);
                    break;
                case 2:
                    Pc pcChosen = ChoosePc();
                    if (pcChosen.Id == null)
                    {
                        pcr.Delete(pcChosen);
                    }

                    Pc pc = ChangePcData(pcChosen);
                    pcr.Update(pc);
                    break;
                case 3:
                    Tv tvChosen = ChooseTv();
                    if (tvChosen.Id == null)
                    {
                        tr.Delete(tvChosen);
                    }

                   Tv tv = ChangeTvData(tvChosen);
                    tr.Update(tv);
                    break;
            }
        }

        private static Tv ChangeTvData(Tv tv)
        {
            bool check = true;
            int choice;
            do
            {
                Console.WriteLine("Quale dato vuoi modificare? \n1. Marca \n2.Modello \n3.Quantità \n4.Pollici \n0.Per non modificare");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Inserisci la marca :");
                        tv.Brand = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Inserisci il modello :");
                        tv.Model = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Inserisci la quantità :");
                        int quantity;
                        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
                        {
                            Console.WriteLine("Scelta non valida! Riprova.");
                        }
                        tv.Quantity = quantity;
                        break;
                    case 4:
                        Console.WriteLine("Inserisci i pollici :");
                        int p = 0;
                        while (!int.TryParse(Console.ReadLine(), out p) || p < 0)
                        {
                            Console.WriteLine("Scelta non valida! Riprova.");
                        }
                        tv.Inches = p;
                        break;
                    case 0:
                        check = false;
                        break;
                }

            } while (check);
            return tv;
        }

        private static Tv ChooseTv()
        {
            List<Tv> tvs = tr.Fetch();

            int i = 1;
            foreach (var x in tvs)
            {
                Console.WriteLine($"Premi {i} per {x.Print()}");
                i++;
            }

            bool isInt;
            int tvChosen;
            do
            {
                Console.WriteLine("Quale cellulare vuoi eliminare/modificare?");

                isInt = int.TryParse(Console.ReadLine(), out tvChosen);

            } while (!isInt || tvChosen <= 0 || tvChosen > tvs.Count);

            return tvs.ElementAt(tvChosen - 1);
        }

        private static Pc ChangePcData(Pc pc)
        {
            bool check = true;
            int choice;
            do
            {
                Console.WriteLine("Quale dato vuoi modificare? \n1. Marca \n2.Modello \n3.Quantità \n4.Sistema operativo \n5.Touchscreen \n0.Per non modificare");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 5)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Inserisci la marca :");
                        pc.Brand = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Inserisci il modello :");
                        pc.Model = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Inserisci la quantità :");
                        int quantity;
                        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
                        {
                            Console.WriteLine("Scelta non valida! Riprova.");
                        }
                        pc.Quantity = quantity;
                        break;
                    case 4:
                        Console.WriteLine("Inserisci il sistema operativo : 1.Windows, 2.Mac, 3.Linux :");
                        int s = 0;
                        while (!int.TryParse(Console.ReadLine(), out s) || s < 0)
                        {
                            Console.WriteLine("Scelta non valida! Riprova.");
                        }
                        pc.OperatingSystem = (EnumOperatingSystem)s;
                        break;
                    case 5:
                        Console.WriteLine("E' touchscreen? 0 -> no, 1 -> sì :");
                        int t;
                        while (!int.TryParse(Console.ReadLine(), out t) || t < 0 || t > 1)
                        {
                            Console.WriteLine("Scelta non valida! Riprova.");
                        }
                        pc.TouchScreen = Convert.ToBoolean(t);
                        break;
                    case 0:
                        check = false;
                        break;
                }

            } while (check);
            return pc;
        }

        private static Pc ChoosePc()
        {
            List<Pc> pcs = pcr.Fetch();

            int i = 1;
            foreach (var x in pcs)
            {
                Console.WriteLine($"Premi {i} per {x.Print()}");
                i++;
            }

            bool isInt;
            int pcChosen;
            do
            {
                Console.WriteLine("Quale pc vuoi eliminare/modificare?");

                isInt = int.TryParse(Console.ReadLine(), out pcChosen);

            } while (!isInt || pcChosen <= 0 || pcChosen > pcs.Count);

            return pcs.ElementAt(pcChosen - 1);
        }

        private static CellPhone ChangeCellPhoneData(CellPhone cellPhone)
        {
            bool check = true;
            int choice;
            do
            {
                Console.WriteLine("Quale dato vuoi modificare? \n1. Marca \n2.Modello \n3.Quantità \n4.Memoria \n0.Per non modificare");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }

                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Inserisci la marca :");
                        cellPhone.Brand = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Inserisci il modello :");
                        cellPhone.Model = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Inserisci la quantità :");
                        int quantity;
                        while(!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
                        {
                            Console.WriteLine("Scelta non valida! Riprova.");
                        }
                        cellPhone.Quantity = quantity;
                        break;
                    case 4:
                        Console.WriteLine("Inserisci i giga :");
                        int giga = 0;
                        while (!int.TryParse(Console.ReadLine(), out giga) || giga < 0)
                        {
                            Console.WriteLine("Scelta non valida! Riprova.");
                        }
                        cellPhone.Memory = giga;
                        break;
                    case 0:
                        check = false;
                        break;
                }

            } while (check);
            return cellPhone;
        }

        private static CellPhone ChooseCellPhone()
        {
            List<CellPhone> cellPhones = cr.Fetch();

            int i = 1;
            foreach (var x in cellPhones)
            {
                Console.WriteLine($"Premi {i} per {x.Print()}");
                i++;
            }

            bool isInt;
            int cellChosen;
            do
            {
                Console.WriteLine("Quale cellulare vuoi eliminare/modificare?");

                isInt = int.TryParse(Console.ReadLine(), out cellChosen);

            } while (!isInt || cellChosen <= 0 || cellChosen > cellPhones.Count);

            return cellPhones.ElementAt(cellChosen - 1);
        }

        internal static void DeleteProduct()
        {
            int chosenProduct;
            bool isInt;

            do
            {
                Console.WriteLine("Che prodotto vuoi eliminare?");
                Console.WriteLine("Premi 1 per eliminare un cellulare");
                Console.WriteLine("Premi 2 per eliminare un pc");
                Console.WriteLine("Premi 3 per eliminare una tv");

                isInt = int.TryParse(Console.ReadLine(), out chosenProduct);

            } while (!isInt || chosenProduct <= 0 || chosenProduct >= 4);

            switch (chosenProduct)
            {
                case 1:
                    CellPhone cellPhone = ChooseCellPhone();
                    cr.Delete(cellPhone);
                    break;
                case 2:
                    Pc pc = ChoosePc();
                    pcr.Delete(pc);
                    break;
                case 3:
                    Tv tv = ChooseTv();
                    tr.Delete(tv);
                    break;
            }
        }
    }
}
