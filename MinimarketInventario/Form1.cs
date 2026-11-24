using Microsoft.Data.Sqlite;
using MinimarketInventario.Data;
using MinimarketInventario.Models;

namespace MinimarketInventario
{
    public partial class Form1 : Form
    {
        private readonly ProductoRepository _repositorio = new();
        private int? _idEditando = null;
        public Form1()
        {
            InitializeComponent();
            dgvProductos.CellClick += dgvProductos_CellClick;
            btnActualizar.Enabled = false;
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
        }
    }
}
