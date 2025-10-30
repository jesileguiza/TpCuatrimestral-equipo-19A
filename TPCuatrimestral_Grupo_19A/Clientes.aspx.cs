using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class Clientes : System.Web.UI.Page
    {
        private static List<string> listaclientes = new List<string>
        {
            "Cliente A",
            "Cliente B",
            "Cliente C"
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
            lstClientes.DataSource = listaclientes;
            lstClientes.DataBind();
        }

        // 🔹 Evento del botón "Alta"
        protected void btnAlta_Click(object sender, EventArgs e)
        {
            listaclientes.Add("Nuevo Cliente " + (listaclientes.Count + 1));
            CargarClientes();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (lstClientes.SelectedIndex >= 0)
            {
                string seleccionado = lstClientes.SelectedItem.Text;
                listaclientes[lstClientes.SelectedIndex] = seleccionado + " (Modificado)";
                CargarClientes();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            var filtrados = listaclientes.FindAll(p => p.ToLower().Contains(filtro));

            lstClientes.DataSource = filtrados;
            lstClientes.DataBind();
        }





    }
}
