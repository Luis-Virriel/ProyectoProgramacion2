using ProyectoProgramacion2.Models;
using System;
using System.Linq;
using System.Web.UI;
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

        private void CargarDatos()
        {
            string tecnicoCI = Session["VariableUsuario"]?.ToString();
            if (string.IsNullOrEmpty(tecnicoCI))
            {
                Response.Redirect("Login.aspx");
                return;
            }

            try
            {
                var ordenesFiltradas = BaseDeDatos.OrdenesDeTrabajo
                    .Where(o => o.TecnicoAsignado.CI == tecnicoCI)
                    .ToList();

                gvOrdenes.DataSource = ordenesFiltradas;
                gvOrdenes.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", $"alert('Error al cargar las órdenes: {ex.Message}');", true);
            }
        }

        protected void gvOrdenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int numeroOrden = Convert.ToInt32(e.CommandArgument);
            try
            {
                if (e.CommandName == "AbrirComentario")
                {
                    AbrirComentarios(numeroOrden);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", $"alert('Error: {ex.Message}');", true);
            }
        }

        private void AbrirComentarios(int numeroOrden)
        {
            var orden = BaseDeDatos.OrdenesDeTrabajo.FirstOrDefault(o => o.NumeroOrden == numeroOrden);
            if (orden != null)
            {
                rptComentarios.DataSource = orden.Comentarios;
                rptComentarios.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('Orden no encontrada.');", true);
            }
        }

        protected void btnGuardarComentario_Click(object sender, EventArgs e)
        {
            string comentarioTexto = txtComentario.Text;
            if (string.IsNullOrWhiteSpace(comentarioTexto))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('Comentario vacío.');", true);
                return;
            }

            int numeroOrden = Convert.ToInt32(Session["NumeroOrden"]);
            var orden = BaseDeDatos.OrdenesDeTrabajo.FirstOrDefault(o => o.NumeroOrden == numeroOrden);

            if (orden != null)
            {
                // Crear un nuevo comentario sin 'id'
                var nuevoComentario = new Comentario(comentarioTexto, DateTime.Now);

                orden.Comentarios.Add(nuevoComentario);

                // Recargar los comentarios
                AbrirComentarios(numeroOrden);

                // Limpiar el campo de texto
                txtComentario.Text = string.Empty;

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Comentario guardado.');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('Orden no encontrada.');", true);
            }
        }


        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
