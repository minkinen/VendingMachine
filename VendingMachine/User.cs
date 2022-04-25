using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class User
    {
        private static string action;

        public static string UserAction()
        {
            bool usingVendingMachine = false;
            while (usingVendingMachine == false)
            {
                ScreenText screenText = new ScreenText();


                string input = Console.ReadLine();
                action = input.ToUpper();

                string[] inputElements = action.Split(' ');
                if (inputElements.Length == 2)
                {
                    switch (inputElements[0])
                    {
                        case "U":
                            VendingSelection choice;
                            Product chosenProduct;
                            string testProductName = inputElements[1];
                            screenText.CurrentDisplay();
                            if (Enum.TryParse<VendingSelection>(inputElements[1], out choice))
                            {
                                Management.menu.TryGetValue(choice, out chosenProduct);
                                chosenProduct.Examine();
                                break;
                            }
                            foreach (var (key, value) in Management.menu)
                            {
                                if (value.Name == testProductName)
                                {
                                    choice = key;
                                    Management.menu.TryGetValue(choice, out chosenProduct);
                                    chosenProduct.Examine();
                                    break;
                                }
                            }
                            break;
                        case "K":
                            VendingSelection consumptionChoice;
                            Product onsumptionChoiceProduct;
                            string consumptionTestProductName = inputElements[1];
                            screenText.CurrentDisplay();
                            if (Enum.TryParse<VendingSelection>(inputElements[1], out choice))
                            {
                                Management.menu.TryGetValue(choice, out chosenProduct);
                                chosenProduct.Use();
                                break;
                            }
                            foreach (var (key, value) in Management.menu)
                            {
                                if (value.Name == consumptionTestProductName)
                                {
                                    choice = key;
                                    Management.menu.TryGetValue(choice, out chosenProduct);
                                    chosenProduct.Use();
                                    break;
                                }
                            }
                            break;
                        default:
                            // code block?
                            break;
                    }

                }

                switch (action)
                {
                    case "A1" or "A2" or "A3" or "B1" or "B2" or "B3" or "C1" or "C2" or "C3":
                        Enum.TryParse(action, out VendingSelection codeValue);
                        Vending purchaseService = new Vending();
                        Purchase newPurchase = purchaseService.ExecutePurchase(codeValue);
                        usingVendingMachine = true;
                        Product chosenProduct;
                        Management.menu.TryGetValue(codeValue, out chosenProduct);
                        screenText.CurrentDisplay();
                        Console.WriteLine("Du har köpt en " + chosenProduct.Singular + chosenProduct.Name.ToLower() + ".");


                        break;
                    case "MENU":

                        Vending showAllService = new Vending();
                        ShowAll newShowAll = showAllService.ExecuteShowAll();
                        screenText.CurrentDisplay();
                        usingVendingMachine = true;
                        break;
                    case "1" or "5" or "10" or "20" or "50" or "100" or "500" or "1000":
                        MoneyDenominations moneyValue = (MoneyDenominations)Int16.Parse(action);
                        Vending insertMoneyService = new Vending();
                        InsertMoney newInsertMoney = insertMoneyService.ExecuteInsertMoney(moneyValue);
                        screenText.CurrentDisplay();
                        usingVendingMachine = true;
                        break;
                    case "V":
                        if (MoneyPool.moneyPool > 0)
                        {
                            int totalChange = MoneyPool.moneyPool;
                            Dictionary<MoneyDenominations, int> changeInMoneyTypes = new Dictionary<MoneyDenominations, int>();
                            Vending endTransactionService = new Vending();
                            EndTransaction newEndTransaction = endTransactionService.ExecuteEndTransaction(changeInMoneyTypes);
                            screenText.CurrentDisplay();
                            Console.Write("Du får tillbaka");
                            for (int x = 0; x < changeInMoneyTypes.Count; x++)
                            {
                                Console.Write(" {1} st {0}", changeInMoneyTypes.Keys.ElementAt(x), changeInMoneyTypes[changeInMoneyTypes.Keys.ElementAt(x)]);
                                if (x < changeInMoneyTypes.Count - 1)
                                {
                                    Console.Write(",");
                                }
                            }
                            Console.Write(".");
                            usingVendingMachine = true;
                        }
                        else
                        {
                            Console.WriteLine("Du har ingen växel att få tillbaka.");
                        }
                        break;
                    case "Ä":
                        // Not implemented
                        Program.currentDisplay = Display.Own;
                        screenText.CurrentDisplay();
                        usingVendingMachine = true;
                        break;
                    case "T":
                        Program.currentDisplay = Display.Titel;
                        screenText.CurrentDisplay();
                        usingVendingMachine = true;
                        break;
                    default:
                        break;
                }
            }
            return action;
        }


    }



}
