using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace bb
{
    public partial class Payment : Form
    {
        int index;
        DataTable table = new DataTable("table");
        public Payment()
        {
            InitializeComponent();
        }

        private void paymentloadform(object sender, EventArgs e)
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
        private string GetProductPrice(string filePath, string productName)
        {
            string[] productLines = File.ReadAllLines(filePath);
            foreach (string line in productLines)
            {
                string[] productData = line.Split(',');
                if (productData.Length > 4 && productData[0] == productName)
                {
                    return productData[4]; // Return the price (assuming it's the 5th index)
                }
            }
            return null; // RReturn null if the product is not found
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    string productName = selectedRow.Cells[0].Value.ToString(); // Get the product name from the first index

                    string priceString = GetProductPrice("product.txt", productName);

                    if (int.TryParse(priceString, out int price))
                    {
                        int quantity = Convert.ToInt32(selectedRow.Cells[1].Value); // Get the quantity from the second index
                        int totalPrice = quantity * price;
                        //MessageBox.Show($"Total Price: {totalPrice}");
                        textBox3.Text = totalPrice.ToString(); // Update the TextBox with the total price   
                    }
                    else
                    {
                        MessageBox.Show("Invalid price! Please ensure the product exists in the product file.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while multiplying the quantity: " + ex.Message);
            }




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

        private void button7_Click(object sender, EventArgs e)
        {
            string filePath = "cart.txt"; // Replace with your actual file path
            List<string> lines = ReadTextFile(filePath);

            LoadDataIntoDataGridView(lines);
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

        private void button8_Click(object sender, EventArgs e)
        {
            Form f = new Customer();
            f.Show();
            // Hides the current form
            this.Hide();

        }
    }
}
