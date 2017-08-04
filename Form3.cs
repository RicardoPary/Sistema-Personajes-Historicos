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
    public partial class Form3 : Form
    {
              
        public Form3()
        {
        InitializeComponent();
        }

        public static DataTable Cargar()
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
 
        private void cargar()
        {
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.DataSource = Cargar();
        try
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                 row.Height = 150;            
                 DataRowView rows = row.DataBoundItem as DataRowView;               
                 if (rows == null) 
                 {
                 Image IM = this.pictureBox1.Image;
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





private void button1_Click(object sender, EventArgs e)
{  
Insert(int.Parse(T1.Text), Metodos2.Objeto_Image_A_Bytes(pictureBox2.Image,System.Drawing.Imaging.ImageFormat.Jpeg)); 
}


private void button2_Click(object sender, EventArgs e)
{
    file.Filter = "Archivo JPG|*.jpg";
    if (file.ShowDialog() == DialogResult.OK)
    {pictureBox2.Image = Image.FromFile(file.FileName);}
}

private void button3_Click(object sender, EventArgs e)
{   this.cargar();  }


}
    
}
