using Microsoft.Data.Sqlite;
using MinimarketInventario.Data;
using MinimarketInventario.Models;

namespace MinimarketInventario
{
    public partial class Form1 : Form
    {
        private readonly ProductoRepository _repositorio = new();
        private int? _idEditando = null;
        private static readonly Color ColorPrimario = Color.FromArgb(37, 99, 235);
        private static readonly Color ColorExito = Color.FromArgb(5, 150, 105);
        private static readonly Color ColorPeligro = Color.FromArgb(220, 38, 38);
        private static readonly Color ColorNeutro = Color.FromArgb(107, 114, 128);
        private static readonly Color ColorFondo = Color.FromArgb(243, 244, 246);
        public Form1()
        {
            InitializeComponent();
            dgvProductos.CellClick += dgvProductos_CellClick;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            AplicarEstilo();
            CargarProductos();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private Producto? LeerFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El código y el nombre son obligatorios.", "Datos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (numPrecio.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que cero.", "Datos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return new Producto
            {
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Categoria = txtCategoria.Text.Trim(),
                Precio = numPrecio.Value,
                Stock = (int)numStock.Value
            };
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var producto = LeerFormulario();
            if (producto == null) return;

            try
            {
                _repositorio.Insertar(producto);
                MessageBox.Show("Producto guardado correctamente.", "Listo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarProductos();
            }
            catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
            {
                MessageBox.Show("Ya existe un producto con ese código.", "Código repetido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCategoria.Clear();
            numPrecio.Value = 0;
            numStock.Value = 0;
            txtCodigo.Focus();

            _idEditando = null;
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = _repositorio.ObtenerTodos();
            dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "N2";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_idEditando == null) return;

            var producto = LeerFormulario();
            if (producto == null) return;
            producto.Id = _idEditando.Value;

            try
            {
                _repositorio.Actualizar(producto);
                MessageBox.Show("Producto actualizado correctamente.", "Listo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarProductos();
            }
            catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
            {
                MessageBox.Show("Ya existe otro producto con ese código.", "Código repetido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void dgvProductos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // clic en el encabezado

            if (dgvProductos.Rows[e.RowIndex].DataBoundItem is not Producto producto) return;

            _idEditando = producto.Id;
            txtCodigo.Text = producto.Codigo;
            txtNombre.Text = producto.Nombre;
            txtCategoria.Text = producto.Categoria;
            numPrecio.Value = producto.Precio;
            numStock.Value = producto.Stock;

            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idEditando == null) return;

            var respuesta = MessageBox.Show(
                $"¿Seguro que deseas eliminar \"{txtNombre.Text}\"? Esta acción no se puede deshacer.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes) return;

            _repositorio.Eliminar(_idEditando.Value);
            MessageBox.Show("Producto eliminado correctamente.", "Listo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
            CargarProductos();
        }

        private void AplicarEstilo()
        {
            BackColor = ColorFondo;

            EstilizarBoton(btnGuardar, ColorPrimario);
            EstilizarBoton(btnActualizar, ColorExito);
            EstilizarBoton(btnCancelar, ColorNeutro);
            EstilizarBoton(btnEliminar, ColorPeligro);

            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProductos.ColumnHeadersHeight = 36;
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = ColorPrimario;
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvProductos.RowTemplate.Height = 30;
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 219, 254);
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private static void EstilizarBoton(Button boton, Color color)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = color;
            boton.ForeColor = Color.White;
            boton.Cursor = Cursors.Hand;
            RedondearBoton(boton);
        }

        private static void RedondearBoton(Button boton, int radio = 12)
        {
            var ruta = new System.Drawing.Drawing2D.GraphicsPath();
            var r = new Rectangle(0, 0, boton.Width, boton.Height);
            ruta.AddArc(r.X, r.Y, radio, radio, 180, 90);
            ruta.AddArc(r.Right - radio, r.Y, radio, radio, 270, 90);
            ruta.AddArc(r.Right - radio, r.Bottom - radio, radio, radio, 0, 90);
            ruta.AddArc(r.X, r.Bottom - radio, radio, radio, 90, 90);
            ruta.CloseFigure();
            boton.Region = new Region(ruta);
        }

    }
}
