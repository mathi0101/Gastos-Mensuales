using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MisGastos.Clases.Log {

	public class CLogForms {

		#region Propiedades

		private Form parent;

		#endregion Propiedades

		#region Constructor

		public CLogForms(Form formParent) {
			parent = formParent;
		}

		#endregion Constructor

		#region Públicas

		public void Open(Form form2open) {
			if (!isOpen(form2open)) {
				form2open.MdiParent = parent;
				form2open.Show();
			} else {
				MostrarArriba(form2open);
			}
		}

		private void MostrarArriba(Form form2open) {
			var f = Application.OpenForms[form2open.Name];
			f.Activate();
		}

		#endregion Públicas

		#region Privadas

		private bool isOpen(Form form) {
			return Application.OpenForms[form.Name] != null;
		}

		#endregion Privadas
	}
}