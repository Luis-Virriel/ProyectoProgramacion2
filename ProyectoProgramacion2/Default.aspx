<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoProgramacion2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


        <main>
        <section class="row">
            <h1>Gestión de Órdenes de Trabajo</h1>
            <p class="lead">Bienvenido al sistema de gestión de órdenes de trabajo de servicios técnicos.</p>
        </section>

        <div class="row mt-4">
            <section class="col-md-4">
                <h2>Órdenes Pendientes</h2>
                <p>Total de órdenes en estado "Pendiente": <asp:Label ID="lblPendingCount" runat="server"></asp:Label></p>
                <a href="Ordenes.aspx" class="btn btn-default">Ver Detalles &raquo;</a>
            </section>

            <section class="col-md-4">
                <h2>Órdenes En Progreso</h2>
                <p>Total de órdenes en estado "En Progreso": <asp:Label ID="lblInProgressCount" runat="server"></asp:Label></p>
                <a href="Ordenes.aspx" class="btn btn-default">Ver Detalles &raquo;</a>
            </section>

            <section class="col-md-4">
                <h2>Órdenes Completadas</h2>
                <p>Total de órdenes en estado "Completada": <asp:Label ID="lblCompletedCount" runat="server"></asp:Label></p>
                <a href="Ordenes.aspx" class="btn btn-default">Ver Detalles &raquo;</a>
            </section>
        </div>
    </main>
    

</asp:Content>
