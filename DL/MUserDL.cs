using bb.BL;
using System;
using System.Collections.Generic;
using System.IO;
namespace bb.DL
{
    internal class MUserDL
    {
        string path = "login.txt";
        public static List<MUser> user = new List<MUser>();
        /// <summary>
        /// store data in list
        /// </summary>

        public static void storeDataInList(MUser u)
        {
            user.Add(u);
        }
        /// <summary>
        /// store data in file
        /// </summary>

        public static void storeDataInFile(string path, MUser u)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(u.getName() + "," + u.getPassword() + "," + u.getRole());
            file.Flush();
            file.Close();
        }
        /// <summary>
        /// signinfunction
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public static MUser signIn(MUser u)
        {
            foreach (MUser storedUser in user)
            {
                if (u.getName() == storedUser.getName() && u.getPassword() == storedUser.getPassword())
                {
                    return storedUser;
                }
            }
            return null;
        }
        /// <summary>
        /// is valid name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool isvalidname(string name)
        {
            bool flag = true;
            int size = name.Length;
            for (int i = 0; i < size; i++)
            {
                if ((name[i] >= 95 && name[i] <= 120))//||(name[i]<=122||name[i]==32))
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
        /// <summary>
        /// is valid role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static bool isvalidrole(string role)
        {
            bool flag = true;

            if (role == "seller" || role == "customer")
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        /// <summary>
        /// is valid password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsValidPassword(string password)
        {
            bool isValid = true;
            int size = password.Length;

            for (int i = 0; i < size; i++)
            {
                if (!char.IsDigit(password[i]))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }
        /// <summary>
        /// read data from fle for login functionality
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool readData(string path)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string name = parseData(record, 1);
                    string password = parseData(record, 2);
                    string role = parseData(record, 3);
                    MUser u = new MUser(name, password, role);
                    storeDataInList(u);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }
        /// <summary>
        /// pasrse data fnction
        /// </summary>
        /// <param name="record"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        /// <summary>
        /// /feedback
        /// </summary>
        /// <param name="u"></param>
        public static void storefeedbackinlist(MUser u)
        {
            user.Add(u);
        }
        public static void storeProductDataInFile(MUser u)
        {
            string path = "feedback.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(u.getName() + "," + u.getPassword());
            file.Flush();
            file.Close();
        }
        public static void loaddatafromfileforfeedback()
        {
            string path = "feedback.txt";
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
                    string feedback = data[1];
                    // Create a new Product object

                    MUser info = new MUser(Name, feedback);
                    // Add the Product object to the user list
                    user.Add(info);

                    // Print the information of the product
                    Console.WriteLine($" name: {info.getName()}, feedback: {info.getPassword()},");
                }

                // Close the file after reading
                fileVariable.Close();
            }

        }
    }
}


