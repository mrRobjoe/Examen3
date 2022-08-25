<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaestro.Master" AutoEventWireup="true" CodeBehind="UsuariosCat.aspx.cs" Inherits="Examen3.WebForm3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/Buttons.css" rel="stylesheet" />

    <div>
        <p>
            <b>Ingresar:</b>Para ingresar a Usuario agregar todos los campos a excepción de código de usuario.<br />
            <b>Borrar:</b>Parar borrar a Usuario agregar únicamente el código de usuario.<br />
            <b>Modificar:</b>Para modificar a Usuario llenar todos los campos.<br />
        </p>
    </div>

    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>

    <div>
        <p>
            Código Usuario:
            <asp:TextBox onkeypress="return soloNumeros(event)" ID="tcodUser" runat="server" Style="margin-left:8px"></asp:TextBox>
        </p>
        <p>
            Nombre usuario:
            <asp:TextBox ID="tnomUser" runat="server" Style="margin-left:5px"></asp:TextBox>
        </p>
        <p>
            Clave usuario:
            <asp:TextBox ID="tclavUser" runat="server" Style="margin-left:20px"></asp:TextBox>
        </p>
        <p>
            Tipo Usuario:         
                    <asp:DropDownList ID="dTipoUs" runat="server" Height="21px" Style="margin-left:21px">
                        <asp:ListItem Value="1">Regular</asp:ListItem>
                        <asp:ListItem Value="2">Administrador</asp:ListItem>
                    </asp:DropDownList>
        </p>
    </div>

    <div>
        <asp:Button class="button button1" ID="bIngresar" runat="server" Text="Ingresar" OnClick="bIngresar_Click" />
        <asp:Button CssClass="button button2" ID="bBorrar" runat="server" Text="Borrar" OnClick="bBorrar_Click" />
        <asp:Button CssClass="button button3" ID="bModificar" runat="server" Text="Modificar" OnClick="bModificar_Click" />
    </div>

    <script src="js/Validaciones.js"></script>
</asp:Content>
