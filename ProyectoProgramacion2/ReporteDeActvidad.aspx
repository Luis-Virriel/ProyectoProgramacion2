<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteDeActvidad.aspx.cs" Inherits="ProyectoProgramacion2.Scripts.ReporteDeActvidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvResumenTecnicos" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="Tecnico" HeaderText="Técnico" />
        <asp:BoundField DataField="TotalOrdenes" HeaderText="Total Órdenes" />
        <asp:BoundField DataField="Pendientes" HeaderText="Pendientes" />
        <asp:BoundField DataField="EnProgreso" HeaderText="En Progreso" />
        <asp:BoundField DataField="Completadas" HeaderText="Completadas" />
    </Columns>
</asp:GridView>

<asp:GridView ID="gvOrdenesCompletadas" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" />
        <asp:BoundField DataField="ClienteNombre" HeaderText="Cliente" />
        <asp:BoundField DataField="TecnicoNombre" HeaderText="Técnico" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
        <asp:BoundField DataField="FechaCompletada" HeaderText="Fecha Completada" DataFormatString="{0:dd/MM/yyyy}" />
    </Columns>
</asp:GridView>


</asp:Content>
