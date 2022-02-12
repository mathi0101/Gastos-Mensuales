using ConexionDB;
using ConexionDB.Database;
using Login.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.Forms {

	public partial class FormSplashScreen : Form {

		#region Propiedades

		private int contador = 0;
		public bool connectionReady = false;

		#endregion Propiedades

		#region Formulario

		public FormSplashScreen() {
			InitializeComponent();
		}

		private void FormSplashScreen_Load(object sender, EventArgs e) {
			timer.Start();
			label.Text = "Iniciando...";
		}

		#endregion Formulario

		#region Tick

		private void timer1_Tick(object sender, EventArgs e) {
			panelslide.Left += 2;

			if (panelslide.Left > 315) {
				panelslide.Left = -35;
			}

			contador += contador >= 0 ? 5 : 0;
			if (contador > 200) {
				label.Text = "Leyendo configuración del programa...";
			}
			if (contador > 300) {
				label.Text = "Cargando aplicación...";
			}
			if (contador > 500) {
				if (Database.Existe()) {
					connectionReady = Database.TryConectar();
					label.Text = "Cargando Base de Datos...";
				} else {
					connectionReady = Database.CrearBase();
					label.Text = "Creando la Base de Datos...";
				}
			}
			if (contador > 600) {
				this.Dispose();
			}
		}

		#endregion Tick
	}
}