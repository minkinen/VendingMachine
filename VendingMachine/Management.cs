using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public static class Management
    {

        static ChocolateBar Daim = new ChocolateBar("DAIM", 5, "Daim Singel 28g Marabou");
        static ChocolateBar Kexchoklad = new ChocolateBar("KEXCHOKLAD", 10, "Stor 60g Cloetta");
        static ChocolateBar Mjolkchoklad = new ChocolateBar("MJÖLKCHOKLAD", 25, "Karl Fazer Mjölkchoklad 145g");
        static Snack Chips = new Snack("CHIPS", 25, "Chips Saltade 175gr Lay´s");
        static Snack Ostbagar = new Snack("OSTBÅGAR", 25, "Cheez Doodles Original 160g OLW");
        static Snack Notmix = new Snack("NÖTMIX", 35, "Jordnötter, cashewnötter, mandel 200g Estrella");
        static Drink Vatten = new Drink("SODA VATTEN", 12, "Kolsyrat Soda Vatten 33cl Plastflaska Spendrups");
        static Drink Pepsi = new Drink("PEPSI", 15, "Läsk Cola 33cl Plastflaska Pepsi");
        static Drink Zingo = new Drink("ZINGO", 15, "Läsk Apelsin 33cl Plastflaska Zingo");

        public static Dictionary<VendingSelection, Product> menu = new Dictionary<VendingSelection, Product>
        {
            { VendingSelection.A1, Daim },
            { VendingSelection.A2, Kexchoklad },
            { VendingSelection.A3, Mjolkchoklad },
            { VendingSelection.B1, Chips },
            { VendingSelection.B2, Ostbagar },
            { VendingSelection.B3, Notmix },
            { VendingSelection.C1, Vatten },
            { VendingSelection.C2, Pepsi },
            { VendingSelection.C3, Zingo }
        };

        public static Product GetProduct(VendingSelection codeKey)
        {
            // Get the result from the static Dictionary.
            Product matchingProduct;
            if (menu.TryGetValue(codeKey, out matchingProduct))
            {
                return matchingProduct;
            }
            else
            {
                return null;
            }
        }
    }
}
