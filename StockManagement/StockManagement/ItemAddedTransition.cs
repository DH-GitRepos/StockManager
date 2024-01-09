using System;

namespace StockManagement
{
    public class ItemAddedTransaction : Transaction
    {
        public int StockItemCode { get; set; }
        public string StockItemName { get; set; }
        public int QuantityAdded { get; set; }

        public ItemAddedTransaction(DateTime transactionDatetime, int stockItemCode, string stockItemName, int quantityAdded) : base(transactionDatetime)
        {
            StockItemCode = stockItemCode;
            StockItemName = stockItemName;
            QuantityAdded = quantityAdded;
            TransactionName = "Item added";
        }

        public override string ToString()
        {
            return $"{TransactionDatetime:dd/MM/yyyy HH:mm} Item added       - Item {StockItemCode}: {StockItemName} added. Quantity in stock: {QuantityAdded}";

        }
    }
}
