namespace PapeleriaDESKAPP
{
    partial class Efectivo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCobro = new System.Windows.Forms.TextBox();
            this.BtnPagar = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Ptstxt = new System.Windows.Forms.TextBox();
            this.PtsUsartxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(263, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 54);
            this.label2.TabIndex = 2;
            this.label2.Text = "Efectivo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(325, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cobro";
            // 
            // txtCobro
            // 
            this.txtCobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCobro.Location = new System.Drawing.Point(231, 131);
            this.txtCobro.Name = "txtCobro";
            this.txtCobro.ReadOnly = true;
            this.txtCobro.Size = new System.Drawing.Size(266, 45);
            this.txtCobro.TabIndex = 5;
            this.txtCobro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BtnPagar
            // 
            this.BtnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPagar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnPagar.Location = new System.Drawing.Point(293, 394);
            this.BtnPagar.Name = "BtnPagar";
            this.BtnPagar.Size = new System.Drawing.Size(120, 51);
            this.BtnPagar.TabIndex = 6;
            this.BtnPagar.Text = "Pagar";
            this.BtnPagar.UseVisualStyleBackColor = true;
            this.BtnPagar.Click += new System.EventHandler(this.BtnPagar_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.Cornsilk;
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBtn.ForeColor = System.Drawing.Color.Indigo;
            this.BackBtn.Location = new System.Drawing.Point(12, 12);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(104, 40);
            this.BackBtn.TabIndex = 7;
            this.BackBtn.Text = "Volver";
            this.BackBtn.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(708, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 46);
            this.label3.TabIndex = 10;
            this.label3.Text = "Puntos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(733, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 31);
            this.label5.TabIndex = 11;
            this.label5.Text = "Saldo";
            // 
            // Ptstxt
            // 
            this.Ptstxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Ptstxt.Location = new System.Drawing.Point(690, 174);
            this.Ptstxt.Name = "Ptstxt";
            this.Ptstxt.ReadOnly = true;
            this.Ptstxt.Size = new System.Drawing.Size(185, 45);
            this.Ptstxt.TabIndex = 12;
            this.Ptstxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PtsUsartxt
            // 
            this.PtsUsartxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.PtsUsartxt.Location = new System.Drawing.Point(690, 276);
            this.PtsUsartxt.Name = "PtsUsartxt";
            this.PtsUsartxt.Size = new System.Drawing.Size(185, 45);
            this.PtsUsartxt.TabIndex = 13;
            this.PtsUsartxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PtsUsartxt.TextChanged += new System.EventHandler(this.PtsUsartxt_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(697, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 31);
            this.label6.TabIndex = 14;
            this.label6.Text = "Puntos a Usar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(325, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "Pago";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(306, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 31);
            this.label7.TabIndex = 16;
            this.label7.Text = "Cambio";
            // 
            // txtPago
            // 
            this.txtPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.txtPago.Location = new System.Drawing.Point(231, 216);
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(266, 45);
            this.txtPago.TabIndex = 17;
            this.txtPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPago.TextChanged += new System.EventHandler(this.txtPago_TextChanged);
            // 
            // txtCambio
            // 
            this.txtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.txtCambio.Location = new System.Drawing.Point(231, 310);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.ReadOnly = true;
            this.txtCambio.Size = new System.Drawing.Size(266, 45);
            this.txtCambio.TabIndex = 18;
            this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Efectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(938, 457);
            this.Controls.Add(this.txtCambio);
            this.Controls.Add(this.txtPago);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PtsUsartxt);
            this.Controls.Add(this.Ptstxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.BtnPagar);
            this.Controls.Add(this.txtCobro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "Efectivo";
            this.Text = "EfectivoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCobro;
        private System.Windows.Forms.Button BtnPagar;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Ptstxt;
        private System.Windows.Forms.TextBox PtsUsartxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.TextBox txtCambio;
    }
}