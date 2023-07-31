using bb.BL;
using bb.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace bb
{
    public partial class addcart : Form
    {
        int index;
        DataTable table = new DataTable("table");

        public addcart()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                table.Rows.Add(textBox1.Text, textBox6.Text);

                string username = textBox1.Text;
                while (!ProductDL.isvalidproductname(username))
                {
                    MessageBox.Show("Invalid name! Please enter a valid name:");
                    return; // Stop execution if the name is invalid
                }




                string quantity = textBox6.Text;
                while (!ProductDL.IsValidprice(quantity))
                {
                    MessageBox.Show("Invalid quantity! Please enter a valid quantity:");
                    return; // Stop execution if the name is invalid
                }
                table.Rows.Add(username, quantity);

                string productFilePath = "product.txt";
                string path = "cart.txt";
                List<string> productLines = ReadTextFile(productFilePath);
                List<string> cartLines = new List<string>();
                foreach (string line in productLines)
                {
                    string[] data = line.Split(',');
                    if (data.Length > 0 && data[0] == username)
                    {
                        Cart1 u = new Cart1(username, quantity);
                        CartDL.storeDataInListcart(u);
                        CartDL.storeProductDataInFilecart(u);



                        //string path = "cart.txt";

                        MessageBox.Show("Stored in file");
                    }
                    // Make sure 'table' is properly initialized and accessible
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while adding a new row: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox6.Text = row.Cells[1].Value.ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {


            string filePath = "cart.txt"; // Replace with your actual file path
            List<string> lines = ReadTextFile(filePath);

            // Clear the existing rows in the DataGridView
            table.Rows.Clear();

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                // Add a new row to the DataTable
                table.Rows.Add(data);
            }
        }



        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadDataIntoDataGridView(List<string> lines)
        {

            table.Rows.Clear();

            foreach (string line in lines)
            {
                string[] rowData = line.Split(','); // Assuming comma-separated data, adjust as per your file format
                table.Rows.Add(rowData);
            }

            dataGridView1.DataSource = table;
        }



        private void addcartLoad(object sender, EventArgs e)
        {
            List<string> lines = new List<string>();
            table.Columns.Add("Product", Type.GetType("System.String"));

            table.Columns.Add("quantity", Type.GetType("System.String"));
            foreach (string line in lines)
            {
                string[] rowData = line.Split(','); // Assuming tab-separated data, adjust as per your file format
                table.Rows.Add(rowData);
            }

            dataGridView1.DataSource = table;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string filePath = "cart.txt"; // Replace with your actual file path
            List<string> lines = ReadTextFile(filePath);

            // Clear the existing rows in the DataGridView
            table.Rows.Clear();

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                // Add a new row to the DataTable
                table.Rows.Add(data);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = "cart.txt"; // Replace with your actual file path
            List<string> lines = ReadTextFile(filePath);

            // Call the LoadDataIntoDataGridView method to load data into the DataGridView
            LoadDataIntoDataGridView(lines);
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Form f = new Payment();
            f.Show();
            // Hides the current form
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell != null)
                {
                    index = dataGridView1.CurrentCell.RowIndex;
                    if (index >= 0 && index < dataGridView1.Rows.Count)
                    {
                        string productName = dataGridView1.Rows[index].Cells[0].Value.ToString();
                        CartDL.user.RemoveAt(index);

                        dataGridView1.Rows.RemoveAt(index);


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while removing the row: " + ex.Message);
            }
        }
    }
}
