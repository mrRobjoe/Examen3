<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaestro.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Examen3.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="h1Inic-estilo">Bienvenido al inicio de administrador</h1>
    <div class="centrar">
        <img src="images/welcome-sign.jpg" alt="Alternate Text" class="img-acomodo" />
    </div>

</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .h1Inic-estilo{
            text-align:center;
            text-shadow:
                2px 2px 1px #FF3333,
                4px 4px 2px #66B2FF,
                6px 6px 2px #000099;
        }
        .centrar{
            text-align:center;
        }

    </style>
</asp:Content>
