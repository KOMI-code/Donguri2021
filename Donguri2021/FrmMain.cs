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
using System.Data.SQLite;

namespace Donguri2021
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Properties.Settings.Default.DataFile))
            {
                CreateDatabase(); // データベースファイルが無ければ新規に作成する
            }
        }
        using SQLite;

namespace ConsoleApplication1
    {
        class Program
        {
            public class User
            {
                public User() { }

                [AutoIncrement, PrimaryKey]
                public int Id { get; set; } // 主キー

                public string Name { get; set; } // 名前

                public int Age { get; set; } // 年齢
            }

            public static void Main()
            {
                // データベースへ接続
                using (var connection = new SQLiteConnection(@"C:\test\SQLiteTest.db"))
                {
                    // テーブルの作成
                    connection.CreateTable<User>();
                }
            }
        }
    }
    private void CheckCreateDatabase()
        {
            if (!File.Exists(Properties.Settings.Default.DataFile))
            {
                SQLiteConnection.CreateFile(Properties.Settings.Default.DataFile);

                // データベースへ接続
                using (var connection = new SQLiteConnection(@"C:\test\SQLiteTest.db"))
                {
                    // テーブルの作成
                    connection.CreateTable<User>();
                }


            };

        }

    }
}
