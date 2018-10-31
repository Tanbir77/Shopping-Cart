using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Cart
{
    class ShoppingCart
    {
        ArrayList items = new ArrayList();
        ProductInventory inventoryInstance = ProductInventory.getInstance();
        public void addItem(int itemNo)
        {
            items.Add(inventoryInstance.getproduct(itemNo));
            inventoryInstance.adjustProductQuantity(itemNo);


        }
        public void removeItem()
        {
            Console.Write("Which item you want to remove from your Cart?\nInsert Item Number :");
            String itmNo = Console.ReadLine();
            Console.Clear();
            int itemNo;
            bool flag = Int32.TryParse(itmNo, out itemNo);
            if (flag)
            {
                if (items.Count >= itemNo)
                {

                    inventoryInstance.adjustProductQuantity(items[itemNo - 1]);
                    items.RemoveAt(itemNo - 1);
                    Console.WriteLine("{0}", "Desired item is successfully removed from the cart");
                }
                else
                {
                    Console.WriteLine("\nItem Number is not included in your Shopping Cart");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("invalid Keyword...");
            }
            
            
        }
        public bool viewCart()
        {
            bool itemsAvailable;
            if (items.Count==0)
            {
                
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("No items are included");
                return itemsAvailable = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Your included items are :\n");
                PrintIncludedItems(items);
                return itemsAvailable = true;
            }
            
        }
        public void checkoutAndPay()
        {
            if (items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n No items are included in your Cart!!");
            }
            else
            {
                Console.WriteLine("*******************************Payment Method***********************************");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\n   Itmes name");
                Console.WriteLine("\t\t\t\t\t\t   Price(Sickle)\n");
                Console.ForegroundColor = ConsoleColor.Gray;

                IEnumerable includedItemListist = items;
                int totalCost = 0;
                int count = 1;

                foreach (Object obj in includedItemListist)
                {

                    int itemNo = 0;
                    while (true)
                    {
                        if (obj == inventoryInstance.jaggedArray[itemNo][1])
                        {
                            Console.WriteLine("{0}.{1}\t\t\t\t\t\t\t{2}", count, obj, inventoryInstance.getproductPrice(itemNo + 1));
                            count++;
                            int price = Int32.Parse(inventoryInstance.getproductPrice(itemNo + 1));
                            totalCost = totalCost + price;
                            break;
                        }

                        itemNo++;
                    }


                }
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.Write("Total price you have to pay :\t\t\t\t\t");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(totalCost);
            }
  
        }
        public static void PrintIncludedItems(IEnumerable myList)
        {
            
            int itemNo = 1;
            foreach (Object obj in myList)
                Console.WriteLine($"{itemNo++}.{obj}\n");
        }
                

    }
}
