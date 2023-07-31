using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace bb
{
    public partial class lodinload : Form
    {
        public lodinload()
        {
            InitializeComponent();
        }

        private void loginload(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = "user.txt"; // Replace with your actual file path
            List<string> lines = ReadTextFile(filePath);
            LoadDataIntoDataGridView(lines);

        }
        private void LoadDataIntoDataGridView(List<string> lines)
        {
            DataTable table = new DataTable();
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("password", typeof(string));
            table.Columns.Add("role", typeof(string));
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form f = new Seller();
            f.Show();
            // Hides the current form
            this.Hide();

        }
    }
}
