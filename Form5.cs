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
using System.Drawing.Imaging;

namespace Proyecto_Inf_281
{
    public partial class Form5 : Form
    {
      DataTable Personas = new DataTable();
      OleDbConnection cone;
      String sexo = "";
      String tipo="";

      public Form5(String cadena)
      {
          cone = new OleDbConnection(cadena);       
          InitializeComponent(); 
          this.Picture2.Visible=false;
      }

      public static DataTable Cargar()
      {
              OleDbConnection cone = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Personajes Historicos.accdb");
              DataTable dt = new DataTable();
              string query = "SELECT * FROM Cuenta";
              OleDbCommand cmd = new OleDbCommand(query, cone);
              OleDbDataAdapter adap=new OleDbDataAdapter(cmd);
              adap.Fill(dt);
              return dt;       
      } 

      private void cargar()
      {
          Data1.AutoGenerateColumns = false;
          Data1.DataSource = Cargar();

          foreach (DataGridViewRow row in Data1.Rows)
          {
              row.Height = 70;
              DataRowView rows = row.DataBoundItem as DataRowView;
              if (rows == null)
              {
                  Image IM = this.Picture2.Image;             
                  row.Cells["Foto"].Value = IM;                  
              }
              else
              {
                  Image IM = Metodos2.Bytes_A_Imagen((byte[])rows["Foto"]);
                  row.Cells["Foto"].Value = IM;
              }
          }
      }

      public static void Insert(string nombre,string paterno,string materno,string fechaNacimiento,string sexo,string nick,string correo,string contraseña,string tipo,byte[] foto)
      {
              OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Personajes Historicos.accdb");
              string query = "INSERT INTO Cuenta(Nombre,Paterno,Materno,FechaNacimiento,Sexo, Nick,CorreoElectronico,Contraseña,Tipo,Foto) VALUES(@nombre,@paterno,@materno,@fechaNacimiento,@sexo,@nick,@correoElectronico,@contraseña,@tipo,@foto)";
              OleDbCommand cmd = new OleDbCommand(query, conn);

              cmd.Parameters.AddWithValue("@nombre",nombre);
              cmd.Parameters.AddWithValue("@paterno",paterno);
              cmd.Parameters.AddWithValue("@materno",materno);
              cmd.Parameters.AddWithValue("@fechaNacimiento",fechaNacimiento);
              cmd.Parameters.AddWithValue("@sexo", sexo);
              cmd.Parameters.AddWithValue("@nick", nick);
              cmd.Parameters.AddWithValue("@correoElectronico", correo);
              cmd.Parameters.AddWithValue("@contraseña", contraseña);
              cmd.Parameters.AddWithValue("@tipo", tipo);
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







        public void buscar()
        {
                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM Cuenta WHERE Codigo="+int.Parse(Cuenta1.Text)+ "", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Cuenta");

                Cuenta2.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                Cuenta3.Text = ds.Tables[0].Rows[0]["Paterno"].ToString();
                Cuenta4.Text = ds.Tables[0].Rows[0]["Materno"].ToString();
                Text = ds.Tables[0].Rows[0]["FechaNacimiento"].ToString();
               
                String sexo= ds.Tables[0].Rows[0]["Sexo"].ToString();
                if(sexo.Equals("Masculino"))
                { CuentaR1.Select(); }
                else 
                { CuentaR2.Select(); }

                Cuenta5.Text = ds.Tables[0].Rows[0]["Nick"].ToString();
                Cuenta6.Text = ds.Tables[0].Rows[0]["CorreoElectronico"].ToString();                 
                Cuenta7.Text = ds.Tables[0].Rows[0]["Contraseña"].ToString();             
                String tipo = ds.Tables[0].Rows[0]["Tipo"].ToString();
                if(tipo.Equals("Usuario"))
                {CuentaR3.Select();}
                else
                {CuentaR4.Select();}



                int aux2 = int.Parse(Cuenta1.Text);
              
              
                DataGridViewCell dgc;
                DataGridViewCell dgc2;
               
                for (int i = 0; i < Data1.Rows.Count; i++)
                {                   
                  dgc2 = Data1.Rows[i].Cells["Codigo"];
                  if (dgc2.Value == null)
                  { }
                  else
                  {
                      int aux = (int)dgc2.Value;
                      dgc = Data1.Rows[i].Cells["Foto"];
                      if (aux == aux2)
                      {
                          Image IM = Metodos2.Bytes_A_Imagen((byte[])dgc.Value);
                          this.Pintura.Image = IM;
                      }
                  }
                    
                }

        



                   
       }    

      
        private void InsertarCuenta()
        {
            String Fecha = CuentaC1.Text + "/" + CuentaC2.Text + "/" + CuentaC3.Text;

            Insert(Cuenta2.Text, Cuenta3.Text, Cuenta4.Text, Fecha, sexo, Cuenta5.Text, Cuenta6.Text, Cuenta7.Text,tipo,Metodos2.Objeto_Image_A_Bytes(this.Pintura.Image, System.Drawing.Imaging.ImageFormat.Jpeg));
        
                             
            
       
        }
        
        public void EliminarCuenta()
        {
            OleDbCommand aaq = new OleDbCommand("DELETE FROM `Cuenta` WHERE `Codigo`=" + int.Parse(Cuenta1.Text) + "", cone);
            cone.Open();
            aaq.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("Eliminado Correctamente");       
        }
        
        public void modificar()
        {
             try
            {
            String Fecha = CuentaC1.Text + "/" + CuentaC2.Text + "/" + CuentaC3.Text;
            OleDbCommand aaq = new OleDbCommand("UPDATE `Cuenta` SET `Nombre` ='" + Cuenta2.Text 
                                                                + "', `Paterno` ='" + Cuenta3.Text 
                                                                + "', `Materno` = '" + Cuenta4.Text 
                                                                + "',`FechaNacimiento` = '" + Fecha 
                                                                + "', `Sexo` = '" +sexo 
                                                                + "', `Nick` = '" + Cuenta5.Text 
                                                                + "', `CorreoElectronico` = '" + Cuenta6.Text 
                                                                + "', `Contraseña` = '" + Cuenta7.Text 
                                                                + "', `Tipo` = '" + tipo
                                                                + "',`Foto` = '" + Metodos2.Objeto_Image_A_Bytes(Pintura.Image, System.Drawing.Imaging.ImageFormat.Jpeg)
                                                                + "' WHERE `Codigo` = "+int.Parse(Cuenta1.Text)+"", cone);

            cone.Open();
            aaq.ExecuteNonQuery();
            cone.Close();
            MessageBox.Show("Modificado correctamentre");
            }
             catch (Exception b)
             {
                 MessageBox.Show("Error al Modificar");
                 cone.Close();
             }
        
        }
                
      
        private void B1_Click(object sender, EventArgs e)
        {           
        this.InsertarCuenta();         
        }

        private void B4_Click(object sender, EventArgs e)
        {
        this.buscar();
        }

        private void B3_Click(object sender, EventArgs e)
        {
        this.Close();
        }

        private void B2_Click(object sender, EventArgs e)
        {
        this.EliminarCuenta();
        }

        private void B5_Click(object sender, EventArgs e)
        {
        this.modificar();        
        }

        private void Form5_Load(object sender, EventArgs e)
        {
        this.cargar();
   
        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM DatosPersonales", cone);
        ad.Fill(Personas);
       
        for (int i = 0; i < Personas.Columns.Count; i++)
        {
        this.CuentaCBuscar.Items.Add(Personas.Columns[i].ToString());
        }
      




        }


        private void B101_Click(object sender, EventArgs e)
        {
            this.cargar();
        }

        private void CuentaR1_CheckedChanged(object sender, EventArgs e)
        {
        this.sexo="Masculino";
        }

        private void CuentaR2_CheckedChanged(object sender, EventArgs e)
        {
        this.sexo="Femenino";
        }

        private void CuentaR3_CheckedChanged(object sender, EventArgs e)
        {
        this.tipo="Usuario";
        }

        private void CuentaR4_CheckedChanged(object sender, EventArgs e)
        {
        this.tipo = "Administrador";
        }

        private void CuentaB6_Click(object sender, EventArgs e)
        {
            Open.Title = "Abrir Imagen";
            Open.FileName = ".JPEG";
            Open.ShowDialog();
            Pintura.Image = Image.FromFile(Open.FileName);
        }

        private void ImagenC1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ImagenC1.SelectedIndex)
            {
                case 0:
                    this.Pintura.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case 1:
                    this.Pintura.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
                case 2:
                    this.Pintura.SizeMode = PictureBoxSizeMode.CenterImage;
                    break;
            }
        }

        private void B100_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter ah = new OleDbDataAdapter("SELECT * FROM Cuenta WHERE " + this.CuentaCBuscar.Text + " LIKE '%" + T200.Text + "%' ORDER BY Nombres", cone);
            DataSet ds = new DataSet();
            ah.Fill(ds,"Cuenta");
            this.Data1.DataSource = ds.Tables[0];
        }
     
    }
}
