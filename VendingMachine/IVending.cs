using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal interface IVending
    {

        Purchase ExecutePurchase(VendingSelection codeValue);

        ShowAll ExecuteShowAll();

        InsertMoney ExecuteInsertMoney(MoneyDenominations moneyValue);

        EndTransaction ExecuteEndTransaction(Dictionary<MoneyDenominations, int> changeInMoneyTypes);

    }
}
