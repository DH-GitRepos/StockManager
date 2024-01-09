using System;

namespace StockManagement
{
    public class StockItem
    {
        public int Code { get; private set; }

        public string Name { get; private set; }

        public int QuantityInStock { get; private set; }

        public StockItem(int code, string name, int quantityInStock)
        {
            Code = code;
            Name = name;
            QuantityInStock = quantityInStock;

            if (Code < 0 & Name.Length == 0 & QuantityInStock <= 0)
            {
                throw new Exception("Item code must be a positive integer. Item name cannot be blank. Quantity cannot be zero or negative. ");
            }

            if (Code < 0 & Name.Trim().Length == 0)
            {
                throw new Exception("Item code must be a positive integer. Item name cannot be just spaces. ");
            }

            if (Code < 0)
            {
                throw new Exception("Item code must be a positive integer. ");
            }
            
            if (Name == null | Name.Length == 0)
            {
                throw new Exception("Item name cannot be blank. ");
            }

            if (Name.Trim().Length == 0)
            {
                throw new Exception("Item name cannot be just spaces. ");
            }

            if (QuantityInStock <= 0)
            {
                throw new Exception("Quantity cannot be zero or negative. ");
            }
        }

        public void AddQuantity(int qty)
        {
            if (qty >= 0)
            {
                int existingQty = QuantityInStock;
                int newQtyInStock = existingQty + qty;
                
                QuantityInStock = newQtyInStock;
            }
            else
            {
                throw new Exception("Quantity cannot be negative");
            }           
        }

        public void SubtractQuantity(int qty)
        {
            if (qty < 0)
            {
                throw new Exception("Quantity cannot be negative");
            }
            else if (QuantityInStock - qty < 0)
            {
                throw new Exception("Insufficient quantity in stock");
            }
            else
            {
                QuantityInStock -= qty;
            }
        }
    }
}
