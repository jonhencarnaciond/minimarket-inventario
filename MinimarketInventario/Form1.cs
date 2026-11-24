using Microsoft.Data.Sqlite;
using MinimarketInventario.Data;
using MinimarketInventario.Models;

namespace MinimarketInventario
{
    public partial class Form1 : Form
    {
        private readonly ProductoRepository _repositorio = new();
        public Form1()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El código y el nombre son obligatorios.", "Datos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numPrecio.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que cero.", "Datos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var producto = new Producto
            {
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Categoria = txtCategoria.Text.Trim(),
                Precio = numPrecio.Value,
                Stock = (int)numStock.Value
            };

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
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = _repositorio.ObtenerTodos();
            dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "N2";
        }
    }
}
