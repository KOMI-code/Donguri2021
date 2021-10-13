using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

private string ConnectString { get; set; } = @"Data Source = D:\SQLiteTest.db";

namespace DbGen
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
            using (var connection = new SQLiteConnection(Properties.Settings.Default.DataFile))
            {
                // テーブルの作成
                connection.CreateTable<User>();
            }
        }
    }
}
