using System;

namespace StockManagement
{
    public class QuantityAddedTransaction : Transaction
    {
        public int StockItemCode { get; set; }
        public string StockItemName { get; set; }
        public int QuantityAdded { get; set; }
        public int NewQuantityInStock { get; set; }

        public QuantityAddedTransaction(DateTime transactionDatetime, int stockItemCode, string stockItemName, int quantityAdded, int newQuantityInStock) : base(transactionDatetime)
        {
            StockItemCode = stockItemCode;
            StockItemName = stockItemName;
            QuantityAdded = quantityAdded;
            NewQuantityInStock = newQuantityInStock;
            TransactionName = "Quantity added";
        }

        public override string ToString()
        {
            return $"{TransactionDatetime:dd/MM/yyyy HH:mm} Quantity added   - Item {StockItemCode}: {StockItemName}. Quantity added: {QuantityAdded}. New quantity in stock: {NewQuantityInStock}";
        }
    }
}
