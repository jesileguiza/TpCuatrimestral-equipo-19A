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
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="header-container">
        <h1>Catálogo de Productos</h1>
    </div>

    <p class="categoria-recordatorio">Recordatorio de Categorías</p>

    <div class="div-categorias">
        <div>1 - Cotillón</div>
        <div>2 - Papelería</div>
        <div>3 - Juguetería</div>
        <div>4 - Repostería</div>
        <div>5 - Librería</div>
    </div>

    <asp:GridView runat="server" ID="dgvProductos" CssClass="tabla-catalogo"></asp:GridView>
    <asp:Button runat="server" ID="btnAgregarProducto" Text="Agregar Nuevo Producto" CssClass="btn-accion" onclick="btnAgregarProducto_Click" />
</asp:Content>
