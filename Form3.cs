using bb.BL;
using bb.DL;
using System;
using System.Windows.Forms;

namespace bb
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            while (!MUserDL.isvalidname(username))
            {
                MessageBox.Show("Invalid name! Please enter a valid name:");
                return; // Stop execution if the name is invalid
            }

            string password = textBox2.Text;
            if (!IsNumeric(password))
            {
                MessageBox.Show("Invalid password! Please enter a password consisting only of numeral digits.");
                return; // Stop execution if the password is invalid
            }

            string role = textBox1.Text;
            if (role.ToLower() != "seller" && role.ToLower() != "customer")
            {
                MessageBox.Show("Invalid role! Please enter either 'seller' or 'customer'.");
                return; // Stop execution if the role is invalid
            }

            string path = "user.txt";
            MUser user = new MUser(username, password, role);
            MUserDL.storeDataInList(user);
            MUserDL.storeDataInFile(path, user);

            MessageBox.Show("Stored in file");

            MUser validUser = MUserDL.signIn(user);
            if (validUser != null)
            {
                MessageBox.Show("User is valid");
            }
            else
            {
                MessageBox.Show("User is invalid");
            }
        }

        private bool IsNumeric(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }


        /*  private void button1_Click(object sender, EventArgs e)
          {
              string username = textBox3.Text;
              while (!MUserDL.isvalidname(username))
              {
                  MessageBox.Show( "Invalid name! Please enter a valid name:");


              }
              string password = textBox2.Text;
              string role = textBox1.Text;
              string path = "user.txt";
              MUser user = new MUser(username, password,role);
              MUserDL.storeDataInList(user);
              MUserDL.storeDataInFile(path, user);
                MessageBox.Show("store in file");
              MUser validUser = MUserDL.signIn(user);
              if (validUser != null)
              {
                  MessageBox.Show("user is valid");
              }
              else
              {
                  MessageBox.Show("user is invalid");

              }
          }*/

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
