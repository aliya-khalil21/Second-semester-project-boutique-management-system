using bb.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace bb.DL
{
    class CartDL
    {
        protected string path = "cart.txt";
        public static List<Cart1> user = new List<Cart1>();
        public static void storeDataInListcart(Cart1 temp)
        {
            user.Add(temp);
        }
        /// <summary>
        /// store in file in cart
        /// </summary>
        /// <param name="temp"></param>
        public static void storeProductDataInFilecart(Cart1 temp)
        {
            string path = "cart.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(temp.getproductname() + "," + temp.getquantity());

            file.Flush();
            file.Close();

        }

        /// <summary>
        /// loaddata cart
        /// </summary>
        /// <param name="path"></param>
        /* public static void LoadDatacart()
         {
             string path = "cart.txt";
             Console.Clear();
             if (File.Exists(path))
             {
                 // Open the file for reading
                 StreamReader fileVariable = new StreamReader(path);
                 string record;
                 // Clear the existing user list before populating it with the data from the file
                 user.Clear();
                 // Read each line from the file
                 while ((record = fileVariable.ReadLine()) != null)
                 {
                     // Split the record into individual data elements
                 *//*    str*//*ing[] data = record.Split(',');

                     // Check if data has at least two elements
                     if (data.Length >= 2)
                     {
                         string productname = data[0];
                         string quantity = data[1];

                         // Create a new Cart object
                         Cart info = new Cart1(productname, quantity);

                         // Add the Cart object to the user list
                         user.Add(info);

                         // Print the information of the product
                 *//*        Cons*//*ole.WriteLine($"Product name: {info.getproductname()}");
                     }
                     else
                     {
                         Console.WriteLine("Invalid record format: " + record);
                     }
                 }


                 // Close the file after reading
                 fileVariable.Close();
             }
             else
             {
                 Console.WriteLine("File does not exist.");
             }
 */
        /* Console.ReadLine();
         Console.Clear();
         Console.WriteLine("If you want to go to the main menu, press any key.");
         Console.ReadLine();
     }
     /// <summary>*/
        /// delete product
        /// </summary>
        /// <param name="productname1"></param>
        public static void deleteproductcart(string productname1)
        {
            Console.Clear();
            string path = "cart.txt";
            List<string> lines = File.ReadAllLines(path).ToList();
            bool productFound = false;
            for (int i = 0; i < lines.Count; i++)
            {
                string[] fields = lines[i].Split(',');

                if (fields[0] == productname1)
                {
                    lines.RemoveAt(i);
                    productFound = true;
                    break;
                }
            }

            if (productFound)
            {
                File.WriteAllLines(path, lines);
                Console.WriteLine($"Product '{productname1}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Product '{productname1}' not found.");
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("if you want to go main menu press any key");
            Console.ReadLine();
        }
        /// <summary>
        /// feedback
        /// </summary>
        /// <param name="temp"></param>


    }
}
