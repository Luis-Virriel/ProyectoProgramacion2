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
            // Obtener las órdenes filtradas por estado y asignarlas a los GridView
            var ordenesPendientes = FiltrarPorEstado(Estado.Pendiente);
            gvOrdenesPendientes.DataSource = ordenesPendientes;
            gvOrdenesPendientes.DataBind();

            var ordenesEnProgreso = FiltrarPorEstado(Estado.EnProgreso);
            gvOrdenesEnProgreso.DataSource = ordenesEnProgreso;
            gvOrdenesEnProgreso.DataBind();

            var ordenesCompletadas = FiltrarPorEstado(Estado.Completada);
            gvOrdenesCompletadas.DataSource = ordenesCompletadas;
            gvOrdenesCompletadas.DataBind();

            // Asignar las cantidades a los Labels
            lblPendingCount.Text = ordenesPendientes.Count.ToString();
            lblInProgressCount.Text = ordenesEnProgreso.Count.ToString();
            lblCompletedCount.Text = ordenesCompletadas.Count.ToString();
        }

        public List<OrdenTrabajo> FiltrarPorEstado(Estado estado)
        {
            // Filtrar las órdenes según el estado
            return BaseDeDatos.OrdenesDeTrabajo.Where(o => o.Estado == estado).ToList();
        }

        protected void btnPendientes_Click(object sender, EventArgs e)
        {
            // Mostrar u ocultar los GridView según el botón presionado
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
