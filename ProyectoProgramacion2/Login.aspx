<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoProgramacion2.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <style>
        body {
            margin-top: 0; 
        }
        .navbar, .footer {
            display: none; 
        }
    </style>


    <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
        <div class="bg-dark p-4 rounded shadow-lg" style="width: 300px;">
            <h2 class="text-center text-light mb-4">Iniciar Sesión</h2>

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
    </div>
</asp:Content>
