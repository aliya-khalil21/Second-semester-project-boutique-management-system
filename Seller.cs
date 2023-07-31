using System;
using System.Windows.Forms;

namespace bb
{
    public partial class Seller : Form
    {
        public Seller()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form moreform = new Productform();
            moreform.Show();
            //checkBox2.Checked = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void Seller_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form moreform = new Customer();
            moreform.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
           /* Form moreform = new Productform();
            moreform.Show();*/
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /* Form moreform = new ProductWomen();
             moreform.Show();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form moreform = new Seeproductcs();
            moreform.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            /*Form moreform = new feedbackloadcs();
            moreform.Show();*/
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form moreform = new baby();
            moreform.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form moreform = new lodinload();
            moreform.Show();

            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form moreform = new Form2();
            moreform.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form moreform = new feedbackload();
            moreform.Show();
            this.Hide();
        }
    }
}
