<%@ Page Title="Reporte de Actividad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteDeActvidad.aspx.cs" Inherits="ProyectoProgramacion2.ReporteDeActividad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center text-light mb-4">Reporte de Actividad</h2>

        <div class="bg-dark p-4 rounded shadow-lg">

            <h3 class="text-center text-light mb-4">Resumen por Técnico</h3>
            <div class="table-responsive">
                <asp:GridView ID="gvResumenTecnico" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-bordered table-striped text-center">
                    <Columns>
                        <asp:BoundField DataField="NombreTecnico" HeaderText="Nombre Técnico" SortExpression="NombreTecnico" />
                        <asp:BoundField DataField="Pendientes" HeaderText="Pendientes" SortExpression="Pendientes" />
                        <asp:BoundField DataField="EnProgreso" HeaderText="En Progreso" SortExpression="EnProgreso" />
                        <asp:BoundField DataField="Completadas" HeaderText="Completadas" SortExpression="Completadas" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>


        <div class="bg-dark p-4 rounded shadow-lg mt-5">
            <h3 class="text-center text-light mb-4">Órdenes Completadas</h3>
            <div class="table-responsive">
                <asp:GridView ID="gvOrdenesCompletadas" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-bordered table-striped text-center">
                    <Columns>
                        <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" />
                        <asp:BoundField DataField="ClienteNombre" HeaderText="Cliente" />
                        <asp:BoundField DataField="TecnicoNombre" HeaderText="Técnico" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="FechaCompletada" HeaderText="Fecha Completada" DataFormatString="{0:dd/MM/yyyy}" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
