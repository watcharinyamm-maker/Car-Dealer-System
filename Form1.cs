using System;
using System.Data;
using System.Data.SQLite; // ต้องติดตั้ง NuGet: System.Data.SQLite
using System.Windows.Forms;
using WinFormsApp6.Database; // เรียกใช้ DbHelper จาก Namespace ของคุณ

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        // ตัวแปรเก็บ ID รถที่ถูกเลือก
        private int currentCarID = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelper.InitializeDatabase(); // สร้าง Database
                LoadData(); // ดึงข้อมูลมาโชว์
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Database: " + ex.Message);
            }
        }

        // ฟังก์ชันดึงข้อมูล
        private void LoadData()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Cars";
                using (var da = new SQLiteDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // *** ต้องแน่ใจว่าตั้งชื่อตารางในหน้า Design ว่า dataGridView1 ***
                    if (dataGridView1 != null) dataGridView1.DataSource = dt;
                }
            }
        }

        // เมื่อคลิกตาราง
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                currentCarID = Convert.ToInt32(row.Cells["CarID"].Value);

                // แก้ชื่อตัวแปรให้ตรงกับหน้า Design ของคุณ
                // สมมติว่าคุณใช้ textBox1, textBox2 ฯลฯ
                // txtID.Text = row.Cells["CarID"].Value.ToString(); 
                // txtName.Text = row.Cells["ModelName"].Value.ToString();
            }
        }

        // ปุ่มขาย
        private void btnSell_Click(object sender, EventArgs e)
        {
            // ใส่ Logic ขายตรงนี้
            MessageBox.Show("กดปุ่มขายแล้ว!");
        }

        // ปุ่มเพิ่มสินค้า
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ใส่ Logic เพิ่มสินค้าตรงนี้
        }
    }
}