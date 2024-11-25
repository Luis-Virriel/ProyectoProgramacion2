<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoProgramacion2.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            margin-top: 0;
        }

        .navbar, .footer {
            display: none;
        }

        .login-container {
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .login-box {
            display: flex;
            justify-content: space-between;
            align-items: center;
            background-color: #343a40;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            width: 700px;
            padding: 20px;
        }

        .login-form {
            width: 50%;
            padding: 20px;
        }

        .login-logo {
            width: 45%;
            display: flex;
            justify-content: center;
            align-items: center;
        }

            .login-logo img {
                max-width: 100%;
                height: auto;
                border-radius: 10px;
            }
    </style>

    <div class="login-container">
        <div class="login-box">

            <div class="login-form">
                <h2 class="text-light text-center mb-4">Bienvenidos a DanLuis Solutions</h2>

                <div class="form-group">
                    <label for="txtUsername" class="col-form-label text-light">Usuario:</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control bg-secondary text-light" placeholder="Ingrese su usuario" />
                </div>

                <div class="form-group">
                    <label for="txtPassword" class="col-form-label text-light">Contraseña:</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control bg-secondary text-light" placeholder="Ingrese su contraseña" />
                </div>

                <div class="form-group text-center mt-4">
                    <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary px-4" OnClick="btnLogin_Click" />
                </div>

                <div class="form-group text-center">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
                </div>
            </div>

            <div class="login-logo">
                <div class="login-logo">
                    <img src="../Imagenes/MITAD_BARBA.png" alt="Logo DanLuis Solutions" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
