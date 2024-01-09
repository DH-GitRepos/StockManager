using System;
using System.Collections.Generic;

namespace StockManagement
{
    public class AdminUI
    {
        public StockManager stockMgr { get; private set; }
        public TransactionManager transactionMgr { get; private set; }

        public AdminUI(StockManager stkMgr, TransactionManager trMgr)
        {
            stockMgr = stkMgr;
            transactionMgr = trMgr;
        }

        public List<string> AddANewItemOfStock(int code, string name, int quantityInStock)
        {
            List<string> returnResult = new List<string>();

            try
            {
                StockItem sItem = stockMgr.CreateStockItem(code, name, quantityInStock);
                transactionMgr.RecordItemAdded(sItem);

                int transactionsLength = transactionMgr.Transactions.Count - 1;
                string trName = transactionMgr.Transactions[transactionsLength].TransactionName;

                returnResult.Add($"{trName}. Item code: {code}");
            }

            catch (Exception e)
            {
                returnResult.Add($"{e.Message}");
            }

            return returnResult;
        }

        public List<string> AddQuantityToAStockItem(int code, int quantityToAdd) 
        {
            List<string> returnResult = new List<string>();

            try
            {
                StockItem sItem = stockMgr.AddQuantityToStockItem(code, quantityToAdd);
                transactionMgr.RecordQuantityAdded(sItem, quantityToAdd);

                int newQuantity = stockMgr.StockItems[code].QuantityInStock;

                returnResult.Add($"Quantity added to item: {code}. New quantity in stock: {newQuantity}");
            }

            catch (Exception e)
            {
                returnResult.Add($"{e.Message}");
            }

            return returnResult;
        }

        public List<string> RemoveQuantityFromAStockItem(int code, int quantityToRemove) 
        {
            List<string> returnResult = new List<string>();

            try
            {
                StockItem sItem = stockMgr.RemoveQuantityFromStockItem(code, quantityToRemove);
                transactionMgr.RecordQuantityRemoved(sItem, quantityToRemove);

                int newQuantity = stockMgr.StockItems[code].QuantityInStock;

                returnResult.Add($"Quantity removed from item: {code}. New quantity in stock: {newQuantity}");
            }

            catch (Exception e)
            {
                returnResult.Add($"{e.Message}");
            }

            return returnResult;
        }

        public List<string> DeleteAStockItem(int code)
        {
            List<string> returnResult = new List<string>();

            try
            {
                StockItem sItem = stockMgr.DeleteStockItem(code);
                transactionMgr.RecordItemDeleted(sItem);

                returnResult.Add($"Item {code} deleted.");
            }

            catch (Exception e)
            {
                returnResult.Add($"{e.Message}");
            }

            return returnResult;
        }

        public List<string> ViewStockLevels()
        {
            List<string> returnResult = new List<string>();

            SortedDictionary<int, StockItem> stockList = stockMgr.GetAllStockItems();

            returnResult.Add("\nStock Levels");
            returnResult.Add("============");
            
            if(stockList.Count != 0)
            {
                returnResult.Add("\tItem code\tItem name           \tQuantity in stock");

                foreach (KeyValuePair<int, StockItem> item in stockList)
                {
                    returnResult.Add($"\t{item.Value.Code,-9}\t{item.Value.Name,-20}\t{item.Value.QuantityInStock}");
                }
            }
            else
            {
                returnResult.Add("No stock items");
            }

            return returnResult;
        }

        public List<string> ViewTransactionLog()
        {
            List<string> returnResult = new List<string>();

            List<Transaction> transactionList = transactionMgr.GetAllTransactions();

            returnResult.Add("\nTransaction log");
            returnResult.Add("===============");

            if (transactionList.Count != 0)
            {
                foreach (Transaction item in transactionList)
                {
                    string itemDate = item.TransactionDatetime.ToString("dd/MM/yyyy HH:mm");
                    string itemTrName = item.TransactionName;

                    if (item is ItemAddedTransaction tr_1)
                    {
                        int itemCode = tr_1.StockItemCode;
                        string itemName = tr_1.StockItemName;
                        int itemQty = tr_1.QuantityAdded;

                        returnResult.Add($"{itemDate} {itemTrName,-16} - Item {itemCode}: {itemName} added. Quantity in stock: {itemQty}");
                    }

                    else if (item is QuantityAddedTransaction tr_2)
                    {
                        int itemCode = tr_2.StockItemCode;
                        string itemName = tr_2.StockItemName;
                        int itemQty = tr_2.NewQuantityInStock;
                        int qtyAdded = tr_2.QuantityAdded;

                        returnResult.Add($"{itemDate} {itemTrName,-16} - Item {itemCode}: {itemName}. Quantity added: {qtyAdded}. New quantity in stock: {itemQty}");
                    }

                    else if (item is QuantityRemovedTransaction tr_3)
                    {
                        int itemCode = tr_3.StockItemCode;
                        string itemName = tr_3.StockItemName;
                        int itemQty = tr_3.NewQuantityInStock;
                        int qtyRemoved = tr_3.QuantityRemoved;

                        returnResult.Add($"{itemDate} {itemTrName,-16} - Item {itemCode}: {itemName}. Quantity removed: {qtyRemoved}. New quantity in stock: {itemQty}");
                    }

                    if (item is ItemDeletedTransaction tr_4)
                    {
                        int itemCode = tr_4.StockItemCode;
                        string itemName = tr_4.StockItemName;

                        returnResult.Add($"{itemDate} {itemTrName,-17}- Item {itemCode}: {itemName} deleted.");
                    }
                }
            }

            else
            {
                returnResult.Add("No transactions");
            }

            return returnResult;
        }

    }
}
