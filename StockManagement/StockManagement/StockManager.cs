using System;
using System.Collections.Generic;

namespace StockManagement
{
    public class StockManager
    {
        public SortedDictionary<int, StockItem> StockItems = new SortedDictionary<int, StockItem>();

        public StockItem AddQuantityToStockItem(int code, int quantityToAdd)
        {
            if (!StockItems.ContainsKey(code))
            {
                throw new Exception($"Stock item {code} not found. Quantity not added.");
            }
            else
            {
                StockItems[code].AddQuantity(quantityToAdd);
                return StockItems[code];
            }
        }

        public StockItem CreateStockItem(int code, string name, int quantityInStock)
        {
            if (StockItems.ContainsKey(code))
            {
                throw new Exception($"Item code {code} already exists. Item not added.");
            }
            else
            {
                StockItem newItem = new StockItem(code, name, quantityInStock);
                StockItems.Add(code, newItem);
                return newItem;
            }    
        }

        public StockItem DeleteStockItem(int code)
        {
            if (!StockItems.ContainsKey(code))
            {
                throw new Exception("Item has not been deleted because it cannot be found");
            }
            else
            {
                StockItem itemCheck = StockItems[code];
                
                if(itemCheck.QuantityInStock > 0)
                {
                    throw new Exception("Item cannot be deleted because quantity in stock is not zero");
                }
                else
                {
                    StockItem item = StockItems[code];
                    StockItems.Remove(code);
                    return item;
                } 
            }
        }

        public StockItem FindStockItem(int code)
        {
            if (StockItems.ContainsKey(code))
            {
                return StockItems[code];
            }
            else { 
                return null; 
            }              
        }

        public SortedDictionary<int, StockItem> GetAllStockItems()
        {
            return StockItems;
        }

        public StockItem RemoveQuantityFromStockItem(int code, int quantityToRemove)
        {
            if (!StockItems.ContainsKey(code))
            {
                throw new Exception($"Stock item {code} not found. Quantity not removed.");
            }
            else
            {
                StockItems[code].SubtractQuantity(quantityToRemove);
                return StockItems[code];
            }
        }
    }
}
