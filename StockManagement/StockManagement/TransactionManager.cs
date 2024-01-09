using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class TransactionManager
    {
        public List<Transaction> Transactions = new List<Transaction>();

        public List<Transaction> GetAllTransactions()
        {
            return Transactions;
        }

        public void RecordItemAdded(StockItem stockItem)
        {
            ItemAddedTransaction transaction = new ItemAddedTransaction(
                DateTime.Now,
                stockItem.Code,
                stockItem.Name,
                stockItem.QuantityInStock);
                                         
            Transactions.Add(transaction);
        }

        public void RecordItemDeleted(StockItem stockItem)
        {
            ItemDeletedTransaction transaction = new ItemDeletedTransaction(
                DateTime.Now,
                stockItem.Code,
                stockItem.Name);
                        
            Transactions.Add(transaction);
        }

        public void RecordQuantityAdded(StockItem stockItem, int quantityAdded)
        {


            QuantityAddedTransaction transaction = new QuantityAddedTransaction(
                DateTime.Now,
                stockItem.Code,
                stockItem.Name,
                quantityAdded,
                stockItem.QuantityInStock);

            Transactions.Add(transaction);
        }

        public void RecordQuantityRemoved(StockItem stockItem, int quantityRemoved)
        {
            QuantityRemovedTransaction transaction = new QuantityRemovedTransaction(
                DateTime.Now,
                stockItem.Code,
                stockItem.Name,
                quantityRemoved,
                stockItem.QuantityInStock);

            Transactions.Add(transaction);
        }
    }
}
