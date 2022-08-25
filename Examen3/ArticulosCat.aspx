<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaestro.Master" AutoEventWireup="true" CodeBehind="ArticulosCat.aspx.cs" Inherits="Examen3.WebForm2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Css/Buttons.css" rel="stylesheet" />

    <div>
        <p>
            <b>Ingresar:</b>Para ingresar Artículo agregar todos los campos a excepción del código de artículo.<br />
            <b>Borrar:</b>Parar borrar Artículo agregar únicamente el código de artículo.<br />
            <b>Modificar:</b>Para modificar Artículo llenar todos los campos.<br />
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
            Código artículo:
            <asp:TextBox onkeypress="return soloNumeros(event)" ID="tcodArt" runat="server" Style="margin-left:31px" ></asp:TextBox>
        </p>
        <p>
            Descripción artículo:
            <asp:TextBox ID="tdescArt" runat="server" Style="margin-left:5px"></asp:TextBox>
        </p>
        <p>
            Código tipo:
            <asp:TextBox onkeypress="return soloNumeros(event)" ID="tcodTipo" runat="server" Style="margin-left:53px" ></asp:TextBox>
        </p>
        <p>
            Precio artículo:
            <asp:TextBox onkeypress="return soloNumeros(event)" ID="tPrecArt" runat="server" Style="margin-left:37px"></asp:TextBox>
        </p>
        <p>
            Costo artículo:
            <asp:TextBox onkeypress="return soloNumeros(event)" ID="tcostArt" runat="server" Style="margin-left:38px"></asp:TextBox>
        </p>
        <p>
            Cantidad:
            <asp:TextBox onkeypress="return soloNumeros(event)" ID="tCant" runat="server" Style="margin-left:67px"></asp:TextBox>
        </p>
    </div>
    <div>
        <asp:Button class="button button1" ID="bIngresar" runat="server" Text="Ingresar" OnClick="bIngresar_Click" />
        <asp:Button CssClass="button button2" ID="bBorrar" runat="server" Text="Borrar" OnClick="bBorrar_Click" />
        <asp:Button CssClass="button button3" ID="bModificar" runat="server" Text="Modificar" OnClick="bModificar_Click" />
    </div>

    <script src="js/Validaciones.js"></script>

</asp:Content>
