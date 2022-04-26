
namespace VendingMachine
{
    // Hårdkodad klass som rör versamheten för maskinens underhåll.
    public static class Management
    {

        static ChocolateBar Daim = new ChocolateBar("Daim", 5, "Daim Singel 28g Marabou");
        static ChocolateBar Kexchoklad = new ChocolateBar("Kexchoklad", 10, "Stor 60g Cloetta");
        static ChocolateBar Mjolkchoklad = new ChocolateBar("Mjölkchoklad", 25, "Karl Fazer Mjölkchoklad 145g");
        static Snack Chips = new Snack("Chips", 25, "Chips Saltade 175gr Lay´s");
        static Snack Ostbagar = new Snack("Ostbågar", 25, "Cheez Doodles Original 160g OLW");
        static Snack Notmix = new Snack("Nötmix", 35, "Jordnötter, cashewnötter, mandel 200g Estrella");
        static Drink Vatten = new Drink("Soda Vatten", 12, "Kolsyrat Soda Vatten 33cl Plastflaska Spendrups");
        static Drink Pepsi = new Drink("Pepsi", 15, "Läsk Cola 33cl Plastflaska Pepsi");
        static Drink Zingo = new Drink("Zingo", 15, "Läsk Apelsin 33cl Plastflaska Zingo");

        // Använder en Dictionary för att sätt in de olika produkterna(Product-Objects) i maskinens olika fack(VendingSelection-Enums).
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

        // Funktion för att se vilken vara som säljs i vilket fack i maskinen, används i menyn för att presentera varorna samt när användaren vill se sina tillgångar av inköpta varor.
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
