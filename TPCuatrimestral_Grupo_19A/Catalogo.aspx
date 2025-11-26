<%@ Page Title="" Language="C#" MasterPageFile="~/MasterComercio.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #f4f6f8; 
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; 
            color: #333; 
        }
        h1 {
            color: #1a7d40;
            text-align: center;
            margin-top: 40px; 
            margin-bottom: 25px;
            font-size: 2.5em; 
            border-bottom: 3px solid #1a7d40; 
            display: inline-block;
            padding-bottom: 5px;
        }
        .header-container {
            text-align: center;
        }
        .categoria-recordatorio {
            font-weight: bold;
            margin: 15px auto 10px auto;
            max-width: 600px;
            text-align: center;
            color: #555;
        }

        .div-categorias {
            display: flex;
            justify-content: center; 
            gap: 20px; 
            max-width: 700px;
            margin: 0 auto 30px auto; 
            background-color: #e6ffe6; 
            padding: 15px;
            border-radius: 8px;
            border: 1px solid #c8e6c9;
            box-shadow: 0 1px 4px rgba(0,0,0,0.05);
        }

        .div-categorias div {
            font-weight: 600;
            color: #2e7d32; 
        }
        .tabla-catalogo {
            width: 90%;
            max-width: 1100px; 
            margin: 30px auto;
            border-collapse: collapse;
            background-color: #ffffff;
            box-shadow: 0 4px 12px rgba(0,0,0,0.1); 
            border-radius: 10px; 
            overflow: hidden;
            border: 1px solid #ddd;
        }

        .tabla-catalogo th {
            background-color: #388e3c; 
            color: white;
            padding: 14px 10px; 
            text-align: left; 
            font-weight: 600;
            border-right: 1px solid #4caf50;
        }
        .tabla-catalogo th:last-child {
            border-right: none; 
            text-align: center; 
        }

        .tabla-catalogo td {
            padding: 12px 10px;
            border-bottom: 1px solid #eee; 
            text-align: left; 
        }
        .tabla-catalogo td:last-child {
            text-align: center;
        }

        .tabla-catalogo tr:nth-child(even) {
            background-color: #fcfcfc;
        }

        .tabla-catalogo tr:hover {
            background-color: #e8f5e9; 
            cursor: pointer;
        }
        .btn-accion {
            display: block;
            width: fit-content;
            margin: 20px auto; 
            background-color: #4CAF50; 
            color: white;
            border: none;
            padding: 10px 25px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 1.1em;
            font-weight: bold;
            transition: background-color 0.3s, transform 0.2s;
            box-shadow: 0 2px 5px rgba(0,0,0,0.2);
            text-decoration: none; 
        }
        .btn-accion:hover {
            background-color: #388e3c; 
            transform: translateY(-1px); 
            box-shadow: 0 4px 8px rgba(0,0,0,0.2);
        }
       .filtro-container {
            width: 90%;
            max-width: 700px;
            margin: 0 auto 25px auto;
            display: flex;
            align-items: center;
           justify-content: center;
           gap: 15px;
           background-color: #e8f5e9;
           padding: 15px 20px;
           border-radius: 8px;
           border: 1px solid #c5e1a5;
           box-shadow: 0 1px 4px rgba(0,0,0,0.08);
       }

       .dropdown-filtro {
           padding: 8px;
           border: 1px solid #a5d6a7;
           border-radius: 5px;
           background-color: #ffffff;
           font-size: 1em;
       }

       .input-search-wrapper {
           position: relative;
           width: 50%;
       }

       .icono-lupa {
           position: absolute;
           top: 50%;
           left: 8px;
           transform: translateY(-50%);
           color: #388e3c;
           font-size: 1.1em;
       }

       .input-search {
           width: 100%;
           padding: 8px 10px 8px 30px;
           border: 1px solid #a5d6a7;
           border-radius: 5px;
           font-size: 1em;
       }

       .input-search:focus {
           outline: none;
           box-shadow: 0 0 6px #66bb6a;
       } 

       .btn-limpiar {
           background-color: #ef5350;
           color: white;
           border: none;
           padding: 8px 15px;
           border-radius: 6px;
           cursor: pointer;
           font-size: 1em;
           font-weight: bold;
           transition: background-color 0.3s;
           box-shadow: 0 2px 4px rgba(0,0,0,0.2);
       }

       .btn-limpiar:hover {
           background-color: #d32f2f;
       } 
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="header-container">
        <h1>Catálogo de Productos</h1>
    </div>
<div class="filtro-container">

    <asp:Label Text="Filtrar por:" runat="server" />

    <asp:DropDownList ID="ddlFiltro" runat="server" CssClass="dropdown-filtro">
        <asp:ListItem Value="Nombre">Nombre</asp:ListItem>
        <asp:ListItem Value="IdProducto">ID Producto</asp:ListItem>
        <asp:ListItem Value="Descripcion">Descripción</asp:ListItem>
        <asp:ListItem Value="Proveedor">Proveedor</asp:ListItem>
        <asp:ListItem Value="Categoria">Categoría</asp:ListItem>
        <asp:ListItem Value="Marca">Marca</asp:ListItem>
    </asp:DropDownList>

    <div class="input-search-wrapper">
        <i class="fa fa-search icono-lupa"></i>
        <asp:TextBox runat="server" ID="Filtro" CssClass="input-search" AutoPostBack="true" OnTextChanged="Filtro_TextChanged1" />
    </div>

    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn-limpiar" OnClick="btnLimpiar_Click" />
</div>

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />


    <asp:GridView runat="server" ID="dgvProductos" AutoGenerateColumns="False" CssClass="tabla-catalogo" DataKeyNames="IdProducto" OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged">
       <Columns>
       <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="👆" />
       <asp:CheckBoxField HeaderText="Activo" DataField="Activo" /> 
       <asp:BoundField DataField="IdProducto" HeaderText="ID" />
       <asp:BoundField DataField="Nombre" HeaderText="Producto" />
       <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
       <asp:BoundField DataField="Proveedor.RazonSocial" HeaderText="Proveedor" />
       <asp:BoundField DataField="categoria.IdCategoria" HeaderText="ID Categoría" />
       <asp:BoundField DataField="categoria.Descripcion" HeaderText="Categoría" />
       <asp:BoundField DataField="Marca.IdMarca" HeaderText="ID Marca" />
        <asp:BoundField DataField="Marca.Descripcion" HeaderText="Marca" />
       <asp:BoundField DataField="Stock" HeaderText="Stock" />
       <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
       </Columns>
    </asp:GridView>

    <asp:Button runat="server" ID="btnAgregarProducto" Text="Agregar Nuevo Producto" CssClass="btn-accion" onclick="btnAgregarProducto_Click" />

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</asp:Content>
