<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoProgramacion2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h1 class="text-primary">Gestión de Órdenes de Trabajo</h1>
        <p class="lead">Bienvenido al sistema de gestión de órdenes de trabajo de servicios técnicos.</p>

        <div class="row mt-4">
            <!-- Órdenes Pendientes -->
            <section class="col-md-4">
                <h2 class="text-secondary">Órdenes Pendientes</h2>
                <p>Total de órdenes en estado "Pendiente": 
                    <asp:Label ID="lblPendingCount" runat="server" CssClass="fw-bold text-danger"></asp:Label>
                </p>
                <asp:Button runat="server" ID="btnPendientes" Text="Ver Detalles" CssClass="btn btn-outline-primary mb-3" OnClick="btnPendientes_Click" />
                <div class="shadow-sm p-3 bg-body-tertiary rounded">
                    <div class="table-responsive">
                    <asp:GridView ID="gvOrdenesPendientes" Visible="false" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" DataKeyNames="NumeroOrden">
                        <Columns>
                            <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" />
                            <asp:BoundField DataField="ClienteAsociado.Nombre" HeaderText="Cliente" />
                            <asp:BoundField DataField="TecnicoAsignado.Nombre" HeaderText="Técnico Asignado" />
                            <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripción" />
                            <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate><%# Eval("Estado") %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comentarios">
                                <ItemTemplate>
                                    <asp:Label ID="lblComentarios" runat="server" Text='<%# string.Join(", ", (Eval("Comentarios") as List<ProyectoProgramacion2.Models.Comentario>).Select(c => c.Texto)) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                        </div>
                </div>
            </section>

            <!-- Órdenes En Progreso -->
            <section class="col-md-4">
                <h2 class="text-secondary">Órdenes En Progreso</h2>
                <p>Total de órdenes en estado "En Progreso": 
                    <asp:Label ID="lblInProgressCount" runat="server" CssClass="fw-bold text-warning"></asp:Label>
                </p>
                <asp:Button runat="server" ID="btnEnProgreso" Text="Ver Detalles" CssClass="btn btn-outline-primary mb-3" OnClick="btnEnProgreso_Click" />
                <div class="shadow-sm p-3 bg-body-tertiary rounded">
                    <div class="table-responsive">
                    <asp:GridView ID="gvOrdenesEnProgreso" Visible="false" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" DataKeyNames="NumeroOrden">
                        <Columns>
                            <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" />
                            <asp:BoundField DataField="ClienteAsociado.Nombre" HeaderText="Cliente" />
                            <asp:BoundField DataField="TecnicoAsignado.Nombre" HeaderText="Técnico Asignado" />
                            <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripción" />
                            <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate><%# Eval("Estado") %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comentarios">
                                <ItemTemplate>
                                    <asp:Label ID="lblComentarios" runat="server" Text='<%# string.Join(", ", (Eval("Comentarios") as List<ProyectoProgramacion2.Models.Comentario>).Select(c => c.Texto)) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                        </div>
                </div>
            </section>

            <!-- Órdenes Completadas -->
            <section class="col-md-4">
                <h2 class="text-secondary">Órdenes Completadas</h2>
                <p>Total de órdenes en estado "Completada": 
                    <asp:Label ID="lblCompletedCount" runat="server" CssClass="fw-bold text-success"></asp:Label>
                </p>
                <asp:Button runat="server" ID="btnCompletadas" Text="Ver Detalles" CssClass="btn btn-outline-primary mb-3" OnClick="btnCompletadas_Click" />
                <div class="shadow-sm p-3 bg-body-tertiary rounded">
                    <div class="table-responsive">
                    <asp:GridView ID="gvOrdenesCompletadas" Visible="false" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" DataKeyNames="NumeroOrden">
                        <Columns>
                            <asp:BoundField DataField="NumeroOrden" HeaderText="Número de Orden" />
                            <asp:BoundField DataField="ClienteAsociado.Nombre" HeaderText="Cliente" />
                            <asp:BoundField DataField="TecnicoAsignado.Nombre" HeaderText="Técnico Asignado" />
                            <asp:BoundField DataField="DescripcionProblema" HeaderText="Descripción" />
                            <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate><%# Eval("Estado") %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comentarios">
                                <ItemTemplate>
                                    <asp:Label ID="lblComentarios" runat="server" Text='<%# string.Join(", ", (Eval("Comentarios") as List<ProyectoProgramacion2.Models.Comentario>).Select(c => c.Texto)) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                        </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
