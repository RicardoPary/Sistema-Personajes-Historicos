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
    public partial class Form2 : Form
    {
        String Sexo="";
        String Tipo="Usuario";


        OleDbConnection cone;

        public Form2(String cadena)
        {
            cone = new OleDbConnection(cadena);

            InitializeComponent();
            pictureBox1.Image=null;
        }

        public static void Insert(string nombre, string paterno, string materno, string fechaNacimiento, string sexo, string nick, string correo, string contraseña, string tipo, byte[] foto)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Personajes Historicos.accdb");
            string query = "INSERT INTO Cuenta(Nombre,Paterno,Materno,FechaNacimiento,Sexo, Nick,CorreoElectronico,Contraseña,Tipo,Foto) VALUES(@nombre,@paterno,@materno,@fechaNacimiento,@sexo,@nick,@correoElectronico,@contraseña,@tipo,@foto)";
            OleDbCommand cmd = new OleDbCommand(query, conn);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@paterno", paterno);
            cmd.Parameters.AddWithValue("@materno", materno);
            cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
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



        public void InsertarNuevo()
        {


            String Fecha = CrearC1.Text + "/" + CrearC2.Text + "/" + CrearC3.Text;


            Insert(Crear1.Text, Crear2.Text, Crear3.Text, Fecha, Sexo, Crear4.Text, Crear5.Text, Crear6.Text, Tipo, Metodos2.Objeto_Image_A_Bytes(pictureBox1.Image, System.Drawing.Imaging.ImageFormat.Jpeg));
                                   
            
       
      
            
        }

        private void CrearB1_Click(object sender, EventArgs e)
        {
            this.InsertarNuevo();
            this.Close();
        }

        private void CrearB2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CrearB3_Click(object sender, EventArgs e)
        {
            try{
           
            Open.FileName = ".JPEG";
            Open.ShowDialog();
            this.pictureBox1.Image = Image.FromFile(Open.FileName);
            }
            catch (Exception a)
            {
                MessageBox.Show("Error "+a.ToString());
                cone.Close();
            }
         
        }


        private void CrearR1_CheckedChanged(object sender, EventArgs e)
        {
            this.Sexo="Masculino";
        }

        private void CrearR2_CheckedChanged(object sender, EventArgs e)
        {
            this.Sexo="Femenino";
        }

        private void CrearC4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CrearC4.SelectedIndex)
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
      






   

     




    }
}
