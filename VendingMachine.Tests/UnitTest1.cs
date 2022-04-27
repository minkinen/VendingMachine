using Xunit;
using VendingMachine;
using System;
using System.Collections.Generic;

namespace VendingMachine.Tests
{
    public class ChocolateBarTest
    {    
        [Fact]
        public void FactTestChocolateBar()
        {
            // Arrange 1
            string name = "Geisha";
            int price = 25;
            string info = "Mjölkhocklad med mjuk hasselnötsfyllning 121g Fazer";
            string upperName = "GEISHA";
            string lowerName = "geisha";
            string singular = "";
            string plural = "";
            string usage = "smaskar i dig en";
            int bought = 0;
            int consumed = 0;
            string infoMessage = "Mjölkhocklad med mjuk hasselnötsfyllning 121g Fazer. Pris 25kr.";   
            string consumptionMessage1 = "Du äger ingen geisha";
            string consumptionMessage2 = "Du smaskar i dig en geisha";
            // Act 1
            ChocolateBar testCase = new ChocolateBar(name, price, info);
            string actualIM = testCase.Examine();
            string actualCM = testCase.Use();
            // Assert 1
            Assert.Equal(name, testCase.Name);
            Assert.Equal(price, testCase.Price);
            Assert.Equal(info, testCase.Info);
            Assert.Equal(upperName, testCase.UpperName);
            Assert.Equal(lowerName, testCase.LowerName);
            Assert.Equal(singular, testCase.Singular);
            Assert.Equal(plural, testCase.Plural);
            Assert.Equal(usage, testCase.Usage);
            Assert.Equal(bought, testCase.Bought);
            Assert.Equal(consumed, testCase.Consumed);  
            Assert.Equal(infoMessage, actualIM);
            Assert.Equal(consumptionMessage1, actualCM);

            // Arrange 2
            testCase.Bought = 1;
            testCase.Consumed = 0;
            // Act 2
            actualCM = testCase.Use();
            // Assert 2
            Assert.Equal(consumptionMessage2, actualCM);

            // Arrange 3
            testCase.Bought = 1;
            testCase.Consumed = 1;
            // Act 3
            actualCM = testCase.Use();
            // Assert 3
            Assert.Equal(consumptionMessage1, actualCM);

            // Arrange 4
            testCase.Bought = 12;
            testCase.Consumed = 5;
            // Act 4
            actualCM = testCase.Use();
            // Assert 4
            Assert.Equal(consumptionMessage2, actualCM);
        }
    }

    /*
    // För att undvika att olika tester som använder MoneyPool skall påverka varandra, så kommenterar jag bort alla utom ett test som använder MoneyPool.
    public class InsertMoneyTest
    {
        [Fact]
        public void FactTestInseretMoney()
        {
            // Arrange 1
            MoneyPool.moneyPool = 0;
            MoneyDenominations value = (MoneyDenominations)Int16.Parse("20");
            int expectedMoneyPool = 20;
            // Act 1
            InsertMoney testCase = new InsertMoney(value);
            // Assert 1
            Assert.Equal(expectedMoneyPool, MoneyPool.moneyPool);

            // Arrange 2
            value = (MoneyDenominations)Int16.Parse("1");
            expectedMoneyPool = 21;
            // Act 2
            testCase = new InsertMoney(value);
            // Assert 2
            Assert.Equal(expectedMoneyPool, MoneyPool.moneyPool);

            // Arrange 3
            value = (MoneyDenominations)Int16.Parse("100");
            expectedMoneyPool = 121;
            // Act 3
            testCase = new InsertMoney(value);
            // Assert 3
            Assert.Equal(expectedMoneyPool, MoneyPool.moneyPool);

            // Arrange 4
            MoneyPool.moneyPool = 0;
            value = (MoneyDenominations)Int16.Parse("100");
            expectedMoneyPool = 100;
            // Act 4
            testCase = new InsertMoney(value);
            // Assert 4
            Assert.Equal(expectedMoneyPool, MoneyPool.moneyPool);
        }
    }
    */

    /*
    // För att undvika att olika tester som använder MoneyPool skall påverka varandra, så kommenterar jag bort alla utom ett test som använder MoneyPool.
    public class EndTransactionTest
    {
        [Fact]
        public void FactTestEndTransaction()
        {
            // Arrange 1
            MoneyPool.moneyPool = 8;
            MoneyDenominations kr1 = (MoneyDenominations)Int16.Parse("1");
            MoneyDenominations kr5 = (MoneyDenominations)Int16.Parse("5");
            MoneyDenominations kr10 = (MoneyDenominations)Int16.Parse("10");
            MoneyDenominations kr20 = (MoneyDenominations)Int16.Parse("20");
            MoneyDenominations kr50 = (MoneyDenominations)Int16.Parse("50");
            MoneyDenominations kr100 = (MoneyDenominations)Int16.Parse("100");
            MoneyDenominations kr500 = (MoneyDenominations)Int16.Parse("500");
            MoneyDenominations kr1000 = (MoneyDenominations)Int16.Parse("1000");
            int expectedEndTransactionMoneyPool = 0;
            var expectedCIMT = new Dictionary<MoneyDenominations, int>() { {kr5, 1}, {kr1, 3} };
            // Act 1
            Dictionary<MoneyDenominations, int> changeInMoneyTypes = new Dictionary<MoneyDenominations, int>();
            EndTransaction testCase = new EndTransaction(changeInMoneyTypes);
            Dictionary<MoneyDenominations, int>  actualCIMT = changeInMoneyTypes;
            // Assert 1
            Assert.Equal(expectedEndTransactionMoneyPool, MoneyPool.moneyPool);
            Assert.Equal(expectedCIMT, actualCIMT);

            // Arrange 2
            MoneyPool.moneyPool += 1;
            expectedEndTransactionMoneyPool = 0;
            expectedCIMT = new Dictionary<MoneyDenominations, int>() { { kr1, 1 } };
            // Act 2
            changeInMoneyTypes = new Dictionary<MoneyDenominations, int>();
            testCase = new EndTransaction(changeInMoneyTypes);
            actualCIMT = changeInMoneyTypes;
            // Assert 2
            Assert.Equal(expectedEndTransactionMoneyPool, MoneyPool.moneyPool);
            Assert.Equal(expectedCIMT, actualCIMT);
        }
    }
    */

    public class ShowAllTest
    {
        [Fact]
        public void FactTestShowAll()
        {
            // Arrange 
            Program.currentDisplay = Display.UserInventory;
            Display expectedAfterShowMenu = Display.Menu;

            // Act
            ShowAll testCase = new ShowAll();
            Display actual = Program.currentDisplay;

            // Assert
            Assert.Equal(expectedAfterShowMenu, actual);
        }
    }


    // För att undvika att olika tester som använder MoneyPool skall påverka varandra, så kommenterar jag bort alla utom ett test som använder MoneyPool.
    public class PurchaseTest
    {
        [Theory]
        [InlineData(0, "A1", 0, 0, 0)]
        [InlineData(10, "A2", 0, 1, 0)]
        [InlineData(15, "A3", 0, 0, 15)]
        [InlineData(50, "B1", 0, 1, 25)]
        [InlineData(30, "B2", 1, 2, 5)]
        [InlineData(25, "B3", 2, 2, 25)]
        [InlineData(40, "C1", 4, 5, 28)]
        [InlineData(20, "C2", 2, 3, 5)]
        [InlineData(100, "C3", 10, 11, 85)]
        public void TheoryTestPurchase(int money, string productCode, int bought, int expectedBought, int expectedMoneyPool)
        {
            // Arrange 
            VendingSelection choice = (VendingSelection)Enum.Parse(typeof(VendingSelection), productCode);
            Product chosenProduct;
            Management.menu.TryGetValue(choice, out chosenProduct);
            chosenProduct.Bought = bought;
            MoneyPool.moneyPool = money;
            // Act
            Purchase testCase = new Purchase(choice);
            // Assert
            Assert.Equal(expectedMoneyPool, MoneyPool.moneyPool);
            Assert.Equal(expectedBought, chosenProduct.Bought);
        }
    }

}
// I den här videon https://quick-adviser.com/what-is-the-difference-between-fact-and-theory-in-xunit/ (omkring 20 minuter in) 
// så ger han ett förslag på hur man kan köra olika test i serie för att undvika att de påverkar varandra, men jag har inte studerat metoden ännu.