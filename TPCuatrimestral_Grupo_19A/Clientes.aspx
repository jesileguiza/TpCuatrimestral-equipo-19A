<%@ Page Language="C#" MasterPageFile="~/MasterComercio.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.Clientes" %>

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
     <h1>Gestión de Clientes</h1>

     <div class="botonera">
         <asp:Button ID="btnAlta" runat="server" Text="Alta" CssClass="btn btn-success" OnClick="btnAlta_Click" />
         <asp:Button ID="btnModificar" runat="server" Text="Modificación" CssClass="btn btn-success" OnClick="btnModificar_Click" />
         <asp:TextBox ID="txtBuscar" runat="server" placeholder="Buscar Cliente..." CssClass="form-control" Style="display:inline-block; width:200px; margin-left:10px;" />
         <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
     </div>

     <asp:ListBox ID="lstClientes" runat="server" CssClass="listbox"></asp:ListBox>
 </div>


    </asp:Content>
