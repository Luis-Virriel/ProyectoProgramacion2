using ProyectoProgramacion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace ProyectoProgramacion2
{
    public partial class PaginaTecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["VariableUsuario"] = null;
            Response.Redirect("~/Login.aspx");
        }

        private void CargarDatos()
        {
            string tecnicoCI = Session["VariableUsuario"]?.ToString();
            if (string.IsNullOrEmpty(tecnicoCI))
            {
                Response.Redirect("Login.aspx");
                return;
            }

            var ordenes = BaseDeDatos.OrdenesDeTrabajo;
            if (ordenes == null || !ordenes.Any())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "info", "alert('No hay órdenes disponibles.');", true);
                return;
            }

            var ordenesFiltradas = ordenes
                .Where(o => o.TecnicoAsignado?.CI == tecnicoCI)
                .ToList();

            if (ordenesFiltradas.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "info", "alert('No se encontraron órdenes para este técnico.');", true);
            }
            else
            {
                gvOrdenes.DataSource = ordenesFiltradas;
                gvOrdenes.DataBind();
            }
        }

        protected void gvOrdenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AbrirComentario")
            {
                int numeroOrden = Convert.ToInt32(e.CommandArgument.ToString());
                AbrirComentarios(numeroOrden);
            }
        }

        private void AbrirComentarios(int numeroOrden)
        {
            var orden = BaseDeDatos.OrdenesDeTrabajo.FirstOrDefault(o => o.NumeroOrden == numeroOrden);

            if (orden != null)
            {
                // Verificar si hay comentarios antes de enlazarlos al repeater
                if (orden.Comentarios != null && orden.Comentarios.Any())
                {
                    rptComentarios.DataSource = orden.Comentarios;
                }
                else
                {
                    rptComentarios.DataSource = new List<Comentario>(); // No hay comentarios
                }

                rptComentarios.DataBind();
                comentariosSection.Visible = true;
                Session["NumeroOrden"] = numeroOrden;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('Orden no encontrada.');", true);
            }
        }

        protected void btnGuardarComentario_Click(object sender, EventArgs e)
        {
            string comentarioTexto = txtComentario.Text.Trim();

            if (string.IsNullOrWhiteSpace(comentarioTexto))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('Comentario vacío.');", true);
                return;
            }

            int numeroOrden = Convert.ToInt32(Session["NumeroOrden"]);
            var orden = BaseDeDatos.OrdenesDeTrabajo.FirstOrDefault(o => o.NumeroOrden == numeroOrden);

            if (orden != null)
            {
                // Generar un ID único para el comentario
                int comentarioID = orden.Comentarios.Count > 0 ? orden.Comentarios.Max(c => c.ComentarioID) + 1 : 1;

                // Agregar el nuevo comentario
                orden.Comentarios.Add(new Comentario(comentarioID, comentarioTexto, DateTime.Now));

                // Limpiar el campo de texto y recargar los comentarios
                txtComentario.Text = string.Empty;
                AbrirComentarios(numeroOrden);

                ClientScript.RegisterStartupScript(this.GetType(), "success", "alert('Comentario guardado correctamente.');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('Orden no encontrada para guardar el comentario.');", true);
            }
        }
    }
}