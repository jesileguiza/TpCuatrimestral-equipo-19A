<%@ Page Title="Proveedores" Language="C#" MasterPageFile="~/MasterComercio.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .contenedor {
            width: 80%;
            margin: 40px auto;
            text-align: center;
        }

        .botonera {
            margin-bottom: 20px;
        }

        .botonera asp:single-button {
            margin: 5px;
        }

        .listbox {
            width: 100%;
            height: 250px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <h1>Gestión de Proveedores</h1>

        <div class="botonera">
            <asp:Button ID="btnAlta" runat="server" Text="Alta" CssClass="btn btn-success" OnClick="btnAlta_Click" />
            <asp:Button ID="btnBaja" runat="server" Text="Baja" CssClass="btn btn-success" OnClick="btnBaja_Click" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificación" CssClass="btn btn-success" OnClick="btnModificar_Click" />
            <asp:TextBox ID="txtBuscar" runat="server" placeholder="Buscar proveedor..." CssClass="form-control" Style="display:inline-block; width:200px; margin-left:10px;" />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
        </div>

        <%--<asp:ListBox ID="lstProveedores" runat="server" CssClass="listbox"></asp:ListBox>--%>
        <asp:GridView ID="dgvProveedores" runat="server" CssClass="table"></asp:GridView>
    </div>
</asp:Content>