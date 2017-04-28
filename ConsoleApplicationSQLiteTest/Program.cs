using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ConsoleApplicationSQLiteTest {
  class Program {
    static void Main(string[] args) {

      SQLiteConnection.CreateFile("MyDatabase.sqlite");

      SQLiteConnection m_dbConnection;
      m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
      m_dbConnection.Open();

      //creato la tabella
      string sql = "CREATE TABLE highscores (name VARCHAR(20), score INT)";
      SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
      command.ExecuteNonQuery();

      //inserito dei dati
      string sqlinsert = "insert into highscores (name, score) values ('Me', 3000)";
      SQLiteCommand commandInsert = new SQLiteCommand(sqlinsert, m_dbConnection);
      commandInsert.ExecuteNonQuery();
      sqlinsert = "insert into highscores (name, score) values ('Myself', 6000)";
      commandInsert = new SQLiteCommand(sqlinsert, m_dbConnection);
      commandInsert.ExecuteNonQuery();
      sqlinsert = "insert into highscores (name, score) values ('And I', 9000)";
      commandInsert = new SQLiteCommand(sqlinsert, m_dbConnection);
      commandInsert.ExecuteNonQuery();


      //lettura dati
      string sqlselect = "select * from highscores order by score desc";
      SQLiteCommand commandSelect = new SQLiteCommand(sqlselect, m_dbConnection);
      SQLiteDataReader reader = commandSelect.ExecuteReader();
      while (reader.Read())
        Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
    }
  }
}
