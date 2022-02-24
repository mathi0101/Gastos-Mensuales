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
using ConexionDB.Database;
using Usuario.Encrypt;
using System.Configuration;

namespace Login.Forms {

	public partial class FormLogin : Form {

		#region Constantes

		private const int MIN_LARGO_PASSWORD = 1;

		#endregion Constantes

		#region Propiedades

		public CUsuario UsuarioLogueado = null;

		#endregion Propiedades

		#region Formulario

		public FormLogin() {
			InitializeComponent();
		}

		private void FormLogin_Load(object sender, EventArgs e) {
			//CargarUsuariosRegistrados();

			FormSplashScreen form = new FormSplashScreen();
			form.ShowDialog();
			if (!form.connectionOK) {
				MessageBox.Show("No se ha podido conectar a la base de datos.\nAvisale al creador del programa de este error!", "Error al iniciar aplicación!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Dispose();
			} else {
				CargarUsuariosRegistrados();
			}
			this.Cursor = Cursors.Default;
		}

		private void FormLogin_FormClosing(object sender, FormClosingEventArgs e) {
		}

		#endregion Formulario

		#region Eventos

		#region Click

		private void btnLogin_Click(object sender, EventArgs e) {
			if (CondicionesLogin()) {
				Login();
			}
		}

		private void btnRegister_Click(object sender, EventArgs e) {
			FormRegister form = new FormRegister();
			form.ShowDialog();
			LimpiarCampos();
		}

		#endregion Click

		#region KeyPress

		private void txtUser_KeyPress(object sender, KeyPressEventArgs e) {
			if (!char.IsControl(e.KeyChar)
			   & !char.IsDigit(e.KeyChar) & !char.IsLetter(e.KeyChar)
			   & e.KeyChar != '-' & e.KeyChar != '_' & e.KeyChar != '!'
			   & e.KeyChar != '¡' & e.KeyChar != '?') {
				e.Handled = true;
				return;
			}
			e.Handled = false;
			return;
		}

		private void txtPassword_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == (char)13) {
				e.Handled = true;
				btnLogin_Click(null, null);
			}
			if (!char.IsControl(e.KeyChar)
			   & !char.IsDigit(e.KeyChar) & !char.IsLetter(e.KeyChar)
			   & e.KeyChar != '-' & e.KeyChar != '_' & e.KeyChar != '!'
			   & e.KeyChar != '¡' & e.KeyChar != '?') {
				e.Handled = true;
				return;
			}
			e.Handled = false;
			return;
		}

		#endregion KeyPress

		#endregion Eventos

		#region Privadas

		private void CargarUsuariosRegistrados() {
			List<CUsuario> users = new LUsuario().RecuperarTodos();
			AutoCompleteStringCollection data = new AutoCompleteStringCollection();
			data.AddRange(users.Select(u => u.User).ToArray());
			txtUser.AutoCompleteCustomSource = data;

			if (users.Count > 0) {
				CUsuario lastUser = users[0];
				foreach (var user in users) {
					if (user.UltimoLogin > lastUser.UltimoLogin) {
						lastUser = user;
					}
				}
				txtUser.Text = lastUser.User;
				txtPassword.Select();
			}
		}

		private void LimpiarCampos() {
			txtUser.Text = "";
			txtPassword.Text = "";
		}

		private bool CondicionesLogin() {
			bool salida = true;
			if (txtPassword.Text == "" && txtUser.Text == "") {
				return false;
			}
			if (txtUser.Text.Length < 3) {
				MessageBox.Show("Tu nombre de usuario debe contener al menos 3 caracteres.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtPassword.Focus();
				salida = false;
			}
			if (txtPassword.Text.Length < MIN_LARGO_PASSWORD) {
				MessageBox.Show($"Tu contraseña debe contener al menos {MIN_LARGO_PASSWORD} caracteres.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtPassword.Focus();
				salida = false;
			}
			return salida;
		}

		private void Login() {
			CUsuario user = new CUsuario() {
				User = txtUser.Text,
				Password = Encriptacion.Encriptar(txtPassword.Text)
			};
			if (user.Existe()) {
				if (user.IniciaSesion()) {
					//MessageBox.Show("Has iniciado sesión correctamente!\nBienvenido", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
					user.ModificarUltimoLogin(DateTime.Now);
					user.Recuperar();
					UsuarioLogueado = user;
					this.Dispose();
				} else {
					MessageBox.Show("Contraseña Incorrecta", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtPassword.Focus();
				}
			} else {
				MessageBox.Show("Este usuario no existe\nCrea tu usuario con el botón Registrar!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				btnRegister.Focus();
			}
		}

		#endregion Privadas
	}
}