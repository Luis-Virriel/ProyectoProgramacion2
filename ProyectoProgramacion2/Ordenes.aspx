<%@ Page Title="Órdenes de Trabajo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="ProyectoProgramacion2.Ordenes" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-light mb-4 text-center">Gestión de Órdenes de Trabajo</h2>

        <div class="bg-dark p-4 rounded shadow-lg">
            <div class="form-group row">
                <label for="ddlCliente" class="col-sm-3 col-form-label text-light font-weight-bold">Cliente:</label>
                <div class="col-sm-9">
                    <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control bg-secondary text-light" Required="true"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <label for="ddlTecnico" class="col-sm-3 col-form-label text-light font-weight-bold">Técnico Asignado:</label>
                <div class="col-sm-9">
                    <asp:DropDownList ID="ddlTecnico" runat="server" CssClass="form-control bg-secondary text-light" Required="true"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtDescripcion" class="col-sm-3 col-form-label text-light font-weight-bold">Descripción del Problema:</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control bg-secondary text-light" TextMode="MultiLine" placeholder="Ingrese la descripción del problema"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="rfvDescripcion" ValidationGroup="formRequerido" ControlToValidate="txtDescripcion" CssClass="text-danger small" Text="La descripción es requerida."></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-sm-9 offset-sm-3 text-center">
                    <asp:Button ID="btnCrearOrden" runat="server" Text="Crear Orden" CausesValidation="true" ValidationGroup="formRequerido" CssClass="btn btn-danger" OnClick="btnCrearOrden_Click" />
                </div>
            </div>
            <asp:Label ID="Label1" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
        </div>

        <br />

        <h3 class="text-light text-center mb-4">Lista de Órdenes de Trabajo <asp:Label ID="lblNombre" runat="server"></asp:Label> </h3> 
        <asp:GridView ID="gvOrdenes" runat="server" CssClass="table table-dark table-bordered table-striped text-center" AutoGenerateColumns="False" DataKeyNames="NumeroOrden"
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

        <asp:Label ID="lblError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
    </div>
</asp:Content>
