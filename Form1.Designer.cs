namespace Proyecto_Inf_281
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.LK1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.T1 = new System.Windows.Forms.TextBox();
            this.T2 = new System.Windows.Forms.TextBox();
            this.B2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.B3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LK1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.T1);
            this.panel1.Controls.Add(this.T2);
            this.panel1.Controls.Add(this.B2);
            this.panel1.Location = new System.Drawing.Point(670, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 157);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Maroon;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 34);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cliente Registrado";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LK1
            // 
            this.LK1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.LK1.AutoSize = true;
            this.LK1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LK1.ForeColor = System.Drawing.Color.Red;
            this.LK1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.LK1.Location = new System.Drawing.Point(20, 112);
            this.LK1.Name = "LK1";
            this.LK1.Size = new System.Drawing.Size(84, 18);
            this.LK1.TabIndex = 5;
            this.LK1.TabStop = true;
            this.LK1.Text = "Registrarse";
            this.LK1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LK1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(160, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pasword";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(160, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "E-mail";
            // 
            // T1
            // 
            this.T1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T1.Location = new System.Drawing.Point(23, 47);
            this.T1.Name = "T1";
            this.T1.Size = new System.Drawing.Size(114, 20);
            this.T1.TabIndex = 2;
            // 
            // T2
            // 
            this.T2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T2.Location = new System.Drawing.Point(23, 75);
            this.T2.Name = "T2";
            this.T2.PasswordChar = '*';
            this.T2.Size = new System.Drawing.Size(114, 20);
            this.T2.TabIndex = 1;
            // 
            // B2
            // 
            this.B2.BackColor = System.Drawing.Color.Maroon;
            this.B2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B2.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B2.ForeColor = System.Drawing.Color.White;
            this.B2.Location = new System.Drawing.Point(148, 112);
            this.B2.Name = "B2";
            this.B2.Size = new System.Drawing.Size(104, 31);
            this.B2.TabIndex = 0;
            this.B2.Text = "Acceder";
            this.B2.UseVisualStyleBackColor = false;
            this.B2.Click += new System.EventHandler(this.B2_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Proyecto_Inf_281.Properties.Resources._10719095_1515902645316845_664864295_n__2_1;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(9, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(117, 108);
            this.panel2.TabIndex = 2;
            // 
            // B3
            // 
            this.B3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B3.BackColor = System.Drawing.Color.Maroon;
            this.B3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B3.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B3.ForeColor = System.Drawing.Color.White;
            this.B3.Location = new System.Drawing.Point(45, 538);
            this.B3.Name = "B3";
            this.B3.Size = new System.Drawing.Size(81, 27);
            this.B3.TabIndex = 3;
            this.B3.Text = "Salir";
            this.B3.UseVisualStyleBackColor = false;
            this.B3.Click += new System.EventHandler(this.B3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Inf_281.Properties.Resources.Interior_del_Palacio_de_Gobierno;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(970, 606);
            this.ControlBox = false;
            this.Controls.Add(this.B3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.Yellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personajes Historicos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel LK1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox T1;
        private System.Windows.Forms.TextBox T2;
        private System.Windows.Forms.Button B2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button B3;
        private System.Windows.Forms.Label label3;
    }
}

