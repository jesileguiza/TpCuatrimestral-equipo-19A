using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id_Proveedor,RazonSocial, Nombre, Cuit, Telefono, Email, Direccion, Localidad, Activo from Proveedores");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.IdProveedor = datos.Lector["id_Proveedor"] != DBNull.Value ? (int)datos.Lector["id_Proveedor"] : 0;
                    aux.RazonSocial = datos.Lector["RazonSocial"] != DBNull.Value ? (string)datos.Lector["RazonSocial"] : "VACIO";
                    aux.Nombre = datos.Lector["Nombre"] != DBNull.Value ? (string)datos.Lector["Nombre"] : "VACIO";
                    aux.Cuit = datos.Lector["Cuit"] != DBNull.Value ? (string)datos.Lector["Cuit"] : "VACIO";
                    aux.Telefono = datos.Lector["Telefono"] != DBNull.Value ? (string)datos.Lector["Telefono"] : "VACIO";
                    aux.Email = datos.Lector["Email"] != DBNull.Value ? (string)datos.Lector["Email"] : "VACIO";
                    aux.Direccion = datos.Lector["Direccion"] != DBNull.Value ? (string)datos.Lector["Direccion"] : "VACIO";
                    aux.Localidad = datos.Lector["Localidad"] != DBNull.Value ? (string)datos.Lector["Localidad"] : "VACIO";
                    aux.Activo = (bool)datos.Lector["Activo"];

                    //aux. = (int)datos.Lector["Id"];
                    //aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }
}
