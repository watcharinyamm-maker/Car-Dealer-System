using System.Data.SQLite;
using System.IO;

// *** สำคัญมาก: ต้องเป็น WinFormsApp6 ตามด้วย .Database ***
namespace WinFormsApp6.Database
{
    public static class DbHelper
    {
        // ชื่อไฟล์ Database
        public static string DbName = "CarShop.db";
        public static string ConnectionString = $"Data Source={DbName};Version=3;";

        public static void InitializeDatabase()
        {
            if (!File.Exists(DbName))
            {
                SQLiteConnection.CreateFile(DbName);
                using (var conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();
                    // สร้างตาราง
                    string sql = @"
                        CREATE TABLE IF NOT EXISTS Cars (
                            CarID INTEGER PRIMARY KEY AUTOINCREMENT,
                            ModelName TEXT,
                            Brand TEXT,
                            Price DECIMAL,
                            StockQty INTEGER DEFAULT 0
                        );";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
    }
}