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
using Usuario.Encrypt;

namespace Administración_de_gastos.Forms.Inicio_Sesion {

	public partial class FormRegister : Form {

		#region Propiedades

		private const int LARGO_CONTRASEÑA_MIN = 4;
		private const int LARGO_CONTRASEÑA_MAX = 8;

		#endregion Propiedades

		#region Formulario

		public FormRegister() {
			InitializeComponent();
		}

		private void FormRegister_Load(object sender, EventArgs e) {
			dtpBirth.MaxDate = DateTime.Now.AddYears(-18);
		}

		#endregion Formulario

		#region Eventos

		#region TextChanged

		private void tbUser_Validating(object sender, CancelEventArgs e) {
			if (CargarObj().Existe()) {
				MessageBox.Show("Este usuario ya se encuentra registrado.\nElige otro!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				e.Cancel = true;
			}
		}

		private void tbPass_TextChanged(object sender, EventArgs e) {
			if (tbPass.Text.Length == 0) {
				ContraseniasIguales();
				tbPass2.Text = "";
			}
		}

		private void tbPass2_Validating(object sender, CancelEventArgs e) {
		}

		private void tbPass2_TextChanged(object sender, EventArgs e) {
			if (tbPass2.Text.Length != 0) {
				if (tbPass.Text != tbPass2.Text) {
					ContraseniasDistintas();
				} else {
					ContraseniasIguales();
				}
			}
		}

		#endregion TextChanged

		#region Controles Usuario y Contraseña

		private void tbPass_KeyPress(object sender, KeyPressEventArgs e) {
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

		private void tbPass2_KeyPress(object sender, KeyPressEventArgs e) {
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

		private void tbUser_KeyPress(object sender, KeyPressEventArgs e) {
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

		#endregion Controles Usuario y Contraseña

		#region Click

		private void btnAceptar_Click(object sender, EventArgs e) {
			Register();
		}

		private void btnCancelar_Click(object sender, EventArgs e) {
			Dispose();
		}

		#endregion Click

		#endregion Eventos

		#region Privadas

		#region Cargar Objeto

		private CUsuario CargarObj() {
			CUsuario obj = new CUsuario();
			obj.User = tbUser.Text;
			obj.Password = tbPass.Text;
			obj.Nombre = tbName.Text.Replace(" ", "");
			obj.Apellido = tbLastName.Text.Replace(" ", "");
			obj.Nacimiento = dtpBirth.Value;
			obj.Mail = tbMail.Text.Replace(" ", "");

			return obj;
		}

		#endregion Cargar Objeto

		#region Contraseñas

		private void ContraseniasDistintas() {
			lblPass2.ForeColor = Color.Red;
			lblPass2.Font = new Font(lblPass.Font, FontStyle.Bold);
			//MessageBox.Show("Las Contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//lblPass2.Focus();
		}

		private void ContraseniasIguales() {
			lblPass2.ForeColor = Color.Black;
			lblPass2.Font = lblPass.Font;
		}

		private void ErrorContrasenia() {
			tbPass.Text = "";
			tbPass2.Text = "";
			tbPass.Focus();
		}

		#endregion Contraseñas

		#region Registrar

		private void Register() {
			CUsuario obj = CargarObj();

			if (obj.Existe()) {
				MessageBox.Show("Tu nombre de usuario ya se encuentra en uso!\nInicia sesión o elige otro usuario", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				tbUser.Focus();
				return;
			}
			if (CondicionesRegistrar()) {
				string contraEncriptada = Encriptacion.Encriptar(obj.Password);
				obj.Password = contraEncriptada;
				obj.FechaRegistro = DateTime.Now;
				if (obj.Agregar()) {
					MessageBox.Show("Tu cuenta ha sido añadida con éxito.\nYa puedes iniciar sesión con tu cuenta!", "Bienvenido!", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Dispose();
				} else {
					MessageBox.Show("No se ha podido agregar tu usuario a la base de datos.\nVerifica tus datos y vuelve a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private bool CondicionesRegistrar() {
			bool salida = true;
			if (tbUser.Text == "") {
				MessageBox.Show("Debes seleccionar un nombre de usuario para poder crear tu cuenta.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				tbUser.Focus();
				salida = false;
			}
			if (tbUser.Text.Length < 3) {
				MessageBox.Show("Tu nombre de usuario tiene que tener al menos 3 caracteres para poder crear tu cuenta.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				tbUser.Focus();
				salida = false;
			}
			if (tbPass.Text != tbPass2.Text) {
				MessageBox.Show($"Las contraseñas no coinciden", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ContraseniasDistintas();
				salida = false;
			}
			if (tbPass.Text.Length < LARGO_CONTRASEÑA_MIN) {
				MessageBox.Show($"Tu contraseña debe contener al menos {LARGO_CONTRASEÑA_MIN} caracteres.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ErrorContrasenia();
				salida = false;
			}
			if (tbPass.Text.Length > LARGO_CONTRASEÑA_MAX) {
				MessageBox.Show($"Tu contraseña debe contener como máximo {LARGO_CONTRASEÑA_MAX} caracteres.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				ErrorContrasenia();
				salida = false;
			}
			if (tbName.Text == "") {
				MessageBox.Show("Tu nombre no puede estar vacío.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				tbName.Focus();
				salida = false;
			}
			return salida;
		}

		#endregion Registrar

		#endregion Privadas
	}
}