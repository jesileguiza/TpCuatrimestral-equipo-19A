<%@ Page Title="" Language="C#" MasterPageFile="~/MasterComercio.Master" AutoEventWireup="true" CodeBehind="abmProducto.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.abmProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #f4f7f9; 
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: #333;
        }
        .container.mt-4 {
            max-width: 800px; 
            margin: 40px auto;
            padding: 30px;
            background-color: #ffffff;
            border-radius: 10px; 
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        }
        .form-title {
            color: #007bff; 
            text-align: center;
            margin-bottom: 30px;
            font-size: 2.2em;
            font-weight: 600;
            padding-bottom: 10px;
            border-bottom: 3px solid #f0f0f0; 
        }     
        label {
            font-weight: 600; 
            color: #555;
            margin-bottom: 5px;
            display: block;
        }
        .form-control {
            border-radius: 5px;
            border: 1px solid #ced4da;
            padding: 10px 15px; 
            height: auto;
            transition: border-color 0.2s, box-shadow 0.2s;
        }
        .form-control:focus {
            border-color: #80bdff;
            box-shadow: 0 0 0 0.2rem rgba(0, 123, 255, 0.25); 
        }
        .form-group {
            margin-bottom: 20px; 
        }
        input[type="submit"], .aspNetButton {
            padding: 10px 20px;
            font-weight: 600;
            border-radius: 5px;
            transition: background-color 0.3s, transform 0.2s;
            margin-right: 15px; 
            min-width: 120px;
            cursor: pointer;
            border: 1px solid transparent;
        }
        #btnAgregar {
            background-color: #28a745; 
            border-color: #28a745;
            color: white;
        }   
        #btnAgregar:hover {
            background-color: #1e7e34;
            border-color: #1c7430;
            transform: translateY(-1px);
        }
        #btnCancelar {
            background-color: #6c757d; 
            border-color: #6c757d;
            color: white;
        }
        #btnCancelar:hover {
            background-color: #5a6268;
            border-color: #545b62;
            transform: translateY(-1px);
        }
        #btnEliminar {
            background-color: #dc3545;
            border-color: #dc3545;
            color: white;
        }
        #btnEliminar:hover {
            background-color: #c82333;
            border-color: #bd2130;
            transform: translateY(-1px);
        }
        #lblMensaje {
            display: block;
            margin-top: 25px;
            font-weight: bold;
            text-align: center;
            font-size: 1.1em;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        
        <h2 class="form-title">Agregar Producto</h2>

        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="TxtNombre">Nombre</label>
                <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <label for="TxtDescripcion">Descripción</label>
                <asp:TextBox ID="TxtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <label for="TxtProvedores">Proveedor</label>
            <asp:TextBox ID="TxtProvedores" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="TxtMarca">ID Marca</label>
            <asp:TextBox ID="TxtMarca" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="txtCategoria">Categoría</label>
                <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <label for="TxtStock">Stock</label>
                <asp:TextBox ID="TxtStock" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-2">
                <label for="TxtPrecio">Precio</label>
                <asp:TextBox ID="TxtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        
        <hr style="margin-top: 30px; margin-bottom: 25px; border-top: 1px solid #e0e0e0;" />

        <div class="text-center">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="aspNetButton" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="aspNetButton" />
            <asp:Button ID="btnEliminar" Text="Eliminar" runat="server" OnClick="btnEliminar_Click" CssClass="btn btn-danger" />
        </div>
        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>

    </div>
</asp:Content>
