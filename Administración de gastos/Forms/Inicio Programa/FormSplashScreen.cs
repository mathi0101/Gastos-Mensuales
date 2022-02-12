using ConexionDB;
using ConexionDB.Database;
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

namespace Administración_de_gastos.Forms.Inicio_Programa {

	public partial class FormSplashScreen : Form {
		public bool todoOK;

		private int contador = -1;

		public FormSplashScreen() {
			InitializeComponent();
		}

		private void FormSplashScreen_Load(object sender, EventArgs e) {
			timer.Start();

			if (Database.Existe()) {
				label.Text = "Cargando Base de Datos...";
				if (Database.TryConectar()) {
					todoOK = true;
				} else {
					throw new Exception("No se ha podido conectar");
				}
			} else {
				if (Database.CrearBase()) {
					label.Text = "Creando la Base de Datos...";
					todoOK = true;
				} else {
					todoOK = false;
				}
			}
			contador = 0;
		}

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
				label.Text = "Abriendo...";
			}
			if (contador > 600) {
				this.Dispose();
			}
		}
	}
}