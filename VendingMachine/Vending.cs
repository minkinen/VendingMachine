using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Vending : IVending
    {
        public EndTransaction ExecuteEndTransaction(Dictionary<MoneyDenominations, int> changeInMoneyTypes)
        {
            EndTransaction endTransaction = new EndTransaction(changeInMoneyTypes);
            return endTransaction;
        }

        public InsertMoney ExecuteInsertMoney(MoneyDenominations moneyValue)
        {
            InsertMoney insertMoney = new InsertMoney(moneyValue);
            return insertMoney;
        }

        public Purchase ExecutePurchase(VendingSelection codeKey)
        {
            Purchase purchace = new Purchase(codeKey);
            return purchace;
        }

        public ShowAll ExecuteShowAll()
        {
            ShowAll showAll = new ShowAll();
            return showAll;
        }
    }
}
