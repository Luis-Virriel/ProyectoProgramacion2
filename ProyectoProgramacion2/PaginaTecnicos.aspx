<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaTecnicos.aspx.cs" Inherits="ProyectoProgramacion2.PaginaTecnicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Técnicos</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* Personalización para el fondo oscuro con bajo contraste */
        body {
            background-color: #212529; /* Fondo oscuro */
            color: #6c757d; /* Texto de bajo contraste */
        }
        .container {
            background-color: #343a40; /* Fondo oscuro de los paneles */
            padding: 20px;
            border-radius: 10px;
        }
        .btn-danger {
            background-color: #dc3545; /* Botón de color rojo */
            border-color: #dc3545;
        }
        .card {
            background-color: #495057; /* Color de fondo más oscuro en el card */
            color: #f8f9fa; /* Texto claro para el card */
        }
        .text-muted {
            color: #adb5bd !important; /* Color de texto ligeramente más claro */
        }
        .form-control {
            background-color: #495057; 
            color: #f8f9fa; 
            border: 1px solid #6c757d; 
        }
    </style>
</head>
<body>
    <div class="container d-flex justify-content-center align-items-center vh-100">
        <form id="form1" runat="server" class="w-100">

            <asp:GridView ID="gvOrdenes" runat="server" AutoGenerateColumns="False"
                OnRowCommand="gvOrdenes_RowCommand" DataKeyNames="NumeroOrden" EmptyDataText="No hay órdenes disponibles."
                CssClass="table table-dark">
                <Columns>
                    <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" SortExpression="NumeroOrden" HeaderStyle-CssClass="text-center" />
                    <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripción" SortExpression="Descripcion" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnAbrirComentario" runat="server" CommandName="AbrirComentario" Text="Abrir Comentarios"
                                CommandArgument='<%# Eval("NumeroOrden") %>' CssClass="btn btn-info" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Panel ID="comentariosSection" runat="server" CssClass="card mt-4" Visible="false">
                <asp:Repeater ID="rptComentarios" runat="server">
                    <ItemTemplate>
                        <p>
                            <%# Eval("Texto") %> - <%# Eval("Fecha", "{0:dd/MM/yyyy HH:mm}") %>
                            <asp:Button ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Container.ItemIndex %>' Text="Editar" CssClass="btn btn-secondary btn-sm" />
                            <asp:Button ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Container.ItemIndex %>' Text="Eliminar" CssClass="btn btn-danger btn-sm" />
                        </p>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:TextBox ID="txtComentario" runat="server" CssClass="form-control" Placeholder="Escribe un comentario"></asp:TextBox>
                <asp:Button ID="btnGuardarComentario" runat="server" Text="Guardar Comentario" CssClass="btn btn-primary mt-2" OnClick="btnGuardarComentario_Click" />
            </asp:Panel>

            <asp:Panel ID="PanelSalir" runat="server" class="mt-3">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-danger" OnClick="btnSalir_Click">Cerrar Sesión</asp:LinkButton>
            </asp:Panel>
        </form>
    </div>

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
</body>
</html>
