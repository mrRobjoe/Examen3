<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaestro.Master" AutoEventWireup="true" CodeBehind="ReporteArti.aspx.cs" Inherits="Examen3.WebForm5" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <p>Reporte de articulos</p>
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
        <p>Reporte de fondos</p>
    </div>

    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="codigoArticulo" DataSourceID="SqlDataSource1">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="codigoArticulo" HeaderText="codigoArticulo" InsertVisible="False" ReadOnly="True" SortExpression="codigoArticulo" />
            <asp:BoundField DataField="DescripcionArticulo" HeaderText="DescripcionArticulo" SortExpression="DescripcionArticulo" />
            <asp:BoundField DataField="cantidad" HeaderText="cantidad" SortExpression="cantidad" />
            <asp:BoundField DataField="precioArticulo" HeaderText="precioArticulo" SortExpression="precioArticulo" />
            <asp:BoundField DataField="Total ventas" HeaderText="Total ventas" ReadOnly="True" SortExpression="Total ventas" />
            <asp:BoundField DataField="Total Costos" HeaderText="Total Costos" ReadOnly="True" SortExpression="Total Costos" />
            <asp:BoundField DataField="Ganancias" HeaderText="Ganancias" ReadOnly="True" SortExpression="Ganancias" />
        </Columns>
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




    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ControlInventarioConnectionString %>" SelectCommand="select codigoArticulo, DescripcionArticulo, cantidad, precioArticulo,
	cantidad * precioArticulo as [Total ventas],
	cantidad * costoArticulo as [Total Costos],
	(cantidad * precioArticulo) - (cantidad * costoArticulo) as [Ganancias]
	from MaeArticulos"></asp:SqlDataSource>




</asp:Content>
