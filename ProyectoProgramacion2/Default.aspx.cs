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
            var ordenesPendientes = FiltrarPorEstado(Estado.Pendiente);
            gvOrdenesPendientes.DataSource = ordenesPendientes;
            gvOrdenesPendientes.DataBind();

            var ordenesEnProgreso = FiltrarPorEstado(Estado.EnProgreso);
            gvOrdenesEnProgreso.DataSource = ordenesEnProgreso;
            gvOrdenesEnProgreso.DataBind();

            var ordenesCompletadas = FiltrarPorEstado(Estado.Completada);
            gvOrdenesCompletadas.DataSource = ordenesCompletadas;
            gvOrdenesCompletadas.DataBind();

            lblPendingCount.Text = ordenesPendientes.Count.ToString();
            lblInProgressCount.Text = ordenesEnProgreso.Count.ToString();
            lblCompletedCount.Text = ordenesCompletadas.Count.ToString();
        }

        public List<OrdenTrabajo> FiltrarPorEstado(Estado estado)
        {

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
