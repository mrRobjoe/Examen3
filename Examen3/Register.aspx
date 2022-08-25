<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Examen3.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/Register.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
        <div id="centrar" class="loginF">
            <div class="header">
                <h1>Registrarse</h1>
                </div>

            <div class="content">
                <p>
                    Usuario:
                    <asp:TextBox Class="texto" ID="tUserr" runat="server" />
                </p>
                <p>
                    Clave:
                    <asp:TextBox Class="texto" ID="tClav" runat="server" />
                </p>                                                 
                <p>
                    Tipo Usuario:         
                    <asp:DropDownList ID="dTipoUser" runat="server" Height="21px">
                        <asp:ListItem Value="1">Regular</asp:ListItem>
                        <asp:ListItem Value="2">Administrador</asp:ListItem>
                    </asp:DropDownList>
                    
                </p>
            </div>
            <div class="footer">
                  <asp:Button Class="button button1" Text="Registrar" ID="bRegistrar" runat="server" OnClick="bRegistrar_Click" />
              
                <p class="cent">
                    <a href="Login.aspx">Iniciar sesión</a>
                </p>
            </div>

        </div>
    </form>
</body>
</html>
