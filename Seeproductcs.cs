using bb.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace bb
{
    public partial class Seeproductcs : Form
    {
        int index;
        DataTable table = new DataTable("table");
        public Seeproductcs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = "product.txt"; // Replace with your actual file path
            List<string> lines = ReadTextFile(filePath);
            LoadDataIntoDataGridView(lines);

        }
        private void LoadDataIntoDataGridView(List<string> lines)
        {
            DataTable table = new DataTable();
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("quantity", typeof(string));
            table.Columns.Add("color", typeof(string));
            table.Columns.Add("size", typeof(string));
            table.Columns.Add("price", typeof(string));

            table.Columns.Add("brandname", typeof(string));
            foreach (string line in lines)
            {
                string[] rowData = line.Split(','); // Assuming tab-separated data, adjust as per your file format
                table.Rows.Add(rowData);
            }

            dataGridView1.DataSource = table;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private List<string> ReadTextFile(string filePath)
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void Seeproductcs_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form f = new Feedback();
            f.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = "women.txt"; // Replace with your actual file path
            List<string> lines = ReadTextFile(filePath);
            LoadDataIntoDataGridView(lines);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filePath = "baby.txt"; // Replace with your actual file path
            List<string> lines = ReadTextFile(filePath);
            LoadDataIntoDataGridView(lines);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell != null)
                {
                    index = dataGridView1.CurrentCell.RowIndex;
                    if (index >= 0 && index < dataGridView1.Rows.Count)
                    {
                        string productName = dataGridView1.Rows[index].Cells[0].Value.ToString();
                        ProductDL.user.RemoveAt(index);

                        dataGridView1.Rows.RemoveAt(index);

                        // Get the product name from the deleted row

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while removing the row: " + ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form f = new Seller();
            f.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form f = new Customer();
            f.Show();
            // Hides the current form
            this.Hide();

        }
    }
}
