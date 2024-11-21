<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaTecnicos.aspx.cs" Inherits="ProyectoProgramacion2.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {
            margin-top: 0;
        }

        .navbar, .footer {
            display: none;
        }

        .modal-content {
            background-color: #f8f9fa;
            padding: 20px;
        }

        .modal-header {
            background-color: #007bff;
            color: white;
        }

        .modal-footer {
            text-align: right;
        }
    </style>


    <div class="container mt-4">

        <h3 class="text-light text-center mb-4">Lista de Órdenes de Trabajo
            <asp:Label ID="lblNombre" runat="server"></asp:Label>
        </h3>
        <asp:GridView ID="gvOrdenes" runat="server" CssClass="table table-dark table-bordered table-striped text-center" AutoGenerateColumns="False" DataKeyNames="NumeroOrden">
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

                <asp:TemplateField HeaderText="Agregar Comentario">
                    <ItemTemplate>
                        <asp:Button ID="btnAbrirComentario" runat="server" Text="Agregar Comentario" CommandName="AbrirComentario"
                            CommandArgument='<%# Eval("NumeroOrden") %>' CssClass="btn btn-primary" data-bs-toggle="modal" data-bs-target="#comentarioModal" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Mostrar Comentarios">
                    <ItemTemplate>
                        <asp:Button ID="btnMostrarComentarios" runat="server" Text="Mostrar Comentarios" CommandName="MostrarComentarios"
                            CommandArgument='<%# Eval("NumeroOrden") %>' CssClass="btn btn-secondary" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>

        <div class="modal fade" id="comentarioModal" tabindex="-1" aria-labelledby="comentarioModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="comentarioModalLabel">Agregar Comentario</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <textarea id="txtComentario" runat="server" class="form-control" placeholder="Escribe tu comentario"></textarea>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CommandName="AceptarComentario" CssClass="btn btn-success" />
                        <button type="button" class="btn btn-danger" data-bs-dismiss="modal" aria-label="Close">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>

    </div>


</asp:Content>
