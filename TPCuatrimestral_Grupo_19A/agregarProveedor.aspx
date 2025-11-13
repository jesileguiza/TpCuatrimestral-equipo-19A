<%@ Page Title="" Language="C#" MasterPageFile="~/MasterComercio.Master" AutoEventWireup="true" CodeBehind="agregarProveedor.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.abmProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
     body {
         background-color: #f4f7f9; 
         font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
         color: #333;
     }
     .container.mt-4 {
         max-width: 800px; 
         margin: 40px auto;
         padding: 30px;
         background-color: #ffffff;
         border-radius: 10px; 
         box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
     }
     .form-title {
         color: #007bff; 
         text-align: center;
         margin-bottom: 30px;
         font-size: 2.2em;
         font-weight: 600;
         padding-bottom: 10px;
         border-bottom: 3px solid #f0f0f0; 
     }     
     label {
         font-weight: 600; 
         color: #555;
         margin-bottom: 5px;
         display: block;
     }
     .form-control {
         border-radius: 5px;
         border: 1px solid #ced4da;
         padding: 10px 15px; 
         height: auto;
         transition: border-color 0.2s, box-shadow 0.2s;
     }
     .form-control:focus {
         border-color: #80bdff;
         box-shadow: 0 0 0 0.2rem rgba(0, 123, 255, 0.25); 
     }
     .form-group {
         margin-bottom: 20px; 
     }
     input[type="submit"] {
         padding: 10px 20px;
         font-weight: 600;
         border-radius: 5px;
         transition: background-color 0.3s, transform 0.2s;
         margin-right: 15px; 
         min-width: 120px;
         cursor: pointer;
         border: 1px solid transparent;
     }
     #btnAgregar {
         background-color: #28a745; 
         border-color: #28a745;
         color: white;
     }   
     #btnAgregar:hover {
         background-color: #1e7e34;
         border-color: #1c7430;
         transform: translateY(-1px);
     }
     #btnCancelar {
         background-color: #6c757d; 
         border-color: #6c757d;
         color: white;
     }
     
     #btnCancelar:hover {
         background-color: #5a6268;
         border-color: #545b62;
         transform: translateY(-1px);
     }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="form-title">Agregar Proveedor</h2>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="TxtRazonSocialPROV">Razon Social</label>
                <asp:TextBox ID="TxtRazonSocialPROV" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <label for="TxtNombre">Nombre</label>
                <asp:TextBox ID="TxtNombrePROV" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-6"">
                <label for="TxtCuitPROV">Cuit</label>
                <asp:TextBox ID="TxtCuitPROV" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6"">
                <label for="TxtTelefonoPROV">Telefono</label>
                <asp:TextBox ID="TxtTelefonoPROV" runat="server" CssClass="form-control"></asp:TextBox>
            </div>


        </div>
            <div class="form-row">
            <div class="form-group col-md-6">
                <label for="txtEmailPROV">Email</label>
                <asp:TextBox ID="txtEmailPROV" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <label for="TxtDireccionPROV">Direccion</label>
                <asp:TextBox ID="TxtDireccionPROV" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <label for="TxtLocalidadPROV">Localidad</label>
                <asp:TextBox ID="TxtLocalidadPROV" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>
        
        <hr style="margin-top: 30px; margin-bottom: 25px; border-top: 1px solid #e0e0e0;" />

        <asp:Button ID="btnAgregarPROV" runat="server" Text="Agregar" OnClick="btnAgregarPROV_Click" />
        <asp:Button ID="btnCancelarPROV" runat="server" Text="Cancelar" OnClick="btnCancelarPROV_Click" />
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
    </div>
</asp:Content>
