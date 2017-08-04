using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Proyecto_Inf_281
{
    public partial class Form7 : Form
    {
        DataTable Personas = new DataTable();
        DataTable Epocas = new DataTable();
        String cadena = "";
        OleDbConnection cone;
        
        public Form7(String cadena)
        {
        this.cadena = cadena;
        cone = new OleDbConnection(cadena);
        InitializeComponent();   
        }

        public void Conexion()
        {       
        cone.Open();
        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM DatosPersonales ORDER BY Nombres", cone);      
        ad.Fill(Personas);

        OleDbDataAdapter ad1 = new OleDbDataAdapter("SELECT * FROM Epoca ORDER BY CodigoEpoca", cone);
        ad1.Fill(Epocas);   

        }


        public void buscar2(String Nombre)
        {
            try{

            OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM DatosPersonales  WHERE NombresApellidos='" + Nombre + "'", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "DatosPersonales");


                int codigo = int.Parse(ds.Tables[0].Rows[0]["CodigoPersona"].ToString()); 
                L1.Text=ds.Tables[0].Rows[0]["NombresApellidos"].ToString();
                T1.Text = ds.Tables[0].Rows[0]["Nombres"].ToString();
                T2.Text = ds.Tables[0].Rows[0]["Paterno"].ToString();
                T3.Text = ds.Tables[0].Rows[0]["Materno"].ToString();
                T4.Text = ds.Tables[0].Rows[0]["Sexo"].ToString();

     
                T5.Text=ds.Tables[0].Rows[0]["FechaNacimiento"].ToString();
                T6.Text = ds.Tables[0].Rows[0]["LugarNacimiento"].ToString();
                T7.Text=ds.Tables[0].Rows[0]["FechaFallecimiento"].ToString();
                T8.Text = ds.Tables[0].Rows[0]["LugarFallecimiento"].ToString();
                T9.Text = ds.Tables[0].Rows[0]["CausaMuerte"].ToString();
                T10.Text = ds.Tables[0].Rows[0]["Apodos"].ToString();
                T11.Text =ds.Tables[0].Rows[0]["Etnia"].ToString();
                T12.Text = ds.Tables[0].Rows[0]["ConocidoPor"].ToString();
                T13.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
                T14.Text=ds.Tables[0].Rows[0]["Departamento"].ToString();
                T15.Text=ds.Tables[0].Rows[0]["Nacionalidad"].ToString();



                this.cargarData();
             

             
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
                        if (aux == codigo)
                        {
                            Image IM = Metodos2.Bytes_A_Imagen((byte[])dgc.Value);
                            this.pictureBox1.Image = IM;
                        }
                    }
                 }


               }
            catch (Exception ex)
            {  }

      
        }

        public static DataTable CargarImagenes()
        {
            OleDbConnection cone = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Personajes Historicos.accdb");
            DataTable dt = new DataTable();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM Imagen", cone);
            ad.Fill(dt);
            return dt;
        }        
       

        private void cargarData()
        {
            Data10.AutoGenerateColumns = false;
            Data10.DataSource = CargarImagenes();
            try
            {
                foreach (DataGridViewRow row in Data10.Rows)
                {
                    row.Height = 150;
                    DataRowView rows = row.DataBoundItem as DataRowView;
                    if (rows == null)
                    {
                        Image IM = this.picturenulo.Image;
                        row.Cells["Foto"].Value = IM;
                    }
                    else
                    {
                        Image IM = Metodos2.Bytes_A_Imagen((byte[])rows["Foto"]);
                        row.Cells["Foto"].Value = IM;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }

        }

        




        private void Form7_Load(object sender, EventArgs e)
        {           
            this.Data10.Visible=false;
            this.picturenulo.Visible=false;

                        
            this.Conexion();     
            
                foreach (DataRow dr in Personas.Rows)             
                {
                listBox1.Items.Add(dr["NombresApellidos"]);
                }   
        
            foreach (DataRow dr in Epocas.Rows)
            {
          
            this.comboBox1.Items.Add(dr["Nombre"]);
            }

            for(int i=2;i<Personas.Columns.Count;i++)
            {
             
                this.comboBox2.Items.Add(Personas.Columns[i].ToString());
            } 





        }     
        private void cerrarSesionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        buscar2(this.listBox1.Text);
        }

    

  

        private void B100_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            DataTable Personas2 = new DataTable();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM DatosPersonales  WHERE "+this.comboBox2.Text+" LIKE '%" + T100.Text + "%' ORDER BY Nombres", cone);
            ad.Fill(Personas2);         
            foreach (DataRow dr in Personas2.Rows)
            {
            listBox1.Items.Add(dr["NombresApellidos"]);
            }    
    
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable Epocas3 = new DataTable();
            OleDbDataAdapter ad1 = new OleDbDataAdapter("SELECT * FROM Epoca  WHERE Nombre LIKE'%" + this.comboBox1.Text + "%'", cone);
            ad1.Fill(Epocas3);
            int aux = 0;
            foreach (DataRow dr in Epocas3.Rows)
            {
                aux = int.Parse(dr["CodigoEpoca"].ToString());
            }

            this.listBox1.Items.Clear();
            DataTable Personas3 = new DataTable();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM DatosPersonales  WHERE CodigoEpoca LIKE " + aux + " ORDER BY Nombres", cone);
            ad.Fill(Personas3);
            foreach (DataRow dr in Personas3.Rows)
            {
                listBox1.Items.Add(dr["NombresApellidos"]);
            } 
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

          
            this.listBox1.Items.Clear();
            DataTable Personas3 = new DataTable();
            
            if(this.comboBox3.Text.Equals("Todo"))
            {
              

                foreach (DataRow dr in Personas.Rows)
                {
                    listBox1.Items.Add(dr["NombresApellidos"]);
                }   
            }
            else
            {

            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM DatosPersonales  WHERE Nombres LIKE '" + this.comboBox3.Text + "%' ", cone);
            ad.Fill(Personas3);
            foreach (DataRow dr in Personas3.Rows)
            {
            listBox1.Items.Add(dr["NombresApellidos"]);
            } 

            }
        }

        private void cambiarVistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 F6 = new Form6(cadena);
            F6.Show();
        }


    

    }
}
