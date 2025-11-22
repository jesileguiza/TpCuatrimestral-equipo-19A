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
             <asp:Button ID="btnAgregar" runat="server" Text="Alta" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
             <asp:Button ID="btnModificar" runat="server" Text="Modificación" CssClass="btn btn-success" OnClick="btnModificar_Click" />
             <asp:TextBox ID="txtBuscar" runat="server" placeholder="Buscar Cliente..." CssClass="form-control" Style="display: inline-block; width: 200px; margin-left: 10px;" />
             <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
         </div>

         <asp:GridView ID="dgvClientes" runat="server"
             AutoGenerateColumns="False"
             DataKeyNames="ClientesId"
              CssClass="table table-striped table-bordered"
             OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged">
             <Columns>
                 <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="👆" />
                 <asp:BoundField DataField="ClientesId" HeaderText="Id" />
                 <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                 <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                 <asp:BoundField DataField="DNI" HeaderText="DNI" />
                 <asp:BoundField DataField="Email" HeaderText="Email" />
                 <asp:CheckBoxField DataField="Activo" HeaderText="Estado" />
             </Columns>
         </asp:GridView>

        <asp:Button ID="btnEliminarCliente" runat="server" Text="Dar de baja Cliente" CssClass="btn btn-danger mt-3"
            OnClientClick="return confirm('¿Seguro que querés eliminar este Cliente?');"
            OnClick="btnEliminar_Click" />
         <asp:Button ID="btnDarAlta" runat="server" Text="Dar de Alta Cliente" CssClass="btn btn-success mt-3"
            OnClientClick="return confirm('¿Seguro que querés dar de alta este Cliente?');"
            OnClick="btnDarAlta_Click" />

     </div>


    </asp:Content>
