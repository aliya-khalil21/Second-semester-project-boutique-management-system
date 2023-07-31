using bb.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace bb.DL
{
    class ProductDL
    {
        string path = "product.txt";
        public static List<Product> user = new List<Product>();
        public static List<Product> baby = new List<Product>();
        public static void storeDataInList(Product temp)
        {
            user.Add(temp);
        }
        public static void storeDataInListbaby(Product a)
        {
            baby.Add(a);
        }
        public static void storeProductDataInFile(Product temp)
        {
            string path = "product.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(temp.getproductname() + "," + temp.getquantity() + "," + temp.getcolor() + "," + temp.getsize() + "," + temp.getprice());
            file.Flush();
            file.Close();
        }
        public static void storeProductDataInFilewomen(Product temp)
        {
            string path = "female.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(temp.getproductname() + "," + temp.getquantity() + "," + temp.getcolor() + "," + temp.getsize() + "," + temp.getprice());
            file.Flush();
            file.Close();
        }

        public static void storeProductDataInFilebaby(Product temp)
        {
            string path = "baby.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(temp.getproductname() + "," + temp.getquantity() + "," + temp.getcolor() + "," + temp.getsize() + "," + temp.getprice());
            file.Flush();
            file.Close();
        }

        public static void storeDataInListbrand(Product temp)
        {
            user.Add(temp);
        }
        public static void storebrandDataInFile(Product temp)
        {
            try
            {
                string path = "brand.txt";
                using (StreamWriter file = new StreamWriter(path, true))
                {
                    file.WriteLine(temp.getproductname());
                    file.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while storing data in file: " + ex.Message);
            }
        }

        public static void loaddatafromfileforbrand()
        {
            string path = "brand.txt";
            Console.Clear();
            if (File.Exists(path))
            {

                StreamReader fileVariable = new StreamReader(path);
                string record;
                user.Clear();
                while ((record = fileVariable.ReadLine()) != null)
                {
                    // Split the record into individual data elements
                    string[] data = record.Split(',');
                    string Name = data[0];

                    // Create a new Product object

                    Product info = new Product(Name);
                    // Add the Product object to the user list
                    user.Add(info);

                    // Print the information of the product
                    Console.WriteLine($" name: {info.getbrand()},");
                }

                // Close the file after reading
                fileVariable.Close();
            }
        }
        public static void LoadDataProduct()
        {
            string path = "Product.txt";
            //  Console.Clear();
            if (File.Exists(path))
            {
                // Open the file for reading
                StreamReader file = new StreamReader(path);
                string record;
                // Clear the existing user list before populating it with the data from the file
                // user.Clear();
                // Read each line from the file
                while ((record = file.ReadLine()) != null)
                {
                    // Skip empty lines or lines with only whitespace
                    if (string.IsNullOrWhiteSpace(record))
                        continue;

                    // Split the record into individual data elements
                    string[] data = record.Split(',');

                    // Ensure the data array has enough elements
                    if (data.Length >= 6)
                    {
                        string brand = data[5];
                        string product = data[0];
                        string price = data[4];
                        string quantity = data[1];
                        string color = data[2];
                        string size = data[3];
                        Product info = new Product(brand, product, quantity, color, size, price);
                        user.Add(info);

                        // Print the information of the product
                        //Console.WriteLine($"Product name: {info.getproductname()}, Price: {info.getprice()}, Quantity: {info.getquantity()}, color: {info.getcolor()}, size: {info.getsize()}");
                    }
                    else
                    {
                        // Handle the case where the line doesn't have enough values
                        Console.WriteLine("Invalid data format in line: " + record);
                    }
                }

                // Close the file after reading
                file.Close();
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }

            Console.ReadLine();
            //   Console.Clear();
            //   Console.WriteLine("If you want to go to the main menu, press any key.");
            // Console.ReadLine();
        }

        /* public static void LoadDataProduct(string path)
         {
             Console.Clear();
             if (File.Exists(path))
             {
                 // Open the file for reading
                 StreamReader file = new StreamReader(path);
                 string record;
                 // Clear the existing user list before populating it with the data from the file
                 user.Clear();
                 // Read each line from the file
                 while ((record = file.ReadLine()) != null)
                 {
                     // Split the record into individual data elements
                     string[] data = record.Split(',');
                     string brand = data[0];
                     string product = data[1];
                     string price = data[5];
                     string quantity = data[2];
                     string color = data[3];
                     string size = data[4];
                     Product info = new Product(brand, product, quantity, color, size, price);
                     user.Add(info);

                     // Print the information of the product
                     Console.WriteLine($"barndname:{info.getBrandName()},Product name: {info.getproductname()}, Price: {info.getprice()}, Quantity: {info.getquantity()}, color: {info.getcolor()}, size: {info.getsize()}");
                 }

                 // Close the file after reading
                 file.Close();
             }
             else
             {
                 Console.WriteLine("File does not exist.");
             }

             Console.ReadLine();
             Console.Clear();
             Console.WriteLine("If you want to go to the main menu, press any key.");
             Console.ReadLine();
         }*/
        public static void deleteproduct(string productname1)
        {
            Console.Clear();
            string path = "product.txt";
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
        public static bool isvalidproductname(string productname)
        {
            bool flag = true;
            int size = productname.Length;
            for (int i = 0; i < size; i++)
            {
                if ((productname[i] >= 95 && productname[i] <= 120))//||(name[i]<=122||name[i]==32))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }

            }
            return flag;
        }
        public static bool isvalidcolor(string color)
        {
            bool flag = true;
            int size = color.Length;
            for (int i = 0; i < size; i++)
            {
                if ((color[i] >= 95 && color[i] <= 120))//||(name[i]<=122||name[i]==32))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }

            }
            return flag;
        }
        public static bool IsValidquantity(string quantity)
        {
            bool isValid = true;
            int size = quantity.Length;

            for (int i = 0; i < size; i++)
            {
                if (!char.IsDigit(quantity[i]))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }
        public static bool IsValidsize(string size)
        {
            bool flag = true;

            if (size == "xs" || size == "XS" || size == "s" || size == "S" || size == "L" || size == "l" || size == "XL" || size == "xl" || size == "xxl" || size == "XXL")
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;

        }
        public static bool IsValidprice(string price)
        {
            bool isValid = true;
            int size = price.Length;

            for (int i = 0; i < size; i++)
            {
                if (!char.IsDigit(price[i]))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }
        public static void storeshareinlist(Product temp)
        {
            user.Add(temp);
        }
        public static void storeshareproductDataInFile(Product temp)
        {
            string path = "share.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(temp.getproductname() + "," + temp.getprice());
            file.Flush();
            file.Close();
        }
        public static void loaddatafromfileforshare()
        {
            string path = "share.txt";
            Console.Clear();
            if (File.Exists(path))
            {

                StreamReader fileVariable = new StreamReader(path);
                string record;
                user.Clear();
                while ((record = fileVariable.ReadLine()) != null)
                {
                    // Split the record into individual data elements
                    string[] data = record.Split(',');
                    string Name = data[0];
                    string adress = data[1];
                    string age = data[2];
                    string email = data[3];
                    string feedback = data[4];
                    // Create a new Product object

                    Product info = new Product(Name, adress);
                    // Add the Product object to the user list
                    user.Add(info);


                    // Print the information of the product
                    Console.WriteLine($" name: {info.getproductname()},adress: {info.getBrandName()},age: {info.getprice()} ,mail: {info.getcolor()},feedback: {info.getquantity()},");
                }

                // Close the file after reading
                fileVariable.Close();
            }
        }
        public static void storefeedbackinlist(Product temp)
        {
            user.Add(temp);
        }
        public static void storefeedbabckproductDataInFile(Product temp)
        {
            string path = "feedback.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine($"{temp.getproductname()},{temp.getBrandName()},{temp.getprice()}");
            file.Flush();
            file.Close();


        }
    }
}
