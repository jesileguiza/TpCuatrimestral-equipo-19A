<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.Login" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Login TPCuatrimestral</title>
<style>
    body {
        margin: 0;
        padding: 0;
        height: 100vh;
        font-family: Arial, sans-serif;
        display: flex;
        justify-content: center;
        align-items: center;
        background: url("Imagen/fondo login.png") no-repeat center center fixed;
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
</head>

<body>
    <form id="form1" runat="server">
        <div class="login-box">
            <h1>Bienvenido, ingrese usuario y contraseña</h1>
            
            <div>
                <asp:Label ID="Usu" runat="server" Text="Usuario: "></asp:Label>
                <asp:TextBox ID="TxtUsuario" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="Contr" runat="server" Text="Contraseña: "></asp:Label>
                <asp:TextBox ID="TxtContra" runat="server" TextMode="Password"></asp:TextBox>
            </div>

            <div>
                <asp:Button ID="Ingreso" runat="server" Text="Ingresar" />
            </div>
        </div>
    </form>
</body>
</html>


