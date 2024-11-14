<%@ Page Title="Órdenes de Trabajo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="ProyectoProgramacion2.Ordenes" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-danger mb-4">Gestión de Ordenes de Trabajo</h2>

        <div>
            <div class="form-group row">
                <label for="ddlCliente" class="col-sm-3 col-form-label font-weight-bold">Cliente:</label>
                <div class="col-sm-9 d-flex align-items-center">
                    <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control" Required="true"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <label for="ddlTecnico" class="col-sm-3 col-form-label font-weight-bold">Técnico Asignado:</label>
                <div class="col-sm-9 d-flex align-items-center">
                    <asp:DropDownList ID="ddlTecnico" runat="server" CssClass="form-control" Required="true"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtDescripcion" class="col-sm-3 col-form-label font-weight-bold">Descripción del Problema:</label>
                <div class="col-sm-9 d-flex align-items-center">
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Ingrese la descripción del problema"></asp:TextBox>
                    <span class="fst-italic">(*)</span>
                    <asp:RequiredFieldValidator runat="server" ID="rfvDescripcion" ValidationGroup="formRequerido" ControlToValidate="txtDescripcion" CssClass="text-danger small" Text="La descripción es requerida."></asp:RequiredFieldValidator>
                </div>
            </div>
            <br />
            <div class="form-group row">
                <div class="col-sm-9 offset-sm-3">
                    <asp:Button ID="btnCrearOrden" runat="server" Text="Crear Orden" CausesValidation="true" ValidationGroup="formRequerido" CssClass="btn btn-danger" OnClick="btnCrearOrden_Click" />
                </div>
            </div>
            <asp:Label ID="Label1" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
        </div>

        <br />

        <h3 class="text-danger">Lista de Órdenes de Trabajo</h3>
        <asp:GridView ID="gvOrdenes" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" DataKeyNames="NumeroOrden"
            OnRowEditing="gvOrdenes_RowEditing" OnRowUpdating="gvOrdenes_RowUpdating" OnRowCancelingEdit="gvOrdenes_RowCancelingEdit">
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
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control" SelectedValue='<%# Eval("Estado") %>'>
                            <asp:ListItem Text="Pendiente" Value="Pendiente"></asp:ListItem>
                            <asp:ListItem Text="EnProgreso" Value="EnProgreso"></asp:ListItem>
                            <asp:ListItem Text="Completada" Value="Completada"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Comentarios">
                    <ItemTemplate>
                        <asp:Label ID="lblComentarios" runat="server"
                            Text='<%# string.Join(", ", (Eval("Comentarios") as List<ProyectoProgramacion2.Models.Comentario>).Select(c => c.Texto)) %>'></asp:Label>
                        <asp:Button type="button" runat="server" class="btn btn" data-bs-toggle="modal" Text="Agregar" data-bs-target="#exampleModal"></asp:Button>
                        
                        <!-- Modal -->
                        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h1 class="modal-title fs-5" id="exampleModalLabel">Agrege su Comentario</h1>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="mb-3 row">
                                            <label for="ddlTecnico" class="col-sm-2 col-form-label">Seleccione Tecnico</label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="ddlTecnico" runat="server" CssClass="form-control" Required="true"></asp:DropDownList>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvComentario" ValidationGroup="comentarioRequerido" ControlToValidate="ddlTecnico" CssClass="text-danger small"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="mb-3 row">
                                            <label for="txtComentario" class="col-sm-2 col-form-label">Comentario</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox runat="server" TextMode="MultiLine" class="form-control" ID="txtComentario"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                                        <asp:Button Text="Guardar Comentario" ValidationGroup="comentarioRequerido" CausesValidation="true" runat="server" class="btn btn-primary"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>

        <asp:Label ID="lblError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
    </div>
</asp:Content>
