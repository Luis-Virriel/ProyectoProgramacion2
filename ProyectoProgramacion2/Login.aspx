<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoProgramacion2.Login" %>

<!DOCTYPE html>

<html class="bg-dark" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="Login.css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    <title>Ingreso Técnico</title>
    <style>
        /* Personalización adicional */
        .login-container {
            max-width: 400px;
            background: rgba(255, 255, 255, 0.1);
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            border-radius: 10px;
            padding: 2rem;
        }
    </style>
</head>
<body class="d-flex justify-content-center align-items-center vh-100 bg-dark text-light">
    <div class="login-container text-center">
        <h2 class="text-primary mb-4">Ingreso Técnico</h2>
        <form id="formLogin" runat="server">
            <div class="mb-3">
                <asp:TextBox ID="txtCI" TextMode="Number" runat="server" CssClass="form-control" placeholder="Ingrese su cédula"></asp:TextBox>
                <span class="fst-italic">(*)</span>
                <asp:RequiredFieldValidator runat="server" ID="rfvCI" ValidationGroup="formRequerido" ControlToValidate="txtCI" CssClass="text-danger small" Text="El número de documento es requerido."></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" placeholder="Ingrese su contraseña"></asp:TextBox>
                <span class="fst-italic">(*)</span>
                <asp:RequiredFieldValidator runat="server" ID="rfvPs" ValidationGroup="formRequerido" ControlToValidate="txtpassword" CssClass="text-danger small" Text="La contraseña es requerida."></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnLogIn" runat="server" Text="Log-In" CausesValidation="true" ValidationGroup="formRequerido" CssClass="btn btn-primary w-100" OnClick="cmdbtnLogIn_Click" />
            </div>
            
        </form>
    </div>
</body>
</html>
