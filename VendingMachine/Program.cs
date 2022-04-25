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


        // Överflödig än så länge
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
