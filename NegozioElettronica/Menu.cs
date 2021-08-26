using System;
using static NegozioElettronica.Entities.Pc;

namespace NegozioElettronica
{
//    Scrivere un programma che gestisca un negozio di elettronica:



//I prodotti hanno
//- Marca
//- Modello
//- Quantità in magazzino



//I cellulari hanno:
//- Marca
//- Modello
//- Quantità in magazzino
//- Memoria in GB



//I pc hanno:
//- Marca
//- Modello
//- Quantità in magazzino
//- Sistema operativo(Windows, Mac, Linux)
//- se sono o no touch screen



//Le tv hanno:
//- Marca
//- Modello
//- Quantità in magazzino
//- Pollici



//L'utente può
//- visualizzare tutti i prodotti
//- visualizzare tutti i cellulari
//- visualizzare tutti i pc
//- visualizzare tutte le tv
//- inserire un nuovo prodotto(fare a piacere o un unico metodo di inserimenti che chiede quale entità modificare o tre metodi separati)
//- modificare un prodotto(fare a piacere o un unico metodo di inserimenti che chiede quale entità modificare o tre metodi separati)
//- eliminare un prodotto(fare a piacere o un unico metodo di eliminazione che chiede quale entità modificare o tre metodi separati)
//- filtrare i cellulari per memoria superiore a quella scelta
//- filtrare i pc per sistema operativo scelto dall'utente
//- filtrare le tv per pollici uguali a quelli scelti dell'utente



//Note:
//- rispettare la corretta struttura(Ogni classe e ogni metodo hanno uno e un solo scopo)
//- creare un repository fittizio(quindi anche le interfacce)
//- salvare i dati su sql server tramite ado
    internal class Menu
    {
        internal static void Start()
        {
            bool check = true;
            int choice;
            do
            {
                Console.WriteLine("BENEVENUTO!\nPremi 1 per vedere tutti i prodotti \nPremi 2 per vedere tutti i cellulari \nPremi 3 per vedere tutti i pc \nPremi 4 per vedere tutte le tv \nPremi 5 per inserire un nuovo prodotto \nPremi 6 per modificare un prodotto \nPremi 7 per eliminare un prodotto \nPremi 8 per filtrare i cellulari per memoria superiore a quella scelta \nPremi 9 per filtrare i pc per sistema operativo scelto \nPremi 10 per filtrare le tv per pollici uguali a quelli scelti  \nPremi 0 per uscire");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 10)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }

                switch(choice)
                {
                    case 1:
                        ShopManager.ShowProducts();
                        break;
                    case 2:
                        ShopManager.ShowCellPhones();
                        break;
                    case 3:
                        ShopManager.ShowPcs();
                        break;
                    case 4:
                        ShopManager.ShowTvs();
                        break;
                    case 5:
                        ShopManager.InsertProduct();
                        break;
                    case 6:
                        ShopManager.UpdateProduct();
                        break;
                    case 7:
                        ShopManager.DeleteProduct();
                        break;
                    case 8:
                        CellPhonesByMemory();
                        break;
                    case 9:
                        PcsByOperatingSystem();
                        break;
                    case 10:
                        TvsByInches();
                        break;
                    case 0:
                        Console.WriteLine("Ciao ciao!");
                        check = false;
                        break;
                }

            } while(check);
            
        }

        private static void TvsByInches()
        {
            Console.WriteLine("Inserisci i pollici per cui vuoi visualizzare le tv");
            int inches;
            while (!int.TryParse(Console.ReadLine(), out inches) || inches < 0)
            {
                Console.WriteLine("Scelta non approvata. Riprova!");
            }
            ShopManager.TvsByInches(inches);
        }

        private static void PcsByOperatingSystem()
        {
            Console.WriteLine("Inserisci il sistema operativo per cui vuoi visualizzare i pc\n1. Windows, 2.Mac, 3.Linux");
            int so;
            while (!int.TryParse(Console.ReadLine(), out so) || so < 0 || so > 3)
            {
                Console.WriteLine("Scelta non approvata. Riprova!");
            }
            ShopManager.PcsByOperatingSystem((EnumOperatingSystem)so);
        }

        private static void CellPhonesByMemory()
        {
            Console.WriteLine("Inserisci la memoria per cui vuoi visualizzare i cellulari che hanno memoria superiore");
            int memory;
            while(!int.TryParse(Console.ReadLine(), out memory)|| memory < 0)
            {
                Console.WriteLine("Scelta non approvata. Riprova!");
            }
            ShopManager.CellPhonesByMemory(memory);
        }
    }
}