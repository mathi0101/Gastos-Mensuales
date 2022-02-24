
namespace Login.Forms {
	partial class FormSplashScreen {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panelslide = new System.Windows.Forms.Panel();
			this.timerLoadingBar = new System.Windows.Forms.Timer(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.label = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.CadetBlue;
			this.panel1.Controls.Add(this.panelslide);
			this.panel1.Location = new System.Drawing.Point(54, 160);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(337, 14);
			this.panel1.TabIndex = 1;
			this.panel1.UseWaitCursor = true;
			// 
			// panelslide
			// 
			this.panelslide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.panelslide.Location = new System.Drawing.Point(263, 0);
			this.panelslide.Name = "panelslide";
			this.panelslide.Size = new System.Drawing.Size(74, 14);
			this.panelslide.TabIndex = 1;
			this.panelslide.UseWaitCursor = true;
			// 
			// timerLoadingBar
			// 
			this.timerLoadingBar.Interval = 10;
			this.timerLoadingBar.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(154)))), ((int)(((byte)(252)))));
			this.panel2.Controls.Add(this.label);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(450, 235);
			this.panel2.TabIndex = 3;
			this.panel2.UseWaitCursor = true;
			// 
			// label
			// 
			this.label.BackColor = System.Drawing.Color.Transparent;
			this.label.Location = new System.Drawing.Point(54, 177);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(337, 14);
			this.label.TabIndex = 2;
			this.label.Text = "progreso";
			this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label.UseWaitCursor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label3.Font = new System.Drawing.Font("NSimSun", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(50, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(348, 64);
			this.label3.TabIndex = 0;
			this.label3.Text = "Mis Gastos";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label3.UseWaitCursor = true;
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// FormSplashScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(450, 235);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSplashScreen";
			this.Opacity = 0.75D;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormCargar";
			this.UseWaitCursor = true;
			this.Load += new System.EventHandler(this.FormSplashScreen_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panelslide;
		private System.Windows.Forms.Timer timerLoadingBar;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.Label label3;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}