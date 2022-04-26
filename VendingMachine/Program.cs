
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

            Text screenText = new Text();
            screenText.CurrentDisplay();
            Console.WriteLine();

            User.UserAction();
        }

    }

    public class Text
    {
        public void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                    ╔═════════════╦════════════════════════════════════════════════════════╗");
            Console.WriteLine("      T = Titel     ║             ╚═╗  ╔╦═╗╔╗╔╦╦╗╦╔╗╔╔═╗                                   ║  1-1000 = Sätt in valör");
            Console.WriteLine("   MENU = Se utbud  ║               ╚╗╔╝╠╣ ║║║ ║║║║║║║╔╦                                   ║  U VARA = Undersöka vara");
            Console.WriteLine("    KOD = Köp vara  ║                ╚╝ ╚═╩╝╚╝ ╩╩╩╝╚╝╚═╩═╦╦╗╔═╗╔═╦╦ ╗╦╔╗╔╦═╗               ║  K VARA = Konsumera vara");
            Console.WriteLine("      Ä = Äger      ║                                    ║║║╠═╣║  ╠═╣║║║║╠╣                ║       V = Växel tillbaka ");
            Console.WriteLine("     AV = Avsluta   ║                                    ╩ ╩╩ ╩╩═╝╩ ╩╩╝╚╝╚═╩═╗             ║  Pengar = " + MoneyPool.moneyPool + " kr");
            Console.WriteLine("                    ╚════════════════════════════════════════════════════════╩═════════════╝");
            Console.WriteLine();
        }

        public void DisplayMenu()
        {
            var a1 = Management.GetProduct((VendingSelection)1);
            var a2 = Management.GetProduct((VendingSelection)2);
            var a3 = Management.GetProduct((VendingSelection)3);
            var b1 = Management.GetProduct((VendingSelection)4);
            var b2 = Management.GetProduct((VendingSelection)5);
            var b3 = Management.GetProduct((VendingSelection)6);
            var c1 = Management.GetProduct((VendingSelection)7);
            var c2 = Management.GetProduct((VendingSelection)8);
            var c3 = Management.GetProduct((VendingSelection)9);

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                    ╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("      T = Titel     ║ A1  {0}kr ({1})         A2 {2}kr ({3})   A3 {4}kr ({5}) ║  1-1000 = Sätt in peng", a1.Price, a1.Name, a2.Price, a2.Name, a3.Price, a3.Name);
            Console.WriteLine("   MENU = Se utbud  ║                                                                      ║  U VARA = Undersöka vara");
            Console.WriteLine("      T = Titel     ║ B1 {0}kr ({1})        B2 {2}kr ({3})     B3 {4}kr ({5})       ║  K VARA = Konsumera vara", b1.Price, b1.Name, b2.Price, b2.Name, b3.Price, b3.Name);
            Console.WriteLine("    KOD = Köp vara  ║                                                                      ║       V = Växel tillbaka");
            Console.WriteLine("     AV = Avsluta   ║ C1 {0}kr ({1})  C2 {2}kr ({3})        C3 {4}kr ({5})        ║  Pengar = " + MoneyPool.moneyPool + " kr", c1.Price, c1.Name, c2.Price, c2.Name, c3.Price, c3.Name);
            Console.WriteLine("                    ╚══════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

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
            Console.WriteLine("      T = Titel     ║        {0} {1}                 {2} {3}           {4} {5}  ║  1-1000 = Sätt in peng", a1Own, a1.Name, a2Own, a2.Name, a3Own, a3.Name);
            Console.WriteLine("   MENU = Se utbud  ║                                                                      ║  U VARA = Undersöka vara");
            Console.WriteLine("    KOD = Köp vara  ║        {0} {1}                {2} {3}             {4} {5}        ║  K VARA = Konsumera vara", b1Own, b1.Name, b2Own, b2.Name, b3Own, b3.Name);
            Console.WriteLine("      Ä = Äger      ║                                                                      ║       V = Växel tillbaka");
            Console.WriteLine("     AV = Avsluta   ║        {0} {1}          {2} {3}                {4} {5}         ║  Pengar = " + MoneyPool.moneyPool + " kr", c1Own, c1.Name, c2Own, c2.Name, c3Own, c3.Name);
            Console.WriteLine("                    ╚══════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        public void CurrentDisplay()
        {
            Text screenText = new Text();
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

        // Används när text skall centreras till mitten.
        public string Center(string a)
        {
            if (a.Length < 110)
            {
                string spacing = new string(' ', 55 - (a.Length / 2));
                a = spacing + a;
            }
            else
            {
                a = " " + a;
            }
            return a;
        }
    }
}
