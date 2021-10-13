using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DonguriLib
{
    public class DonguriLib
    {

        public void CreateDatabase()
        {
            SQLiteConnection.CreateFile(Properties.Settings.Default.DataFile);
        }

        public void CreateTable(string connectString, string tableName, string fieldList, string primaryKeyList)
        {
            var primary = (primaryKeyList == "") ? "" : (",primary key (" + primaryKeyList + ")");
            var sql = string.Format("create table {0}({1} {2})", tableName, fieldList, primary);

            ExecuteNoneQuery(connectString, sql);
        }

        public class User
        {
            public User() { }

            [AutoIncrement, PrimaryKey]
            public int Id { get; set; } // 主キー

            public string Name { get; set; } // 名前

            public int Age { get; set; } // 年齢
        }
        
            if (!File.Exists(Properties.Settings.Default.DataFile))
            {
                SQLiteConnection.CreateFile(Properties.Settings.Default.DataFile);

                // データベースへ接続
                using (var connection = new SQLiteConnection(@"C:\test\SQLiteTest.db"))
                {
                    // テーブルの作成
                    connection.CreateTable<User>();
                }
}
}
