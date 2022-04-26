
namespace VendingMachine
{
    // En abstrakt klass som bestämmer grundinformation och grundfunktioner för produkter.
    public abstract class Product
    {
        public string Name { get; set; }
        public string UpperName { get; set; }
        public string LowerName { get; set; }
        public string Singular { get; set; }
        public string Plural { get; set; }
        public int Price { get; set; }
        public string Info { get; set; }
        public string Usage { get; set; }
        public int Bought { get; set; }
        public int Consumed { get; set; }

        public abstract string Examine();

        public abstract string Use();
    }

    public class ChocolateBar : Product
    {
        public ChocolateBar(String name, int price, String info)
        {
            this.Name = name;
            this.UpperName = name.ToUpper();
            this.LowerName = name.ToLower();
            this.Singular = "";
            this.Plural = "";
            this.Price = price;
            this.Info = info;
            this.Usage = "smaskar i dig en";
            this.Bought = 0;
            this.Consumed = 0;
        }

        public override string Examine()
        {
            string priceAndInfo = Info + ". Pris " + Price + "kr.";
            return priceAndInfo;
        }

        public override string Use()
        {
            string consumptionMessage;
            if (this.Bought > this.Consumed)
            {
                this.Consumed += 1;
                consumptionMessage = "Du " + Usage + " " + this.LowerName;
            }
            else
            {
                consumptionMessage = "Du äger ingen " + this.LowerName;
            }
            return consumptionMessage;
        }
    }

    public class Snack : Product
    {
        public Snack(String name, int price, String info)
        {
            this.Name = name;
            this.UpperName = name.ToUpper();
            this.LowerName = name.ToLower();
            this.Singular = "påse ";
            this.Plural = "påsar ";
            this.Price = price;
            this.Info = info;
            this.Usage = "äter en påse";
            this.Bought = 0;
            this.Consumed = 0;
        }

        public override string Examine()
        {
            string priceAndInfo = Info + ". Pris " + Price + "kr.";
            return priceAndInfo;
        }

        public override string Use()
        {
            string consumptionMessage;
            if (this.Bought > this.Consumed)
            {
                this.Consumed += 1;
                consumptionMessage = "Du " + Usage + " " + this.LowerName;
            }
            else
            {
                consumptionMessage = "Du äger ingen " + this.LowerName;
            }
            return consumptionMessage;
        }
    }

    public class Drink : Product
    {
        public Drink(String name, int price, String info)
        {
            this.Name = name;
            this.UpperName = name.ToUpper();
            this.LowerName = name.ToLower();
            this.Singular = "flaska ";
            this.Plural = "flaskor ";
            this.Price = price;
            this.Info = info;
            this.Usage = "dricker en flaska";
            this.Bought = 0;
            this.Consumed = 0;
        }

        public override string Examine()
        {
            string priceAndInfo = Info + ". Pris " + Price + "kr.";
            return priceAndInfo;
        }

        public override string Use()
        {
            string consumptionMessage;
            if (this.Bought > this.Consumed)
            {
                this.Consumed += 1;
                consumptionMessage = "Du " + Usage + " " + this.LowerName;
            }
            else
            {
                consumptionMessage = "Du äger ingen " + this.LowerName;
            }
            return consumptionMessage;
        }
    }
}
