using Clases.Clases.Database;
using ConexionDB;
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
		public bool connectionOK = false;
		private bool sumar = true;

		#endregion Propiedades

		#region Formulario

		public FormSplashScreen() {
			InitializeComponent();
		}

		private void FormSplashScreen_Load(object sender, EventArgs e) {
			timerLoadingBar.Start();
			label.Text = "Iniciando...";
		}

		#endregion Formulario

		#region Tick

		private void timer1_Tick(object sender, EventArgs e) {
			panelslide.Left += 2;

			if (panelslide.Left > 315) {
				panelslide.Left = -35;
			}

			contador += sumar ? 5 : 0;
			if (contador == 300) {
				label.Text = "Leyendo configuración del programa...";
			} else if (contador == 500) {
				label.Text = "Cargando aplicación...";
			} else if (contador == 600) {
				if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
				sumar = false;
				contador = 605;
				if (CDatabase.Existe()) {
					label.Text = "Cargando Base de Datos...";
				} else {
					label.Text = "Creando la Base de Datos...";
				}
			} else if (contador == 605) {
				if (!backgroundWorker1.IsBusy) {
					sumar = true;
				}
			} else if (contador > 900) {
				this.Dispose();
			}
		}

		#endregion Tick

		#region Background Database connection

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
			//BackgroundWorker worker = sender as BackgroundWorker;
			bool ok = false;
			int seconds = 0;
			if (CDatabase.Existe()) {
				while (!ok && seconds <= 5) {
					ok = CDatabase.TryConectar();
					GC.Collect();
					GC.WaitForPendingFinalizers();
					if (!ok) Thread.Sleep(1000);
					seconds++;
				}
			} else {
				do {
					ok = CDatabase.CrearBase();
					if (!ok) Thread.Sleep(1000);
					seconds++;
				} while (!ok && seconds <= 5);
			}
			if (!ok) {
				e.Cancel = true;
			}
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (e.Cancelled == true) {
				connectionOK = false;
			} else if (e.Error != null) {
				connectionOK = false;
			} else {
				connectionOK = true;
			}
		}

		#endregion Background Database connection
	}
}