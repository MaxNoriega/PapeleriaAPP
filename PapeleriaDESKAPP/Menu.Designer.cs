﻿namespace PapeleriaDESKAPP
{
    partial class Menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.VentasBtn = new System.Windows.Forms.Button();
            this.ProductosBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(56, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menú";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // VentasBtn
            // 
            this.VentasBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.VentasBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.VentasBtn.Location = new System.Drawing.Point(22, 85);
            this.VentasBtn.Name = "VentasBtn";
            this.VentasBtn.Size = new System.Drawing.Size(209, 62);
            this.VentasBtn.TabIndex = 2;
            this.VentasBtn.Text = "Ventas";
            this.VentasBtn.UseVisualStyleBackColor = true;
            this.VentasBtn.Click += new System.EventHandler(this.VentasBtn_Click);
            // 
            // ProductosBtn
            // 
            this.ProductosBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ProductosBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.ProductosBtn.Location = new System.Drawing.Point(22, 163);
            this.ProductosBtn.Name = "ProductosBtn";
            this.ProductosBtn.Size = new System.Drawing.Size(209, 62);
            this.ProductosBtn.TabIndex = 3;
            this.ProductosBtn.Text = "Productos";
            this.ProductosBtn.UseVisualStyleBackColor = true;
            this.ProductosBtn.Click += new System.EventHandler(this.ProductosBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.VentasBtn);
            this.panel1.Controls.Add(this.ProductosBtn);
            this.panel1.Location = new System.Drawing.Point(473, 83);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 266);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 60F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Lavender;
            this.label2.Location = new System.Drawing.Point(51, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 98);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ventas\r\n";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Impact", 40F);
            this.label3.ForeColor = System.Drawing.Color.Lavender;
            this.label3.Location = new System.Drawing.Point(63, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(295, 94);
            this.label3.TabIndex = 6;
            this.label3.Text = "papelería";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(799, 419);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Name = "Menu";
            this.Text = "Menu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button VentasBtn;
        private System.Windows.Forms.Button ProductosBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}