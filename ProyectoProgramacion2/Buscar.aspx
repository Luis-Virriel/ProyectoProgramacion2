<%@ Page Title="Buscar Orden de Trabajo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buscar.aspx.cs" Inherits="ProyectoProgramacion2.BuscarOrden" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-danger mb-4">Buscar Orden de Trabajo</h2>

        <div class="form-group">
            <label for="txtNumeroOrden" class="font-weight-bold">Número de Orden:</label>
            <asp:TextBox ID="txtNumeroOrden" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar Orden" CssClass="btn btn-danger" OnClick="btnBuscar_Click" />
        </div>

        <asp:GridView ID="gvResultadoBusqueda" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" DataKeyNames="NumeroOrden">
            <Columns>
                <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" />
                <asp:BoundField DataField="ClienteAsociado.Nombre" HeaderText="Cliente" />
                <asp:BoundField DataField="TecnicoAsignado.Nombre" HeaderText="Técnico Asignado" />
                <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripción" />
                <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
            </Columns>
        </asp:GridView>

        <asp:Label ID="lblError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
    </div>
</asp:Content>
