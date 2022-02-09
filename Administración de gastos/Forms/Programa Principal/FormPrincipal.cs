using Administración_de_gastos.Clases.Log;
using Administración_de_gastos.Forms.Programa_Principal.Personal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Usuario.Clases;

namespace Administración_de_gastos.Forms.Programa_Principal {

	public partial class FormPrincipal : Form {

		#region Propiedades

		private CLogForms log;
		private CUsuario usuarioLogin;

		#endregion Propiedades

		#region Formulario

		public FormPrincipal(CUsuario user) {
			InitializeComponent();
			usuarioLogin = user;
		}

		private void FormPrincipal_Load(object sender, EventArgs e) {
			CargarInfoStatus();
			log = new CLogForms(this);
		}

		#endregion Formulario

		#region Privadas

		#region Status

		private void CargarInfoStatus() {
			toolStripStatusUsuario.Text = usuarioLogin.NombreCompleto;
		}

		#endregion Status

		#endregion Privadas

		#region Personal

		private void gestiónDeTarjetasBancariasToolStripMenuItem_Click(object sender, EventArgs e) {
			//new FormGestionTarjetas() { MdiParent = this }.Show();
			log.Open(new FormGestionTarjetas());
		}

		#endregion Personal
	}
}