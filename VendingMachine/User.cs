
namespace VendingMachine
{
    internal class User
    {
        private static string action;

        public static void UserAction()
        {
            bool usingVendingMachine = true;
            while (usingVendingMachine == true)
            {
                Text screenText = new Text();

                Console.WriteLine();
                Console.Write("                    ");
                string input = Console.ReadLine();
                action = input.ToUpper();
                screenText.CurrentDisplay();

                // Separerar input för att se om användaren önskade att använda något av de val som är en kombination av två termer.
                string[] inputElements = action.Split(' ');
                if (inputElements.Length == 2)
                {
                    switch (inputElements[0])
                    {
                        case "U":
                            VendingSelection choice;
                            Product chosenProduct;
                            string testProductName = inputElements[1];
                            bool isExaminable = false;
                            if (Enum.TryParse<VendingSelection>(inputElements[1], out choice))
                            {
                                isExaminable = true;
                                Management.menu.TryGetValue(choice, out chosenProduct);
                                string priceAndInfo = chosenProduct.Examine();
                                Console.WriteLine(screenText.Center(priceAndInfo));
                                break;
                            }
                            else
                            {
                                foreach (var (key, value) in Management.menu)
                                {
                                    if (value.UpperName == testProductName)
                                    {
                                        isExaminable = true;
                                        choice = key;
                                        Management.menu.TryGetValue(choice, out chosenProduct);
                                        string priceAndInfo = chosenProduct.Examine();
                                        Console.WriteLine(screenText.Center(priceAndInfo));
                                        break;
                                    }
                                }
                            }
                            if (isExaminable == false)
                            {
                                string notExaminable = "Undersök en produkt genom att skriva U mellanslag och en varu-kod eller produkt. Ex. U C2 eller U Pepsi";
                                Console.WriteLine(screenText.Center(notExaminable));
                            }
                            break;

                        case "K":
                            VendingSelection consumptionChoice;
                            Product onsumptionChoiceProduct;
                            string consumptionTestProductName = inputElements[1];
                            bool isConsumable = false;

                            // Check om användaren skrev in en varu-kod
                            if (Enum.TryParse<VendingSelection>(inputElements[1], out choice))
                            {
                                isConsumable = true;
                                Management.menu.TryGetValue(choice, out chosenProduct);
                                string consumption = chosenProduct.Use();
                                screenText.CurrentDisplay();
                                Console.WriteLine(screenText.Center(consumption));
                                break;
                            }  

                            // Check om användaren skrev in ett produktnamn
                            foreach (var (key, value) in Management.menu)
                            {
                                if (value.UpperName == consumptionTestProductName)
                                {
                                    isConsumable = true;
                                    choice = key;
                                    Management.menu.TryGetValue(choice, out chosenProduct);
                                    string consumption = chosenProduct.Use();
                                    screenText.CurrentDisplay();
                                    Console.WriteLine(screenText.Center(consumption));
                                    break;
                                }
                            }

                            // Meddelande om användaren skrev in något som inte känns igen. 
                            if (isConsumable == false)
                            {
                                string notConsumable = "Konsumera en produkt genom att skriva K mellanslag och en varu-kod eller produkt. Ex. K C2 eller K Pepsi";
                                Console.WriteLine(screenText.Center(notConsumable));
                            }
                            break;

                        default:
                            // code block?
                            break;
                    }
                }

                // Check ifall input matcher något av de val som endast består av en term.
                switch (action)
                {
                    case "A1" or "A2" or "A3" or "B1" or "B2" or "B3" or "C1" or "C2" or "C3":
                        Enum.TryParse(action, out VendingSelection codeValue);
                        var product = Management.GetProduct((VendingSelection)codeValue);
                        int numberAlreadyBought = product.Bought;
                        Vending purchaseService = new Vending();
                        Purchase newPurchase = purchaseService.ExecutePurchase(codeValue);
                        Product chosenProduct;
                        Management.menu.TryGetValue(codeValue, out chosenProduct);
                        if  (product.Bought > numberAlreadyBought)
                        {
                            screenText.CurrentDisplay();
                            string buyMessage = "Du har köpt en " + chosenProduct.Singular + chosenProduct.LowerName;
                            Console.WriteLine(screenText.Center(buyMessage));
                        }
                        else
                        {
                            string needMoreMoney = "Du behöver sätta in mer pengar för att köpa en " + chosenProduct.Singular + chosenProduct.LowerName;
                            Console.WriteLine(screenText.Center(needMoreMoney));
                        }
                        break;

                    case "MENU":
                        if (Program.currentDisplay != Display.Menu)
                        {
                            Vending showAllService = new Vending();
                            ShowAll newShowAll = showAllService.ExecuteShowAll();
                            screenText.CurrentDisplay();
                            Console.WriteLine();
                        }
                        else
                        {
                            string alreadyMenuMessage = "Menyn visas redan";
                            Console.WriteLine(screenText.Center(alreadyMenuMessage));
                        }
                        break;

                    case "1" or "5" or "10" or "20" or "50" or "100" or "500" or "1000":
                        MoneyDenominations moneyValue = (MoneyDenominations)Int16.Parse(action);
                        Vending insertMoneyService = new Vending();
                        InsertMoney newInsertMoney = insertMoneyService.ExecuteInsertMoney(moneyValue);
                        string moneyType = moneyValue.ToString();
                        string depositMessage = "Du matar in en " + moneyType;
                        screenText.CurrentDisplay();
                        Console.WriteLine(screenText.Center(depositMessage));
                        break;

                    case "V":
                        if (MoneyPool.moneyPool > 0)
                        {
                            int totalChange = MoneyPool.moneyPool;
                            Dictionary<MoneyDenominations, int> changeInMoneyTypes = new Dictionary<MoneyDenominations, int>();
                            Vending endTransactionService = new Vending();
                            EndTransaction newEndTransaction = endTransactionService.ExecuteEndTransaction(changeInMoneyTypes);
                            Quantity someNumber = new Quantity();
                            screenText.CurrentDisplay();
                            string quantity;
                            Console.Write(" Du får tillbaka");
                            // Loopar igenom växeln (en dictionary som innehåller de antal av olika sedlar och mynt) som användaren får tillbaka. För att få rätt gramatik i texten om hur mycket växel användaren får tillbaka.
                            for (int x = 0; x < changeInMoneyTypes.Count; x++)
                            {
                                // Använder enum Quantity för att skriva antalet i ord istället för siffor så länge det handlar om ett ental.
                                if (changeInMoneyTypes.ElementAt(x).Value < 10)
                                {
                                    quantity = Enum.GetName(typeof(Quantity), changeInMoneyTypes.ElementAt(x).Value);
                                }
                                else
                                {
                                    quantity = changeInMoneyTypes.ElementAt(x).Value.ToString();
                                }

                                // Om antalet av den nuvarande valören i loopen är fler än 1 så skriver den ut valören i pluralform, annars skriver den ut valören vanligt.
                                if (changeInMoneyTypes.ElementAt(x).Value > 1)
                                {
                                    Console.Write(" {0} {1}", quantity, Enumerations.GetEnumDescription(changeInMoneyTypes.ElementAt(x).Key));
                                }
                                else
                                { 
                                    Console.Write(" {0} {1}", quantity, changeInMoneyTypes.Keys.ElementAt(x));

                                }

                                // Separerar växeln med ',' om det är fler än 1 valör kvar i loopen att skriva ut.
                                if (x < changeInMoneyTypes.Count - 2)
                                {
                                    Console.Write(",");
                                }

                                // Separar växeln med 'och' ifall det bara är 1 valör kvar i loopen att skriva ut.
                                if (x == changeInMoneyTypes.Count - 2)
                                {
                                    Console.Write(" och");
                                }
                            }
                            Console.Write(".");
                        }
                        else
                        {
                            string noChangeMessage = "Du har ingen växel att få tillbaka";
                            Console.WriteLine(screenText.Center(noChangeMessage));
                        }
                        break;

                    case "Ä":
                        // Not implemented
                        Program.currentDisplay = Display.Own;
                        screenText.CurrentDisplay();
                        Console.WriteLine();
                        break;

                    case "T":
                        Program.currentDisplay = Display.Titel;
                        screenText.CurrentDisplay();
                        Console.WriteLine();
                        break;

                    case "AV":
                        Console.WriteLine();
                        usingVendingMachine = false;
                        break;

                    default:
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
