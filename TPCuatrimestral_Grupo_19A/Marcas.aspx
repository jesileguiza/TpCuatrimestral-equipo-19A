<%@ Page Title="" Language="C#" MasterPageFile="~/MasterComercio.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.Marcas" %>
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
         <h1>Gestión de Marcas</h1>

         <div class="botonera">
             <asp:Button ID="btnAgregarMarca" runat="server" Text="Alta" CssClass="btn btn-success" OnClick="btnAgregarMarca_Click" />
             <asp:Button ID="btnModificarMarca" runat="server" Text="Modificación" CssClass="btn btn-success" OnClick="btnModificarMarca_Click" />
             <asp:TextBox ID="txtBuscarMarca" runat="server" placeholder="Buscar Marca..." CssClass="form-control" Style="display: inline-block; width: 200px; margin-left: 10px;" />
             <asp:Button ID="btnBuscarMarca" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscarMarca_Click" />
         </div>

         <asp:GridView ID="dgvMarcas" runat="server"
             AutoGenerateColumns="False"
             DataKeyNames="IdMarca"
              CssClass="table table-striped table-bordered"
             OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged">
             <Columns>
                 <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="👆" />
                 <asp:BoundField DataField="IdMarca" HeaderText="Id" />
                 <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                 <asp:CheckBoxField DataField="Activo" HeaderText="Estado" />
             </Columns>
         </asp:GridView>

        <asp:Button ID="btnEliminarMarca" runat="server" Text="Dar de baja Marca" CssClass="btn btn-danger mt-3"
            OnClientClick="return confirm('¿Seguro que querés eliminar esta marca?');"
            OnClick="btnEliminarMarca_Click" />
         <asp:Button ID="btnDarAltaMarca" runat="server" Text="Dar de Alta Marca" CssClass="btn btn-success mt-3"
            OnClientClick="return confirm('¿Seguro que querés dar de alta esta marca?');"
            OnClick="btnDarAltaMarca_Click" />

     </div>
</asp:Content>
