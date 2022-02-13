using Administración_de_gastos.Forms.Programa_Principal;
using ConexionDB.Database;
using Login.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administración_de_gastos {

	internal static class Program {

		/// <summary>
		/// Punto de entrada principal para la aplicación.
		/// </summary>
		[STAThread]
		private static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			//Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			//config.ConnectionStrings.ConnectionStrings.Remove("cadena");
			//config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("cadena", $"Data Source={Database.RutaReal};Version=3;"));
			//config.Save(ConfigurationSaveMode.Modified);
			//ConfigurationManager.RefreshSection("connectionStrings");

			FormLogin login = new FormLogin();
			Application.Run(login);
			if (login.UsuarioLogueado != null) {
				Application.Run(new FormPrincipal(null));
			}

			// End of program
			CDatabase.Cerrar();
		}
	}
}