using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class Proveedores : Page
    {

        //private static List<string> listaProveedores = new List<string>
        //{
        //    "Proveedor A",
        //    "Proveedor B",
        //    "Proveedor C"
        //};

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    CargarProveedores();
            //}

            ProveedorNegocio negocio = new ProveedorNegocio();
            dgvProveedores.DataSource = negocio.listar();
            dgvProveedores.DataBind();
        }

        //private void CargarProveedores()
        //{
        //    lstProveedores.DataSource = listaProveedores;
        //    lstProveedores.DataBind();
        //}

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            //listaProveedores.Add("Nuevo Proveedor " + (listaProveedores.Count + 1));
            //CargarProveedores();
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            //if (lstProveedores.SelectedIndex >= 0)
            //{
            //    listaProveedores.RemoveAt(lstProveedores.SelectedIndex);
            //    CargarProveedores();
            //}
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ////if (lstProveedores.SelectedIndex >= 0)
            ////{
            ////    string seleccionado = lstProveedores.SelectedItem.Text;
            ////    listaProveedores[lstProveedores.SelectedIndex] = seleccionado + " (Modificado)";
            ////    CargarProveedores();
            //}
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //string filtro = txtBuscar.Text.Trim().ToLower();
            //var filtrados = listaProveedores.FindAll(p => p.ToLower().Contains(filtro));

            //lstProveedores.DataSource = filtrados;
            //lstProveedores.DataBind();
        }
    }
}