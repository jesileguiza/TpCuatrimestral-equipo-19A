<%@ Page Title="" Language="C#" MasterPageFile="~/MasterComercio.Master" AutoEventWireup="true" CodeBehind="detalleVentas.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.DetalleVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body { font-family: Arial, sans-serif; background-color: #f2f4f7; }
        .tabla-detalle { width: 100%; border-collapse: collapse; margin-top: 20px; }
        .tabla-detalle th, .tabla-detalle td { border: 1px solid #ddd; padding: 8px; text-align: center; }
        .tabla-detalle th { background-color: #007bff; color: white; }
        .titulo { font-size: 1.8em; margin-top: 20px; color: #007bff; text-align: center; }
        .btn-volver { margin-top: 15px; padding: 8px 12px; background-color: #6c757d; color: white; border: none; border-radius: 5px; cursor: pointer; }
        .btn-volver:hover { background-color: #5a6268; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2 class="titulo">Detalle de Venta</h2>
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
        <asp:GridView ID="gvDetalleVenta" runat="server" AutoGenerateColumns="False" CssClass="tabla-detalle">
            <Columns>
                <asp:BoundField DataField="ProductoId" HeaderText="ID Producto" />
                <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="btnVolver" runat="server" Text="← Volver" CssClass="btn-volver" OnClick="btnVolver_Click" />
    </div>
</asp:Content>
