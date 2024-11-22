<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaTecnicos.aspx.cs" Inherits="ProyectoProgramacion2.PaginaTecnicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            margin-top: 0;
        }

        .navbar, .footer {
            display: none;
        }

        .container {
            padding-top: 30px;
        }

        .table thead {
            background-color: #007bff;
            color: white;
        }

        .btn-primary {
            background-color: #28a745;
            border-color: #28a745;
        }

        .btn-primary:hover {
            background-color: #218838;
            border-color: #1e7e34;
        }

        .comentarios-section {
            margin-top: 20px;
        }

        .comentario-item {
            margin-bottom: 10px;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
            background-color: #f8f9fa;
        }

        .comentario-item p {
            margin: 0;
        }

        .comentario-actions {
            margin-top: 10px;
        }

        .comentario-actions button {
            margin-right: 5px;
        }

    </style>

    <div class="container">
        <h3 class="text-center mb-4">Lista de Órdenes de Trabajo</h3>

        <asp:GridView ID="gvOrdenes" runat="server" CssClass="table table-bordered table-striped text-center" AutoGenerateColumns="False" DataKeyNames="NumeroOrden" OnRowCommand="gvOrdenes_RowCommand">
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
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select bg-secondary text-light">
                            <asp:ListItem Text="Pendiente" Value="Pendiente"></asp:ListItem>
                            <asp:ListItem Text="EnProgreso" Value="EnProgreso"></asp:ListItem>
                            <asp:ListItem Text="Completada" Value="Completada"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnAbrirComentario" runat="server" Text="Agregar Comentario" CommandName="AbrirComentario" CommandArgument='<%# Eval("NumeroOrden") %>' CssClass="btn btn-primary" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>

        <div id="comentariosContainer">
            <asp:Repeater ID="rptComentarios" runat="server">
                <ItemTemplate>
                    <div class="comentarios-section">
                        <h5>Comentarios:</h5>
                        <div class="comentario-item">
                            <p><%# Eval("Texto") %></p>
                            <div class="comentario-actions">
                                <asp:Button ID="btnEditarComentario" runat="server" Text="Editar" CommandName="EditarComentario" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-warning btn-sm" />
                                <asp:Button ID="btnEliminarComentario" runat="server" Text="Eliminar" CommandName="EliminarComentario" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger btn-sm" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div class="comentarios-section">
            <h5>Agregar Comentario:</h5>
            <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Escribe tu comentario"></asp:TextBox>
            <asp:Button ID="btnGuardarComentario" runat="server" Text="Guardar Comentario" CssClass="btn btn-primary mt-2" OnClick="btnGuardarComentario_Click" />
        </div>

        <br />
        <asp:LinkButton ID="btnSalir" runat="server" CssClass="btn btn-danger" OnClick="btnSalir_Click">Cerrar Sesión</asp:LinkButton>
    </div>
</asp:Content>
