namespace PapeleriaDESKAPP
{
    partial class VentaForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ListaProductos = new System.Windows.Forms.DataGridView();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_Producto_Venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_Producto_Venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PtosGen_Producto_Venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNumCtrlVenta = new System.Windows.Forms.TextBox();
            this.txtBuscarProdVenta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PagarBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCostoTotal = new System.Windows.Forms.TextBox();
            this.BackBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPtosGenerados = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ListaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // ListaProductos
            // 
            this.ListaProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ListaProductos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.ListaProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListaProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.ListaProductos.ColumnHeadersHeight = 40;
            this.ListaProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.Nombre_Producto_Venta,
            this.Precio_Producto_Venta,
            this.PtosGen_Producto_Venta});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListaProductos.DefaultCellStyle = dataGridViewCellStyle12;
            this.ListaProductos.GridColor = System.Drawing.SystemColors.ControlText;
            this.ListaProductos.Location = new System.Drawing.Point(19, 84);
            this.ListaProductos.Name = "ListaProductos";
            this.ListaProductos.RowHeadersWidth = 62;
            this.ListaProductos.Size = new System.Drawing.Size(1097, 326);
            this.ListaProductos.TabIndex = 0;
            // 
            // IdProducto
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdProducto.DefaultCellStyle = dataGridViewCellStyle8;
            this.IdProducto.HeaderText = "ID Producto";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.Visible = false;
            // 
            // Nombre_Producto_Venta
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.Nombre_Producto_Venta.DefaultCellStyle = dataGridViewCellStyle9;
            this.Nombre_Producto_Venta.HeaderText = "Nombre";
            this.Nombre_Producto_Venta.MinimumWidth = 8;
            this.Nombre_Producto_Venta.Name = "Nombre_Producto_Venta";
            // 
            // Precio_Producto_Venta
            // 
            this.Precio_Producto_Venta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.Precio_Producto_Venta.DefaultCellStyle = dataGridViewCellStyle10;
            this.Precio_Producto_Venta.HeaderText = "Precio";
            this.Precio_Producto_Venta.MinimumWidth = 8;
            this.Precio_Producto_Venta.Name = "Precio_Producto_Venta";
            // 
            // PtosGen_Producto_Venta
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.PtosGen_Producto_Venta.DefaultCellStyle = dataGridViewCellStyle11;
            this.PtosGen_Producto_Venta.HeaderText = "Puntos Generados";
            this.PtosGen_Producto_Venta.MinimumWidth = 8;
            this.PtosGen_Producto_Venta.Name = "PtosGen_Producto_Venta";
            // 
            // txtNumCtrlVenta
            // 
            this.txtNumCtrlVenta.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.txtNumCtrlVenta.Location = new System.Drawing.Point(201, 427);
            this.txtNumCtrlVenta.Name = "txtNumCtrlVenta";
            this.txtNumCtrlVenta.Size = new System.Drawing.Size(180, 39);
            this.txtNumCtrlVenta.TabIndex = 1;
            // 
            // txtBuscarProdVenta
            // 
            this.txtBuscarProdVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtBuscarProdVenta.Location = new System.Drawing.Point(866, 28);
            this.txtBuscarProdVenta.Name = "txtBuscarProdVenta";
            this.txtBuscarProdVenta.Size = new System.Drawing.Size(226, 38);
            this.txtBuscarProdVenta.TabIndex = 2;
            this.txtBuscarProdVenta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarProdVenta_KeyDown);
            this.txtBuscarProdVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarProdVenta_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Gothic", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(557, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar Producto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS PGothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Núm. Control:";
            // 
            // PagarBtn
            // 
            this.PagarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PagarBtn.Location = new System.Drawing.Point(463, 525);
            this.PagarBtn.Name = "PagarBtn";
            this.PagarBtn.Size = new System.Drawing.Size(235, 50);
            this.PagarBtn.TabIndex = 5;
            this.PagarBtn.Text = "Pagar";
            this.PagarBtn.UseVisualStyleBackColor = true;
            this.PagarBtn.Click += new System.EventHandler(this.PagarBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS PGothic", 20.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(396, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total:";
            // 
            // txtCostoTotal
            // 
            this.txtCostoTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.txtCostoTotal.Location = new System.Drawing.Point(492, 427);
            this.txtCostoTotal.Name = "txtCostoTotal";
            this.txtCostoTotal.ReadOnly = true;
            this.txtCostoTotal.Size = new System.Drawing.Size(180, 39);
            this.txtCostoTotal.TabIndex = 8;
            this.txtCostoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.Cornsilk;
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BackBtn.ForeColor = System.Drawing.Color.Indigo;
            this.BackBtn.Location = new System.Drawing.Point(12, 9);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(109, 38);
            this.BackBtn.TabIndex = 9;
            this.BackBtn.Text = "Volver";
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS PGothic", 20.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(678, 434);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 27);
            this.label4.TabIndex = 10;
            this.label4.Text = "Puntos Generados:";
            // 
            // txtPtosGenerados
            // 
            this.txtPtosGenerados.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.txtPtosGenerados.Location = new System.Drawing.Point(932, 430);
            this.txtPtosGenerados.Name = "txtPtosGenerados";
            this.txtPtosGenerados.Size = new System.Drawing.Size(180, 39);
            this.txtPtosGenerados.TabIndex = 11;
            this.txtPtosGenerados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VentaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(1128, 587);
            this.Controls.Add(this.txtPtosGenerados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.txtCostoTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PagarBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscarProdVenta);
            this.Controls.Add(this.txtNumCtrlVenta);
            this.Controls.Add(this.ListaProductos);
            this.Name = "VentaForm";
            this.Text = "VentaForm";
            ((System.ComponentModel.ISupportInitialize)(this.ListaProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ListaProductos;
        private System.Windows.Forms.TextBox txtNumCtrlVenta;
        private System.Windows.Forms.TextBox txtBuscarProdVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PagarBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCostoTotal;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPtosGenerados;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Producto_Venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_Producto_Venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn PtosGen_Producto_Venta;
    }
}