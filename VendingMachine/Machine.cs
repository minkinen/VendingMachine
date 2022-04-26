using System.ComponentModel;
using System.Reflection;

namespace VendingMachine
{

    // Berikad med en Description för att ha en pluralbeskrivning av valörerna (using System.ComponentModel;)
    public enum MoneyDenominations
    {
        [Description("enkronor")]
        enkrona = 1,
        [Description("femkronor")]
        femkrona = 5,
        [Description("tiokronor")]
        tiokrona = 10,
        [Description("tjugolappar")]
        tjugolapp = 20,
        [Description("femtiolappar")]
        femtiolapp = 50,
        [Description("hundralappar")]
        hundralapp = 100,
        [Description("femhundralappar")]
        femhundralapp = 500,
        [Description("tusenlappar")]
        tusenlapp = 1000
    }

    // Vill simulera en vanlig Vending Machine där man använder en kod för att välja vilken vara man vill köpa
    public enum VendingSelection
    {
        A1 =1, A2, A3, B1, B2, B3, C1, C2, C3
    }

    public enum Quantity
    {
        en = 1, två, tre, fyra, fem, sex, sju, åtta, nio
    }

    // En generisk typ <T> är användbar när jag vill bolla med enums, likt där jag vill loopa växeln baklänges 
    public static class Enum<T>
    {
        public static IEnumerable<T> AllValues()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }

    public class Enumerations
    {
        // Funktion för att enkelt komma åt enum Description. FieldInfo behöver (using System.Reflection;)
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }

    // Hur mycket pengar som användaren har kvar att använda i maskinen
    public static class MoneyPool
    {
        static int _moneyPool;
        public static int moneyPool
        {
            set { _moneyPool = value; }
            get { return _moneyPool; }
        }
    }

    // Om användarens insatta belopp är tillräcklig, så lämnar maskinen ut den önskade varam och drar av varans pris från beloppet som användaren kan handla för.
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

    // Funktion som bestämmer att menyn med varorna skall visas.
    public class ShowAll
    {
        public ShowAll()
        {
            Program.currentDisplay = Display.Menu;
        }
    }

    // Ökar beloppet som användaren kan handla för med värdet av myntet/sedeln som användaren matade in i maskinen.
    public class InsertMoney
    {
        public int MoneyDenomination { get; set; }

        public InsertMoney(MoneyDenominations value)
        {
            Object valueNumber = Convert.ChangeType(value, value.GetTypeCode());
            int moneyValue = (int)valueNumber;
            MoneyPool.moneyPool += moneyValue;
        }
    }

    // Ger tillbaka det återstående insatta beloppet i minst antal möjliga valörer.
    public class EndTransaction
    {
        public Dictionary<MoneyDenominations, int> ChangeInMoneyTypes { get; set; }
        public EndTransaction(Dictionary<MoneyDenominations, int> changeInMoneyTypes)
        {
            if (MoneyPool.moneyPool > 0)
            {
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
        }
    }
}
