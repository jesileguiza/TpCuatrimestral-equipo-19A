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
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
         
            <asp:Button ID="btnModificar" runat="server" Text="Modificación" CssClass="btn btn-success" OnClick="btnModificar_Click" />
            <asp:TextBox ID="txtBuscar" runat="server" placeholder="Buscar proveedor..." CssClass="form-control" Style="display:inline-block; width:200px; margin-left:10px;" />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
        </div>

        <%--<asp:ListBox ID="lstProveedores" runat="server" CssClass="listbox"></asp:ListBox>--%>
        <asp:GridView ID="dgvProveedores" runat="server"
            AutoGenerateColumns="False"
            CssClass="table table-striped table-bordered"
            DataKeyNames="IdProveedor"
            OnSelectedIndexChanged="dgvProveedores_SelectedIndexChanged">
            <Columns>

                <asp:CommandField HeaderText="accion" ShowSelectButton="true" SelectText="👆" />


                <asp:BoundField DataField="IdProveedor" HeaderText="ID" />
                <asp:BoundField DataField="RazonSocial" HeaderText="Razón Social" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Cuit" HeaderText="CUIT" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                <asp:BoundField DataField="Localidad" HeaderText="Localidad" />
                <asp:CheckBoxField DataField="Activo" HeaderText="Activo" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar seleccionado" CssClass="btn btn-danger mt-3"
            OnClientClick="return confirm('¿Seguro que querés eliminar este proveedor?');"
            OnClick="btnEliminar_Click" />
        <asp:Button ID="BtnAlta" runat="server" Text="Dar de alta seleccionado" CssClass="btn btn-success mt-3"
            OnClientClick="return confirm('¿Seguro que querés dar de alta este proveedor?');"
            OnClick="btnAlta_Click" />
    </div>


</asp:Content>
