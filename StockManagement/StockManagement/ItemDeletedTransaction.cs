using System;

namespace StockManagement
{
    public class ItemDeletedTransaction : Transaction
    {
        public int StockItemCode { get; set; }
        public string StockItemName { get; set; }

        public ItemDeletedTransaction(DateTime transactionDatetime, int stockItemCode, string stockItemName) : base(transactionDatetime)
        {
            StockItemCode = stockItemCode;
            StockItemName = stockItemName;
            TransactionName = "Item deleted";
        }

        public override string ToString()
        {
            return $"{TransactionDatetime:dd/MM/yyyy HH:mm} Item deleted     - Item {StockItemCode}: {StockItemName} deleted.";
        }
    }
}
