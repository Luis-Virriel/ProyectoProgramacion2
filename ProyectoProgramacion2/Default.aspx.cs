using ProyectoProgramacion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoProgramacion2
{
    public partial class _Default : Page
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





            gvOrdenesPendientes.DataSource = FiltrarPorEstado(Estado.Pendiente);
            gvOrdenesPendientes.DataBind();

            gvOrdenesEnProgreso.DataSource = FiltrarPorEstado(Estado.EnProgreso);
            gvOrdenesEnProgreso.DataBind();

            gvOrdenesCompletadas.DataSource = FiltrarPorEstado(Estado.Completada);
            gvOrdenesCompletadas.DataBind();
        }

        public List<OrdenTrabajo> FiltrarPorEstado(Estado estado)
        {
            //List<OrdenTrabajo> ListaOrdenes = new List<OrdenTrabajo>();
            return BaseDeDatos.OrdenesDeTrabajo.Where(o => o.Estado == estado).ToList();
        }

        protected void btnPendientes_Click(object sender, EventArgs e)
        {
            gvOrdenesPendientes.Visible = true;
            gvOrdenesEnProgreso.Visible = false;
            gvOrdenesCompletadas.Visible = false;
        }

        protected void btnEnProgreso_Click(object sender, EventArgs e)
        {
            gvOrdenesEnProgreso.Visible = true;
            gvOrdenesPendientes.Visible = false;
            gvOrdenesCompletadas.Visible = false;
        }

        protected void btnCompletadas_Click(object sender, EventArgs e)
        {

            gvOrdenesEnProgreso.Visible = false;
            gvOrdenesPendientes.Visible = false;
            gvOrdenesCompletadas.Visible = true;
        }
    }
}