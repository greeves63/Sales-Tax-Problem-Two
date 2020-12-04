using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales_Tax_Problem_Number_Two
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReturnProduct returnProduct = new ReturnProduct();
            List<Product> itemsInCart = new List<Product>();
            int count = 0;

            while (true)
            {
                Console.WriteLine("----------------- Shopping Cart -------------");
                Console.WriteLine("Add Items to Cart");
                Console.WriteLine("");
                Console.WriteLine($"Item {++count}");
                Console.WriteLine("");

                Console.WriteLine("Name : ");
                var name = Console.ReadLine();

                Console.WriteLine("Price : ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    throw new Exception("Invalid price");
                }

                Console.WriteLine("Quantity : ");
                if (!int.TryParse(Console.ReadLine(), out int quantity))
                {
                    throw new Exception("Invalid quantity");
                }

                Console.WriteLine("Is the item imported : (Y/N) [Note: Any other key except Y/y is considered as No]");
                var isImported = Console.ReadLine().ToLower() == "y" ? true : false;

                Console.WriteLine("Choose The Type of Item (Select from the list below)\n1. Book\n2. Food\n3. Medical\n4. Other");

                if (!Enum.TryParse<ItemType>(Console.ReadLine(), out ItemType itemType))
                {
                    throw new Exception("Invalid type");
                }

                Console.WriteLine("Would you like to add more items? (Y/N) [Note: Any other key except Y/y is considered as No]");
                var input = Console.ReadLine().ToLower();

                var product = returnProduct.GetProduct(name, Convert.ToDecimal(price), Convert.ToInt32(quantity), itemType, isImported);
                itemsInCart.Add(product);

                if (input == "y")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("Thank yor for your purchase.\n");
            Console.WriteLine("------- Date : " + DateTime.Now.ToString("MM/dd/yyyy") + " -------");
            Console.WriteLine("");
            Console.WriteLine("Item(Quantity): Price");
            Console.WriteLine("");

            foreach (var item in itemsInCart)
            {
                decimal itemPrice = item.Price;
                decimal itemTax = item.CalculateTax();
                decimal itemTotal = itemPrice + itemTax;

                Console.WriteLine(item.Name + " (" +item.Quantity + "): " + itemTotal);
            }

            Console.WriteLine("\n");

            Console.WriteLine($"------- Total Number Of Items In Cart : {itemsInCart.Count()} -------\n");
            Console.WriteLine("Sales Taxes: " + itemsInCart.Sum(item => item.CalculateTax())); //Imported Tax + Service Tax
            decimal totalTax = 0;
            decimal totalPrice = 0;
            
            totalTax += itemsInCart.Sum(item => item.CalculateTax());
            totalPrice += itemsInCart.Sum(item => item.Price);


            decimal finalPrice = totalPrice + totalTax;
            Console.WriteLine("Total: " + finalPrice);

            Console.ReadLine();
        }
    }
}
