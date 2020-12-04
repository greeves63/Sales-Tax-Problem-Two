using System;

namespace Sales_Tax_Problem_Number_Two
{
    public interface IReturnProduct
    {
        Product GetProduct(string Name, decimal price, int quantity, ItemType itemType, bool isImported);
    }

    public class ReturnProduct : IReturnProduct
    {
        public Product GetProduct(string name, decimal price, int quantity, ItemType itemType, bool isImported)
        {
            switch (itemType)
            {
                case ItemType.Book:
                    return new Book(name, isImported, price, quantity);

                case ItemType.Food:
                    return new Food(name, isImported, price, quantity);

                case ItemType.Medical:
                    return new Medical(name, isImported, price, quantity);

                case ItemType.Other:
                    return new Others(name, isImported, price, quantity);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
