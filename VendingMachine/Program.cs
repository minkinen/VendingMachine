using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{

    enum Display
    {
        Titel,
        Menu,
        Own
    }

    internal class Program
    {
        internal static Display currentDisplay = Display.Titel;

        static void Main()
        {


            MoneyPool.moneyPool = 0;

            ScreenText screenText = new ScreenText();
            screenText.CurrentDisplay();

            bool activationOn = true;
            while (activationOn == true)
            {
                activationOn = RunVending();
            }
        }
        public static bool RunVending()
        {

            string vendingFunction = User.UserAction();

            return true;
        }

    }

    public class ScreenText
    {
        public void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                    ╔═════════════╦════════════════════════════════════════════════════════╗");
            Console.WriteLine("      T = Titel     ║             ╚═╗  ╔╦═╗╔╗╔╦╦╗╦╔╗╔╔═╗                                   ║  1-1000 = Sätt in valör");
            Console.WriteLine("   MENU = Se utbud  ║               ╚╗╔╝╠╣ ║║║ ║║║║║║║╔╦                                   ║  U VARA = Undersöka vara");
            Console.WriteLine("    KOD = Köp vara  ║                ╚╝ ╚═╩╝╚╝ ╩╩╩╝╚╝╚═╩═╦╦╗╔═╗╔═╦╦ ╦╦╔╗╔╦═╗               ║  K VARA = Konsumera vara");
            Console.WriteLine("      Ä = Äger      ║                                    ║║║╠═╣║  ╠═╣║║║║╠╣                ║       V = Växel tillbaka ");
            Console.WriteLine("     AV = Avsluta   ║                                    ╩ ╩╩ ╩╩═╝╩ ╩╩╝╚╝╚═╩═╗             ║  Pengar = " + MoneyPool.moneyPool + " kr");
            Console.WriteLine("                    ╚════════════════════════════════════════════════════════╩═════════════╝");
            Console.Write("   ");
        }

        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                    ╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("      T = Titel     ║ A1  5kr (Daim)         A2 10kr (Kexchoklad)   A3 25kr (Mjölkchoklad) ║  1-1000 = Sätt in peng");
            Console.WriteLine("   MENU = Se utbud  ║                                                                      ║  U VARA = Undersöka vara");
            Console.WriteLine("    KOD = Köp vara  ║ B1 25kr (Chips)        B2 25kr (Ostbågar)     B3 35kr (Nötmix)       ║  K VARA = Konsumera vara");
            Console.WriteLine("      Ä = Äger      ║                                                                      ║       V = Växel tillbaka");
            Console.WriteLine("     AV = Avsluta   ║ C1 10kr (Soda Vatten)  C2 15kr (Pepsi)        C3 15kr (Zingo)        ║  Pengar = " + MoneyPool.moneyPool + " kr");
            Console.WriteLine("                    ╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write("   ");
        }

        // Ej implementerad
        public void DisplayOwn()
        {
            var a1 = Management.GetProduct((VendingSelection)1);
            int a1Own = a1.Bought - a1.Consumed;
            var a2 = Management.GetProduct((VendingSelection)2);
            int a2Own = a2.Bought - a2.Consumed;
            var a3 = Management.GetProduct((VendingSelection)3);
            int a3Own = a3.Bought - a3.Consumed;
            var b1 = Management.GetProduct((VendingSelection)4);
            int b1Own = b1.Bought - b1.Consumed;
            var b2 = Management.GetProduct((VendingSelection)5);
            int b2Own = b2.Bought - b2.Consumed;
            var b3 = Management.GetProduct((VendingSelection)6);
            int b3Own = b3.Bought - b3.Consumed;
            var c1 = Management.GetProduct((VendingSelection)7);
            int c1Own = c1.Bought - c1.Consumed;
            var c2 = Management.GetProduct((VendingSelection)8);
            int c2Own = c2.Bought - c2.Consumed;
            var c3 = Management.GetProduct((VendingSelection)9);
            int c3Own = c3.Bought - c3.Consumed;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                    ╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("      T = Titel     ║        " + a1Own + " Daim                 " + a2Own + " Kexchoklad           " + a3Own + " Mjölkchoklad  ║  1-1000 = Sätt in peng"); ; ; ;
            Console.WriteLine("   MENU = Se utbud  ║                                                                      ║  U VARA = Undersöka vara");
            Console.WriteLine("    KOD = Köp vara  ║        " + b1Own + " Chips                " + b2Own + " Ostbågar             " + b3Own + " Nötmix        ║  K VARA = Konsumera vara");
            Console.WriteLine("      Ä = Äger      ║                                                                      ║       V = Växel tillbaka");
            Console.WriteLine("     AV = Avsluta   ║        " + c1Own + " Soda Vatten          " + c2Own + " Pepsi                " + c3Own + " Zingo         ║  Pengar = " + MoneyPool.moneyPool + " kr");
            Console.WriteLine("                    ╚══════════════════════════════════════════════════════════════════════╝");
            Console.Write("   ");
        }

        public void CurrentDisplay()
        {
            ScreenText screenText = new ScreenText();
            switch (Program.currentDisplay)
            {
                case Display.Titel:
                    DisplayTitle();
                    break;
                case Display.Menu:
                    DisplayMenu();
                    break;
                case Display.Own:
                    DisplayOwn();
                    break;
                default:
                    DisplayTitle();
                    break;
            }
        }

    }
}
