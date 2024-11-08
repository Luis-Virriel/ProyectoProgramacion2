using ProyectoProgramacion2.Models;
using System;
using System.Linq; 
using System.Web.UI.WebControls;

namespace ProyectoProgramacion2
{
    public partial class BuscarOrden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                gvResultadoBusqueda.DataSource = BaseDeDatos.OrdenesDeTrabajo;
                gvResultadoBusqueda.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumeroOrden.Text.Trim(), out int numeroOrden))
            {
                var ordenEncontrada = BaseDeDatos.OrdenesDeTrabajo.FirstOrDefault(o => o.NumeroOrden == numeroOrden);

                if (ordenEncontrada != null)
                {
                    gvResultadoBusqueda.DataSource = new[] { ordenEncontrada };
                    gvResultadoBusqueda.DataBind();
                }
                else
                {
                    gvResultadoBusqueda.DataSource = null;
                    gvResultadoBusqueda.DataBind();

                    lblError.Visible = true;
                    lblError.Text = "Orden no encontrada.";
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Por favor, ingrese un número de orden válido.";

            }
}

