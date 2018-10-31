using System;
using System.Collections.Generic;

namespace Shopping_Cart
{
    partial class ProductInventory
    {
        static ProductInventory uniqueInstance;
        string[] lines;
        IEnumerable<string> line = new List<string>();
        public string[][] jaggedArray = new string[1000][];
        private ProductInventory() {
            lines = System.IO.File.ReadAllLines("product.inventory.txt");
            int lineNumber = 0;
            foreach (String line in lines)
            {   
                jaggedArray[lineNumber] = line.Split(',');
                lineNumber++;
            }

        }

        public static ProductInventory getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new ProductInventory();
            }
            return uniqueInstance;
        }

    }
}
