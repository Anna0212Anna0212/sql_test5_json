using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace sql_test5
{
    public partial class Form1 : Form
    {
        Database1Entities db = new Database1Entities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
                string JsonString = File.ReadAllText("COD03_景點清單附檔模擬.json");
                List<test5> JsonData = JsonSerializer.Deserialize<List<test5>>(JsonString);

                int ID = 0;
                foreach (test5 Table in JsonData)
                {
                    Table.Id = ID++;
                    db.test5.Add(Table);
                }
                db.SaveChanges();

                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("about");
                dt.Columns.Add("address");
                dt.Columns.Add("traffic");
                dt.Columns.Add("time");

                foreach (var table in db.test5)
                {
                    dt.Rows.Add(table.name, table.about, table.address, table.traffic, table.time);
                }
                // 將 DataTable 設定為 DataGridView 的資料來源
                dataGridView1.DataSource = dt;
            
        }
    }
}
