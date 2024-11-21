using ProyectoProgramacion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoProgramacion2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        public void CargarDatos()
        {
            string tecnicoCI = Session["VariableUsuario"]?.ToString();
            var ordenesFiltradas = BaseDeDatos.OrdenesDeTrabajo
                .Where(o => o.TecnicoAsignado.CI == tecnicoCI)
                .ToList();
            gvOrdenes.DataSource = ordenesFiltradas; // Asignar las órdenes filtradas
            gvOrdenes.DataBind();

            
        }

        protected void gvOrdenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int numeroOrden = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "AbrirComentario")
            {
                // Abrir el modal para agregar comentario
                Session["NumeroOrden"] = numeroOrden; // Guardar el número de orden en la sesión
            }
            else if (e.CommandName == "AceptarComentario")
            {
                // Guardar el comentario en la orden
                string comentarioTexto = Request.Form["txtComentario.text"];
                if (!string.IsNullOrWhiteSpace(comentarioTexto))
                {
                    var orden = BaseDeDatos.OrdenesDeTrabajo.FirstOrDefault(o => o.NumeroOrden == numeroOrden);
                    if (orden != null)
                    {
                        Comentario nuevoComentario = new Comentario(comentarioTexto, DateTime.Now);
                        orden.Comentarios.Add(nuevoComentario);
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Comentario agregado.');", true);
                    }
                }
            }
            else if (e.CommandName == "MostrarComentarios")
            {
                // Mostrar los comentarios
                var orden = BaseDeDatos.OrdenesDeTrabajo.FirstOrDefault(o => o.NumeroOrden == numeroOrden);
                if (orden != null && orden.Comentarios.Any())
                {
                    string comentarios = string.Join("\n", orden.Comentarios.Select(c => c.Texto));
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Comentarios:\n{comentarios}');", true);
                }
            }
        }
    }


    
}