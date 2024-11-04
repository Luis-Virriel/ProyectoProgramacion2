﻿<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="ProyectoProgramacion2.Clientes" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-primary mb-4">Formulario de Clientes</h2>

        <div>
            <div class="form-group row">
                <label for="txtNombre" class="col-sm-3 col-form-label font-weight-bold">Nombre:</label>
                <div class="col-sm-9 d-flex align-items-center">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese su nombre"></asp:TextBox>
                    <span class="fst-italic">(*)</span>
                    <asp:RequiredFieldValidator runat="server" ID="rfvNombre" ValidationGroup="formRequerido" ControlToValidate="txtNombre" CssClass="text-danger small" Text="El nombre es requerido."></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtApellido" class="col-sm-3 col-form-label font-weight-bold">Apellido:</label>
                <div class="col-sm-9 d-flex align-items-center">
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese su apellido"></asp:TextBox>
                    <span class="fst-italic">(*)</span>
                    <asp:RequiredFieldValidator runat="server" ID="rfvApellido" ValidationGroup="formRequerido" ControlToValidate="txtApellido" CssClass="text-danger small" Text="El apellido es requerido."></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtCI" class="col-sm-3 col-form-label font-weight-bold">Cédula de Identidad:</label>
                <div class="col-sm-9 d-flex align-items-center">
                    <asp:TextBox ID="txtCI" TextMode="Number" runat="server" CssClass="form-control" placeholder="Ingrese su cédula"></asp:TextBox>
                    <span class="fst-italic">(*)</span>
                    <asp:RequiredFieldValidator runat="server" ID="rfvCI" ValidationGroup="formRequerido" ControlToValidate="txtCI" CssClass="text-danger small" Text="El número de documento es requerido."></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtDireccion" class="col-sm-3 col-form-label font-weight-bold">Dirección:</label>
                <div class="col-sm-9 d-flex align-items-center">
                    <asp:TextBox ID="txtDireccion" runat="server" ValidationGroup="formRequerido" CssClass="form-control" placeholder="Ingrese su dirección"></asp:TextBox>
                    <br />
                </div>
            </div>

            <div class="form-group row">
                <label for="txtTelefono" class="col-sm-3 col-form-label font-weight-bold">Teléfono:</label>
                <div class="col-sm-9 d-flex align-items-center">
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ingrese su teléfono"></asp:TextBox>
                    <br />
                </div>
            </div>

            <div class="form-group row">
                <label for="txtEmail" class="col-sm-3 col-form-label font-weight-bold">Correo electrónico:</label>
                <div class="col-sm-9 d-flex align-items-center">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Ingrese su correo electrónico"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationGroup="formRequerido" ControlToValidate="txtEmail" ErrorMessage="Ingresa un correo válido" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" CssClass="text-danger small"></asp:RegularExpressionValidator>
                </div>
            </div>
            <br />
            <div class="form-group row">
                <div class="col-sm-9 offset-sm-3">
                    <asp:Button ID="cmdVer" runat="server" Text="Crear Cliente" CausesValidation="true" ValidationGroup="formRequerido" CssClass="btn btn-primary" OnClick="cmdVer_Click" />
                </div>
            </div>
        </div>

        <h3 class="text-primary">Lista de Clientes</h3>
        <asp:GridView ID="gvClientes" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" DataKeyNames="CI"
            AutoGenerateEditButton="True" AutoGenerateDeleteButton="True"
            OnRowEditing="EditarClientes" OnRowUpdating="ActualizarClientes"
            OnRowDeleting="BorrarClientes" OnRowCancelingEdit="CanceloEditarClientes">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="CI" HeaderText="Cédula de Identidad" />
                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Email" HeaderText="Correo Electrónico" />
            </Columns>
        </asp:GridView>

        <asp:Label ID="lblError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
    </div>
</asp:Content>