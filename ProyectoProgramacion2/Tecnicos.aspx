<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="ProyectoProgramacion2.Tecnicos" %>
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

 <asp:Label ID="Label4" runat="server" Text="Especialidad :"></asp:Label><asp:DropDownList ID ="dEspecialidad" runat="server">
     <asp:ListItem>Refrigeracion</asp:ListItem>
     <asp:ListItem>Plomero</asp:ListItem>
 </asp:DropDownList>
    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="<dEspecialidad" ForeColor="Red" Text="La especialidad es requerida."></asp:RequiredFieldValidator>
 <br />

    <br />
<br />

<asp:DropDownList ID="cboTecnicos" runat="server"></asp:DropDownList>
<asp:Button ID="cmdVer" runat="server" Text="Crear Tecnico" OnClick="cmdVer_Click" />
    <br />
    <br />
<asp:GridView runat="server" ID="gvTecnicos" Width="90%" BorderWidth="1" BorderColor="Blue"></asp:GridView>
    <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
<br />
</asp:Content>
