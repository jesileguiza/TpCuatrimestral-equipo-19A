<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login TPCuatrimestral</title>

<style>
    body {
        text-align: center;
        height: 100vh; 
        display: flex;
        align-items: center;
        justify-content: center;
        font-family: Arial, sans-serif;
        background-color: #f3f3f3;
        margin: 0;
        padding: 20px;
    }
    .login{
        background-color: #7a42f4;
        color:white;
        padding: 30px 40px;
        border-radius: 12px;
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);
        text-align: center;
        width: 320px;
    }
    .login-box {
        background-color: #7a42f4;
        color: white;
        padding: 30px 40px;
        border-radius: 12px;
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        text-align: center;
        width: 300px;
        margin: auto;
    }



    .login-box input[type="text"], .login-box input[type="password"] {
        width: 100%;
        padding: 10px;
        margin: 10px 0;
        border: none;
        border-radius: 5px;
        box-sizing: border-box;
    }

    .login-box button {
        background-color: #7a42f4;
        text-align: right;
        color: white;
        padding: 10px 20px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        width: 100%;
    }
    .login-box input[type="submit"]:hover {
        background-color: #4b25a8;
    }



</style>


</head>
<body >
    <form id="form1" runat="server">
        <div class="login-box">
        <div > 
            <h1>Bienvenido, Ingrese usuario y contraseña</h1>
        </div>
        <div>
            <asp:Label ID="Usu" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="TxtUsuario" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Contr" runat="server" Text="Contraseña: "></asp:Label>
    <asp:TextBox ID="TxtContra" runat="server" ></asp:TextBox>
        </div>


        <div> 
            <asp:Button ID="Ingreso" runat="server" Text="Ingresar"  /> 
        </div>
            </div>
    </form>
</body>
</html>

