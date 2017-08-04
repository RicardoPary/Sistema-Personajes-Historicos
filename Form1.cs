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
    public partial class Form1 : Form
    {
  

        //OleDbConnection cone = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Ricardo\\Documents\\Visual Studio 2015\\Projects\\Personajes Historicos.accdb");
        OleDbConnection cone = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\Carrera de Informatica\\Inf - 281(Taller de Sistemas de Informacion)\\Proyecto Inf - 281\\Personajes Historicos.accdb");

        String Cadena = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\Carrera de Informatica\\Inf - 281(Taller de Sistemas de Informacion)\\Proyecto Inf - 281\\Personajes Historicos.accdb";
              
     
        String Tipo = "";


        public Form1()
        {
            InitializeComponent();    

        }
        
        

        private void B3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que desear Salir?", "Confirmacion", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            { this.Close(); }
            else if (result == DialogResult.No)
            { }                         
        }

      

        public void Borrar()
        {
            T1.Text="";
            T2.Text="";
        }
     
        private void B2_Click(object sender, EventArgs e)
        {

            if (this.Verifica())
            {
                if (Tipo.Equals("Administrador"))
                {
                    Form9 F9 = new Form9(Cadena);
                    MessageBox.Show("Cuenta Administrador");
                    this.Borrar();
                    F9.Show();
                    
                }
                else
                {
                    Form7 F7 = new Form7(Cadena);
                    MessageBox.Show("Cuenta Usuario");
                    this.Borrar();
                    F7.Show();
                }

                
            }
            else
            {
                MessageBox.Show("No existe");
            }


        }

        public bool Verifica()
        {
            try
            {

                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT Tipo FROM Cuenta  WHERE `CorreoElectronico`='" + T1.Text + "' AND `Contraseña`='" + T2.Text + "'", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Cuenta");
                Tipo = ds.Tables[0].Rows[0]["Tipo"].ToString();
                return true;
                
            }
            catch (Exception e) { return false; }
        }


       



        private void LK1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 F2 = new Form2(this.Cadena);
            F2.Show();
        }

        private void LK2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {           
            Form6 F6 = new Form6(this.Cadena);
            F6.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    
     

       
    }
}
