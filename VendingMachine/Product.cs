using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{

    public abstract class Product
    {

        public string Name { get; set; }
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
            Console.WriteLine(priceAndInfo);
            return priceAndInfo;
        }

        public override string Use()
        {
            ScreenText screenText = new ScreenText();
            string konsumerarVara = "";
            if (this.Bought > this.Consumed)
            {
                this.Consumed += 1;
                konsumerarVara = "Du " + Usage + " " + this.Name.ToLower() + ".";
                screenText.CurrentDisplay();
                Console.WriteLine(konsumerarVara);
            }
            else
            {
                screenText.CurrentDisplay();
                Console.WriteLine("Du äger ingen " + this.Name.ToLower() + ".");
            }
            return konsumerarVara;
        }
    }

    public class Snack : Product
    {

        public Snack(String name, int price, String info)
        {
            this.Name = name;
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
            Console.WriteLine(priceAndInfo);
            return priceAndInfo;
        }

        public override string Use()
        {
            ScreenText screenText = new ScreenText();
            string konsumerarVara = "";
            if (this.Bought > this.Consumed)
            {
                this.Consumed += 1;
                konsumerarVara = "Du " + Usage + " " + this.Name.ToLower() + ".";
                screenText.CurrentDisplay();
                Console.WriteLine(konsumerarVara);
            }
            else
            {
                screenText.CurrentDisplay();
                Console.WriteLine("Du äger ingen " + this.Name.ToLower() + ".");
            }
            return konsumerarVara;
        }
    }

    public class Drink : Product
    {

        public Drink(String name, int price, String info)
        {
            this.Name = name;
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
            Console.WriteLine(priceAndInfo);
            return priceAndInfo;
        }

        public override string Use()
        {
            ScreenText screenText = new ScreenText();
            string konsumerarVara = "";
            if (this.Bought > this.Consumed)
            {
                this.Consumed += 1;
                konsumerarVara = "Du " + Usage + " " + this.Name.ToLower() + ".";
                Console.WriteLine(konsumerarVara);
            }
            else
            {
                Console.WriteLine("Du äger ingen " + this.Name.ToLower() + ".");
            }
            return konsumerarVara;
        }
    }



}
