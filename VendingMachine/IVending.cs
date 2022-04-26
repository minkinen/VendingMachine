
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
