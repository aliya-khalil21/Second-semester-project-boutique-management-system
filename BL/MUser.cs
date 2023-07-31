using System;

namespace bb.BL
{
    internal class MUser
    {


        protected string name;
        protected string password;
        protected string role;
        /// <summary>
        /// constructer
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        public MUser(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public MUser(string name, string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;
        }
        /// <summary>
        /// setter and getter function for user class
        /// </summary>
        /// <param name="name"></param>
        public void setname(string name)
        {
            if (string.IsNullOrEmpty(this.name) == true)
            {
                Console.WriteLine("name is required");
            }
            else
            {
                this.name = name;
            }

        }
        public string getName()
        {
            return name;
        }
        public void setRole(string role)
        {
            this.role = role;
        }
        public string getRole()
        {
            return role;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
        public string getPassword()
        {
            return password;
        }
        /// <summary>
        /// to check role is seller 
        /// </summary>
        /// <returns></returns>

        public bool isAdmin()
        {
            if (role == "seller")
            {
                return true;
            }
            return false;
        }
    }
}




