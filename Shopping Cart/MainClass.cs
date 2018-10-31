using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Cart
{
    class MainClass
    {
        static void Main(string[] args)
        {
            ProductInventory inventoryInstance = ProductInventory.getInstance(); //Create a instance of the ProductInventory class to get inventory items from the text file;
            ShoppingCart cart1 = new ShoppingCart();                             //create shopping cart instance

            while (true)
            {
                try
                {

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("{0}{1}", "\n\t\t\t   WELCOME TO", " THE SHOPPING CART");
                    Console.WriteLine("\n********************************************************************************");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\nFollowing Options are available to you:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n1.{0}\n2.{1}\n3.{2}\n4.{3}\n5.{4}", " Add an item to CART", " Remove an item from CART", " View the CART", " Checkout and Pay", " Exit");
                    String optn = Console.ReadLine();  //Take input from the users to choose their desired options
                    int option=Int32.Parse(optn);
                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("{0}{1}", "\n\t\t\t   WELCOME TO", " THE SHOPPING CART");
                            Console.WriteLine("\n********************************************************************************");
                            Console.WriteLine("Items availabe:\n ");
                            inventoryInstance.showProductsDetails(); //show all products those are currently available in the inventory.
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Insert an item id add to the Cart.");
                            String itmNo = Console.ReadLine();//Taking input from the user to add their desired items to their Cart.
                            int itemNo = Int32.Parse(itmNo);
                            cart1.addItem(itemNo);  //add item to the cart . Here "itemNo" is passing as it can be taken from the items Array.
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("{0}{1}", "\n\t\t\t   WELCOME TO", " THE SHOPPING CART");
                            Console.WriteLine("\n********************************************************************************");
                            bool itemsAvailable = cart1.viewCart();
                            if (itemsAvailable)
                            {
                                cart1.removeItem();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\npress any key to continue.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\npress any key to continue.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            
                           
                            break;
                        case 3:
                            Console.Clear();
                            cart1.viewCart();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\npress any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("{0}{1}", "\n\t\t\t   WELCOME TO", " THE SHOPPING CART");
                            Console.WriteLine("\n********************************************************************************\n\n");
                            cart1.checkoutAndPay();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\npress any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 5:
                            System.Environment.Exit(0);
                            break;
                       default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option is choosen.Input a valid One.");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\npress any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                    }



                }
                catch (NullReferenceException e )
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Product Id.Please, insert a valid one");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\npress any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch(ArgumentException e)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option is choosen.Input a valid One.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\npress any key to continue.");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option is choosen.Input a valid One.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\npress any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
                finally
                {
                
                }



            }
        }
    }
}
