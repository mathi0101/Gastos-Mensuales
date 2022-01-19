using System;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pruebas {

	internal class Program {

		private static void Main(string[] args) {
			Console.WriteLine("Hello World");
			//Thread.Sleep(5000);

			SQLiteConnection.CreateFile("hola.db");

			using (SQLiteConnection conexion = new SQLiteConnection("Data Source=hola.db;Version=3;")) {
				conexion.Open();

				string sql = "create table highscores (name varchar(20), score int)";

				SQLiteCommand command = new SQLiteCommand(sql, conexion);
				int respuesta = command.ExecuteNonQuery();

				sql = "insert into highscores (name, score) values ('Me', 9001)";

				command = new SQLiteCommand(sql, conexion);
				command.ExecuteNonQuery();

				Console.WriteLine(respuesta);
			}

			Console.ReadLine();
		}
	}
}