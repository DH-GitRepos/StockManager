using System;

namespace StockManagement
{
    public class QuantityRemovedTransaction : Transaction
    {
        public int StockItemCode { get; set; }
        public string StockItemName { get; set; }
        public int QuantityRemoved { get; set; }
        public int NewQuantityInStock { get; set; }

        public QuantityRemovedTransaction(DateTime transactionDatetime, int stockItemCode, string stockItemName, int quantityRemoved, int newQuantityInStock) : base(transactionDatetime)
        {
            StockItemCode = stockItemCode;
            StockItemName = stockItemName;
            QuantityRemoved = quantityRemoved;
            NewQuantityInStock = newQuantityInStock;
            TransactionName = "Quantity removed";
        }

        public override string ToString()
        {
            return $"{TransactionDatetime:dd/MM/yyyy HH:mm} Quantity removed - Item {StockItemCode}: {StockItemName}. Quantity removed: {QuantityRemoved}. New quantity in stock: {NewQuantityInStock}";
        }
    }
}
