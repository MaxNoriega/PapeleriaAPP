namespace PapeleriaDESKAPP
{
    partial class MetodoPagoForm
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
            this.TransBtn = new System.Windows.Forms.Button();
            this.EfectivoBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TransBtn
            // 
            this.TransBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TransBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.TransBtn.Location = new System.Drawing.Point(138, 231);
            this.TransBtn.Name = "TransBtn";
            this.TransBtn.Size = new System.Drawing.Size(191, 42);
            this.TransBtn.TabIndex = 0;
            this.TransBtn.Text = "Transferencia";
            this.TransBtn.UseVisualStyleBackColor = true;
            this.TransBtn.Click += new System.EventHandler(this.TransBtn_Click);
            // 
            // EfectivoBtn
            // 
            this.EfectivoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EfectivoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EfectivoBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.EfectivoBtn.Location = new System.Drawing.Point(334, 231);
            this.EfectivoBtn.Name = "EfectivoBtn";
            this.EfectivoBtn.Size = new System.Drawing.Size(195, 42);
            this.EfectivoBtn.TabIndex = 1;
            this.EfectivoBtn.Text = "Efectivo";
            this.EfectivoBtn.UseVisualStyleBackColor = true;
            this.EfectivoBtn.Click += new System.EventHandler(this.PuntosBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(100, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione el Método de Pago";
            // 
            // MetodoPagoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(665, 419);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EfectivoBtn);
            this.Controls.Add(this.TransBtn);
            this.Name = "MetodoPagoForm";
            this.Text = "MetodoPagoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TransBtn;
        private System.Windows.Forms.Button EfectivoBtn;
        private System.Windows.Forms.Label label1;
    }
}