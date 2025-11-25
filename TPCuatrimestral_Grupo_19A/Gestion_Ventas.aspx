<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterComercio.Master" CodeBehind="Gestion_Ventas.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.Gestion_Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body { font-family: Arial, sans-serif; background-color: #f2f4f7; margin: 0; padding: 0; }
        header { background-color: #28a745; color: white; padding: 20px; text-align: center; }
        main { max-width: 900px; margin: 30px auto; background-color: white; padding: 20px; border-radius: 10px; box-shadow: 0 2px 8px rgba(0,0,0,0.1); }
        h2 { color: #2d89ef; }
        table { width: 100%; border-collapse: collapse; margin-top: 15px; }
        th, td { border: 1px solid #ddd; padding: 10px; text-align: center; }
        th { background-color: #2d89ef; color: white; }
        tr:nth-child(even) { background-color: #f9f9f9; }
        .boton-agregar { margin-top: 10px; background-color: #28a745; color: white; border: none; padding: 8px 15px; border-radius: 5px; cursor: pointer; font-size: 14px; }
        .boton-agregar:hover { background-color: #1e7e34; }
        .formulario-venta { margin-top: 15px; display: none; background-color: #f8f9fa; padding: 15px; border-radius: 5px; }
        .formulario-venta input { margin: 5px; padding: 5px; }
        footer { text-align: center; padding: 15px; background-color: #2d89ef; color: white; margin-top: 30px; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <h1>Panel Principal - Sistema de Ventas</h1>
    </header>

    <main id="contenido">
        <asp:Button ID="btnAgregarVenta" runat="server" Text="➕ Agregar Venta" CssClass="boton-agregar" OnClick="btnAgregarVenta_Click" />

        <asp:GridView ID="dgvVentas" runat="server" AutoGenerateColumns="False" CssClass="tabla-ventas" DataKeyNames="VentaId" OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="👆" HeaderText="Acción" />
                <asp:BoundField DataField="VentaId" HeaderText="ID" />
                <asp:BoundField DataField="ClienteNombre" HeaderText="Cliente" />
                <asp:BoundField DataField="DNI" HeaderText="DNI" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
    </main>

    <footer>
        © 2025 Equipo_19A - Todos los derechos reservados.
    </footer>
</asp:Content>



