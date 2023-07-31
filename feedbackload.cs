using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bb
{
    public partial class feedbackload : Form
    {
        public feedbackload()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f= new Form2();
            f.Show();
            // Hides the current form
            this.Hide();

        }
    }
}
