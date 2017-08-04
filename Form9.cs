using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Proyecto_Inf_281
{
    public partial class Form9 : Form
    {
        OleDbConnection cone;
        String cadena = "";
        String sexo = "";
        String TipoColegio = "";
        String NivelPrimario = "";
        String NivelSecundario = "";

        public Form9(String cadena)
        {
            this.cadena = cadena;
            cone = new OleDbConnection(cadena);
            InitializeComponent();
        }

        public static DataTable CargarImagenes()
        {
            OleDbConnection cone = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Personajes Historicos.accdb");
            DataTable dt = new DataTable();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM Imagen", cone);
            ad.Fill(dt);      
            return dt;
        }
        public static void Insert(int codigo, byte[] foto)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Personajes Historicos.accdb");
            string query = "INSERT INTO Imagen(CodigoPersona,Foto) VALUES(@codigo,@foto)";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@CodigoPersona", codigo);
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.Image).Value = foto;
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro Ingresado con Exito...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void InsertEpoca(int CodigoEpoca, string Nombre, string Tipo, string Descripcion, int AñoInicio, int AñoFinal,byte[] Foto)
        {      
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Personajes Historicos.accdb");
            string query = "INSERT INTO Epoca(CodigoEpoca,Nombre,Tipo,Descripcion,AñoInicio,AñoFinal,Foto) VALUES(@CodigoEpoca,@Nombre,@Tipo,@Descripcion,@AñoInicio,@AñoFinal,@foto)";
            OleDbCommand cmd = new OleDbCommand(query, conn);

            cmd.Parameters.AddWithValue("@CodigoEpoca",CodigoEpoca);
            cmd.Parameters.AddWithValue("@Nombre",Nombre);
            cmd.Parameters.AddWithValue("@Tipo", Tipo);
            cmd.Parameters.AddWithValue("@Descripcion",Descripcion);
            cmd.Parameters.AddWithValue("@AñoInicio",AñoInicio);
            cmd.Parameters.AddWithValue("@AñoFinal",AñoFinal);        
            cmd.Parameters.Add("@Foto", System.Data.SqlDbType.Image).Value = Foto;

            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro Ingresado con Exito...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }        


        private void cargarData()
        {
            Data10.AutoGenerateColumns = false;
            DataTable di = new DataTable();
            di = CargarImagenes();
            Data10.DataSource = CargarImagenes();
            for (int i = 0; i < di.Columns.Count-1; i++)
            { FiltrarImagen.Items.Add(di.Columns[i].ToString()); }
            try
            {
                foreach (DataGridViewRow row in Data10.Rows)
                {
                    row.Height = 150;
                    DataRowView rows = row.DataBoundItem as DataRowView;
                    if (rows == null)
                    {
                        Image IM = this.PictureNulo.Image;
                        row.Cells["Foto"].Value = IM;
                    }
                    else
                    {
                        Image IM = Metodos2.Bytes_A_Imagen((byte[])rows["Foto"]);
                        row.Cells["Foto"].Value = IM;
                    }
                }

                foreach (DataGridViewRow row in Data11.Rows)
                {
                    row.Height = 200;
                    DataRowView rows = row.DataBoundItem as DataRowView;
                    if (rows == null)
                    {
                        Image IM = this.PictureNulo.Image;
                        row.Cells["Fot"].Value = IM;
                    }
                    else
                    {
                        Image IM = Metodos2.Bytes_A_Imagen((byte[])rows["Foto"]);
                        row.Cells["Fot"].Value = IM;
                    }
                }




            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }

        }        
        public void Conexion()
        {
            OleDbDataAdapter ah1 = new OleDbDataAdapter("SELECT * FROM DatosPersonales ORDER BY CodigoPersona", cone);
            DataSet ds1 = new DataSet();
            DataTable ds11 = new DataTable();
            ah1.Fill(ds1, "DatosPersonales");
            ah1.Fill(ds11);
            this.Data1.DataSource = ds1.Tables[0];
            for (int i = 0; i < ds11.Columns.Count; i++)
            { this.Filtrar1.Items.Add(ds11.Columns[i].ToString()); }

            OleDbDataAdapter ah2 = new OleDbDataAdapter("SELECT * FROM Colegio", cone);
            DataSet ds2 = new DataSet();
            DataTable ds22 = new DataTable();
            ah2.Fill(ds2, "Colegio");
            ah2.Fill(ds22);
            this.Data2.DataSource = ds2.Tables[0];
            for (int i = 0; i < ds22.Columns.Count; i++)
            { this.Filtrar2.Items.Add(ds22.Columns[i].ToString()); }

            OleDbDataAdapter ah3 = new OleDbDataAdapter("SELECT * FROM TituloPostgrado", cone);
            DataTable ds33=new DataTable();
            DataSet ds3 = new DataSet();
            ah3.Fill(ds33);
            ah3.Fill(ds3, "TituloPostgrado");
            this.Data3.DataSource = ds3.Tables[0];
            for (int i = 0; i < ds33.Columns.Count; i++)
            {this.Filtrar3.Items.Add(ds33.Columns[i].ToString());}
      

            OleDbDataAdapter ah4 = new OleDbDataAdapter("SELECT * FROM CargoPublico", cone);
            DataSet ds4 = new DataSet();
            DataTable ds44 = new DataTable();
            ah4.Fill(ds4, "CargoPublico");
            ah4.Fill(ds44);
            this.Data4.DataSource = ds4.Tables[0];
            for (int i = 0; i < ds44.Columns.Count; i++)
            { this.Filtrar4.Items.Add(ds44.Columns[i].ToString()); }

            OleDbDataAdapter ah5 = new OleDbDataAdapter("SELECT * FROM AlianzaPolitica", cone);
            DataSet ds5 = new DataSet();
            DataTable ds55 = new DataTable();
            ah5.Fill(ds5, "AlianzaPolitica");
            ah5.Fill(ds55);
            this.Data5.DataSource = ds5.Tables[0];
            for (int i = 0; i < ds55.Columns.Count; i++)
            { this.Filtrar5.Items.Add(ds55.Columns[i].ToString()); }

            OleDbDataAdapter ah6 = new OleDbDataAdapter("SELECT * FROM Propiedad", cone);
            DataSet ds6 = new DataSet();
            DataTable ds66 = new DataTable();
            ah6.Fill(ds6, "Propiedad");
            ah6.Fill(ds66);
            this.Data6.DataSource = ds6.Tables[0];
            for (int i = 0; i < ds66.Columns.Count; i++)
            { this.Filtrar6.Items.Add(ds66.Columns[i].ToString()); }

            OleDbDataAdapter ah7 = new OleDbDataAdapter("SELECT * FROM PertenenciaSectorial", cone);
            DataSet ds7 = new DataSet();
            DataTable ds77 = new DataTable();
            ah7.Fill(ds7, "PertenenciaSectorial");
            ah7.Fill(ds77);
            this.Data7.DataSource = ds7.Tables[0];
            for (int i = 0; i < ds77.Columns.Count; i++)
            { this.Filtrar7.Items.Add(ds77.Columns[i].ToString()); }

            OleDbDataAdapter ah8 = new OleDbDataAdapter("SELECT * FROM Idioma", cone);
            DataSet ds8 = new DataSet();
            DataTable ds88 = new DataTable();
            ah8.Fill(ds8, "Idioma");
            ah8.Fill(ds88);
            this.Data8.DataSource = ds8.Tables[0];
            for (int i = 0; i < ds88.Columns.Count; i++)
            { this.Filtrar8.Items.Add(ds88.Columns[i].ToString()); }

            OleDbDataAdapter ah9 = new OleDbDataAdapter("SELECT * FROM Parentesco", cone);
            DataSet ds9 = new DataSet();
            DataTable ds99 = new DataTable();
            ah9.Fill(ds9, "Parentesco");
            ah9.Fill(ds99);
            this.Data9.DataSource = ds9.Tables[0];
            for (int i = 0; i < ds99.Columns.Count; i++)
            { this.Filtrar9.Items.Add(ds99.Columns[i].ToString()); }

            this.cargarData();

            OleDbDataAdapter ah11 = new OleDbDataAdapter("SELECT * FROM Epoca ORDER BY CodigoEpoca", cone);
            DataSet ds11u = new DataSet();
            DataTable ds111 = new DataTable();      
            ah11.Fill(ds11u, "Epoca");
            ah11.Fill(ds111);
            this.Data11.DataSource = ds11u.Tables[0];
            for (int i = 0; i < ds111.Columns.Count; i++)
            { this.EpocaC3.Items.Add(ds111.Columns[i].ToString()); }


            
        }
        
        public void EliminarPersona()
        {
            try
            {
                OleDbCommand aaq = new OleDbCommand("DELETE FROM `DatosPersonales` WHERE `CodigoPersona` =" + int.Parse(P1.Text) + "", cone);
                cone.Open();
                aaq.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Eliminado Correctamente");
            }
            catch (Exception e)
            { MessageBox.Show("No se puede eliminar dato " + e); }
        }
        public void BuscarPersona()
        {
            try
            {

                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  DatosPersonales  WHERE CodigoPersona=" + int.Parse(P1.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "DatosPersona");


                P13.Text = ds.Tables[0].Rows[0]["CodigoEpoca"].ToString(); ;
                ds.Tables[0].Rows[0]["NombresApellidos"].ToString();
                P2.Text = ds.Tables[0].Rows[0]["Nombres"].ToString();
                P3.Text = ds.Tables[0].Rows[0]["Paterno"].ToString();
                P4.Text = ds.Tables[0].Rows[0]["Materno"].ToString();
                String sexo = ds.Tables[0].Rows[0]["Sexo"].ToString();
                if (sexo.Equals("Masculino"))
                { this.radioButton1.Select(); }
                else { this.radioButton2.Select(); }
                ds.Tables[0].Rows[0]["FechaNacimiento"].ToString();
                P5.Text = ds.Tables[0].Rows[0]["LugarNacimiento"].ToString();
                ds.Tables[0].Rows[0]["FechaFallecimiento"].ToString();
                P6.Text = ds.Tables[0].Rows[0]["LugarFallecimiento"].ToString();
                P7.Text = ds.Tables[0].Rows[0]["CausaMuerte"].ToString();
                P8.Text = ds.Tables[0].Rows[0]["Apodos"].ToString();
                P9.Text = ds.Tables[0].Rows[0]["Etnia"].ToString();
                P10.Text = ds.Tables[0].Rows[0]["ConocidoPor"].ToString();
                P11.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
                CD.Text = ds.Tables[0].Rows[0]["Departamento"].ToString();
                CN.Text = ds.Tables[0].Rows[0]["Nacionalidad"].ToString();


            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void BuscarPersona3()
        {
            try
            {

                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  DatosPersonales  WHERE CodigoEpoca=" + int.Parse(P13.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "DatosPersona");


                P1.Text = ds.Tables[0].Rows[0]["CodigoPersona"].ToString(); ;
                ds.Tables[0].Rows[0]["NombresApellidos"].ToString();
                P2.Text = ds.Tables[0].Rows[0]["Nombres"].ToString();
                P3.Text = ds.Tables[0].Rows[0]["Paterno"].ToString();
                P4.Text = ds.Tables[0].Rows[0]["Materno"].ToString();
                String sexo = ds.Tables[0].Rows[0]["Sexo"].ToString();
                if (sexo.Equals("Masculino"))
                { this.radioButton1.Select(); }
                else { this.radioButton2.Select(); }
                ds.Tables[0].Rows[0]["FechaNacimiento"].ToString();
                P5.Text = ds.Tables[0].Rows[0]["LugarNacimiento"].ToString();
                ds.Tables[0].Rows[0]["FechaFallecimiento"].ToString();
                P6.Text = ds.Tables[0].Rows[0]["LugarFallecimiento"].ToString();
                P7.Text = ds.Tables[0].Rows[0]["CausaMuerte"].ToString();
                P8.Text = ds.Tables[0].Rows[0]["Apodos"].ToString();
                P9.Text =  ds.Tables[0].Rows[0]["Etnia"].ToString();
                P10.Text = ds.Tables[0].Rows[0]["ConocidoPor"].ToString();
                P11.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
                CD.Text = ds.Tables[0].Rows[0]["Departamento"].ToString();
                CN.Text = ds.Tables[0].Rows[0]["Nacionalidad"].ToString();


            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void FiltrarPersona()
        {
          OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM DatosPersonales  WHERE "+this.Filtrar1.Text+" LIKE '%" + P12.Text + "%'", cone);
          DataSet ds = new DataSet();
          ah.Fill(ds, "DatosPersonales");
          this.Data1.DataSource = ds.Tables[0];         
       }
        public void InsertarPersona()
        {
            String NombresApellidos = P2.Text + " " + P3.Text + " " + P4.Text;
            String FechaNacimiento = this.CN1.Text + "/" + this.CN2.Text + "/" + this.CN3.Text;
            String FechaFallecimiento = this.CF1.Text + "/" + this.CF2.Text + "/" + this.CF3.Text;
            String Departamento = this.CD.Text;
            String Nacionalidad = this.CN.Text;

            OleDbCommand ah = new OleDbCommand("INSERT INTO `DatosPersonales`(`CodigoEpoca`,`NombresApellidos`,`Nombres`,`Paterno`,`Materno`,                     `Sexo`,             `FechaNacimiento`,`LugarNacimiento`,  `FechaFallecimiento`,`LugarFallecimiento`,`CausaMuerte`, `Apodos`,        `Etnia`,            `ConocidoPor`,  `Religion`,         `Departamento`,`Nacionalidad`)VALUES('"
                                                                               + P13.Text+"','"+ NombresApellidos + "','" + P2.Text + "','" + P3.Text + "','" + P4.Text + "','" + sexo + "','" + FechaNacimiento + "','" + P5.Text + "','" + FechaFallecimiento + "','" + P6.Text + "','" + P7.Text + "','" + P8.Text + "','" + P9.Text + "','" + P10.Text + "','" + P11.Text + "','" + Departamento + "','" + Nacionalidad + "')", cone);
            cone.Open();
            ah.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("insertado correctamente");
        }
        public void ModificarPersona()
        {
            String NombresyApellidos = P2.Text + " " + P3.Text + " " + P4.Text;
            String FechaNacimiento = this.CN1.Text + "/" + this.CN2.Text + "/" + this.CN3.Text;
            String FechaFallecimiento = this.CF1.Text + "/" + this.CF2.Text + "/" + this.CF3.Text;
            String Departamento = this.CD.Text;
            String Nacionalidad = this.CN.Text;

            OleDbCommand aaq = new OleDbCommand("UPDATE `DatosPersonales` SET `NombresApellidos` ='" + NombresyApellidos
                                                                             + "', `CodigoEpoca` =" + int.Parse(P13.Text)
                                                                             + ", `Nombres` ='" + P2.Text
                                                                             + "', `Paterno` = '" + P3.Text
                                                                             + "', `Materno` = '" + P4.Text
                                                                             + "', `Sexo` = '" + this.sexo
                                                                             + "', `FechaNacimiento` = '" + FechaNacimiento
                                                                             + "', `LugarNacimiento` = '" + P5.Text
                                                                             + "', `FechaFallecimiento` = '" + FechaFallecimiento
                                                                             + "', `LugarFallecimiento` = '" + P6.Text
                                                                             + "', `CausaMuerte` = '" + P7.Text
                                                                             + "', `Apodos` = '" + P8.Text
                                                                             + "', `Etnia` = '" + P9.Text
                                                                             + "', `ConocidoPor` = '" + P10.Text
                                                                             + "', `Religion` = '" + P11.Text
                                                                             + "', `Departamento` = '" + Departamento
                                                                             + "',`Nacionalidad` = '" + Nacionalidad
                                                                             + "' WHERE `CodigoPersona` = " + int.Parse(P1.Text) + "", cone);

            cone.Open();
            aaq.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("Modificado correctamentre");
        }

        public void InsertarEpoca()
        {       
            try
            {
            InsertEpoca( int.Parse(Epoca1.Text),Epoca2.Text,Epoca3.Text,Epoca4.Text,int.Parse(EpocaC1.Text),int.Parse(EpocaC2.Text), Metodos2.Objeto_Image_A_Bytes(this.PictureEpoca.Image, System.Drawing.Imaging.ImageFormat.Jpeg));
            }
            catch (Exception e)
            { MessageBox.Show("error " + e); }
        }

        public void EliminarEpoca()
        {
            try
            {
                OleDbCommand aaq = new OleDbCommand("DELETE FROM `Epoca` WHERE `CodigoEpoca` =" + int.Parse(Epoca1.Text) + "", cone);
                cone.Open();
                aaq.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Eliminado Correctamente");
            }
            catch (Exception e)
            { MessageBox.Show("No se puede eliminar dato " + e); }
        }
        public void FiltrarEpoca()
        {
        OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM Epoca  WHERE " + this.EpocaC3.Text + " LIKE '%" + this.textBox1.Text + "%'", cone);
        DataSet ds = new DataSet();
        ah.Fill(ds, "Epoca");
        this.Data11.DataSource = ds.Tables[0];
        }

        public void BuscarColegio()
        {
            try
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  Colegio WHERE CodigoColegio =" + int.Parse(COL1.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Colegio");
                COL2.Text = ds.Tables[0].Rows[0]["CodigoPersona"].ToString();
                COL3.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                String TipoCol = ds.Tables[0].Rows[0]["Tipo"].ToString();
                if (TipoCol.Equals("Fiscal"))
                { this.RC1.Select(); }
                if (TipoCol.Equals("Particular"))
                { this.RC2.Select(); }
                if (TipoCol.Equals("Cema"))
                { this.RC3.Select(); }
                if (TipoCol.Equals("Otros"))
                { this.RC4.Select(); }
            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }
        }
        public void BuscarColegio2()
        {
            try
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM Colegio WHERE CodigoPersona =" + int.Parse(COL2.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Colegio");

                COL1.Text = ds.Tables[0].Rows[0]["CodigoColegio"].ToString();
                COL3.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                String TipoCol = ds.Tables[0].Rows[0]["Tipo"].ToString();

                if (TipoCol.Equals("Fiscal"))
                { this.RC1.Select(); }
                if (TipoCol.Equals("Particular"))
                { this.RC2.Select(); }
                if (TipoCol.Equals("Cema"))
                { this.RC3.Select(); }
                if (TipoCol.Equals("Otros"))
                { this.RC4.Select(); }

            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void BuscarColegio3()
        {
            string select = Filtrar2.Text;
            if (select.Equals("CodigoColegio"))
            {
       
                OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM Colegio  WHERE CodigoColegio LIKE '%" + COL4.Text + "%'", cone);
                DataSet ds = new DataSet();
                ah.Fill(ds, "Colegio");
                this.Data2.DataSource = ds.Tables[0];
            }
            if (select.Equals("CodigoPersona"))
            {
                OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM Colegio  WHERE CodigoPersona LIKE '%" + COL4.Text + "%'", cone);
                DataSet ds = new DataSet();
                ah.Fill(ds, "Colegio");
                this.Data2.DataSource = ds.Tables[0];
            }
            if (select.Equals("Nombre"))
            {
                OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM Colegio  WHERE Nombre LIKE '%" + COL4.Text + "%'", cone);
                DataSet ds = new DataSet();
                ah.Fill(ds, "Colegio");
                this.Data2.DataSource = ds.Tables[0];
            }
            if (select.Equals("Tipo"))
            {
                OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM Colegio  WHERE Tipo LIKE '%" + COL4.Text + "%'", cone);
                DataSet ds = new DataSet();
                ah.Fill(ds, "Colegio");
                this.Data2.DataSource = ds.Tables[0];
            }
            if (select.Equals("Primaria"))
            {
                OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM Colegio  WHERE Primaria LIKE '%" + COL4.Text + "%'", cone);
                DataSet ds = new DataSet();
                ah.Fill(ds, "Colegio");
                this.Data2.DataSource = ds.Tables[0];
            }
            if (select.Equals("Secundaria"))
            {
                OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM Colegio  WHERE Secundaria LIKE '%" + COL4.Text + "%'", cone);
                DataSet ds = new DataSet();
                ah.Fill(ds, "Colegio");
                this.Data2.DataSource = ds.Tables[0];
            }

        }
        public void FiltrarColegio()
        {
        OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM Colegio  WHERE" + this.Filtrar2.Text + "LIKE '%" + COL4.Text + "%'", cone);
        DataSet ds = new DataSet();
        ah.Fill(ds, "Colegio");
        this.Data1.DataSource = ds.Tables[0];
        }
        public void InsertarColegio()
        {
            OleDbCommand ah = new OleDbCommand("INSERT INTO `Colegio`(`CodigoPersona`, `Nombre`, `Tipo`, `Primaria`,`Secundaria`)VALUES(" + int.Parse(COL2.Text) + ",'" + COL3.Text + "','" + this.TipoColegio + "','" + this.NivelPrimario + "','" + this.NivelSecundario + "')", cone);
            cone.Open();
            ah.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("insertado correctamente");
        }
        public void EliminarColegio()
        {
            try
            {
                OleDbCommand aaq = new OleDbCommand("DELETE FROM `Colegio` WHERE `CodigoColegio` =" + int.Parse(COL1.Text) + "", cone);
                cone.Open();
                aaq.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Eliminado Correctamente");
            }
            catch (Exception e)
            { MessageBox.Show("No se puede eliminar dato " + e); }
        }
        public void ModificarColegio()
        {
        
            OleDbCommand aaq = new OleDbCommand("UPDATE `Colegio` SET `CodigoPersona` =" + +int.Parse(COL2.Text) 
                                                                            + ", `Nombre` ='" + COL3.Text 
                                                                             + "', `Tipo` = '"+this.TipoColegio
                                                                             + "', `Primaria` = '" + this.NivelPrimario
                                                                             + "', `Secundaria` = '" + this.NivelSecundario                                                                          
                                                                             + "' WHERE `CodigoColegio` = " + int.Parse(COL1.Text) + "", cone);

            cone.Open();
            aaq.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("Modificado correctamentre");
        }
        
        
        public void InsertarTitulo()
        {
            string Tipo = "";
            if (this.RT1.Checked)
            { Tipo = "Licenciatura"; }
            if (this.RT2.Checked)
            { Tipo = "Maestria"; }
            if (this.RT3.Checked)
            { Tipo = "Doctorado"; }
            if (this.RT4.Checked)
            { Tipo = "Otros"; }

            OleDbCommand ah = new OleDbCommand("INSERT INTO `TituloPostgrado` (`CodigoPersona`, `Nombre`, `Tipo`) VALUES (" + int.Parse(this.Titulo2.Text) + ",'" + this.Titulo3.Text + "','" + Tipo + "')", cone);
            cone.Open();
            ah.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("insertado correctamente");
        }
        public void EliminarTitulo()
        {
            try
            {
                OleDbCommand aq = new OleDbCommand("DELETE FROM `TituloPostGrado` WHERE `CodigoPostgrado` =" + int.Parse(Titulo1.Text) + "", cone);
                cone.Open();
                aq.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Eliminado Correctamente");
            }
            catch (Exception e)
            { MessageBox.Show("No se puede eliminar dato " + e); }
        }
        public void ModificarTitulo()
        {
            string Tipo = "";
            if (this.RT1.Checked)
            { Tipo = "Licenciatura"; }
            if (this.RT2.Checked)
            { Tipo = "Maestria"; }
            if (this.RT3.Checked)
            { Tipo = "Doctorado"; }
            if (this.RT4.Checked)
            { Tipo = "Otros"; }
            OleDbCommand aaq = new OleDbCommand("UPDATE `TituloPostgrado` SET `CodigoPersona` =" + +int.Parse(Titulo2.Text)
                                                                            + ", `Nombre` ='" + Titulo3.Text
                                                                            + "', `Tipo` = '" + Tipo
                                                                            + "' WHERE `CodigoPostgrado` = " + int.Parse(Titulo1.Text) + "", cone);

            cone.Open();
            aaq.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("Modificado correctamentre");
        }
        public void BuscarTitulo()
        {
            try
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  TituloPostgrado WHERE CodigoPostgrado =" + int.Parse(Titulo1.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "TituloPostgrado");

                Titulo2.Text = ds.Tables[0].Rows[0]["CodigoPersona"].ToString();
                Titulo3.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();

            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void BuscarTitulo2()
        {
            try
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  TituloPostgrado WHERE CodigoPersona =" + int.Parse(Titulo2.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "TituloPostgrado");
                Titulo1.Text = ds.Tables[0].Rows[0]["CodigoPostgrado"].ToString();
                Titulo3.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
            }
            catch (Exception e)
            {
            MessageBox.Show("No existe");
            }

        }
        public void FiltrarTitulo()
        {                         
          OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM TituloPostgrado WHERE " + this.Filtrar3.Text + " LIKE '%" + Titulo4.Text + "%'", cone);
          DataSet ds = new DataSet();
          ah.Fill(ds, "TituloPostgrado");
          this.Data3.DataSource = ds.Tables[0];
        }


        public void BuscarCargo()
        {
            try
            {

                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  CargoPublico  WHERE CodigoPublico=" + int.Parse(Cargo1.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "CargoPublico");

                Cargo2.Text=ds.Tables[0].Rows[0]["CodigoPersona"].ToString();
                Cargo3.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                C1CAR.Text = ds.Tables[0].Rows[0]["AñoIngreso"].ToString();
                C2CAR.Text = ds.Tables[0].Rows[0]["AñoSalida"].ToString();
                Cargo4.Text = ds.Tables[0].Rows[0]["FormaIngreso"].ToString();
                Cargo5.Text =ds.Tables[0].Rows[0]["Institucion"].ToString();
                Cargo6.Text = ds.Tables[0].Rows[0]["OrganoEstado"].ToString();
                Cargo7.Text=ds.Tables[0].Rows[0]["Observacion"].ToString();



            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void BuscarCargo2()
        {
            try
            {

                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  CargoPublico  WHERE CodigoPersona=" + int.Parse(Cargo2.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "CargoPublico");

                Cargo1.Text = ds.Tables[0].Rows[0]["CodigoPublico"].ToString();
                Cargo3.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                C1CAR.Text = ds.Tables[0].Rows[0]["AñoIngreso"].ToString();
                C2CAR.Text = ds.Tables[0].Rows[0]["AñoSalida"].ToString();
                Cargo4.Text = ds.Tables[0].Rows[0]["FormaIngreso"].ToString();
                Cargo5.Text = ds.Tables[0].Rows[0]["Institucion"].ToString();
                Cargo6.Text = ds.Tables[0].Rows[0]["OrganoEstado"].ToString();
                Cargo7.Text = ds.Tables[0].Rows[0]["Observacion"].ToString();



            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void InsertarCargo()
        {
            int AñoIngreso = int.Parse(C1CAR.Text);
            int AñoSalida = int.Parse(C2CAR.Text);
            OleDbCommand ah = new OleDbCommand("INSERT INTO `CargoPublico` (`CodigoPersona`,`Nombre`, `AñoIngreso`, `AñoSalida`, `FormaIngreso`, `Institucion`,`OrganoEstado`,`Observacion`) VALUES ("
                                                                    + int.Parse(this.Cargo2.Text) + ",'" + Cargo3.Text + "'," + AñoIngreso + "," + AñoSalida + ",'" + Cargo4.Text + "','" + Cargo5.Text + "','" + Cargo6.Text + "','" + Cargo7.Text + "')", cone);
            cone.Open();
            ah.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("insertado correctamente");
        }
        public void ModificarCargo()
        {
            int AñoIngreso = int.Parse(C1CAR.Text);
            int AñoSalida = int.Parse(C2CAR.Text);
            OleDbCommand aaq = new OleDbCommand("UPDATE `CargoPublico` SET `CodigoPersona` =" + +int.Parse(Cargo2.Text)
                                                                            + ", `Nombre` ='" + Cargo3.Text
                                                                            + "', `AñoIngreso` = '" + AñoIngreso
                                                                            + "', `AñoSalida` = '" + AñoSalida
                                                                            + "', `FormaIngreso` = '" + Cargo4.Text
                                                                            + "', `Institucion` = '" + Cargo5.Text
                                                                            + "', `OrganoEstado` = '" + Cargo6.Text
                                                                            + "', `Observacion` = '" + Cargo7.Text
                                                                            + "' WHERE `CodigoPublico` = " + int.Parse(Cargo1.Text) + "", cone);

            cone.Open();
            aaq.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("Modificado correctamentre");
        }
        public void EliminarCargo()
        {
            try
            {
                OleDbCommand aaq = new OleDbCommand("DELETE FROM `CargoPublico` WHERE `CodigoPublico` =" + int.Parse(Cargo1.Text) + "", cone);
                cone.Open();
                aaq.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Eliminado Correctamente");
            }
            catch (Exception e)
            { MessageBox.Show("No se puede eliminar dato " + e); }
        }        

        public void InsertarAlianza()
        {
            OleDbCommand ah = new OleDbCommand("INSERT INTO `AlianzaPolitica` (`CodigoPersona`, `Aliado`, `Opositor`) VALUES (" + int.Parse(this.Alianza2.Text) + ",'" + Alianza3.Text + "','" + Alianza4.Text + "')", cone);
            cone.Open();
            ah.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("insertado correctamente");
        }
        public void BuscarAlianza()
        {
            try
            {

                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  AlianzaPolitica  WHERE CodigoPolitico=" + int.Parse(Alianza1.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "AlianzaPolitica");
                Alianza2.Text = ds.Tables[0].Rows[0]["CodigoPersona"].ToString();
                Alianza3.Text = ds.Tables[0].Rows[0]["Aliado"].ToString();
                Alianza4.Text = ds.Tables[0].Rows[0]["Opositor"].ToString();      


            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void BuscarAlianza2()
        {
            try
            {

                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  AlianzaPolitica  WHERE CodigoPersona=" + int.Parse(Alianza2.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "AlianzaPolitica");
                Alianza1.Text = ds.Tables[0].Rows[0]["CodigoPolitico"].ToString();
                Alianza3.Text = ds.Tables[0].Rows[0]["Aliado"].ToString();
                Alianza4.Text = ds.Tables[0].Rows[0]["Opositor"].ToString();


            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void ModificarAlianza()
        {

            OleDbCommand aaq = new OleDbCommand("UPDATE `AlianzaPolitica` SET `CodigoPersona` =" + int.Parse(this.Alianza2.Text)
                                                                            + ", `Aliado` ='" + Alianza3.Text
                                                                            + "', `Opositor` = '" + Alianza4.Text 
                                                                            + "' WHERE `CodigoAlianza` = " + int.Parse(Alianza1.Text) + "", cone);

            cone.Open();
            aaq.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("Modificado correctamentre");
        }
        public void FiltrarAlianza()
        {
        OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM AlianzaPolitica  WHERE " + this.Filtrar5.Text + " LIKE '%" + this.Alianza5.Text + "%'", cone);
        DataSet ds = new DataSet();
        ah.Fill(ds, "AlianzaPolitica");
        this.Data5.DataSource = ds.Tables[0];
        }
        public void EliminarAlianza()
        {
            try
            {
                OleDbCommand aaq = new OleDbCommand("DELETE FROM `AlianzaPolitica` WHERE `CodigoPolitico`=" + int.Parse(Alianza1.Text) + "", cone);
                cone.Open();
                aaq.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Eliminado Correctamente");
            }
            catch (Exception e)
            { MessageBox.Show("No se puede eliminar dato " + e); }
        }

        
        public void InsertarPropiedad()
        {
            OleDbCommand ah = new OleDbCommand("INSERT INTO `Propiedad` (`CodigoPersona`, `Tipo`, `Nombre`, `Descripcion`) VALUES (" + int.Parse(this.Propiedad2.Text) + ",'" + Propiedad3.Text + "','" + Propiedad4.Text + "','" + Propiedad5.Text + "')", cone);
            cone.Open();
            ah.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("insertado correctamente");
        }
        public void BuscarPropiedad()
        {
            try
            {

                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  Propiedad  WHERE CodigoPropiedad=" + int.Parse(Propiedad1.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Propiedad");
                Propiedad2.Text = ds.Tables[0].Rows[0]["CodigoPersona"].ToString();
                Propiedad3.Text = ds.Tables[0].Rows[0]["Tipo"].ToString();
                Propiedad4.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                Propiedad5.Text = ds.Tables[0].Rows[0]["Descripcion"].ToString();

            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void BuscarPropiedad2()
        {
            try
            {

                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  Propiedad  WHERE CodigoPersona=" + int.Parse(Propiedad2.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Propiedad");
                Propiedad1.Text = ds.Tables[0].Rows[0]["CodigoPropiedad"].ToString();
                Propiedad3.Text = ds.Tables[0].Rows[0]["Tipo"].ToString();
                Propiedad4.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                Propiedad5.Text = ds.Tables[0].Rows[0]["Descripcion"].ToString();

            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void FiltrarPropiedad()
        {
        OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM Propiedad  WHERE " + this.Filtrar6.Text + " LIKE '%" + this.Propiedad6.Text + "%'", cone);
        DataSet ds = new DataSet();
        ah.Fill(ds, "Propiedad");     
        this.Data6.DataSource = ds.Tables[0];
        }
        public void ModificarPropiedad()
        {

            OleDbCommand aaq = new OleDbCommand("UPDATE `Propiedad` SET `CodigoPersona` ="+ int.Parse(this.Propiedad2.Text)
                                                                            + ", `Tipo` ='" + Propiedad3.Text
                                                                            + "', `Nombre` = '" + Propiedad4.Text
                                                                             + "', `Descripcion` = '" + Propiedad5.Text 
                                                                            + "' WHERE `CodigoPropiedad` = " + int.Parse(Propiedad1.Text) + "", cone);

            cone.Open();
            aaq.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("Modificado correctamentre");
        }
        public void EliminarPropiedad()
        {
            try
            {
                OleDbCommand aaq = new OleDbCommand("DELETE FROM `Propiedad` WHERE `CodigoPropiedad` =" + int.Parse(Propiedad1.Text) + "", cone);
                cone.Open();
                aaq.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Eliminado Correctamente");
            }
            catch (Exception e)
            { MessageBox.Show("No se puede eliminar dato " + e); }
        }
        
        public void InsertarSector()
        {
            OleDbCommand ah = new OleDbCommand("INSERT INTO `PertenenciaSectorial`(`CodigoPersona`,`Tipo Sector`, `Nombre`, `Cargo`, `AñoIngreso`, `AñoSalida`)VALUES(" + int.Parse(this.Sector2.Text) + ",'" + Sector3.Text + "','" + this.Sector4.Text + "','" + this.Sector5.Text + "'," + int.Parse(SectorC1.Text) + "," + int.Parse(SectorC2.Text) + ")", cone);
            cone.Open();
            ah.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("insertado correctamente");
        }
        public void BuscarSector()
        {


            try
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  PertenenciaSectorial  WHERE CodigoSectorial=" + int.Parse(Sector1.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "PertenenciaSectorial");
                Sector2.Text = ds.Tables[0].Rows[0]["CodigoPersona"].ToString();
                Sector3.Text = ds.Tables[0].Rows[0]["Tipo Sector"].ToString();
                Sector4.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                Sector5.Text = ds.Tables[0].Rows[0]["Cargo"].ToString();
                SectorC1.Text = ds.Tables[0].Rows[0]["AñoIngreso"].ToString();
                SectorC2.Text = ds.Tables[0].Rows[0]["AñoSalida"].ToString();

            
          }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void BuscarSector2()
        {
            try
            {

                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  PertenenciaSectorial  WHERE CodigoPersona=" + int.Parse(Sector2.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "PertenenciaSectorial");
                Sector1.Text = ds.Tables[0].Rows[0]["CodigoSectorial"].ToString();
                Sector3.Text = ds.Tables[0].Rows[0]["Tipo Sector"].ToString();
                Sector4.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                Sector5.Text = ds.Tables[0].Rows[0]["Cargo"].ToString();
                SectorC1.Text = ds.Tables[0].Rows[0]["AñoIngreso"].ToString();
                SectorC2.Text = ds.Tables[0].Rows[0]["AñoSalida"].ToString();

            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void FiltrarSector()
        {
        OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM CargoPublico  WHERE " + this.Filtrar4.Text + " LIKE '%" + this.Cargo8.Text + "%'", cone);
        DataSet ds = new DataSet();
        ah.Fill(ds, "CargoPublico");
        this.Data4.DataSource = ds.Tables[0];
        }
        public void ModificarSector()
        {

            OleDbCommand aaq = new OleDbCommand("UPDATE `PertenenciaSectorial` SET `CodigoPersona` ="+ int.Parse(this.Sector2.Text)
                                                                            + ", `Tipo Sector` ='" + Sector3.Text
                                                                            + "', `Nombre` = '" + this.Sector4.Text
                                                                            + "', `Cargo` = '" + this.Sector5.Text
                                                                            + "', `AñoIngreso` = " + int.Parse(SectorC1.Text)
                                                                            + "', `AñoSalida` = " + int.Parse(SectorC2.Text) 
                                                                            + "' WHERE `CodigoSectorial` = " + int.Parse(Sector1.Text) + "", cone);

            cone.Open();
            aaq.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("Modificado correctamentre");
        }
        public void EliminarSector()
        {
            try
            {
                OleDbCommand aaq = new OleDbCommand("DELETE FROM `PertenenciaSectorial` WHERE `CodigoSectorial` =" + int.Parse(Sector1.Text) + "", cone);
                cone.Open();
                aaq.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Eliminado Correctamente");
            }
            catch (Exception e)
            { MessageBox.Show("No se puede eliminar dato " + e); }
        }
        
        public void InsertarIdioma()
        {
            OleDbCommand ah = new OleDbCommand("INSERT INTO `Idioma`(`CodigoPersona`,`Nombre`)VALUES(" + int.Parse(Idioma2.Text) + ",'" + Idioma3.Text + "')", cone);
            cone.Open();
            ah.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("insertado correctamente");
        }
        public void BuscarIdioma()
        {
            try
            {

                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  Idioma  WHERE CodigoIdioma=" + int.Parse(Idioma1.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Idioma");
                Idioma2.Text = ds.Tables[0].Rows[0]["CodigoPersona"].ToString();
                Idioma3.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
         

            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void BuscarIdioma2()
        {
            try
            {

                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  Idioma  WHERE CodigoPersona=" + int.Parse(Idioma2.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Idioma");
                Idioma1.Text = ds.Tables[0].Rows[0]["CodigoIdioma"].ToString();
                Idioma3.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();


            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void FiltrarIdioma()
        {
        OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM Idioma  WHERE " + this.Filtrar8.Text + " LIKE '%" + this.Idioma4.Text + "%'", cone);
        DataSet ds = new DataSet();
        ah.Fill(ds, "Idioma");
        this.Data8.DataSource = ds.Tables[0];
        }
        public void ModificarIdioma()
        {

            OleDbCommand aaq = new OleDbCommand("UPDATE `Idioma` SET `CodigoPersona` =" + int.Parse(Idioma2.Text)
                                                                            + ", `Nombre` ='" + Idioma3.Text                                                                       
                                                                            + "' WHERE `CodigoIdioma` = " + int.Parse(Idioma1.Text) + "", cone);

            cone.Open();
            aaq.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("Modificado correctamentre");
        }
        public void EliminarIdioma()
        {
            try
            {
                OleDbCommand aaq = new OleDbCommand("DELETE FROM `Idioma` WHERE `CodigoIdioma` =" + int.Parse(Idioma1.Text) + "", cone);
                cone.Open();
                aaq.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Eliminado Correctamente");
            }
            catch (Exception e)
            { MessageBox.Show("No se puede eliminar dato " + e); }
        }        

        public void InsertarParentesco()
        {
            OleDbCommand ah = new OleDbCommand("INSERT INTO `Parentesco` (`CodigoPersona`, `Nombres`, `Paterno`,`Materno`,`CargoEstado`,`Gestion`,`Parentesco`) VALUES ("
                                                                + int.Parse(Parentesco2.Text) + ",'" + Parentesco3.Text + "','" + Parentesco4.Text + "','" + Parentesco5.Text + "','" + Parentesco6.Text + "'," + int.Parse(ParentescoC1.Text) + ",'" + Parentesco7.Text + "')", cone);
            cone.Open();
            ah.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("insertado correctamente");
        }
        public void ModificarParentesco()
        {

            OleDbCommand aaq = new OleDbCommand("UPDATE `Parentesco` SET `CodigoPersona` =" + int.Parse(Parentesco2.Text)
                                                                            + ", `Nombres` ='" + Parentesco3.Text
                                                                            + "', `Paterno` ='" + Parentesco4.Text
                                                                            + "', `Materno` ='" + Parentesco5.Text
                                                                            + "', `CargoEstado` ='" + Parentesco6.Text
                                                                            + ", `Gestion` =" + int.Parse(ParentescoC1.Text)
                                                                            + "',`Parentesco` ='" + Parentesco7.Text                                                                        

                                                                            + "' WHERE `CodigoParentesco` = " + int.Parse(Parentesco1.Text) + "", cone);

            cone.Open();
            aaq.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("Modificado correctamentre");
        }
        public void EliminarParentesco()
        {
            try
            {
                OleDbCommand aaq = new OleDbCommand("DELETE FROM `Parentesco` WHERE `CodigoParentesco` =" + int.Parse(Parentesco1.Text) + "", cone);
                cone.Open();
                aaq.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Eliminado Correctamente");
            }
            catch (Exception e)
            { MessageBox.Show("No se puede eliminar dato " + e); }
        }
        public void BuscarParentesco()
        {
            try
            {

                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  Parentesco  WHERE CodigoParentesco=" + int.Parse(Parentesco1.Text) + "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Parentesco");
                Parentesco2.Text = ds.Tables[0].Rows[0]["CodigoPersona"].ToString();
                Parentesco3.Text = ds.Tables[0].Rows[0]["Nombres"].ToString();
                Parentesco4.Text = ds.Tables[0].Rows[0]["Paterno"].ToString();
                Parentesco5.Text = ds.Tables[0].Rows[0]["Materno"].ToString();
                Parentesco6.Text = ds.Tables[0].Rows[0]["CargoEstado"].ToString();
                ParentescoC1.Text = ds.Tables[0].Rows[0]["Gestion"].ToString();
                Parentesco7.Text = ds.Tables[0].Rows[0]["Parentesco"].ToString();

            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }
        public void BuscarParentesco2()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  Parentesco  WHERE CodigoPersona=" + int.Parse(Parentesco2.Text) + "", cone);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Parentesco");
            Parentesco1.Text = ds.Tables[0].Rows[0]["CodigoParentesco"].ToString();
            Parentesco3.Text = ds.Tables[0].Rows[0]["Nombres"].ToString();
            Parentesco4.Text = ds.Tables[0].Rows[0]["Paterno"].ToString();
            Parentesco5.Text = ds.Tables[0].Rows[0]["Materno"].ToString();
            Parentesco6.Text = ds.Tables[0].Rows[0]["CargoEstado"].ToString();
            ParentescoC1.Text = ds.Tables[0].Rows[0]["Gestion"].ToString();
            Parentesco7.Text = ds.Tables[0].Rows[0]["Parentesco"].ToString();            
        }
        public void FiltrarParentesco()
        {
        OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM Parentesco  WHERE " + this.Filtrar9.Text + " LIKE '%" + this.Parentesco8.Text + "%'", cone);
        DataSet ds = new DataSet();
        ah.Fill(ds, "Parentesco");
        this.Data9.DataSource = ds.Tables[0];
        }

        private void InsertarImagen()
        {
         try
            {
            Insert(int.Parse(Imagen2.Text), Metodos2.Objeto_Image_A_Bytes(pictureBox1.Image, System.Drawing.Imaging.ImageFormat.Jpeg));
            }
         catch (Exception e)
         { MessageBox.Show("error " + e); }

        }
        public void EliminarImagen()
        {
            try
            {
                OleDbCommand aaq = new OleDbCommand("DELETE FROM `Imagen` WHERE `CodigoImagen` =" + int.Parse(this.Imagen1.Text) + "", cone);
                cone.Open();
                aaq.ExecuteNonQuery();
                cone.Close();
                MessageBox.Show("Eliminado Correctamente");
            }
            catch (Exception e)
            { MessageBox.Show("No se puede eliminar foto " + e); }
        }      
        public void BuscarImagen()
        {           
           try
           {
            
            
            OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  Imagen WHERE CodigoImagen=" + int.Parse(Imagen1.Text) + "", cone);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Imagen");
            Imagen2.Text = ds.Tables[0].Rows[0]["CodigoPersona"].ToString();

            int aux2 = int.Parse(Imagen1.Text);


            DataGridViewCell dgc;
            DataGridViewCell dgc2;

            for (int i = 0; i < Data10.Rows.Count; i++)
            {
                dgc2 = Data10.Rows[i].Cells["CodigoImagen"];
                if (dgc2.Value == null)
                { }
                else
                {
                    int aux = (int)dgc2.Value;
                    dgc = Data10.Rows[i].Cells["Foto"];
                    if (aux == aux2)
                    {
                        Image IM = Metodos2.Bytes_A_Imagen((byte[])dgc.Value);
                        this.pictureBox1.Image = IM;
                    }
                }

            }

        


             }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }
       
           
       
        }
        public void BuscarImagen2()
        {
          
            try{
            
            OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  Imagen WHERE CodigoPersona=" + int.Parse(Imagen2.Text) + "", cone);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Imagen");
            Imagen1.Text = ds.Tables[0].Rows[0]["CodigoImagen"].ToString();

            int aux2 = int.Parse(Imagen2.Text);


            DataGridViewCell dgc;
            DataGridViewCell dgc2;

            for (int i = 0; i < Data10.Rows.Count; i++)
            {
                dgc2 = Data10.Rows[i].Cells["CodigoPersona"];
                if (dgc2.Value == null)
                { }
                else
                {
                    int aux = (int)dgc2.Value;
                    dgc = Data10.Rows[i].Cells["Foto"];
                    if (aux == aux2)
                    {
                        Image IM = Metodos2.Bytes_A_Imagen((byte[])dgc.Value);
                        this.pictureBox1.Image = IM;
                    }
                }

            }



             }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }




        }
        public void BuscarImagen3()
        {             
            OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM Imagen  WHERE "+this.FiltrarImagen.Text+" LIKE '%" + Imagen3.Text + "%'", cone);
            DataSet ds = new DataSet();
            ah.Fill(ds, "Imagen");
            this.Data10.DataSource = ds.Tables[0];       
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.sexo = "Masculino";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.sexo = "Femenino";
        }
        private void BD1_Click(object sender, EventArgs e)
        {
            this.InsertarPersona();
        }
        private void BD2_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Seguro que desear Eliminar?", "Confirmacion", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            { this.EliminarPersona(); }
            else if (result == DialogResult.No)
            { }

        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this.TipoColegio = "Fiscal";
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.TipoColegio = "Particular";
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.TipoColegio = "Cema";
        }
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            this.TipoColegio = "Otros";
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.NivelPrimario = "Si";
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {this.NivelSecundario = "Si";}
        private void BCOL1_Click(object sender, EventArgs e)
        {
            this.InsertarColegio();
        }
        private void BCOL4_Click(object sender, EventArgs e)
        {
            this.BuscarColegio2();
        }
        private void cuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 F5 = new Form5(this.cadena);
            F5.Show();
        }
        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void B1titulo_Click(object sender, EventArgs e)
        {
            this.InsertarTitulo();
        }
        private void B3alianza_Click(object sender, EventArgs e)
        {
            this.InsertarAlianza();
        }
        private void B3imagen_Click(object sender, EventArgs e)
        {
            this.BuscarImagen();
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            this.PictureNulo.Visible=false;
            this.Text = "Administrador";
            this.Conexion();
        }
        private void cerraSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void B7persona_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter ah1 = new OleDbDataAdapter("SELECT * FROM PersonaC", cone);
            DataSet ds1 = new DataSet();
            ah1.Fill(ds1, "PersonaC");
            this.Data1.DataSource = ds1.Tables[0];
        }
        private void administrarCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
        Form5 F5 = new Form5(this.cadena);
        F5.Show();
        }
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
        Form3 F3 = new Form3();
        F3.Show();
        }

        private void BP2_Click(object sender, EventArgs e)
        {
        this.InsertarPersona();
        }
        private void BP6_Click(object sender, EventArgs e)
        {
        this.Conexion();
        }
        private void BP3_Click(object sender, EventArgs e)
        {
        this.EliminarPersona();
        }
        private void BP4_Click(object sender, EventArgs e)
        {
        this.ModificarPersona();
        }
        private void BP1_Click(object sender, EventArgs e)
        {
         this.BuscarPersona();
        }
        private void BP5_Click(object sender, EventArgs e)
        {
        this.FiltrarPersona();
        }
        private void P12_TextChanged(object sender, EventArgs e)
        {
        this.FiltrarPersona();
        }
        private void BC7_Click(object sender, EventArgs e)
        {
        this.Conexion();
        }
        private void BC1_Click(object sender, EventArgs e)
        {
        this.BuscarColegio();
        }
        private void BU7_Click(object sender, EventArgs e)
        {
        this.Conexion();
        }
        private void BU1_Click(object sender, EventArgs e)
        {
        this.BuscarTitulo();
        }
        private void BU2_Click(object sender, EventArgs e)
        {
        this.BuscarTitulo2();
        }
        private void BCargo7_Click(object sender, EventArgs e)
        {
        this.Conexion();
        }
        private void BCargo3_Click(object sender, EventArgs e)
        {
        this.InsertarCargo();
        }
        private void BAlianza4_Click(object sender, EventArgs e)
        {this.EliminarAlianza();}
        private void BPropiedad3_Click(object sender, EventArgs e)
        {this.InsertarPropiedad();}
        private void BPropiedad4_Click(object sender, EventArgs e)
        {this.EliminarPropiedad();}
        private void IdiomaB3_Click(object sender, EventArgs e)
        {this.InsertarIdioma();}
        private void IdiomaB4_Click(object sender, EventArgs e)
        {this.EliminarIdioma();}

        private void SectorB3_Click(object sender, EventArgs e)
        {
        this.InsertarSector();
        }
        private void SectorB4_Click(object sender, EventArgs e)
        {
        this.EliminarSector();
        }

        private void ParentescoB5_Click(object sender, EventArgs e)
        {
        this.InsertarParentesco();
        }
        private void ParentescoB4_Click(object sender, EventArgs e)
        {
         this.EliminarParentesco();
        }


        private void ImagenC1_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (ImagenC1.SelectedIndex)
            {
                case 0:
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case 1:
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
                case 2:
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                    break;
            }


        }

      
        private void ImagenB1_Click(object sender, EventArgs e)
        {
        this.BuscarImagen();
        }
           
        private void Data1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = Data1.Rows[e.RowIndex];
            

            if (e.RowIndex >= 0)
            {

                P1.Text = row.Cells["CodigoPersona"].Value.ToString();
                P13.Text = row.Cells["CodigoEpoca"].Value.ToString();
                P2.Text = row.Cells["NombresApellidos"].Value.ToString();
                P2.Text = row.Cells["Nombres"].Value.ToString();
                P3.Text = row.Cells["Paterno"].Value.ToString();
                P4.Text = row.Cells["Materno"].Value.ToString();
                String sexo = row.Cells["Sexo"].Value.ToString();
                if (sexo.Equals("Masculino"))
                { this.radioButton1.Select(); }
                else { this.radioButton2.Select(); }

                row.Cells["FechaNacimiento"].Value.ToString(); 
                P5.Text = row.Cells["LugarNacimiento"].Value.ToString();
                row.Cells["FechaFallecimiento"].Value.ToString();
                P6.Text = row.Cells["LugarFallecimiento"].Value.ToString();
                P7.Text = row.Cells["CausaMuerte"].Value.ToString();
                P8.Text = row.Cells["Apodos"].Value.ToString();
                P9.Text = row.Cells["Etnia"].Value.ToString();
                P10.Text = row.Cells["ConocidoPor"].Value.ToString();
                P11.Text = row.Cells["Religion"].Value.ToString(); 
                CD.Text = row.Cells["Departamento"].Value.ToString();
                CN.Text = row.Cells["Nacionalidad"].Value.ToString();

            }


        }

        private void BC5_Click(object sender, EventArgs e)
        {
            this.ModificarColegio();
        }

        private void BU5_Click(object sender, EventArgs e)
        {
            this.ModificarTitulo();
        }

        private void BCargo5_Click(object sender, EventArgs e)
        {
            this.ModificarCargo();
        }

        private void BAlianza5_Click(object sender, EventArgs e)
        {
            this.ModificarAlianza();
        }

        private void BAlianza7_Click(object sender, EventArgs e)
        {
            this.Conexion();
        }

        private void BPropiedad7_Click(object sender, EventArgs e)
        {
            this.Conexion();
        }

        private void SectorB7_Click(object sender, EventArgs e)
        {
            this.Conexion();
        }

        private void IdiomaB7_Click(object sender, EventArgs e)
        {
            this.Conexion();
        }

        private void ParentescoB7_Click(object sender, EventArgs e)
        {
            this.Conexion();
        }

        private void BCargo1_Click(object sender, EventArgs e)
        {
            this.BuscarCargo();
        }

        private void BCargo2_Click(object sender, EventArgs e)
        {
            this.BuscarCargo2();
        }

        private void Balianza1_Click(object sender, EventArgs e)
        {
            this.BuscarAlianza();
        }

        private void BAlianza2_Click(object sender, EventArgs e)
        {
            this.BuscarAlianza2();
        }

        private void BPropiedad1_Click(object sender, EventArgs e)
        {
            this.BuscarPropiedad();
        }

        private void BPropiedad2_Click(object sender, EventArgs e)
        {
            this.BuscarPropiedad2();
        }

        private void SectorB1_Click(object sender, EventArgs e)
        {
            this.BuscarSector();
        }

        private void SectorB2_Click(object sender, EventArgs e)
        {
            this.BuscarSector2();
        }

        private void IdiomaB1_Click(object sender, EventArgs e)
        {
            this.BuscarIdioma();
        }

        private void IdiomaB2_Click(object sender, EventArgs e)
        {
            this.BuscarIdioma2();
        }

        private void ParentescoB1_Click(object sender, EventArgs e)
        {
            this.BuscarParentesco();
        }

        private void ParentescoB2_Click(object sender, EventArgs e)
        {
            this.BuscarParentesco2();
        }
            

        private void BC6_Click(object sender, EventArgs e)
        {FiltrarColegio();}
        private void COL4_TextChanged(object sender, EventArgs e)
        {FiltrarColegio();} 

        private void ImagenB3_Click_1(object sender, EventArgs e)
        {
            this.InsertarImagen();
        }

        private void ImagenB4_Click_1(object sender, EventArgs e)
        {
            this.EliminarImagen();
        }

        private void ImagenB5_Click(object sender, EventArgs e)
        {
           // this.ModificarImagen();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.cargarData();
        }

        private void ImagenB1_Click_1(object sender, EventArgs e)
        {
        this.BuscarImagen();   
        }

        private void ImagenB6_Click_1(object sender, EventArgs e)
        {
            Open.Title = "Abrir Imagen";
            Open.FileName = ".JPEG";
            Open.ShowDialog();
            this.pictureBox1.Image = Image.FromFile(Open.FileName);
        }

        private void ImagenB2_Click(object sender, EventArgs e)
        {
            this.BuscarImagen2();
        }

        private void ImagenB7_Click(object sender, EventArgs e)
        {this.BuscarImagen3();}

        private void BP7_Click(object sender, EventArgs e)
        {
            this.BuscarPersona3();
        }

     

    

     

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form8 F8 = new Form8();
            F8.Show();
        }

        private void BU6_Click(object sender, EventArgs e)
        {FiltrarTitulo();}
        private void BCargo6_Click(object sender, EventArgs e)
        {FiltrarSector();}
        private void BAlianza6_Click(object sender, EventArgs e)
        {FiltrarAlianza();}
        private void BPropiedad6_Click(object sender, EventArgs e)
        {FiltrarPropiedad();}
        private void SectorB6_Click(object sender, EventArgs e)
        { FiltrarSector(); }
        private void IdiomaB6_Click(object sender, EventArgs e)
        {FiltrarIdioma();}
        private void ParentescoB6_Click(object sender, EventArgs e)
        {FiltrarParentesco();}
    
        private void Titulo4_TextChanged(object sender, EventArgs e)
        {FiltrarTitulo();}
        private void Cargo8_TextChanged(object sender, EventArgs e)
        {FiltrarSector();}
        private void Alianza5_TextChanged(object sender, EventArgs e)
        {FiltrarAlianza();}
        private void Propiedad6_TextChanged(object sender, EventArgs e)
        {this.FiltrarPropiedad();}
        private void Sector6_TextChanged(object sender, EventArgs e)
        {FiltrarSector();}
        private void Idioma4_TextChanged(object sender, EventArgs e)
        {this.FiltrarIdioma();}
        private void Parentesco8_TextChanged(object sender, EventArgs e)
        {FiltrarParentesco();}
        private void textBox1_TextChanged(object sender, EventArgs e)
        {FiltrarEpoca();}
        private void Imagen3_TextChanged(object sender, EventArgs e)
        {this.BuscarImagen3();}       

        private void BPictureEpoca_Click_1(object sender, EventArgs e)
        {
            this.openFileDialog1.Title = "Abrir Imagen";
            this.openFileDialog1.FileName = ".JPEG";
            this.openFileDialog1.ShowDialog();
            this.PictureEpoca.Image = Image.FromFile(this.openFileDialog1.FileName);

        }

        private void EpocaB3_Click_1(object sender, EventArgs e)
        {
            this.InsertarEpoca();
        }

        private void EpocaB4_Click_1(object sender, EventArgs e)
        {
            this.EliminarEpoca();
        }

        private void EpocaB1_Click(object sender, EventArgs e)
        {

        }

        private void EpocaB7_Click_1(object sender, EventArgs e)
        {
            this.Conexion();
        }

        private void EpocaB6_Click_1(object sender, EventArgs e)
        {
            FiltrarEpoca();
        }

        private void groupBox35_Enter(object sender, EventArgs e)
        {

        }

        private void Data4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Data5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
       
    }

}