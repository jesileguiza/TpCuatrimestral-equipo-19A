<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterComercio.Master" CodeBehind="Gestion_Ventas.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.Gestion_Ventas"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style>
    body {
        font-family: Arial, sans-serif;
        background-color: #f2f4f7;
        margin: 0;
        padding: 0;
    }

    header {
        background-color: #28a745;
        color: white;
        padding: 20px;
        text-align: center;
    }

    nav {
        display: flex;
        justify-content: center;
        background-color: #28a745;
        padding: 10px;
        gap: 15px;
    }

    nav button {
        background-color: #28a745;
        color: white;
        border: none;
        padding: 10px 20px;
        font-size: 16px;
        border-radius: 6px;
        cursor: pointer;
        transition: 0.3s;
    }

    nav button:hover {
        background-color: #1b5ebc;
    }

    main {
        max-width: 900px;
        margin: 30px auto;
        background-color: white;
        padding: 20px;
        border-radius: 10px;
        box-shadow: 0 2px 8px rgba(0,0,0,0.1);
    }

    h2 {
        color: #2d89ef;
    }

    table {
        width: 100%;
        border-collapse: collapse;
        margin-top: 15px;
    }

    th, td {
        border: 1px solid #ddd;
        padding: 10px;
        text-align: center;
    }

    th {
        background-color: #2d89ef;
        color: white;
    }

    tr:nth-child(even) {
        background-color: #f9f9f9;
    }

    .boton-agregar {
        margin-top: 10px;
        background-color: #28a745;
        color: white;
        border: none;
        padding: 8px 15px;
        border-radius: 5px;
        cursor: pointer;
        font-size: 14px;
    }

    .boton-agregar:hover {
        background-color: #1e7e34;
    }

    .formulario {
        margin-top: 15px;
        display: none;
        background-color: #f8f9fa;
        padding: 15px;
        border-radius: 5px;
    }

    .formulario input {
        margin: 5px;
        padding: 5px;
    }

    footer {
        text-align: center;
        padding: 15px;
        background-color: #2d89ef;
        color: white;
        margin-top: 30px;
    }

</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   



          <header>
        <h1>Panel Principal - Sistema de Ventas</h1>
    </header>

       

         <main id="contenido">
        <!-- Sección principal -->
        <section id="inicio">

             

            <asp:Button ID="btnMostrarFormulario" runat="server" Text="➕ Agregar Venta" CssClass="boton-agregar" OnClick="btnMostrarFormulario_Click"/>

            <asp:Panel ID="PnlFormularioVenta" runat="server" Visible="false" CssClass="formulario-venta">
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="false"></asp:Label>  
                
                <h3>Agregar Venta</h3>

         <asp:Label Text="Cliente: " AssociatedControlID="txtCliente" runat="server" />
         <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
           <br />

          <asp:Label Text="DNI: " AssociatedControlID="txtDNI" runat="server" />
        <asp:TextBox ID="txtDNI" runat="server"></asp:TextBox>
        <br />

         <asp:Label Text="Email: " AssociatedControlID="txtEmail" runat="server" />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />


        <asp:Label Text="Fecha:" AssociatedControlID="txtFecha" runat="server" />
        <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
        <br />

        <asp:Label Text="Total:" AssociatedControlID="txtTotal" runat="server" />
        <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
        <br />

     <asp:Button ID="btnGuardarVenta" runat="server" Text="Guardar" OnClick="btnGuardarVenta_Click" CssClass="btn-guardar" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn-cancelar" />
        </asp:Panel>

        <hr />

            <h2>Lista de Ventas</h2>
            <asp:GridView ID="dgvVentas" runat="server" CssClass="table" ></asp:GridView>

           </section>
           
    </main>

    <footer>
        © 2025 Equipo_19A - Todos los derechos reservados.
    </footer>

        <script>
            // Mostrar secciones
            function mostrarSeccion(id) {
                document.querySelectorAll("main section").forEach(sec => sec.style.display = "none");
                document.getElementById(id).style.display = "block";
            }

            // Mostrar formulario
            function mostrarFormulario(idForm) {
                const form = document.getElementById(idForm);
                form.style.display = (form.style.display === "none" || form.style.display === "") ? "block" : "none";
            }

            // Agregar nueva venta
            function agregarVenta() {
                const id = document.getElementById("idVenta").value;
                const cliente = document.getElementById("clienteVenta").value;
                const fecha = document.getElementById("fechaVenta").value;
                const total = document.getElementById("totalVenta").value;

                if (!id || !cliente || !fecha || !total) {
                    alert("Por favor, completa todos los campos de la venta.");
                    return;
                }

                const tabla = document.getElementById("tablaVentas");
                const fila = tabla.insertRow(-1);
                fila.insertCell(0).innerText = id;
                fila.insertCell(1).innerText = cliente;
                fila.insertCell(2).innerText = fecha;
                fila.insertCell(3).innerText = `$${parseFloat(total).toFixed(2)}`;

                document.getElementById("formVenta").reset;
                mostrarFormulario('formVenta');
            }

            // Agregar nueva compra
            function agregarCompra() {
                const id = document.getElementById("idCompra").value;
                const proveedor = document.getElementById("proveedorCompra").value;
                const fecha = document.getElementById("fechaCompra").value;
                const total = document.getElementById("totalCompra").value;

                if (!id || !proveedor || !fecha || !total) {
                    alert("Por favor, completa todos los campos de la compra.");
                    return;
                }

                const tabla = document.getElementById("tablaCompras");
                const fila = tabla.insertRow(-1);
                fila.insertCell(0).innerText = id;
                fila.insertCell(1).innerText = proveedor;
                fila.insertCell(2).innerText = fecha;
                fila.insertCell(3).innerText = `$${parseFloat(total).toFixed(2)}`;

                document.getElementById("formCompra").reset;
                mostrarFormulario('formCompra');
            }
        </script>






</asp:Content>


