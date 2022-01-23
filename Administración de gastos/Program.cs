using Administración_de_gastos.Forms.Inicio_Programa;
using ConexionDB;
using System;
using System.Collections.Generic;
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
			Conexion.conexion.Open();
			FormSplashScreen start = new FormSplashScreen();
			Application.Run(start);
			if (start.todoOK) {
				Application.Run(new FormLogin());
			}

			// End of program
			Conexion.conexion.Close();
		}
	}
}