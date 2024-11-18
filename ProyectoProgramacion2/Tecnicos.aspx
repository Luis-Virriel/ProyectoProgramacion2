<%@ Page Title="Tecnicos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="ProyectoProgramacion2.Tecnicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center text-light mb-4">Formulario Técnicos</h2>

        <div class="bg-dark p-4 rounded shadow-lg">
            <div class="form-group row">
                <label for="txtNombre" class="col-sm-3 col-form-label text-light">Nombre:</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control bg-secondary text-light" placeholder="Ingrese su nombre"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ValidationGroup="formRequerido" ControlToValidate="txtNombre" CssClass="text-danger small" Text="El nombre es requerido."></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtApellido" class="col-sm-3 col-form-label text-light">Apellido:</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control bg-secondary text-light" placeholder="Ingrese su apellido"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ValidationGroup="formRequerido" ControlToValidate="txtApellido" CssClass="text-danger small" Text="El apellido es requerido."></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtCI" class="col-sm-3 col-form-label text-light">Cédula de Identidad:</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtCI" TextMode="Number" runat="server" CssClass="form-control bg-secondary text-light" placeholder="Ingrese su cédula"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ValidationGroup="formRequerido" ControlToValidate="txtCI" CssClass="text-danger small" Text="El número de documento es requerido."></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtEspecialidad" class="col-sm-3 col-form-label text-light">Especialidad:</label>
                <div class="col-sm-9">
                    <asp:DropDownList runat="server" ID="txtEspecialidad" class="form-select bg-secondary text-light">
                        <asp:ListItem runat="server" Selected="True">Seleccione la especialidad</asp:ListItem>
                        <asp:ListItem runat="server" Value="ReparacionElectrodomesticos">Reparación de Electrodomésticos</asp:ListItem>
                        <asp:ListItem runat="server" Value="Informatica">Informática</asp:ListItem>
                        <asp:ListItem runat="server" Value="Mecanica">Mecánica</asp:ListItem>
                        <asp:ListItem runat="server" Value="Electricidad">Electricidad</asp:ListItem>
                        <asp:ListItem runat="server" Value="Plomeria">Plomería</asp:ListItem>
                        <asp:ListItem runat="server" Value="Construccion">Construcción</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ValidationGroup="formRequerido" ControlToValidate="txtEspecialidad" CssClass="text-danger small" Text="La especialidad es requerida."></asp:RequiredFieldValidator>
                </div>
            </div>


            <div class="form-group row">
                <div class="col-sm-9 offset-sm-3">
                    <asp:Button ID="Button1" runat="server" Text="Crear Técnico" CausesValidation="true" ValidationGroup="formRequerido" CssClass="btn btn-primary px-4" OnClick="cmdCrearTecnico_Click" />
                </div>
            </div>
        </div>

        <h3 class="text-center text-light mt-5">Lista de Técnicos</h3>
        <div class="table-responsive">
            <asp:GridView ID="gvTecnicos" runat="server" CssClass="table table-dark table-hover text-center" AutoGenerateColumns="False" DataKeyNames="CI"
                OnRowEditing="EditarTecnicos" OnRowUpdating="ActualizarTecnicos" OnRowDeleting="BorrarTecnicos" OnRowCancelingEdit="CanceloEditarTecnicos">
                <Columns>
                    <asp:BoundField DataField="CI" HeaderText="Cédula de Identidad" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:TemplateField HeaderText="Especialidad">
                        <ItemTemplate>
                            <%# Eval("Especialidad") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-select bg-secondary text-light"
                                SelectedValue='<%# Eval("Especialidad") %>'>
                                <asp:ListItem Text="ReparacionElectrodomesticos" Value="ReparacionElectrodomesticos"></asp:ListItem>
                                <asp:ListItem Text="Informatica" Value="Informatica"></asp:ListItem>
                                <asp:ListItem Text="Mecanica" Value="Mecanica"></asp:ListItem>
                                <asp:ListItem Text="Electricidad" Value="Electricidad"></asp:ListItem>
                                <asp:ListItem Text="Plomeria" Value="Plomeria"></asp:ListItem>
                                <asp:ListItem Text="Construccion" Value="Construccion"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>

        <asp:Label ID="lblError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
    </div>
</asp:Content>
