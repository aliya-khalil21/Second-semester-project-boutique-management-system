using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using bb.DL;
using bb.BL;
namespace bb
{
    public partial class Productform : Form
    {
        int index;
        DataTable table = new DataTable("table");
        public Productform()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                table.Rows.Add(textBox1.Text, textBox4.Text, textBox2.Text, textBox6.Text, textBox3.Text, textBox5.Text);

                string username = textBox1.Text;
                while (!ProductDL.isvalidproductname(username))
                {
                    MessageBox.Show("Invalid name! Please enter a valid name:");
                    return;
                }
                string brandname = textBox6.Text;
                while (!ProductDL.isvalidproductname(username))
                {
                    MessageBox.Show("Invalid brandname! Please enter a valid name:");
                    return;
                }
                string size = textBox5.Text;
                while (!ProductDL.IsValidsize(size))
                {
                    MessageBox.Show("Invalid size! Please enter a valid size:");
                    return;
                }
                string price = textBox4.Text;
                while (!ProductDL.IsValidprice(price))
                {
                    MessageBox.Show("Invalid pricr! Please enter a valid price:");
                    return;
                }
                string color = textBox2.Text;
                while (!ProductDL.isvalidcolor(color))
                {
                    MessageBox.Show("Invalid color! Please enter a valid color:");
                    return;
                }

                string quantity = textBox3.Text;
                while (!ProductDL.IsValidquantity(quantity))
                {
                    MessageBox.Show("Invalid quantity! Please enter a valid quantity:");
                    return;
                }
                string path = "product.txt";
                Product u = new Product(username, brandname, quantity, color, size, price);
              //  ProductDL.storeDataInList(u);
                ProductDL.storeProductDataInFile(u);

                MessageBox.Show("Stored in file");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while adding a new row: " + ex.Message);
            }
        }

        private void Productformload(object sender, EventArgs e)
        {
            try
            {
                table = new DataTable(); // Initialize the DataTable if necessary
                table.Columns.Add("name", typeof(string));
                table.Columns.Add("brandname", typeof(string));
                table.Columns.Add("price", typeof(string));
                table.Columns.Add("color", typeof(string));
                table.Columns.Add("quantity", typeof(string));
                table.Columns.Add("size", typeof(string));

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while setting up the data source: " + ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataGridViewRow newdata = dataGridView1.Rows[index];
            newdata.Cells[0].Value = textBox1.Text;
            newdata.Cells[1].Value = textBox4.Text;
            newdata.Cells[2].Value = textBox2.Text;
            newdata.Cells[3].Value = textBox3.Text;
            newdata.Cells[4].Value = textBox4.Text;
            newdata.Cells[5].Value = textBox4.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox6.Text = string.Empty;
        }

        private void button9_Click(object sender, EventArgs e)
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
                        // Delete the corresponding data from the file
                        //ProductDL.deleteproduct(productName);
                        // Remove the row from the DataGridView
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
            // table.Columns.Add("brandname", typeof(string));
            table.Columns.Add("quantity", typeof(string));
            table.Columns.Add("color", typeof(string));
            table.Columns.Add("size", typeof(string));
            table.Columns.Add("price", typeof(string));


            foreach (string line in lines)
            {
                string[] rowData = line.Split(','); // Assuming tab-separated data, adjust as per your file format
                table.Rows.Add(rowData);
            }

            dataGridView1.DataSource = table;
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

        private void button12_Click(object sender, EventArgs e)
        {
            Form f = new  Seller();
            f.Show();
            // Hides the current form
            this.Hide();


        }
    }
}
