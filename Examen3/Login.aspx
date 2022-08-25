<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Examen3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/LoginEstilos.css" rel="stylesheet" />
</head>
<body>
    <div id="wrapper">

        <form name="login-form" class="login-form" action="#" method="post" runat="server">

            <div class="header">
                <h1>Iniciar Sesión</h1>
                <span>Si no tiene un usuario y clave registrese.</span>
            </div>

            <div class="content">
                <asp:TextBox ID="tUser" name="username" class="input username" runat="server" placeholder="Usuario" />
                <div class="user-icon"></div>
                <asp:TextBox ID="tClave" name="password" Class="input password" runat="server" placeholder="Clave" />
                <div class="pass-icon"></div>
                Tipo Usuario:         
                    <asp:DropDownList ID="dTipoUser" runat="server" Height="21px" OnSelectedIndexChanged="dTipoUser_SelectedIndexChanged">
                        <asp:ListItem Value="1">Regular</asp:ListItem>
                        <asp:ListItem Value="2">Administrador</asp:ListItem>
                    </asp:DropDownList>
            </div>

            <div class="footer">
                <asp:Button ID="bIniciarSesion" type="submit" Text="Iniciar sesión" CssClass="button" runat="server" OnClick="bIniciarSesion_Click" />
                <asp:Button ID="bRegistrar" type="submit" name="submit" Text="Registrarse" Class="register" runat="server" OnClick="bRegistrar_Click" />
            </div>

        </form>

    </div>
    <div class="gradient"></div>
</body>
</html>
