
namespace VendingMachine
{
    enum Display
    {
        Menu,
        UserInventory
    }

    internal class Program
    {
        internal static Display currentDisplay = Display.Menu;

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
        public void DisplayMenu()
        {
            string[] menuItems = new string[9];
            int menuItemsElement = 0;
            foreach (var (code, product) in Management.menu)
            {
                string productCode = code.ToString();
                string productName = product.Name.ToString();
                productName = productName.Truncate(12);
                string nameSpacePadding = new string(' ', 12 - (productName.Length));
                string price = product.Price.ToString();
                price = price.Truncate(3);
                string priceSpacePadding = new string(' ', 3 - (price.Length));
                menuItems[menuItemsElement] = productCode + priceSpacePadding + price + "kr (" + productName + ")" + nameSpacePadding;
                menuItemsElement += 1;
            }
            string moneyPool = MoneyPool.moneyPool.ToString();
            moneyPool = moneyPool.Truncate(6);
            string moneyPoolSpacePadding = new string(' ', 6 - (moneyPool.Length));

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                    ╔═════════════╦════════════════════════════════════════════════════════╗");
            Console.WriteLine("  Pengar: {0} kr {1}║             ╚═╗  ╔╦═╗╔╗╔╦╦╗╦╔╗╔╔═╗                                   ║  U vara = Undersöka vara", moneyPool, moneyPoolSpacePadding);
            Console.WriteLine("                    ║               ╚╗╔╝╠╣ ║║║ ║║║║║║║╔╦                                   ║");
            Console.WriteLine("      M = Menu      ║                ╚╝ ╚═╩╝╚╝ ╩╩╩╝╚╝╚═╩═╦╦╗╔═╗╔═╦╦ ╗╦╔╗╔╦═╗               ║  K vara = Konsumera vara");
            Console.WriteLine("                    ║                                    ║║║╠═╣║  ╠═╣║║║║╠╣                ║");
            Console.WriteLine("      Ä = Ägogods   ║                                    ╩ ╩╩ ╩╩═╝╩ ╩╩╝╚╝╚═╩═╗             ║  vara* innebär att skriva");
            Console.WriteLine("                    ╠════════════════════════════════════════════════════════╩═════════════╣  varu-kod eller varu-namn");
            Console.WriteLine("    kod = Köp vara  ║                                                                      ║  (ex. U C2 eller K Pepsi)");
            Console.WriteLine("      (ex. A3)      ║ {0} {1} {2} ║", menuItems[0], menuItems[1], menuItems[2]);
            Console.WriteLine("                    ║                                                                      ║   valör = Insättning");
            Console.WriteLine("      V = Växel     ║ {0} {1} {2} ║", menuItems[3], menuItems[4], menuItems[5]);
            Console.WriteLine("  (pengar tillbaka) ║                                                                      ║  valör* innebär att skriva");
            Console.WriteLine("                    ║ {0} {1} {2} ║  talet för valörens värde", menuItems[6], menuItems[7], menuItems[8]);
            Console.WriteLine("     AV = Avsluta   ║                                                                      ║  1 5 10 20 50 100 500 1000");
            Console.WriteLine("                    ╚══════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        public void DisplayUserInventory()
        {
            // Menyn har dynamiska långa mellanrum för att anpassa sig efter längden av produktnamnen och kvantiteterna. Dock är menyn liten så alla produktnamn längre än 18 tecken blir beskärda ner till 18 tecken.
            string[] inventoryItems = new string[9];
            int inventoryElement = 0;
            foreach (var (code, product) in Management.menu)
            {
                string productName = product.Name.ToString();
                productName = productName.Truncate(18);
                string nameSpacePadding = new string(' ', 18 - (productName.Length));
                int quantityInUserInventory = product.Bought - product.Consumed;
                string quantity = quantityInUserInventory.ToString();
                quantity = quantity.Truncate(3);
                string quantitySpacePadding = new string(' ', 3 - (quantity.Length));
                inventoryItems[inventoryElement] = quantitySpacePadding + quantity + " " + productName + nameSpacePadding;
                inventoryElement += 1;
            }
            string moneyPool = MoneyPool.moneyPool.ToString();
            moneyPool = moneyPool.Truncate(6);
            string moneyPoolSpacePadding = new string(' ', 6 - (moneyPool.Length));

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                    ╔═════════════╦════════════════════════════════════════════════════════╗");
            Console.WriteLine("  Pengar: {0} kr {1}║             ╚═╗  ╔╦═╗╔╗╔╦╦╗╦╔╗╔╔═╗                                   ║  U vara = Undersöka vara", moneyPool, moneyPoolSpacePadding);
            Console.WriteLine("                    ║               ╚╗╔╝╠╣ ║║║ ║║║║║║║╔╦                                   ║");
            Console.WriteLine("      M = Menu      ║                ╚╝ ╚═╩╝╚╝ ╩╩╩╝╚╝╚═╩═╦╦╗╔═╗╔═╦╦ ╗╦╔╗╔╦═╗               ║  K vara = Konsumera vara");
            Console.WriteLine("                    ║                                    ║║║╠═╣║  ╠═╣║║║║╠╣                ║");
            Console.WriteLine("      Ä = Ägogods   ║                                    ╩ ╩╩ ╩╩═╝╩ ╩╩╝╚╝╚═╩═╗             ║  vara* innebär att skriva");
            Console.WriteLine("                    ╠════════════════════════════════════════════════════════╩═════════════╣  varu-kod eller varu-namn");
            Console.WriteLine("    kod = Köp vara  ║                                                                      ║  (ex. U C2 eller K Pepsi)");
            Console.WriteLine("      (ex. A3)      ║ {0}{1}{2}   ║", inventoryItems[0], inventoryItems[1], inventoryItems[2]);
            Console.WriteLine("                    ║                                                                      ║   valör = Insättning");
            Console.WriteLine("      V = Växel     ║ {0}{1}{2}   ║", inventoryItems[3], inventoryItems[4], inventoryItems[5]);
            Console.WriteLine("  (pengar tillbaka) ║                                                                      ║  valör* innebär att skriva");
            Console.WriteLine("                    ║ {0}{1}{2}   ║  talet för valörens värde", inventoryItems[6], inventoryItems[7], inventoryItems[8]);
            Console.WriteLine("     AV = Avsluta   ║                                                                      ║  1 5 10 20 50 100 500 1000");
            Console.WriteLine("                    ╚══════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        public void CurrentDisplay()
        {
            Text screenText = new Text();
            switch (Program.currentDisplay)
            {
                case Display.Menu:
                    DisplayMenu();
                    break;
                case Display.UserInventory:
                    DisplayUserInventory();
                    break;
                default:
                    DisplayMenu();
                    break;
            }
        }

        // Används när text skall centreras till mitten.
        public string Center(string a)
        {
            if (a.Length < 110)
            {
                string spacing = new string(' ', 56 - (a.Length / 2));
                a = spacing + a;
            }
            else
            {
                a = " " + a;
            }
            return a;
        }
    }

    // En function som ser om en text är längre än den maximala tillåtna längden och i så fall skär ner texten till den maximala tillåtna längden.
    public static class StringExt
    {
        public static string Truncate(this string variable, int Length)
        {
            if (string.IsNullOrEmpty(variable)) return variable;
            return variable.Length <= Length ? variable : variable.Substring(0, Length);
        }
    }
}
