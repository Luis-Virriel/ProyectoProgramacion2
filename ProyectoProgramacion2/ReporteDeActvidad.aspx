<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteDeActividad.aspx.cs" Inherits="ProyectoProgramacion2.ReporteDeActividad"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvResumenTecnico" runat="server" AutoGenerateColumns="False">
        <Columns>
        <asp:BoundField DataField="NombreTecnico" HeaderText="Nombre Técnico" SortExpression="NombreTecnico" />
        <asp:BoundField DataField="Pendientes" HeaderText="Pendientes" SortExpression="Pendientes" />
        <asp:BoundField DataField="EnProgreso" HeaderText="En Progreso" SortExpression="EnProgreso" />
        <asp:BoundField DataField="Completadas" HeaderText="Completadas" SortExpression="Completadas" />
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
