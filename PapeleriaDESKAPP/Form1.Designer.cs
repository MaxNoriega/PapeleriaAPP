namespace PapeleriaDESKAPP
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.btn_Acceder = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(458, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(384, 233);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // userTextBox
            // 
            this.userTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTextBox.Location = new System.Drawing.Point(360, 152);
            this.userTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(306, 41);
            this.userTextBox.TabIndex = 2;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(360, 305);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(306, 41);
            this.PasswordTextBox.TabIndex = 3;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // btn_Acceder
            // 
            this.btn_Acceder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Acceder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Acceder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Acceder.Location = new System.Drawing.Point(402, 406);
            this.btn_Acceder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Acceder.Name = "btn_Acceder";
            this.btn_Acceder.Size = new System.Drawing.Size(219, 77);
            this.btn_Acceder.TabIndex = 4;
            this.btn_Acceder.Text = "Entrar";
            this.btn_Acceder.UseVisualStyleBackColor = true;
            this.btn_Acceder.Click += new System.EventHandler(this.btn_Acceder_Click);
            // 
            // btn_Salir
            // 
            this.btn_Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Salir.Location = new System.Drawing.Point(13, 567);
            this.btn_Salir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(174, 63);
            this.btn_Salir.TabIndex = 5;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = true;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(422, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 46);
            this.label3.TabIndex = 0;
            this.label3.Text = "Usuario:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(998, 644);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.btn_Acceder);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button btn_Acceder;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Label label3;
    }
}

