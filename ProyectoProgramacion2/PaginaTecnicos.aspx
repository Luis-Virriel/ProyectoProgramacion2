<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaTecnicos.aspx.cs" Inherits="ProyectoProgramacion2.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {
            margin-top: 0;
        }

        .navbar, .footer {
            display: none;
        }
    </style>


    <div class="container mt-4">

        <h3 class="text-light text-center mb-4">Lista de Órdenes de Trabajo <asp:Label ID="lblNombre" runat="server"></asp:Label>
        </h3>
        <asp:GridView ID="gvOrdenes" runat="server" CssClass="table table-dark table-bordered table-striped text-center" AutoGenerateColumns="False" DataKeyNames="NumeroOrden"
             >
            <Columns>
                <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" />
                <asp:BoundField DataField="ClienteAsociado.Nombre" HeaderText="Cliente" />
                <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripción" />
                <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <%# Eval("Estado") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select bg-secondary text-light" SelectedValue='<%# Eval("Estado") %>'>
                            <asp:ListItem Text="Pendiente" Value="Pendiente"></asp:ListItem>
                            <asp:ListItem Text="EnProgreso" Value="EnProgreso"></asp:ListItem>
                            <asp:ListItem Text="Completada" Value="Completada"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>

    </div>


</asp:Content>
