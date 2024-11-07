<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoProgramacion2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <main>
        <section class="row">
            <h1>Gestión de Órdenes de Trabajo</h1>
            <p class="lead">Bienvenido al sistema de gestión de órdenes de trabajo de servicios técnicos.</p>
        </section>

        <div class="row mt-4">
            <section class="row-md-4">
                <h2>Órdenes Pendientes</h2>
                <p>
                    Total de órdenes en estado "Pendiente":
                    <asp:Label ID="lblPendingCount" runat="server"></asp:Label>
                </p>
                <asp:Button runat="server" ID="btnPendientes" Text="Ver Detalles..." class="btn btn-outline-secondary" OnClick="btnPendientes_Click"></asp:Button>
                <asp:GridView ID="gvOrdenesPendientes" Visible="false" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" DataKeyNames="NumeroOrden">
                    <Columns>
                        <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" />
                        <asp:BoundField DataField="ClienteAsociado.Nombre" HeaderText="Cliente" />
                        <asp:BoundField DataField="TecnicoAsignado.Nombre" HeaderText="Técnico Asignado" />
                        <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripción" />
                        <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <%# Eval("Estado") %>
                            </ItemTemplate>


                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comentarios">
                            <ItemTemplate>
                                <asp:Label ID="lblComentarios" runat="server"
                                    Text='<%# string.Join(", ", (Eval("Comentarios") as List<ProyectoProgramacion2.Models.Comentario>).Select(c => c.Texto)) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </section>

            <section class="row-md-4">
                <h2>Órdenes En Progreso</h2>
                <p>
                    Total de órdenes en estado "En Progreso":
                    <asp:Label ID="lblInProgressCount" runat="server"></asp:Label>
                </p>
                <asp:Button runat="server" ID="btnEnProgreso" Text="Ver Detalles..." class="btn btn-outline-secondary" OnClick="btnEnProgreso_Click"></asp:Button>
                <asp:GridView ID="gvOrdenesEnProgreso" Visible="false" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" DataKeyNames="NumeroOrden">
                    <Columns>
                        <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" />
                        <asp:BoundField DataField="ClienteAsociado.Nombre" HeaderText="Cliente" />
                        <asp:BoundField DataField="TecnicoAsignado.Nombre" HeaderText="Técnico Asignado" />
                        <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripción" />
                        <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <%# Eval("Estado") %>
                            </ItemTemplate>


                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comentarios">
                            <ItemTemplate>
                                <asp:Label ID="lblComentarios" runat="server"
                                    Text='<%# string.Join(", ", (Eval("Comentarios") as List<ProyectoProgramacion2.Models.Comentario>).Select(c => c.Texto)) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </section>

            <section class="row-md-4">
                <h2>Órdenes Completadas</h2>
                <p>
                    Total de órdenes en estado "Completada":
                    <asp:Label ID="lblCompletedCount" runat="server"></asp:Label>
                </p>
                <asp:Button runat="server" ID="btnCompletadas" Text="Ver Detalles..." class="btn btn-outline-secondary" OnClick="btnCompletadas_Click"></asp:Button>
                <asp:GridView ID="gvOrdenesCompletadas" Visible="false" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" DataKeyNames="NumeroOrden">
                    <Columns>
                        <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" />
                        <asp:BoundField DataField="ClienteAsociado.Nombre" HeaderText="Cliente" />
                        <asp:BoundField DataField="TecnicoAsignado.Nombre" HeaderText="Técnico Asignado" />
                        <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripción" />
                        <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <%# Eval("Estado") %>
                            </ItemTemplate>


                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comentarios">
                            <ItemTemplate>
                                <asp:Label ID="lblComentarios" runat="server"
                                    Text='<%# string.Join(", ", (Eval("Comentarios") as List<ProyectoProgramacion2.Models.Comentario>).Select(c => c.Texto)) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </section>
        </div>
    </main>


</asp:Content>
