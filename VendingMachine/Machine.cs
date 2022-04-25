using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{

    public enum MoneyDenominations
    {
        enkronor=1, femkrona=5, tiokrona=10, tjugolappar=20, femtiolappar=50, hundralappar=100, femhundralappar=500, tusenlappar=1000
    }

    public enum VendingSelection
    {
        A1=1, A2, A3, B1, B2, B3, C1, C2, C3
    }

    public static class Enum<T>
    {
        public static IEnumerable<T> AllValues()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }

    public static class MoneyPool
    {
        static int _moneyPool;
        public static int moneyPool
        {
            set { _moneyPool = value; }
            get { return _moneyPool; }
        }

    }

    public class Purchase
    {
        public VendingSelection BoughtItem { get; set; }

        public Purchase(VendingSelection choice)
        {
            Product chosenProduct;
            Management.menu.TryGetValue(choice, out chosenProduct);
            if (MoneyPool.moneyPool >= chosenProduct.Price)
            {
                chosenProduct.Bought = chosenProduct.Bought + 1;
                MoneyPool.moneyPool -= chosenProduct.Price;

            }

        }
    }

    public class ShowAll
    {
        public ShowAll()
        {
            Program.currentDisplay = Display.Menu;

        }
    }

    public class InsertMoney
    {
        public int MoneyDenomination { get; set; }

        public InsertMoney(MoneyDenominations value)
        {
            string moneyType = value.ToString();
            Object valueNumber = Convert.ChangeType(value, value.GetTypeCode());
            int moneyValue = (int)valueNumber;
            MoneyPool.moneyPool += moneyValue;

            Console.WriteLine("Du matade in en " + moneyType);

            Console.WriteLine(valueNumber);
        }
    }

    public class EndTransaction
    {
        public Dictionary<MoneyDenominations, int> ChangeInMoneyTypes { get; set; }
        public EndTransaction(Dictionary<MoneyDenominations, int> changeInMoneyTypes)
        {
            if (MoneyPool.moneyPool > 0)
            {
                //IDictionary<MoneyDenominations, int> changeInMoneyTypes = new Dictionary<MoneyDenominations, int>();
                foreach (var val in Enum<MoneyDenominations>.AllValues().Reverse())
                {
                    int moneyType = (int)val;
                    int numberOfThisMoneyType = MoneyPool.moneyPool / moneyType;
                    if (numberOfThisMoneyType > 0)
                    {
                        changeInMoneyTypes.Add(val, numberOfThisMoneyType);
                        MoneyPool.moneyPool -= numberOfThisMoneyType * moneyType;
                    }
                }
            }

            /* kod för att testa värden
            int change = MoneyPool.moneyPool;
            MoneyPool.moneyPool = 0;
            Console.WriteLine("Du får tillbaka din växel på " + change + "kr");
            Console.WriteLine();
            Console.Write("   ");
            */
        }
    }
}
