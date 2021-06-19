using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AgregarInventarioJPG
{
	public class frmSelCte : Form
	{
		public static string idCteSel;

		public static string nomCteSel;

		private IContainer components = null;

		private ComboBox cmbListCtes;

		private Label lblSelCte;
        private TextBox txtUsr;
        private Label lblUsr;
        private Label lblPass;
        private TextBox txtPass;
        private Button btnSelCte;
        private Label lblAviso;
        conectaBD _conectaBD = new conectaBD();

        public frmSelCte()
		{
			this.InitializeComponent();
		}

		private void btnSelCte_Click(object sender, EventArgs e)
		{
			frmSelCte.idCteSel = this.cmbListCtes.SelectedValue.ToString();
			frmSelCte.nomCteSel = this.cmbListCtes.Text;
            if (_conectaBD.login(txtUsr.Text, txtPass.Text))
            {
                (new frmInfoComputadora()).Show();
            } else
            {
                MessageBox.Show("Error!. El usuario y/o la contraseña son incorrectos.");
            }
		}

		private void cmbListCtes_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void frmSelCte_Load(object sender, EventArgs e)
		{
			// conectaBD _conectaBD = new conectaBD();
			string[,] strArrays = _conectaBD.listaCtes();
			BindingList<Globales> globales = new BindingList<Globales>();
			for (int i = 0; i < strArrays.Length / 2; i++)
			{
				globales.Add(new Globales()
				{
					idCliente = strArrays[i, 0],
					nombreCte = strArrays[i, 1]
				});
			}
			this.cmbListCtes.DataSource = globales;
			this.cmbListCtes.DisplayMember = "nombreCte";
			this.cmbListCtes.ValueMember = "idCliente";
			_conectaBD.CloseConnection();
		}

		private void InitializeComponent()
		{
            this.cmbListCtes = new System.Windows.Forms.ComboBox();
            this.lblSelCte = new System.Windows.Forms.Label();
            this.btnSelCte = new System.Windows.Forms.Button();
            this.txtUsr = new System.Windows.Forms.TextBox();
            this.lblUsr = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblAviso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbListCtes
            // 
            this.cmbListCtes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbListCtes.FormattingEnabled = true;
            this.cmbListCtes.Location = new System.Drawing.Point(85, 35);
            this.cmbListCtes.Name = "cmbListCtes";
            this.cmbListCtes.Size = new System.Drawing.Size(345, 24);
            this.cmbListCtes.TabIndex = 0;
            this.cmbListCtes.SelectedIndexChanged += new System.EventHandler(this.cmbListCtes_SelectedIndexChanged);
            // 
            // lblSelCte
            // 
            this.lblSelCte.AutoSize = true;
            this.lblSelCte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelCte.Location = new System.Drawing.Point(8, 38);
            this.lblSelCte.Name = "lblSelCte";
            this.lblSelCte.Size = new System.Drawing.Size(55, 16);
            this.lblSelCte.TabIndex = 1;
            this.lblSelCte.Text = "Cliente: ";
            // 
            // btnSelCte
            // 
            this.btnSelCte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelCte.Location = new System.Drawing.Point(175, 154);
            this.btnSelCte.Name = "btnSelCte";
            this.btnSelCte.Size = new System.Drawing.Size(106, 31);
            this.btnSelCte.TabIndex = 2;
            this.btnSelCte.Text = "Aceptar";
            this.btnSelCte.UseVisualStyleBackColor = true;
            this.btnSelCte.Click += new System.EventHandler(this.btnSelCte_Click);
            // 
            // txtUsr
            // 
            this.txtUsr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtUsr.Location = new System.Drawing.Point(85, 67);
            this.txtUsr.Name = "txtUsr";
            this.txtUsr.Size = new System.Drawing.Size(345, 22);
            this.txtUsr.TabIndex = 3;
            // 
            // lblUsr
            // 
            this.lblUsr.AutoSize = true;
            this.lblUsr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsr.Location = new System.Drawing.Point(8, 70);
            this.lblUsr.Name = "lblUsr";
            this.lblUsr.Size = new System.Drawing.Size(61, 16);
            this.lblUsr.TabIndex = 5;
            this.lblUsr.Text = "Usuario: ";
            this.lblUsr.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(8, 101);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(71, 16);
            this.lblPass.TabIndex = 6;
            this.lblPass.Text = "Password:";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtPass.Location = new System.Drawing.Point(85, 98);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(345, 22);
            this.txtPass.TabIndex = 7;
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.Red;
            this.lblAviso.Location = new System.Drawing.Point(16, 123);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(410, 13);
            this.lblAviso.TabIndex = 8;
            this.lblAviso.Text = "UTILIZA LAS MISMAS CREDENCIALES DE LA PAGINA: nscco.com.mx";
            this.lblAviso.Click += new System.EventHandler(this.lblAviso_Click);
            // 
            // frmSelCte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 197);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUsr);
            this.Controls.Add(this.txtUsr);
            this.Controls.Add(this.btnSelCte);
            this.Controls.Add(this.lblSelCte);
            this.Controls.Add(this.cmbListCtes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSelCte";
            this.Text = "Selecciona el cliente";
            this.Load += new System.EventHandler(this.frmSelCte_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAviso_Click(object sender, EventArgs e)
        {

        }
    }
}