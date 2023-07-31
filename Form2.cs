using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bb.BL;
using bb.DL;
using System.IO;
namespace bb
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_BackColorChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            //  username = textBox3.Text;
            while (!MUserDL.isvalidname(username))
            {
                MessageBox.Show("Invalid name! Please enter a valid name:");
                return; // Stop execution if the name is invalid
            }

            //string password = textBox2.Text;
            if (!MUserDL.IsValidPassword(password))
            {
                MessageBox.Show("Invalid password! Please enter a password consisting only of numeral digits.");
                return;
            }

            MUser user = new MUser(username, password);
            string path = "user.txt";
            bool check = MUserDL.readData(path);
            if (check == true)
            {
                MUser validUser = MUserDL.signIn(user);
                if (validUser != null)
                {
                    //  MessageBox.Show("user is valid");
                    if ((validUser.isAdmin()))
                    {
                        Form moreform = new Seller();
                        moreform.Show();

                        // s();
                        //  MessageBox.Show("i am present");
                    }
                    else
                    {
                        Form moreform = new Customer();
                        moreform.Show();

                        //  MessageBox.Show("i am not  present");
                    }
                }
                else
                {
                    MessageBox.Show("user is invalid");

                }


                Console.ReadLine();

            }
            else
            {
                MessageBox.Show("user is ......................invalid");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
