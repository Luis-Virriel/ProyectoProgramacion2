<%@ Page Title="Buscar Orden de Trabajo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buscar.aspx.cs" Inherits="ProyectoProgramacion2.BuscarOrden" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center text-light mb-4">Buscar Orden de Trabajo</h2>

        <div class="bg-dark p-4 rounded shadow-lg">
            <div class="form-group row">
                <label for="txtNumeroOrden" class="col-sm-3 col-form-label text-light font-weight-bold">Número de Orden:</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtNumeroOrden" runat="server" CssClass="form-control bg-secondary text-light" placeholder="Ingrese el número de orden"></asp:TextBox>
                </div>
            </div>

            <div class="form-group text-center mt-4">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar Orden" CssClass="btn btn-danger px-4" OnClick="btnBuscar_Click" />
            </div>
        </div>

        <br />

        <h3 class="text-center text-light mt-5">Resultados de la Búsqueda</h3>
        <div class="table-responsive">
            <asp:GridView ID="gvResultadoBusqueda" runat="server" CssClass="table table-dark table-hover text-center" AutoGenerateColumns="False" DataKeyNames="NumeroOrden">
                <Columns>
                    <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" />
                    <asp:BoundField DataField="ClienteAsociado.Nombre" HeaderText="Cliente" />
                    <asp:BoundField DataField="TecnicoAsignado.Nombre" HeaderText="Técnico Asignado" />
                    <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripción" />
                    <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                </Columns>
            </asp:GridView>
        </div>

        <asp:Label ID="lblError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
    </div>
</asp:Content>
