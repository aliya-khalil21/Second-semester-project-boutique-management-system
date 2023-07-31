using bb.BL;
using bb.DL;
using System;
using System.Windows.Forms;

namespace bb
{
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Feedback_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //table.Rows.Add(textBox1.Text, textBox6.Text, textBox4.Text, textBox2.Text, textBox3.Text, textBox5.Text);

                string username = textBox1.Text;
                while (!ProductDL.isvalidproductname(username))
                {
                    MessageBox.Show("Invalid name! Please enter a valid name:");
                    return; // Stop execution if the name is invalid
                }
                string email = textBox2.Text;
                while (!ProductDL.isvalidproductname(email))
                {
                    MessageBox.Show("Invalid brandname! Please enter a valid name:");
                    return; // Stop execution if the name is invalid
                }

                string feedback = textBox3.Text;
                while (!ProductDL.isvalidcolor(feedback))
                {
                    MessageBox.Show("Invalid color! Please enter a valid color:");
                    return; // Stop execution if the name is invalid
                }


                string path = "product.txt";
                Product u = new Product(email, username, feedback);
                ProductDL.storefeedbackinlist(u);
                ProductDL.storefeedbabckproductDataInFile(u);

                MessageBox.Show("Stored in file");

                // Make sure 'table' is properly initialized and accessible
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while adding a new row: " + ex.Message);
            }

        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form f = new Form2();
            f.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form f = new Productform();
            f.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
           /* Form f = new ProductWomen();
            f.Show();*/
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form f = new baby();
            f.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //  Form f = new Produc();
            //f.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form f = new Customer();
            f.Show();
            // Hides the current form
            this.Hide();

        }
    }
}
