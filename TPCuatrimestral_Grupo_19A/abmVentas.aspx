<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterComercio.Master" CodeBehind="abmVentas.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.abmVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tabla-catalogo {
    width: 100%;
    border-collapse: collapse;
    margin-top: 20px;
    font-family: Arial, sans-serif;
}

.tabla-catalogo th, .tabla-catalogo td {
    border: 1px solid #ddd;
    padding: 8px;
    text-align: center;
}

.tabla-catalogo th {
    background-color: #007bff;
    color: white;
    font-weight: 600;
}

.tabla-catalogo tr:nth-child(even) {
    background-color: #f9f9f9;
}

.tabla-catalogo tr:hover {
    background-color: #e2e6ea;
}

.tabla-catalogo td {
    font-size: 0.95em;
}


.tabla-catalogo td:nth-child(4),
.tabla-catalogo td:nth-child(5),
.tabla-catalogo td:nth-child(6) {
    text-align: right;
}


.total-container {
    margin-top: 10px;
    text-align: right;
    font-weight: bold;
    color: #28a745;
    font-size: 1.1em;
}


.btn {
    padding: 5px 12px;
    border-radius: 5px;
    border: none;
    cursor: pointer;
}

.btn-danger {
    background-color: #dc3545;
    color: white;
}

.btn-danger:hover {
    background-color: #c82333;
}

.btn-primary {
    background-color: #007bff;
    color: white;
}

.btn-primary:hover {
    background-color: #0069d9;
}

.btn-success {
    background-color: #28a745;
    color: white;
}

.btn-success:hover {
    background-color: #218838;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="form-title">Agregar / Modificar Venta</h2>

        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="TxtVentaId">ID Venta</label>
                <asp:TextBox ID="TxtVentaId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <label for="ddlCliente">Cliente</label>
                <asp:DropDownList 
                    ID="ddlCliente" 
                    runat="server" 
                    CssClass="form-control"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="btnNuevoCliente" runat="server" Text="Nuevo Cliente" CssClass="btn btn-primary mt-2" OnClick="btnNuevoCliente_Click" />
            </div>
        </div>

        <h3>Agregar Productos</h3>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>Producto</label>
                <asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-3">
                <label>Cantidad</label>
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" Text="1"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <label>&nbsp;</label>
                <asp:Button ID="btnAgregarDetalle" runat="server"
                    Text="Agregar Producto"
                    CssClass="aspNetButton"
                    OnClick="btnAgregarDetalle_Click" />
            </div>
        </div>

        
        <asp:GridView ID="gvDetalles" OnRowCommand="gvDetalles_RowCommand" runat="server" AutoGenerateColumns="False" CssClass="tabla-catalogo">
            <Columns>
                <asp:BoundField DataField="ProductoId" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderText="Ganancia ($)">
                    <ItemTemplate>
                        <%# (Convert.ToDecimal(Eval("PrecioUnitario")) * Convert.ToInt32(Eval("Cantidad")) * Convert.ToDecimal(Eval("Ganancia")) / 100).ToString("0.00") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderText="Quitar">
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnQuitar" Text="X" CommandName="Quitar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        
        <div class="totales-container" style="margin-top:20px; text-align:right;">
            <div style="display:inline-block; padding:15px 20px; background-color:#f8f9fa; border-radius:8px; border:1px solid #ddd;">
                <h4 style="margin:0 0 10px 0; color:#007bff;">Totales</h4>
                <p style="margin:5px 0; font-weight:600;">Total Venta: 
                    <asp:TextBox ID="TxtTotal" runat="server" CssClass="form-control" ReadOnly="true" Style="display:inline-block; width:120px; text-align:right;" />
                </p>
                <p style="margin:5px 0; font-weight:600;">Total Ganancia: 
                    <asp:Label ID="lblTotalGanancia" runat="server" Text="$0.00" Style="display:inline-block; width:120px; text-align:right;"></asp:Label>
                </p>
            </div>
        </div>

        <div class="form-row" style="margin-top:20px;">
            <div class="form-group col-md-6">
                <label for="TxtDNI">DNI</label>
                <asp:TextBox ID="TxtDNI" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <label for="TxtEmail">Email</label>
                <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="TxtFecha">Fecha</label>
                <asp:TextBox ID="TxtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
        </div>

        <hr style="margin-top: 30px; margin-bottom: 25px; border-top: 1px solid #e0e0e0;" />

        <div class="text-center mt-4">
    <asp:Button ID="btnAgregar" runat="server" Text="Guardar" OnClick="btnAgregar_Click" CssClass="btn btn-success mr-2" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary mr-2" />
    
</div>


        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
