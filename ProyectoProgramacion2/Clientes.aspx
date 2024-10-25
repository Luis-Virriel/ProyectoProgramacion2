<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="ProyectoProgramacion2.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <asp:Label ID="Label1" runat="server" Text="Nombre :"></asp:Label><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <asp:Label runat="server" Font-Italic="True">(*)</asp:Label>
    <asp:RequiredFieldValidator runat="server" ID="rfvNombre" ControlToValidate="txtNombre" ForeColor="Red" Text="El nombre es requerido."></asp:RequiredFieldValidator>
    <br />

    <asp:Label ID="Label2" runat="server" Text="Apellido :"></asp:Label><asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
    <asp:Label runat="server" Font-Italic="True">(*)</asp:Label>
    <asp:RequiredFieldValidator runat="server" ID="rfvApellido" ControlToValidate="txtApellido" ForeColor="Red" Text="El apellido es requerido."></asp:RequiredFieldValidator>
    <br />

    <asp:Label ID="Label3" runat="server" Text="Cédula de Identidad :"></asp:Label><asp:TextBox ID="txtCI" TextMode="Number" runat="server"></asp:TextBox>
    <asp:Label runat="server" Font-Italic="True">(*)</asp:Label>
    <asp:RequiredFieldValidator runat="server" ID="rfvCI" ControlToValidate="txtCI" ForeColor="Red" Text="El número de documento es requerido."></asp:RequiredFieldValidator>
    <br />

    <asp:Label ID="Label4" runat="server" Text="Dirección :"></asp:Label><asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
    <br />

    <asp:Label ID="Label5" runat="server" Text="Teléfono :"></asp:Label><asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>





    <br />
    <br />

    <asp:DropDownList ID="cboClientes" runat="server"></asp:DropDownList>
    <asp:Button ID="cmdVer" runat="server" Text="Crear Cliente" OnClick="cmdVer_Click" />
    <br />
    <br />
    <asp:GridView runat="server" ID="gvClientes" Width="90%" BorderWidth="1" BorderColor="Blue"></asp:GridView>
    <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
    <br />





</asp:Content>
