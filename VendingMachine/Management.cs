using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public static class Management
    {

        static ChoclateBar DAIM = new ChoclateBar("DAIM", 5, "Daim Singel 28g Marabou");
        static ChoclateBar KEXCHOKLAD = new ChoclateBar("KEXCHOKLAD", 10, "Stor 60g Cloetta");
        static ChoclateBar MJÖLKCHOKLAD = new ChoclateBar("MJÖLKCHOKLAD", 25, "Karl Fazer Mjölkchoklad 145g");
        static Snack CHIPS = new Snack("CHIPS", 25, "Chips Saltade 175gr Lay´s");
        static Snack OSTBÅGAR = new Snack("OSTBÅGAR", 25, "Cheez Doodles Original 160g OLW");
        static Snack NÖTMIX = new Snack("NÖTMIX", 35, "Jordnötter, cashewnötter, mandel 200g Estrella");
        static Drink VATTEN = new Drink("SODA VATTEN", 12, "Kolsyrat Soda Vatten 33cl Plastflaska Spendrups");
        static Drink PEPSI = new Drink("PEPSI", 15, "Läsk Cola 33cl Plastflaska Pepsi");
        static Drink ZINGO = new Drink("ZINGO", 15, "Läsk Apelsin 33cl Plastflaska Zingo");



        public static Dictionary<VendingSelection, Product> menu = new Dictionary<VendingSelection, Product>
        {
            { VendingSelection.A1, DAIM },
            { VendingSelection.A2, KEXCHOKLAD },
            { VendingSelection.A3, MJÖLKCHOKLAD },
            { VendingSelection.B1, CHIPS },
            { VendingSelection.B2, OSTBÅGAR },
            { VendingSelection.B3, NÖTMIX },
            { VendingSelection.C1, VATTEN },
            { VendingSelection.C2, PEPSI },
            { VendingSelection.C3, ZINGO }
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
