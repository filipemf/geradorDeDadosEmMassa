using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System;

namespace MassaDeDados
{
    class Database
    {
        public SQLiteConnection conn;
        private static string conexao = "Data Source=banco.db";
        private static string nomebanco = "banco.db";

        public int id { get; set; }
        public string nome { get; set; }

        public Database()
        {
            /*
            conn = new SQLiteConnection("Data Source=database.slite3; URI=file: ../Databases/database.sqlite3; Version=3;");

            if (!File.Exists("../Database/database.sqlite3"))
            {
                SQLiteConnection.CreateFile("../Database/database.sqlite3");
                MessageBox.Show("Database file created.");
            }*/
            
           
 
        }

        public void OpenConnection()
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }

        public void CloseConnection()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }

    }
}
