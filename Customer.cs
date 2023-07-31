using System;
using System.Windows.Forms;

namespace bb
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form moreform = new Seeproductcs();
            moreform.Show();
            // Hides the current form
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form moreform = new addcart();
            moreform.Show();
            // Hides the current form
            this.Hide();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form moreform = new Form2();
            moreform.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form moreform = new Feedback();
            moreform.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form moreform = new addcart();
            moreform.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form moreform = new Feedback();
            moreform.Show();
            // Hides the current form
            this.Hide();

        }
    }
}
