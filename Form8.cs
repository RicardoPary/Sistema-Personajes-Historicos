using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_Inf_281
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        this.panel2.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.panel2.Visible=false;
      
        }

        private void BCargo3_Click(object sender, EventArgs e)
        {
            this.panel3.Visible=false;
        }

        private void BAlianza3_Click(object sender, EventArgs e)
        {
            this.panel4.Visible=false;
        }

        private void BCargo5_Click(object sender, EventArgs e)
        {
            this.panel4.Visible=true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.panel3.Visible=true;
        }

        private void ParentescoB5_Click(object sender, EventArgs e)
        {
            this.panel6.Visible=false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

       

       
    }
}
