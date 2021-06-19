using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AgregarInventarioJPG
{
	public class frmInfoComputadora : Form
	{
		public static string idAVAlt;

		private Globales gbls = new Globales();

		private IContainer components = null;

		private ComboBox cmbListaSucCtes;

		private Label lblSucuersalCte;

		private Label lblCte;

		private TextBox txtCteSeleccionado;

		private Label lblSO;

		private Label lblHost;

		private Label lblMAC;

		private Label lblHD;

		private Label lblFabricante;

		private Label lblOffice;

		private Label lblCPU;

		private Label lblRAM;

		private Label lblObservaciones;

		private Label lblAntivirus;

		private Label lblFechaRegistro;

		private TextBox txtSO;

		private TextBox txtHost;

		private TextBox txtMAC;

		private TextBox txtHD;

		private TextBox txtCPU;

		private TextBox txtRAM;

		private TextBox txtFabricante;

		private TextBox txtObservaciones;

		private ComboBox cmbAV;

		private DateTimePicker dtpFechaRegistro;
        private ComboBox cmbListaOffice;
        private Button btnConsultaCompu;

		static frmInfoComputadora()
		{
			frmInfoComputadora.idAVAlt = "";
		}

		public frmInfoComputadora()
		{
			this.InitializeComponent();
		}

		private void btnConsultaCompu_Click(object sender, EventArgs e)
		{
			conectaBD _conectaBD = new conectaBD();
            _conectaBD.registrarCompu2(frmSelCte.idCteSel, this.txtSO.Text, this.txtHost.Text, this.txtMAC.Text, this.txtHD.Text, this.txtCPU.Text, this.txtRAM.Text, this.txtFabricante.Text, this.txtObservaciones.Text, this.dtpFechaRegistro.Text, this.cmbListaSucCtes.SelectedValue.ToString(), this.cmbListaOffice.SelectedValue.ToString(), this.cmbAV.SelectedValue.ToString());
            _conectaBD.CloseConnection();
			base.Close();
		}

		private void btnRegistrarEquipo_Click(object sender, EventArgs e)
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

		private void dtpFechaRegistro_ValueChanged(object sender, EventArgs e)
		{
		}

		private void frmInfoComputadora_Load(object sender, EventArgs e)
		{
			this.dtpFechaRegistro.Format = DateTimePickerFormat.Custom;
			this.dtpFechaRegistro.CustomFormat = "yyyy-MM-dd";
			this.txtCteSeleccionado.Text = frmSelCte.nomCteSel;
			conectaBD _conectaBD = new conectaBD();

			string[,] arListaSucCtes = _conectaBD.listaSucCtes(frmSelCte.idCteSel);
            BindingList<Globales> gListaSucCtes = new BindingList<Globales>();
			for (int i = 0; i < arListaSucCtes.Length / 2; i++)
			{
                gListaSucCtes.Add(new Globales()
				{
					idSucursalCte = arListaSucCtes[i, 0],
					nombreSucCte = arListaSucCtes[i, 1]
				});
			}
			this.cmbListaSucCtes.DataSource = gListaSucCtes;
			this.cmbListaSucCtes.DisplayMember = "nombreSucCte";
			this.cmbListaSucCtes.ValueMember = "idSucursalCte";
			_conectaBD.CloseConnection();

            string[,] arListaAV = _conectaBD.listaAV();
            BindingList<Globales> gListaAV = new BindingList<Globales>();
            for (int i = 0; i < arListaAV.Length / 2; i++)
            {
                gListaAV.Add(new Globales()
                {
                    idLicAV = arListaAV[i, 0],
                    descripcionAV = arListaAV[i, 1]
                });
            }
            this.cmbAV.DataSource = gListaAV;
            this.cmbAV.DisplayMember = "descripcionAV";
            this.cmbAV.ValueMember = "idLicAV";
            _conectaBD.CloseConnection();

            string[,] arListaOffice = _conectaBD.listaOffice();
            BindingList<Globales> gListaOffice = new BindingList<Globales>();
            for (int i = 0; i < arListaOffice.Length / 2; i++)
            {
                gListaOffice.Add(new Globales()
                {
                    idLicOffice = arListaOffice[i, 0],
                    descripcionOffice = arListaOffice[i, 1]
                });
            }
            this.cmbListaOffice.DataSource = gListaOffice;
            this.cmbListaOffice.DisplayMember = "descripcionOffice";
            this.cmbListaOffice.ValueMember = "idLicOffice";
            _conectaBD.CloseConnection();

            hardwareInfo _hardwareInfo = new hardwareInfo();
			this.txtSO.Text = _hardwareInfo.GetOSInformation();
			this.txtHD.Text = _hardwareInfo.GetHDDSerialNo();
			this.txtMAC.Text = _hardwareInfo.GetMACAddress();
			this.txtHost.Text = _hardwareInfo.GetComputerName();
			this.txtRAM.Text = _hardwareInfo.GetPhysicalMemory();
			// this.txtOffice.Text = _hardwareInfo.GetOfficeVersion();
			this.txtFabricante.Text = _hardwareInfo.GetCSProduct();
			this.txtCPU.Text = _hardwareInfo.GetCPUManufacturer();
            /* string[,] strArrays1 = _hardwareInfo.AntivirusInstalled();
			for (int j = 0; j < strArrays1.Length / 3; j++)
			{
				this.cmbAV.Items.Add(strArrays1[j, 0]);
			} */
        }

        private void InitializeComponent()
		{
            this.cmbListaSucCtes = new System.Windows.Forms.ComboBox();
            this.lblSucuersalCte = new System.Windows.Forms.Label();
            this.lblCte = new System.Windows.Forms.Label();
            this.txtCteSeleccionado = new System.Windows.Forms.TextBox();
            this.lblSO = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblMAC = new System.Windows.Forms.Label();
            this.lblHD = new System.Windows.Forms.Label();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.lblOffice = new System.Windows.Forms.Label();
            this.lblCPU = new System.Windows.Forms.Label();
            this.lblRAM = new System.Windows.Forms.Label();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.lblAntivirus = new System.Windows.Forms.Label();
            this.lblFechaRegistro = new System.Windows.Forms.Label();
            this.txtSO = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtMAC = new System.Windows.Forms.TextBox();
            this.txtHD = new System.Windows.Forms.TextBox();
            this.txtCPU = new System.Windows.Forms.TextBox();
            this.txtRAM = new System.Windows.Forms.TextBox();
            this.txtFabricante = new System.Windows.Forms.TextBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.cmbAV = new System.Windows.Forms.ComboBox();
            this.dtpFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.btnConsultaCompu = new System.Windows.Forms.Button();
            this.cmbListaOffice = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbListaSucCtes
            // 
            this.cmbListaSucCtes.FormattingEnabled = true;
            this.cmbListaSucCtes.Location = new System.Drawing.Point(106, 38);
            this.cmbListaSucCtes.Name = "cmbListaSucCtes";
            this.cmbListaSucCtes.Size = new System.Drawing.Size(397, 21);
            this.cmbListaSucCtes.TabIndex = 1;
            // 
            // lblSucuersalCte
            // 
            this.lblSucuersalCte.AutoSize = true;
            this.lblSucuersalCte.Location = new System.Drawing.Point(25, 46);
            this.lblSucuersalCte.Name = "lblSucuersalCte";
            this.lblSucuersalCte.Size = new System.Drawing.Size(48, 13);
            this.lblSucuersalCte.TabIndex = 2;
            this.lblSucuersalCte.Text = "Sucursal";
            // 
            // lblCte
            // 
            this.lblCte.AutoSize = true;
            this.lblCte.Location = new System.Drawing.Point(25, 17);
            this.lblCte.Name = "lblCte";
            this.lblCte.Size = new System.Drawing.Size(39, 13);
            this.lblCte.TabIndex = 3;
            this.lblCte.Text = "Cliente";
            this.lblCte.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCteSeleccionado
            // 
            this.txtCteSeleccionado.Location = new System.Drawing.Point(106, 13);
            this.txtCteSeleccionado.Name = "txtCteSeleccionado";
            this.txtCteSeleccionado.ReadOnly = true;
            this.txtCteSeleccionado.Size = new System.Drawing.Size(397, 20);
            this.txtCteSeleccionado.TabIndex = 4;
            // 
            // lblSO
            // 
            this.lblSO.AutoSize = true;
            this.lblSO.Location = new System.Drawing.Point(25, 76);
            this.lblSO.Name = "lblSO";
            this.lblSO.Size = new System.Drawing.Size(22, 13);
            this.lblSO.TabIndex = 6;
            this.lblSO.Text = "SO";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(25, 105);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(29, 13);
            this.lblHost.TabIndex = 5;
            this.lblHost.Text = "Host";
            // 
            // lblMAC
            // 
            this.lblMAC.AutoSize = true;
            this.lblMAC.Location = new System.Drawing.Point(25, 137);
            this.lblMAC.Name = "lblMAC";
            this.lblMAC.Size = new System.Drawing.Size(30, 13);
            this.lblMAC.TabIndex = 8;
            this.lblMAC.Text = "MAC";
            // 
            // lblHD
            // 
            this.lblHD.AutoSize = true;
            this.lblHD.Location = new System.Drawing.Point(25, 166);
            this.lblHD.Name = "lblHD";
            this.lblHD.Size = new System.Drawing.Size(23, 13);
            this.lblHD.TabIndex = 7;
            this.lblHD.Text = "HD";
            // 
            // lblFabricante
            // 
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Location = new System.Drawing.Point(25, 256);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(57, 13);
            this.lblFabricante.TabIndex = 12;
            this.lblFabricante.Text = "Fabricante";
            // 
            // lblOffice
            // 
            this.lblOffice.AutoSize = true;
            this.lblOffice.Location = new System.Drawing.Point(25, 285);
            this.lblOffice.Name = "lblOffice";
            this.lblOffice.Size = new System.Drawing.Size(35, 13);
            this.lblOffice.TabIndex = 11;
            this.lblOffice.Text = "Office";
            this.lblOffice.Click += new System.EventHandler(this.lblOffice_Click);
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Location = new System.Drawing.Point(25, 195);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(29, 13);
            this.lblCPU.TabIndex = 10;
            this.lblCPU.Text = "CPU";
            // 
            // lblRAM
            // 
            this.lblRAM.AutoSize = true;
            this.lblRAM.Location = new System.Drawing.Point(25, 224);
            this.lblRAM.Name = "lblRAM";
            this.lblRAM.Size = new System.Drawing.Size(31, 13);
            this.lblRAM.TabIndex = 9;
            this.lblRAM.Text = "RAM";
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(25, 373);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(78, 13);
            this.lblObservaciones.TabIndex = 15;
            this.lblObservaciones.Text = "Observaciones";
            // 
            // lblAntivirus
            // 
            this.lblAntivirus.AutoSize = true;
            this.lblAntivirus.Location = new System.Drawing.Point(25, 312);
            this.lblAntivirus.Name = "lblAntivirus";
            this.lblAntivirus.Size = new System.Drawing.Size(47, 13);
            this.lblAntivirus.TabIndex = 14;
            this.lblAntivirus.Text = "Antivirus";
            // 
            // lblFechaRegistro
            // 
            this.lblFechaRegistro.AutoSize = true;
            this.lblFechaRegistro.Location = new System.Drawing.Point(25, 341);
            this.lblFechaRegistro.Name = "lblFechaRegistro";
            this.lblFechaRegistro.Size = new System.Drawing.Size(74, 13);
            this.lblFechaRegistro.TabIndex = 13;
            this.lblFechaRegistro.Text = "Fecha registro";
            // 
            // txtSO
            // 
            this.txtSO.Location = new System.Drawing.Point(106, 69);
            this.txtSO.Name = "txtSO";
            this.txtSO.ReadOnly = true;
            this.txtSO.Size = new System.Drawing.Size(397, 20);
            this.txtSO.TabIndex = 17;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(106, 98);
            this.txtHost.Name = "txtHost";
            this.txtHost.ReadOnly = true;
            this.txtHost.Size = new System.Drawing.Size(397, 20);
            this.txtHost.TabIndex = 18;
            // 
            // txtMAC
            // 
            this.txtMAC.Location = new System.Drawing.Point(106, 130);
            this.txtMAC.Name = "txtMAC";
            this.txtMAC.ReadOnly = true;
            this.txtMAC.Size = new System.Drawing.Size(397, 20);
            this.txtMAC.TabIndex = 19;
            // 
            // txtHD
            // 
            this.txtHD.Location = new System.Drawing.Point(106, 159);
            this.txtHD.Name = "txtHD";
            this.txtHD.ReadOnly = true;
            this.txtHD.Size = new System.Drawing.Size(397, 20);
            this.txtHD.TabIndex = 20;
            // 
            // txtCPU
            // 
            this.txtCPU.Location = new System.Drawing.Point(106, 188);
            this.txtCPU.Name = "txtCPU";
            this.txtCPU.ReadOnly = true;
            this.txtCPU.Size = new System.Drawing.Size(397, 20);
            this.txtCPU.TabIndex = 21;
            // 
            // txtRAM
            // 
            this.txtRAM.Location = new System.Drawing.Point(106, 217);
            this.txtRAM.Name = "txtRAM";
            this.txtRAM.ReadOnly = true;
            this.txtRAM.Size = new System.Drawing.Size(397, 20);
            this.txtRAM.TabIndex = 22;
            // 
            // txtFabricante
            // 
            this.txtFabricante.Location = new System.Drawing.Point(106, 249);
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.ReadOnly = true;
            this.txtFabricante.Size = new System.Drawing.Size(397, 20);
            this.txtFabricante.TabIndex = 23;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(106, 366);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(397, 61);
            this.txtObservaciones.TabIndex = 26;
            // 
            // cmbAV
            // 
            this.cmbAV.FormattingEnabled = true;
            this.cmbAV.Location = new System.Drawing.Point(106, 304);
            this.cmbAV.Name = "cmbAV";
            this.cmbAV.Size = new System.Drawing.Size(397, 21);
            this.cmbAV.TabIndex = 27;
            this.cmbAV.SelectedIndexChanged += new System.EventHandler(this.cmbAV_SelectedIndexChanged);
            // 
            // dtpFechaRegistro
            // 
            this.dtpFechaRegistro.Enabled = false;
            this.dtpFechaRegistro.Location = new System.Drawing.Point(106, 335);
            this.dtpFechaRegistro.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dtpFechaRegistro.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpFechaRegistro.Name = "dtpFechaRegistro";
            this.dtpFechaRegistro.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaRegistro.TabIndex = 28;
            this.dtpFechaRegistro.Value = new System.DateTime(2019, 7, 13, 0, 0, 0, 0);
            this.dtpFechaRegistro.ValueChanged += new System.EventHandler(this.dtpFechaRegistro_ValueChanged);
            // 
            // btnConsultaCompu
            // 
            this.btnConsultaCompu.Location = new System.Drawing.Point(250, 438);
            this.btnConsultaCompu.Name = "btnConsultaCompu";
            this.btnConsultaCompu.Size = new System.Drawing.Size(75, 23);
            this.btnConsultaCompu.TabIndex = 31;
            this.btnConsultaCompu.Text = "Registrar";
            this.btnConsultaCompu.UseVisualStyleBackColor = true;
            this.btnConsultaCompu.Click += new System.EventHandler(this.btnConsultaCompu_Click);
            // 
            // cmbListaOffice
            // 
            this.cmbListaOffice.FormattingEnabled = true;
            this.cmbListaOffice.Location = new System.Drawing.Point(106, 277);
            this.cmbListaOffice.Name = "cmbListaOffice";
            this.cmbListaOffice.Size = new System.Drawing.Size(397, 21);
            this.cmbListaOffice.TabIndex = 32;
            // 
            // frmInfoComputadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 473);
            this.Controls.Add(this.cmbListaOffice);
            this.Controls.Add(this.btnConsultaCompu);
            this.Controls.Add(this.dtpFechaRegistro);
            this.Controls.Add(this.cmbAV);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.txtFabricante);
            this.Controls.Add(this.txtRAM);
            this.Controls.Add(this.txtCPU);
            this.Controls.Add(this.txtHD);
            this.Controls.Add(this.txtMAC);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.txtSO);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.lblAntivirus);
            this.Controls.Add(this.lblFechaRegistro);
            this.Controls.Add(this.lblFabricante);
            this.Controls.Add(this.lblOffice);
            this.Controls.Add(this.lblCPU);
            this.Controls.Add(this.lblRAM);
            this.Controls.Add(this.lblMAC);
            this.Controls.Add(this.lblHD);
            this.Controls.Add(this.lblSO);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.txtCteSeleccionado);
            this.Controls.Add(this.lblCte);
            this.Controls.Add(this.lblSucuersalCte);
            this.Controls.Add(this.cmbListaSucCtes);
            this.Name = "frmInfoComputadora";
            this.Text = "Datos del registro";
            this.Load += new System.EventHandler(this.frmInfoComputadora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

        private void cmbAV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblOffice_Click(object sender, EventArgs e)
        {

        }
    }
}