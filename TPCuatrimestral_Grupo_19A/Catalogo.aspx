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

    <asp:Button ID="btnAgregar" runat="server" CssClass="boton-agregar" Text="➕ Agregar Producto" OnClick="btnAgregar_Click" />

    <asp:GridView 
        ID="dgvCatalogo" 
        runat="server" 
        AutoGenerateColumns="False" 
        CssClass="tabla-catalogo">
        <Columns>
            <asp:BoundField DataField="Marca" HeaderText="Marca" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Stock" HeaderText="Stock" />
        </Columns>
    </asp:GridView>
</asp:Content>
