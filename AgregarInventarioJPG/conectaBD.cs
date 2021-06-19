using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace AgregarInventarioJPG
{
	internal class conectaBD
	{
		private MySqlConnection connection;

		private string server;

		private string database;

		private string uid;

		private string password;

		private MySqlCommand cmd = new MySqlCommand();

		private DataTable dt = new DataTable();

		private MySqlDataReader reader;

		public conectaBD()
		{
			this.Initialize();
		}

        public bool login (string usr, string pass)
        {
            if (!this.OpenConnection())
            {
                MessageBox.Show("Error: Connection fail!");
                return false;
            } else
            {
                string sql = "SELECT * FROM principalbd.usuarios WHERE usuario = '" + usr + "' AND password = '" + pass + "';";
                MySqlDataReader mySqlDataReader = (new MySqlCommand(sql, this.connection)).ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(mySqlDataReader);
                if (dataTable.Rows.Count > 0)
                {
                    this.CloseConnection();
                    return true;
                } else
                {
                    this.CloseConnection();
                    return false;
                }
                
            }
        }

        public void actualizaCompuInv(string idInventario, string SO, string Host, string HD, string CPU, string RAM, string Observaciones, string idSucCte)
        {
			string str = string.Concat(new string[] { "UPDATE inventarios SET SO = '", SO, "', Host = '", Host, "'" });
			str = string.Concat(new string[] { str, ", HD = '", HD, "', CPU = '", CPU, "', RAM = '", RAM, "'" });
            str = string.Concat(new string[] { str, ", Observaciones = '", Observaciones, "'" });
            str = string.Concat(new string[] { str, ", idsucursalcte = '", idSucCte, "'" });
            str = string.Concat(str, " WHERE idInventario = '", idInventario, "'");
            this.cmd.CommandText = str;
			this.cmd.Connection = this.connection;
			this.cmd.ExecuteNonQuery();
		}

		public bool CloseConnection()
		{
			bool flag;
			try
			{
				this.connection.Close();
				flag = true;
			}
			catch (MySqlException mySqlException)
			{
				MessageBox.Show(mySqlException.Message);
				flag = false;
			}
			return flag;
		}

		private void Initialize()
		{
			this.server = "alvwebmail.dyndns.org";
			this.database = "pagj690609hv7";
			this.uid = "nscluis";
			this.password = "Lgro1982";
			this.connection = new MySqlConnection(string.Concat(new string[] { "SERVER=", this.server, ";DATABASE=", this.database, ";UID=", this.uid, ";PASSWORD=", this.password, ";" }));
		}

		public string[,] listaCtes()
		{
			string[,] strArrays;
			if (!this.OpenConnection())
			{
				MessageBox.Show("Error: Connection fail!");
				strArrays = new string[0, 0];
			}
			else
			{
				MySqlDataReader mySqlDataReader = (new MySqlCommand("SELECT idCliente,nombre FROM clientes ORDER BY nombre", this.connection)).ExecuteReader();
				DataTable dataTable = new DataTable();
				dataTable.Load(mySqlDataReader);
				string[,] str = new string[dataTable.Rows.Count, 2];
				int num = 0;
				foreach (DataRow row in dataTable.Rows)
				{
					str[num, 0] = row["idCliente"].ToString();
					str[num, 1] = row["nombre"].ToString();
					num++;
				}
				strArrays = str;
			}
			return strArrays;
		}

        public string[,] listaAV()
        {
            string[,] strArrays;
            if (!this.OpenConnection())
            {
                MessageBox.Show("Error: Connection fail!");
                strArrays = new string[0, 0];
            } else
            {
                string str = string.Concat("SELECT idlicencia, CONCAT(tl.nombre, ': ', ls.nombre, ', Caduca: ', ls.fechaCaducidad, ', Cte: ', c.nombre) descripcion FROM licenciasDeSoftware ls JOIN tipoDeLicencia tl ON tl.idtipolicencia = ls.idtipolicencia LEFT JOIN clientes c ON c.idCliente = ls.idCliente WHERE ls.idtipolicencia = 1 ORDER BY idlicencia ASC");
                MySqlDataReader mySqlDataReader = (new MySqlCommand(str, this.connection)).ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(mySqlDataReader);
                string[,] str1 = new string[dataTable.Rows.Count, 2];
                int num = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    str1[num, 0] = row["idlicencia"].ToString();
                    str1[num, 1] = row["descripcion"].ToString();
                    num++;
                }
                strArrays = str1;
            }
            
            return strArrays;
        }

        public string[,] listaOffice()
        {
            string[,] strArrays;
            if (!this.OpenConnection())
            {
                MessageBox.Show("Error: Connection fail!");
                strArrays = new string[0, 0];
            }
            else
            {
                string str = string.Concat("SELECT idlicencia, CONCAT(tl.nombre, ': ', ls.nombre, ', Caduca: ', ls.fechaCaducidad, ', Cte: ', c.nombre) descripcion FROM licenciasDeSoftware ls JOIN tipoDeLicencia tl ON tl.idtipolicencia = ls.idtipolicencia LEFT JOIN clientes c ON c.idCliente = ls.idCliente WHERE ls.idtipolicencia = 3 ORDER BY idlicencia ASC");
                MySqlDataReader mySqlDataReader = (new MySqlCommand(str, this.connection)).ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(mySqlDataReader);
                string[,] str1 = new string[dataTable.Rows.Count, 2];
                int num = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    str1[num, 0] = row["idlicencia"].ToString();
                    str1[num, 1] = row["descripcion"].ToString();
                    num++;
                }
                strArrays = str1;
            }
            return strArrays;
        }

        public string[,] listaSucCtes(string idCte)
		{
			string[,] strArrays;
			if (!this.OpenConnection())
			{
				MessageBox.Show("Error: Connection fail!");
				strArrays = new string[0, 0];
			}
			else
			{
				string str = string.Concat("SELECT idSucursalCte,nombre FROM sucursalcte WHERE idcliente = '", idCte, "' ORDER BY nombre");
				MySqlDataReader mySqlDataReader = (new MySqlCommand(str, this.connection)).ExecuteReader();
				DataTable dataTable = new DataTable();
				dataTable.Load(mySqlDataReader);
				string[,] str1 = new string[dataTable.Rows.Count, 2];
				int num = 0;
				foreach (DataRow row in dataTable.Rows)
				{
					str1[num, 0] = row["idSucursalCte"].ToString();
					str1[num, 1] = row["nombre"].ToString();
					num++;
				}
				strArrays = str1;
			}
			return strArrays;
		}

		public bool OpenConnection()
		{
			bool flag;
			try
			{
				this.connection.Open();
				flag = true;
			}
			catch (MySqlException mySqlException)
			{
				int number = mySqlException.Number;
				if (number == 0)
				{
					MessageBox.Show("Cannot connect to server.  Contact administrator");
				}
				else if (number == 0x415)
				{
					MessageBox.Show("Invalid username/password, please try again");
				}
				flag = false;
			}
			return flag;
		}

        public string registrarCompu2(string idCte, string SO, string Host, string MAC, string HD, string CPU, string RAM, string Fabricante, string Observaciones, string fechaRegistro, string idSucCte, string idLicAV, string idLicOffice)
        {
			string str = "";
			string str1 = "";
            string idInsertado;
            string idTipoLicencia;
            int contador;

			if (this.OpenConnection())
			{
				string str2 = string.Concat("SELECT * FROM inventarios WHERE idcliente='", idCte, "'");
				str2 = string.Concat(new string[] { str2, " AND MAC = '", MAC, "'" });
				this.cmd.CommandText = str2;
				this.cmd.Connection = this.connection;
				this.reader = this.cmd.ExecuteReader();
				this.dt.Load(this.reader);
				int count = this.dt.Rows.Count;
				string str3 = "";
				if (count <= 0)
				{
                    string str4 = string.Concat("INSERT INTO inventarios (idCliente,idTipoDeDispositivo,SO,Host,MAC,HD,CPU,RAM,Fabricante,Observaciones,fecharegistro");
                    str4 = string.Concat(str4, ",activo,idsucursalcte)");
                    str4 = string.Concat(new string[] { str4, " VALUES('", idCte, "',1,'", SO, "','", Host, "','", MAC, "'" });
                    str4 = string.Concat(new string[] { str4, ",'", HD, "','", CPU, "','", RAM, "','", Fabricante, "'" });
                    str4 = string.Concat(new string[] { str4, ",'", Observaciones, "','", fechaRegistro, "'" });
                    str4 = string.Concat(new string[] { str4, ",1,'", idSucCte, "'); SELECT LAST_INSERT_ID();" });
					this.cmd.CommandText = str4;
					this.cmd.Connection = this.connection;
                    idInsertado = this.cmd.ExecuteScalar().ToString();

                    // Insertando licencia de office
                    this.cmd.CommandText = "SELECT idTipoLicencia FROM licenciasdesoftware WHERE idlicencia = " + idLicOffice;
                    this.cmd.Connection = this.connection;
                    idTipoLicencia = this.cmd.ExecuteScalar().ToString();

                    this.cmd.CommandText = "INSERT INTO licenciasasignadas (idInventario,idLicencia,idTipoLicencia) " +
                        "VALUES("+ idInsertado + ","+ idLicOffice + ", "+ idTipoLicencia + ");";
                    this.cmd.Connection = this.connection;
                    this.cmd.ExecuteNonQuery();

                    // Insertando licencia de antivirus
                    this.cmd.CommandText = "SELECT idTipoLicencia FROM licenciasdesoftware WHERE idlicencia = " + idLicAV;
                    this.cmd.Connection = this.connection;
                    idTipoLicencia = this.cmd.ExecuteScalar().ToString();

                    this.cmd.CommandText = "INSERT INTO licenciasasignadas (idInventario,idLicencia,idTipoLicencia) " +
                        "VALUES(" + idInsertado + "," + idLicAV + ", " + idTipoLicencia + ");";
                    this.cmd.Connection = this.connection;
                    this.cmd.ExecuteNonQuery();
                    MessageBox.Show("Registro satisfactorio!");
                }
				else
				{
					foreach (DataRow row in this.dt.Rows)
					{
						str3 = row["idinventario"].ToString();
                        str1 = row["Observaciones"].ToString();
					}
					
					str1 = string.Concat(str1, Environment.NewLine, Observaciones);
                    this.actualizaCompuInv(str3, SO, Host, HD, CPU, RAM, str1, idSucCte);

                    // Actualizando licencia de office
                    this.cmd.CommandText = "SELECT idTipoLicencia FROM licenciasdesoftware WHERE idlicencia = " + idLicOffice;
                    this.cmd.Connection = this.connection;
                    idTipoLicencia = this.cmd.ExecuteScalar().ToString();

                    this.cmd.CommandText = "SELECT idAsignacion FROM licenciasasignadas WHERE idInventario = " + str3 + " AND idTipoLicencia = " + idTipoLicencia;
                    this.cmd.Connection = this.connection;
                    count = Convert.ToInt32(this.cmd.ExecuteScalar());

                    if (count <= 0)
                    {
                        this.cmd.CommandText = "INSERT INTO licenciasasignadas (idInventario,idLicencia,idTipoLicencia) " +
                        "VALUES(" + str3 + "," + idLicOffice + ", " + idTipoLicencia + "); ";
                        this.cmd.Connection = this.connection;
                        this.cmd.ExecuteNonQuery();
                    } else
                    {
                        this.cmd.CommandText = "UPDATE licenciasasignadas SET idLicencia = " + idLicOffice + " WHERE idAsignacion = " + count;
                        this.cmd.Connection = this.connection;
                        this.cmd.ExecuteNonQuery();
                    }

                    // Actualizando licencia de antivirus
                    this.cmd.CommandText = "SELECT idTipoLicencia FROM licenciasdesoftware WHERE idlicencia = " + idLicAV;
                    this.cmd.Connection = this.connection;
                    idTipoLicencia = this.cmd.ExecuteScalar().ToString();

                    this.cmd.CommandText = "SELECT idAsignacion FROM licenciasasignadas WHERE idInventario = " + str3 + " AND idTipoLicencia = " + idTipoLicencia;
                    this.cmd.Connection = this.connection;
                    count = Convert.ToInt32(this.cmd.ExecuteScalar());

                    if (count <= 0)
                    {
                        this.cmd.CommandText = "INSERT INTO licenciasasignadas (idInventario,idLicencia,idTipoLicencia) " +
                        "VALUES(" + str3 + "," + idLicAV + ", " + idTipoLicencia + "); ";
                        this.cmd.Connection = this.connection;
                        this.cmd.ExecuteNonQuery();
                    } else
                    {
                        this.cmd.CommandText = "UPDATE licenciasasignadas SET idLicencia = " + idLicAV + " WHERE idAsignacion = " + count;
                        this.cmd.Connection = this.connection;
                        this.cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Registro actualizado satisfactoriamente!");
                }
            }
			return str;
		}
	}
}