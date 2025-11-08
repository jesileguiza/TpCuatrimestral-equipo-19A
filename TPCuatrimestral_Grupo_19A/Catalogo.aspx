<%@ Page Title="" Language="C#" MasterPageFile="~/MasterComercio.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
        body {
            background-color: #d4edda;
            font-family: Arial, sans-serif;
        }

        h1 {
            color: #1e7e34;
            text-align: center;
            margin-top: 20px;
        }

        .tabla-catalogo {
            width: 90%;
            margin: 30px auto;
            border-collapse: collapse;
            background-color: #ffffff;
            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
            border-radius: 8px;
            overflow: hidden;
        }

        .tabla-catalogo th {
            background-color: #28a745;
            color: white;
            padding: 12px;
            text-align: center;
        }

        .tabla-catalogo td {
            padding: 10px;
            border-bottom: 1px solid #ddd;
            text-align: center;
        }

        .tabla-catalogo tr:nth-child(even) {
            background-color: #f8f9fa;
        }

        .tabla-catalogo tr:hover {
            background-color: #e2f0e5;
        }

        .boton-agregar {
            background-color: #28a745;
            color: white;
            border: none;
            padding: 8px 15px;
            border-radius: 5px;
            cursor: pointer;
            margin-left: 5%;
            transition: 0.3s;
        }

        .boton-agregar:hover {
            background-color: #1e7e34;
        }



    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Catálogo de Productos</h1>

    <p style="font-weight:bold; margin-bottom:5px;">Recordatorio de Categorías</p>

<div style="display:flex; justify-content:space-around; max-width:600px; margin-bottom:20px; background-color:#5bed55; padding:10px; border-radius:5px;">
    <div>1 - Cotillón</div>
    <div>2 - Papelería</div>
    <div>3 - Juguetería</div>
    <div>4 - Repostería</div>
    <div>5 - Librería</div>
</div>

   <button type="button" class="btn btn-primary mt-3" onclick="mostrarFormulario()">➕ Agregar Producto</button>

<div id="formAgregar" style="display:none; margin-top:20px;">

    <h3>Nuevo Producto</h3>
    <div class="form-group">
        <label>Nombre:</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Descripción:</label>
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Proveedor:</label>
        <asp:TextBox ID="txtProveedor" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>ID Marca:</label>
        <asp:TextBox ID="txtIdMarca" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>ID Categoría:</label>
        <asp:TextBox ID="txtIdCategoria" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Stock:</label>
        <asp:TextBox ID="txtStock" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Precio:</label>
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Producto" CssClass="btn btn-success mt-3" OnClick="btnAgregar_Click" />
    <button type="button" class="btn btn-secondary mt-3" onclick="ocultarFormulario()">Cancelar</button>

    <br />
    <asp:Label ID="lblMensaje" runat="server" Visible="false"></asp:Label>
</div>    

    <asp:GridView ID="dgvProductos" runat="server" CssClass="table"></asp:GridView>


    
        <script>
function mostrarFormulario() {
    document.getElementById("formAgregar").style.display = "block";
}

function ocultarFormulario() {
    document.getElementById("formAgregar").style.display = "none";
}
        </script>
    


</asp:Content>
