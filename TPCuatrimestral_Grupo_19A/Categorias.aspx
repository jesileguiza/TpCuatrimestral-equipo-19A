<%@ Page Title="" Language="C#" MasterPageFile="~/MasterComercio.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.Categorias" %>
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
    <h1>Gestión de Categorias</h1>

    <div class="botonera">
        <asp:Button ID="btnAgregarCategoria" runat="server" Text="Alta" CssClass="btn btn-success" OnClick="btnAgregarCategoria_Click" />
        <asp:Button ID="btnModificarCategoria" runat="server" Text="Modificación" CssClass="btn btn-success" OnClick="btnModificarCategoria_Click" />
        <asp:TextBox ID="txtBuscarCategoria" runat="server" placeholder="Buscar Categoria..." CssClass="form-control" Style="display: inline-block; width: 200px; margin-left: 10px;" />
        <asp:Button ID="btnBuscarCategoria" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscarCategoria_Click" />
    </div>

    <asp:GridView ID="dgvCategorias" runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="IdCategoria"
         CssClass="table table-striped table-bordered"
        OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged">
        <Columns>
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="👆" />
            <asp:BoundField DataField="IdCategoria" HeaderText="Id" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
            <asp:CheckBoxField DataField="Activo" HeaderText="Estado" />
        </Columns>
    </asp:GridView>

   <asp:Button ID="btnEliminarCategoria" runat="server" Text="Dar de baja categoria" CssClass="btn btn-danger mt-3"
       OnClientClick="return confirm('¿Seguro que querés eliminar esta categoria?');"
       OnClick="btnEliminarCategoria_Click" />
    <asp:Button ID="btnDarAltaCategoria" runat="server" Text="Dar de Alta categoria" CssClass="btn btn-success mt-3"
       OnClientClick="return confirm('¿Seguro que querés dar de alta esta categoria?');"
       OnClick="btnDarAltaCategoria_Click" />

</div>
</asp:Content>
