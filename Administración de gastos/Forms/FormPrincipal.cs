﻿using Clases.Clases.Log;
using MisGastos.Forms.Gastos;
using MisGastos.Forms.Programa_Principal.Personal;
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

namespace MisGastos.Forms.Programa_Principal {

	public partial class FormPrincipal : Form {

		#region Propiedades

		private CLogForms log;
		private CUsuario usuarioLogin;

		#endregion Propiedades

		#region Formulario

		public FormPrincipal() {
			InitializeComponent();
		}

		public FormPrincipal(CUsuario user) : this() {
			CUsuario test = new CUsuario() {
				User = "testing",
				Nombre = "Testing",
			};
			usuarioLogin = user ?? test;
		}

		private void FormPrincipal_Load(object sender, EventArgs e) {
			CargarInfoStatus();
			log = new CLogForms(this);
		}

		private void timer1_Tick(object sender, EventArgs e) {
			toolStripStatusFechaHora.Text = DateTime.Now.ToString("f");
		}

		#endregion Formulario

		#region Privadas

		#region Status

		private void CargarInfoStatus() {
			toolStripStatusUsuario.Alignment = ToolStripItemAlignment.Left;
			toolStripStatusUsuario.Text = usuarioLogin.NombreCompleto;

			toolStripStatusFechaHora.Alignment = ToolStripItemAlignment.Right;
			toolStripStatusFechaHora.Text = DateTime.Now.ToString("f");
		}

		#endregion Status

		#endregion Privadas

		#region Personal

		private void gestiónDeTarjetasBancariasToolStripMenuItem_Click(object sender, EventArgs e) {
			//new FormGestionTarjetas() { MdiParent = this }.Show();
			log.Open(new FormGestionTarjetas());
		}

		#endregion Personal

		#region Gastos

		private void ingresosToolStripMenuItem1_Click(object sender, EventArgs e) {
			log.Open(new FormIngresoDeGastos());
		}

		#endregion Gastos
	}
}