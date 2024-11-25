<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaTecnicos.aspx.cs" Inherits="ProyectoProgramacion2.PaginaTecnicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Técnicos</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-dark text-secondary">
    <div class="container d-flex justify-content-center align-items-center vh-100">
        <form id="form1" runat="server" class="w-100">

            <div class="text-center mb-4">
                <h1 class="text-light">
                    Bienvenido, <asp:Literal ID="litNombreTecnico" runat="server" />
                </h1>
            </div>

            <asp:GridView ID="gvOrdenes" runat="server" AutoGenerateColumns="False"
                OnRowCommand="gvOrdenes_RowCommand" DataKeyNames="NumeroOrden" EmptyDataText="No hay órdenes disponibles."
                CssClass="table table-dark">
                <Columns>
                    <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" SortExpression="NumeroOrden" HeaderStyle-CssClass="text-center" />
                    <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripción" SortExpression="Descripcion" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnAbrirComentario" runat="server" CommandName="AbrirComentario" Text="Abrir Comentarios"
                                CommandArgument='<%# Eval("NumeroOrden") %>' CssClass="btn btn-info" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Panel ID="comentariosSection" runat="server" CssClass="card bg-secondary text-light mt-4" Visible="false">
                <div class="card-body">
                    <asp:Repeater ID="rptComentarios" runat="server" OnItemCommand="rptComentarios_ItemCommand">
                        <ItemTemplate>
                            <p>
                                <%# Eval("Texto") %> - <%# Eval("Fecha", "{0:dd/MM/yyyy HH:mm}") %>
                                <asp:Button ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("ComentarioID") %>'
                                    Text="Editar" CssClass="btn btn-secondary btn-sm" />
                                <asp:Button ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("ComentarioID") %>'
                                    Text="Eliminar" CssClass="btn btn-danger btn-sm" />
                            </p>
                        </ItemTemplate>
                    </asp:Repeater>

                    <asp:TextBox ID="txtComentario" runat="server" CssClass="form-control bg-dark text-light border-secondary" Placeholder="Escribe un comentario"></asp:TextBox>
                    <asp:Button ID="btnGuardarComentario" runat="server" Text="Guardar Comentario" CssClass="btn btn-primary mt-2" OnClick="btnGuardarComentario_Click" />
                </div>
            </asp:Panel>

            <asp:Panel ID="PanelSalir" runat="server" class="mt-5 text-center">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-danger" OnClick="btnSalir_Click">Cerrar Sesión</asp:LinkButton>
            </asp:Panel>
        </form>
    </div>

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
</body>
</html>
