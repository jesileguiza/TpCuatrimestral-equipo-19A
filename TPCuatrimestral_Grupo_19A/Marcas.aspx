<%@ Page Title="" Language="C#" MasterPageFile="~/MasterComercio.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.Marcas" %>

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

        .filtro-container {
            width: 90%;
            max-width: 650px;
            margin: 0 auto 25px auto;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 15px;
            background-color: #e8f5e9;
            padding: 8px 20px;
            border-radius: 8px;
            border: 1px solid #c5e1a5;
            box-shadow: 0 1px 4px rgba(0,0,0,0.08);
        }

        .input-search-wrapper {
            position: relative;
            width: 100%;
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

        .btn-accion, .btn-limpiar {
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

        .btn-limpiar {
            background-color: #ef5350;
        }

        .btn-limpiar:hover {
            background-color: #d32f2f;
        }

        .btn-accion:hover {
            background-color: #388e3c;
            transform: translateY(-1px);
            box-shadow: 0 4px 8px rgba(0,0,0,0.2);
        }

        .tabla-catalogo {
            width: 90%;
            max-width: 900px;
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

        .tabla-catalogo td {
            padding: 12px 10px;
            border-bottom: 1px solid #eee;
            text-align: left;
        }

        .tabla-catalogo tr:nth-child(even) {
            background-color: #fcfcfc;
        }

        .tabla-catalogo tr:hover {
            background-color: #e8f5e9;
            cursor: pointer;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="header-container">
        <h3>Gestión de Marcas</h3>
    </div>

    <div class="filtro-container">
        <asp:Label Text="Buscar:" runat="server" />
         <asp:DropDownList ID="ddlFiltro" runat="server" CssClass="dropdown-filtro">
         <asp:ListItem Value="IdMarca">IdMarca</asp:ListItem>
        <asp:ListItem Value="Descripcion">Descripcion</asp:ListItem>
   </asp:DropDownList>  
        
        <div class="input-search-wrapper">
            <i class="fa fa-search icono-lupa"></i>
            <asp:TextBox ID="Filtro" runat="server" CssClass="input-search" AutoPostBack="true" OnTextChanged="Filtro_TextChanged" />
        </div>

        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn-limpiar" OnClick="btnLimpiar_Click" />
    </div>


    <asp:GridView ID="dgvMarcas" runat="server" AutoGenerateColumns="False" DataKeyNames="IdMarca" CssClass="tabla-catalogo" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged1" >

        <Columns>
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="👆" />
            <asp:BoundField DataField="IdMarca" HeaderText="ID" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:CheckBoxField DataField="Activo" HeaderText="Activo" />
        </Columns>

    </asp:GridView>


    <asp:Button ID="btnAgregarMarca" runat="server" Text="Agregar Marca" CssClass="btn-accion" OnClick="btnAgregarMarca_Click1" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />

</asp:Content>
