using bb.BL;
using bb.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace bb
{
    public partial class baby : Form
    {
        int index;
        DataTable table = new DataTable("table");
        public baby()
        {
            InitializeComponent();
        }

        private void baby_Load(object sender, EventArgs e)
        {
            try
            {
                table = new DataTable(); // Initialize the DataTable if necessary
                                         // table = new DataTable(); // Initialize the DataTable if necessary
                table.Columns.Add("ID", typeof(string));
                table.Columns.Add("price", typeof(string));
                table.Columns.Add("color", typeof(string));
                table.Columns.Add("name", typeof(string));
                table.Columns.Add("quantity", typeof(string));
                table.Columns.Add("size", typeof(string));

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while setting up the data source: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                table.Rows.Add(textBox1.Text, textBox4.Text, textBox2.Text, textBox6.Text, textBox3.Text, textBox5.Text);

                string username = textBox1.Text;
                while (!ProductDL.isvalidproductname(username))
                {
                    MessageBox.Show("Invalid name! Please enter a valid name:");
                    return; // Stop execution if the name is invalid
                }
                string brandname = textBox2.Text;
                while (!ProductDL.isvalidproductname(username))
                {
                    MessageBox.Show("Invalid brandname! Please enter a valid name:");
                    return; // Stop execution if the name is invalid
                }
                string size = textBox6.Text;
                while (!ProductDL.IsValidsize(size))
                {
                    MessageBox.Show("Invalid size! Please enter a valid size:");
                    return; // Stop execution if the name is invalid
                }
                string price = textBox3.Text;
                while (!ProductDL.IsValidprice(price))
                {
                    MessageBox.Show("Invalid pricr! Please enter a valid price:");
                    return; // Stop execution if the name is invalid
                }
                string color = textBox4.Text;
                while (!ProductDL.isvalidcolor(color))
                {
                    MessageBox.Show("Invalid color! Please enter a valid color:");
                    return; // Stop execution if the name is invalid
                }

                string quantity = textBox5.Text;
                while (!ProductDL.IsValidquantity(quantity))
                {
                    MessageBox.Show("Invalid quantity! Please enter a valid quantity:");
                    return; // Stop execution if the name is invalid
                }
                string path = "baby.txt";
                Product u = new Product(username, brandname, quantity, color, size, price);
                ProductDL.storeDataInListbaby(u);
                ProductDL.storeProductDataInFilebaby(u);

                MessageBox.Show("Stored in file");

                // Make sure 'table' is properly initialized and accessible
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
            textBox4.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            textBox6.Text = row.Cells[4].Value.ToString();
            textBox5.Text = row.Cells[5].Value.ToString();
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
                        ProductDL.baby.RemoveAt(index);
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

        private void button17_Click(object sender, EventArgs e)
        {
            string filePath = "baby.txt"; // Replace with your actual file path
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
           /* Form f = new feedbackloadcs();
            f.Show();*/
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form f = new baby();
            f.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
          /*  Form f = new ProductWomen();
            f.Show();*/
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form f = new Productform();
            f.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form f = new Productform();
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
          /*  Form f = new ProductWomen();
            f.Show();*/
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form f = new baby();
            f.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

           /* Form f = new feedbackloadcs();
            f.Show();*/
        }
    }
}
