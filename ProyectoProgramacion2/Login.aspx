<button type="submit" class="btn btn-primary mb-3">Confirm identity</button><%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoProgramacion2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="Login.css" />
    <title></title>
</head>
<body>
    <div class="container mt-4">
        <h2 class="text-primary mb-4">Ingreso Tecnico</h2>



        <div class="form-group row">
            <label for="txtCI" class="col-sm-3 col-form-label font-weight-bold">Cédula de Identidad:</label>
            <div class="col-sm-9 d-flex align-items-center">
                <asp:TextBox ID="txtCI" TextMode="Number" runat="server" CssClass="form-control" placeholder="Ingrese su cédula"></asp:TextBox>
                <span class="fst-italic">(*)</span>
                <asp:RequiredFieldValidator runat="server" ID="rfvCI" ValidationGroup="formRequerido" ControlToValidate="txtCI" CssClass="text-danger small" Text="El número de documento es requerido."></asp:RequiredFieldValidator>
            </div>
        </div>




        <br />
        <div class="form-group row">
            <div class="col-sm-9 offset-sm-3">
                <asp:Button ID="btnLogIn" runat="server" Text="Log-In" CausesValidation="true" ValidationGroup="formRequerido" CssClass="btn btn-primary" OnClick="cmdbtnLogIn_Click" />
            </div>
            <div class="col-sm-9 offset-sm-3">
                <asp:Button ID="btnAdmin" runat="server" Text="Admin"  CssClass="btn" OnClick="cmdbtnAdmin_Click" />
            </div>
        </div>
        
    </div>



    <asp:Label ID="lblError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
    </div>
</body>
</html>
