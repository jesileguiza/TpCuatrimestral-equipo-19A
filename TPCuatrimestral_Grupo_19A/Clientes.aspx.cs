using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class Clientes : System.Web.UI.Page
    {
        private static List<Cliente> listaclientes = new List<Cliente>
        {
    new Cliente { IdCliente = 1, Nombre = "Cliente A", DNI = "30123456", CantidadCompras = 5, UltimaCompra = DateTime.Now, MontoMaximo = 1200 },
    new Cliente { IdCliente = 2, Nombre = "Cliente B", DNI = "30999888", CantidadCompras = 2, UltimaCompra = DateTime.Now.AddDays(-5), MontoMaximo = 800 },
    new Cliente { IdCliente = 3, Nombre = "Cliente C", DNI = "30111222", CantidadCompras = 7, UltimaCompra = DateTime.Now.AddDays(-2), MontoMaximo = 1500 }
};
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = listaclientes;
            dgvClientes.DataBind();
        }

        
        protected void btnAlta_Click(object sender, EventArgs e)
        {
            int nuevoID = listaclientes.Count + 1;
            listaclientes.Add(new Cliente
            {
                IdCliente = nuevoID,
                Nombre = "Nuevo Cliente " + nuevoID,
                DNI = "30" + new Random().Next(1000000, 9999999).ToString(),
                CantidadCompras = 0,
                UltimaCompra = DateTime.Now,
                MontoMaximo = 0
            });

            CargarClientes();
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Cliente agregado exitosamente');", true);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (listaclientes.Any())
            {
                listaclientes[0].Nombre += " (Modificado)";
                CargarClientes();
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Cliente modificado correctamente');", true);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            var filtrados = listaclientes
                .Where(c => c.Nombre.ToLower().Contains(filtro) || c.DNI.Contains(filtro))
                .ToList();

            dgvClientes.DataSource = filtrados;
            dgvClientes.DataBind();
        }
    }





}

