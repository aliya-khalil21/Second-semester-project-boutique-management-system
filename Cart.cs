using System;
using System.Windows.Forms;

namespace bb
{
    public partial class Cart : Form
    {
        public Cart()
        {
            InitializeComponent();
        }

        private void Cart_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form moreform = new addcart();
            moreform.Show();
        }
    }
}
