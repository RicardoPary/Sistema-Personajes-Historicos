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
    public partial class Form6 : Form
    {
        OleDbConnection cone;
        int i = 7;
        int medio = 4; 

        public Form6(string cadena)
        {
            cone = new OleDbConnection(cadena);
            InitializeComponent();
        }


        public static DataTable CargarImagenes()
        {
            OleDbConnection cone = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Personajes Historicos.accdb");
            DataTable dt = new DataTable();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM Epoca ORDER BY CodigoEpoca", cone);
            ad.Fill(dt);
            return dt;
        }


        public void BuscarImagen2()
        {
            // try
            // {
            //  OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  Imagen WHERE CodigoPersona=" + int.Parse(Imagen2.Text) + "", cone);
            // DataSet ds = new DataSet();
            //adp.Fill(ds, "Imagen");
            //ds.Tables[0].Rows[0]["CodigoImagen"].ToString();

            // int aux2 = int.Parse(Imagen2.Text);
            DataGridViewCell dgc;
            DataGridViewCell dgc2;
            for (int i = 0; i < Data10.Rows.Count; i++)
            {
                dgc2 = Data10.Rows[i].Cells["CodigoPersona"];
                if (dgc2.Value == null)
                { }
                else
                {
                    //    int aux = (int)dgc2.Value;
                    //   dgc = Data10.Rows[i].Cells["Foto"];
                    // if (aux == aux2)
                    //  {
                    //   Image IM = Metodos2.Bytes_A_Imagen((byte[])dgc.Value);
                    //  this.P1.Image = IM;

                }

            }

            //    catch (Exception e)
            //  {MessageBox.Show("No existe");}
        }

        private void cargarData()
        {
            Data10.AutoGenerateColumns = false;
            DataTable di = new DataTable();
            di = CargarImagenes();
            Data10.DataSource = CargarImagenes();

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
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }


            for (int i = 0; i < Data10.RowCount; i++)
            {
                if (i == 0)
                {
                    DataGridViewCell dgc = Data10.Rows[i].Cells["Foto"];
                    P1.Image = Metodos2.Bytes_A_Imagen((byte[])dgc.Value);
                }
                if (i == 1)
                {
                    DataGridViewCell dgc = Data10.Rows[i].Cells["Foto"];
                    P2.Image = Metodos2.Bytes_A_Imagen((byte[])dgc.Value);
                }
                if (i == 2)
                {
                    DataGridViewCell dgc = Data10.Rows[i].Cells["Foto"];
                    P3.Image = Metodos2.Bytes_A_Imagen((byte[])dgc.Value);
                }
                if (i == 3)
                {
                    DataGridViewCell dgc = Data10.Rows[i].Cells["Foto"];
                    P4.Image = Metodos2.Bytes_A_Imagen((byte[])dgc.Value);
                }
                if (i == 4)
                {
                    DataGridViewCell dgc = Data10.Rows[i].Cells["Foto"];
                    P5.Image = Metodos2.Bytes_A_Imagen((byte[])dgc.Value);
                }
                if (i == 5)
                {
                    DataGridViewCell dgc = Data10.Rows[i].Cells["Foto"];
                    P6.Image = Metodos2.Bytes_A_Imagen((byte[])dgc.Value);
                }
                if (i == 6)
                {
                    DataGridViewCell dgc = Data10.Rows[i].Cells["Foto"];
                    P7.Image = Metodos2.Bytes_A_Imagen((byte[])dgc.Value);
                }

            }


        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.cargarData();
            this.Data10.Visible = false;
            this.PictureNulo.Visible = false;
            this.buscardatos(medio);
           

        }

        public void cargar2()
        {
            Data10.AutoGenerateColumns = false;
            DataTable di = new DataTable();
            di = CargarImagenes();
            Data10.DataSource = CargarImagenes();

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
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }


        }

        private void button1_Click(object sender, EventArgs e)
        {           
            try
            {
                int c = this.Data10.RowCount;

                if (i < c)
                {
                    DataGridViewCell dgc = Data10.Rows[i].Cells["Foto"];
                    PictureBox aux = new PictureBox();
                    aux.Image = Metodos2.Bytes_A_Imagen((byte[])dgc.Value);
                    this.InsertaFinal(aux.Image);
                    i = i + 1;
                    medio = medio + 1;
                    this.buscardatos(medio);
                }
                else
                {
                    this.Rotar();
                    medio = medio + 1;
                    this.buscardatos(medio);
                }

            }
            catch (Exception ee)
            { MessageBox.Show("" + ee); }

        }


        public void InsertaFinal(Image IM)
        {
            PictureBox aux1 = new PictureBox();
            PictureBox aux2 = new PictureBox();
            PictureBox aux3 = new PictureBox();
            PictureBox aux4 = new PictureBox();
            PictureBox aux5 = new PictureBox();
            PictureBox aux6 = new PictureBox();
            PictureBox aux7 = new PictureBox();

            aux1.Image = P1.Image;
            aux2.Image = P2.Image;
            aux3.Image = P3.Image;
            aux4.Image = P4.Image;
            aux5.Image = P5.Image;
            aux6.Image = P6.Image;
            aux7.Image = P7.Image;

            P1.Image = aux2.Image;
            P2.Image = aux3.Image;
            P3.Image = aux4.Image;
            P4.Image = aux5.Image;
            P5.Image = aux6.Image;
            P6.Image = aux7.Image;
            P7.Image = IM;
        }


        public void InsertaPrincipio(Image IM)
        {
            PictureBox aux1 = new PictureBox();
            PictureBox aux2 = new PictureBox();
            PictureBox aux3 = new PictureBox();
            PictureBox aux4 = new PictureBox();
            PictureBox aux5 = new PictureBox();
            PictureBox aux6 = new PictureBox();
            PictureBox aux7 = new PictureBox();

            aux1.Image = P1.Image;
            aux2.Image = P2.Image;
            aux3.Image = P3.Image;
            aux4.Image = P4.Image;
            aux5.Image = P5.Image;
            aux6.Image = P6.Image;
            aux7.Image = P7.Image;

            P1.Image = IM;
            P2.Image = aux1.Image;
            P3.Image = aux2.Image;
            P4.Image = aux3.Image;
            P5.Image = aux4.Image;
            P6.Image = aux5.Image;
            P7.Image = aux6.Image;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                int c = this.Data10.RowCount;

                if (i >= 0)
                {
                    DataGridViewCell dgc = Data10.Rows[i].Cells["Foto"];
                    PictureBox aux = new PictureBox();
                    aux.Image = Metodos2.Bytes_A_Imagen((byte[])dgc.Value);
                    this.InsertaPrincipio(aux.Image);
                    i = i - 1;
                    medio = medio - 1;
                    this.buscardatos(medio);
                }
                else
                {
                    
                    this.RotarInvertido();
                    medio = medio - 1;
                    this.buscardatos(medio);

                }



            }
            catch (Exception ee)
            { MessageBox.Show("" + ee); }


        }

        public void Rotar()
        {
            if (P5.Image != PictureNulo.Image)
            {
                PictureBox aux1 = new PictureBox();
                PictureBox aux2 = new PictureBox();
                PictureBox aux3 = new PictureBox();
                PictureBox aux4 = new PictureBox();
                PictureBox aux5 = new PictureBox();
                PictureBox aux6 = new PictureBox();
                PictureBox aux7 = new PictureBox();

                aux1.Image = P1.Image;
                aux2.Image = P2.Image;
                aux3.Image = P3.Image;
                aux4.Image = P4.Image;
                aux5.Image = P5.Image;
                aux6.Image = P6.Image;
                aux7.Image = P7.Image;

                P1.Image = aux2.Image;
                P2.Image = aux3.Image;
                P3.Image = aux4.Image;
                P4.Image = aux5.Image;
                P5.Image = aux6.Image;
                P6.Image = aux7.Image;
                P7.Image = this.PictureNulo.Image;
            }
        }


        public void RotarInvertido()
        {
            PictureBox aux1 = new PictureBox();
            PictureBox aux2 = new PictureBox();
            PictureBox aux3 = new PictureBox();
            PictureBox aux4 = new PictureBox();
            PictureBox aux5 = new PictureBox();
            PictureBox aux6 = new PictureBox();
            PictureBox aux7 = new PictureBox();

            aux1.Image = P1.Image;
            aux2.Image = P2.Image;
            aux3.Image = P3.Image;
            aux4.Image = P4.Image;
            aux5.Image = P5.Image;
            aux6.Image = P6.Image;
            aux7.Image = P7.Image;

            P1.Image = this.PictureNulo.Image;
            P2.Image = aux1.Image;
            P3.Image = aux2.Image;
            P4.Image = aux3.Image;
            P5.Image = aux4.Image;
            P6.Image = aux5.Image;
            P7.Image = aux6.Image;
        }




        public void buscardatos(int i)
        {

            DataGridViewCell dgc;
            DataGridViewCell DNombre;
            DataGridViewCell DDescripcion;
            DataGridViewCell DAñoInicio; 
            DataGridViewCell DAñoFinal;
            DataGridViewCell Codigo;
                 
                    
                    DNombre = Data10.Rows[i-1].Cells["Nombre"]; ;
                    DDescripcion = Data10.Rows[i-1].Cells["Descripcion"]; ;
                    DAñoInicio = Data10.Rows[i-1].Cells["AñoInicio"]; ;
                    DAñoFinal = Data10.Rows[i-1].Cells["AñoFinal"]; ;
                    Codigo = Data10.Rows[i - 1].Cells["CodigoEpoca"]; ;

                    Epoca1.Text = DNombre.Value.ToString();
                    Epoca2.Text = DDescripcion.Value.ToString();
                    Epoca3.Text = DAñoInicio.Value.ToString();
                    Epoca4.Text = DAñoFinal.Value.ToString();
                    Epoca100.Text = Codigo.Value.ToString();
               
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
      
        }



    }

}