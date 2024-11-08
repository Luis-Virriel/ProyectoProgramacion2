<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="ProyectoProgramacion2.Tecnicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-success mb-4" textcolor="Green">Formulario Técnicos</h2>

        <div>
            <div class="form-group row">
                <label for="txtNombre" class="col-sm-3 col-form-label font-weight-bold">Nombre:</label>
                <div class="col-sm-9 d-flex align-items-center">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese su nombre"></asp:TextBox>
                    <span class="fst-italic">(*)</span>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ValidationGroup="formRequerido" ControlToValidate="txtNombre" CssClass="text-danger small" Text="El nombre es requerido."></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtApellido" class="col-sm-3 col-form-label font-weight-bold">Apellido:</label>
                <div class="col-sm-9 d-flex align-items-center">
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese su apellido"></asp:TextBox>
                    <span class="fst-italic">(*)</span>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ValidationGroup="formRequerido" ControlToValidate="txtApellido" CssClass="text-danger small" Text="El apellido es requerido."></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtCI" class="col-sm-3 col-form-label font-weight-bold">Cédula de Identidad:</label>
                <div class="col-sm-9 d-flex align-items-center">
                    <asp:TextBox ID="txtCI" TextMode="Number" runat="server" CssClass="form-control" placeholder="Ingrese su cédula"></asp:TextBox>
                    <span class="fst-italic">(*)</span>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ValidationGroup="formRequerido" ControlToValidate="txtCI" CssClass="text-danger small" Text="El número de documento es requerido."></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtEspecialidad" class="col-sm-3 col-form-label font-weight-bold">Especialidad:</label>
                <div class="col-sm-9 d-flex align-items-center">
                    <asp:DropDownList runat="server" ID="txtEspecialidad" class="form-select" aria-label="Default select example">
                        <asp:ListItem runat="server" Selected="True">Seleccione la especialidad </asp:ListItem>
                        <asp:ListItem runat="server" Value="ReparacionElectrodomesticos">Reparacion de Electrodomesticos</asp:ListItem>
                        <asp:ListItem runat="server" Value="Informatica">Informatica</asp:ListItem>
                        <asp:ListItem runat="server" Value="Mecanica">Mecanica</asp:ListItem>
                        <asp:ListItem runat="server" Value="Electricidad">Electricidad</asp:ListItem>
                        <asp:ListItem runat="server" Value="Plomeria">Plomeria</asp:ListItem>
                        <asp:ListItem runat="server" Value="Construccion">Construccion</asp:ListItem>


                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ValidationGroup="formRequerido" ControlToValidate="txtEspecialidad" CssClass="text-danger small" Text="La especialidad es requerida."></asp:RequiredFieldValidator>
                </div>
            </div>
            <br />
            <div class="form-group row">
                <div class="col-sm-9 offset-sm-3">
                    <asp:Button ID="Button1" runat="server" Text="Crear Tecnico" CausesValidation="true" ValidationGroup="formRequerido" CssClass="btn btn-success" OnClick="cmdCrearTecnico_Click" />
                </div>
            </div>




        </div>

        <h3 class="text-primary">Lista de Tecnicos</h3>
        <asp:GridView ID="gvTecnicos" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False"
            DataKeyNames="CI" OnRowEditing="EditarTecnicos" OnRowUpdating="ActualizarTecnicos" OnRowCancelingEdit="CanceloEditarTecnicos"
            OnRowDeleting="BorrarTecnicos">
            <Columns>
                <asp:BoundField DataField="CI" HeaderText="Cédula de Identidad" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:TemplateField HeaderText="Especialidad">
                    <ItemTemplate>
                        <%# Eval("Especialidad") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-control"
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



        <asp:Label ID="lblError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
    </div>














</asp:Content>
