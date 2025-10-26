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
        //public List<Producto> listar()
        //{
        //    List<Producto> lista = new List<Producto>();
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        datos.setearConsulta("select RazonSocial, Nombre, Cuit, Telefono, Email, Direccion, Localidad from Proveedores");
        //        datos.ejecutarLectura();

        //        while (datos.Lector.Read())
        //        {
        //            Producto aux = new Producto();
        //            aux.IdMarca = (int)datos.Lector["Id"];
        //            aux.Descripcion = (string)datos.Lector["Descripcion"];

        //            lista.Add(aux);
        //        }


        //        return lista;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }

        //}

    }
}
