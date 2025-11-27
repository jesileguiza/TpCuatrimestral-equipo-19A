<%@ Page Title="" Language="C#" MasterPageFile="~/MasterComercio.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<style>
    body {
        margin: 0;
        padding: 0;
        height: 100vh;
        font-family: Arial, sans-serif;
        display: flex;
        justify-content: center;
        align-items: center;
        background: url("Imagen/fondo-celeste.jpg") no-repeat center center fixed;
        background-size: cover; 
    }

    .login-box {
        background-color: #3B7A57;
        color: white;
        padding: 40px 45px;
        border-radius: 12px;
        box-shadow: 0 4px 15px rgba(0, 0, 0, 0.4);
        text-align: center;
        width: 320px;
        backdrop-filter: blur(5px); 
    }

    .login-box h1 {
        font-size: 18px;
        margin-bottom: 20px;
    }

    .login-box input[type="text"],
    .login-box input[type="password"] {
        width: 100%;
        padding: 10px;
        margin: 10px 0;
        border: none;
        border-radius: 5px;
        box-sizing: border-box;
    }

    .login-box button,
    .login-box input[type="submit"],
    .login-box asp\:Button {
        background-color: #C46210;
        color: white;
        padding: 10px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        width: 100%;
        font-size: 15px;
        margin-top: 10px;
    }

    .login-box button:hover,
    .login-box input[type="submit"]:hover {
        background-color: #3a1c86;
    }

</style>



    
        <div class="login-box">
            <h1>Bienvenido/a, ingrese usuario y contraseña</h1>
            
            <div>
                <asp:Label ID="Usu" runat="server" Text="Usuario: "></asp:Label>
                <asp:TextBox ID="TxtUsuario" runat="server" ValidateRequestMode="Disabled"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="Contr" runat="server" Text="Contraseña: "></asp:Label>
                <asp:TextBox ID="TxtContra" runat="server" TextMode="Password" ViewStateMode="Enabled"></asp:TextBox>
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <asp:Button ID="Ingreso" runat="server" Text="Ingresar" OnClick="btnIniciarSesion_Click" />
            </div>
        </div>
    

   
</asp:Content>

