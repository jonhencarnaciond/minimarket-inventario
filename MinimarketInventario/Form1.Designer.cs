namespace MinimarketInventario
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            groupBox1 = new GroupBox();
            btnGuardar = new Button();
            numStock = new NumericUpDown();
            label5 = new Label();
            numPrecio = new NumericUpDown();
            label4 = new Label();
            txtCategoria = new TextBox();
            label3 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            txtCodigo = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 56);
            label1.Name = "label1";
            label1.Size = new Size(81, 28);
            label1.TabIndex = 0;
            label1.Text = "Código:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(numStock);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(numPrecio);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtCategoria);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(942, 247);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del producto";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.DodgerBlue;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ButtonHighlight;
            btnGuardar.Location = new Point(737, 81);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(150, 60);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // numStock
            // 
            numStock.DecimalPlaces = 2;
            numStock.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numStock.Location = new Point(554, 112);
            numStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(141, 34);
            numStock.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(462, 118);
            label5.Name = "label5";
            label5.Size = new Size(64, 28);
            label5.TabIndex = 8;
            label5.Text = "Stock:";
            // 
            // numPrecio
            // 
            numPrecio.DecimalPlaces = 2;
            numPrecio.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numPrecio.Location = new Point(554, 50);
            numPrecio.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(141, 34);
            numPrecio.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(462, 56);
            label4.Name = "label4";
            label4.Size = new Size(70, 28);
            label4.TabIndex = 6;
            label4.Text = "Precio:";
            // 
            // txtCategoria
            // 
            txtCategoria.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCategoria.Location = new Point(138, 174);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.Size = new Size(278, 34);
            txtCategoria.TabIndex = 5;
            txtCategoria.TextChanged += textBox3_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(20, 180);
            label3.Name = "label3";
            label3.Size = new Size(101, 28);
            label3.TabIndex = 4;
            label3.Text = "Categoría:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(138, 112);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(278, 34);
            txtNombre.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 118);
            label2.Name = "label2";
            label2.Size = new Size(89, 28);
            label2.TabIndex = 2;
            label2.Text = "Nombre:";
            // 
            // txtCodigo
            // 
            txtCodigo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigo.Location = new Point(138, 50);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(206, 34);
            txtCodigo.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 609);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventario Minimarket";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtCodigo;
        private TextBox txtCategoria;
        private Label label3;
        private NumericUpDown numPrecio;
        private Label label4;
        private Button btnGuardar;
        private NumericUpDown numStock;
        private Label label5;
    }
}
