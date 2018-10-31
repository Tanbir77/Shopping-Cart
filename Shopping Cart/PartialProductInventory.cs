using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Cart
{
    partial class ProductInventory
    {
   

     
        public void showProductsDetails()
        {
            int itemNo= 0;
            while (jaggedArray[itemNo] != null)
            {
                   if(jaggedArray[itemNo][2]!="0")
                    Console.WriteLine($"{jaggedArray[itemNo][0]}.{jaggedArray[itemNo][1]}\tPrice : {jaggedArray[itemNo][3]} Sickle");
               

                itemNo++;
            }
            
          
        }
        public String getproduct(int itemNo)
        {
            return jaggedArray[itemNo-1][1];
        }
        public String getproductPrice(int itemNo)
        {
            return jaggedArray[itemNo - 1][3];
        }
        public void updateInventory(String updateInfo, int lineNo)
        {

            lines[lineNo -1] = updateInfo;
            File.WriteAllLines("product.inventory.txt", lines);
        }
        //This function is used to decrease total products Quantity by 1 after a product is added to Shopping Cart.
        public void adjustProductQuantity(int itemNo)
        {
            //This procces is forAdjust the quantity of the products,products details is in the jaggedArray
            int quantity = Int32.Parse(jaggedArray[itemNo - 1][2]);
            quantity--;
            //update jaggedArray items quantity
            jaggedArray[itemNo - 1][2] = quantity.ToString();
            
            updateInventory(jaggedArray[itemNo - 1].ToString(), itemNo);
        }
        //This function is used to increased total products Quantity by 1 after a product is remove from the Shopping Cart.

        public void adjustProductQuantity(object obj)
        {

                int itemNo = 1;
                bool flag = true;
                while (flag)
                {
                    if (obj == jaggedArray[itemNo-1][1] )
                    {
                        //This procces is forAdjust the quantity of the products,products details is in the jaggedArray
                        String productId = jaggedArray[itemNo - 1][0];
                        String productName = jaggedArray[itemNo - 1][1];
                        int quantity = Int32.Parse(jaggedArray[itemNo - 1][2]);
                        quantity++;
                        //update jaggedArray items quantity
                        jaggedArray[itemNo - 1][2] = quantity.ToString();
                        String price = jaggedArray[itemNo - 1][3];
                        updateInventory($"{productId},{productName},{quantity},{price}", itemNo);
                        flag = false;
                        break;
                    }


                    itemNo++;
                }


            
        }




    }
}
