using System;

namespace StockManagement
{
    public abstract class Transaction
    {
        public DateTime TransactionDatetime { get; set; }
        
        public string TransactionName { get; set; }

        public Transaction(DateTime transactionDatetime, string transactionName)
        {
            TransactionDatetime = transactionDatetime;
            TransactionName = transactionName;
        }

        public Transaction(DateTime transactionDatetime)
        {
            TransactionDatetime = transactionDatetime; 
        }

        public DateTime GetTransaction()
        {
            DateTime dateTime = TransactionDatetime;
            return dateTime;
        } 

        public string GetTransactionName()
        {
            string name = TransactionName;
            return name;
        }

        public abstract override string ToString();

    }
}
