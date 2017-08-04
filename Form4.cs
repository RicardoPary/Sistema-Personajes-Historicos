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
    public partial class Form4 : Form
    {
        OleDbConnection cone;
        public Form4(string cadena)
        {
            cone = new OleDbConnection(cadena);
            InitializeComponent();
        }


        public void BuscarPersona3()
        {
            try
            {

                OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM  Cuenta  WHERE Nick='"+T1.Text+"' AND CorreoElectronico='"+T2.Text+"'", cone);
                DataSet ds = new DataSet();
                adp.Fill(ds, "Cuenta");
                string clave=ds.Tables[0].Rows[0]["Contraseña"].ToString();

                MessageBox.Show(clave);

            }
            catch (Exception e)
            {
                MessageBox.Show("No existe");
            }

        }

        private void B1_Click(object sender, EventArgs e)
        {
            this.BuscarPersona3();
        }




    }
}
