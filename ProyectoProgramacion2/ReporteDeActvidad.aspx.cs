using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoProgramacion2.Models;

namespace ProyectoProgramacion2
{
    public partial class ReporteDeActividad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarResumenTecnicos();
                CargarOrdenesCompletadas();
            }
        }

        private void CargarResumenTecnicos()
        {
            var resumenTecnico = BaseDeDatos.Tecnicos.Select(t => new
            {
                NombreTecnico = $"{t.Nombre} {t.Apellido}",
                Pendientes = BaseDeDatos.OrdenesDeTrabajo.Count(o => o.TecnicoAsignado.CI == t.CI && o.Estado == Estado.Pendiente),
                EnProgreso = BaseDeDatos.OrdenesDeTrabajo.Count(o => o.TecnicoAsignado.CI == t.CI && o.Estado == Estado.EnProgreso),
                Completadas = BaseDeDatos.OrdenesDeTrabajo.Count(o => o.TecnicoAsignado.CI == t.CI && o.Estado == Estado.Completada)
            }).ToList();

            gvResumenTecnico.DataSource = resumenTecnico;
            gvResumenTecnico.DataBind();
        }

        private void CargarOrdenesCompletadas()
        {
            var ordenesCompletadas = BaseDeDatos.OrdenesDeTrabajo
                .Where(o => o.Estado == Estado.Completada)
                .Select(o => new
                {
                    NumeroOrden = o.NumeroOrden,
                    ClienteNombre = $"{o.ClienteAsociado.Nombre} {o.ClienteAsociado.Apellido}",
                    TecnicoNombre = $"{o.TecnicoAsignado.Nombre} {o.TecnicoAsignado.Apellido}",
                    Descripcion = o.DescripcionProblema,
                    FechaCompletada = o.FechaCompletada.HasValue ? o.FechaCompletada.Value.ToString("dd/MM/yyyy") : "N/A"
                })
                .ToList();

            gvOrdenesCompletadas.DataSource = ordenesCompletadas;
            gvOrdenesCompletadas.DataBind();
        }
    }
}

