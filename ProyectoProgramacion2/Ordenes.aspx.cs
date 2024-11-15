using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoProgramacion2.Models;

namespace ProyectoProgramacion2
{
    public partial class Ordenes : Page
    {
        private static List<OrdenTrabajo> OrdenesTrabajo => BaseDeDatos.OrdenesDeTrabajo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
                CargarTecnicos();
                CargarDatos();
            }
        }

        private void CargarClientes()
        {
            ddlCliente.DataSource = BaseDeDatos.Clientes;
            ddlCliente.DataTextField = "Nombre";
            ddlCliente.DataValueField = "CI";
            ddlCliente.DataBind();
            ddlCliente.Items.Insert(0, new ListItem("Seleccione un cliente", ""));
        }

        private void CargarTecnicos()
        {
            ddlTecnico.DataSource = BaseDeDatos.Tecnicos;
            ddlTecnico.DataTextField = "Nombre";
            ddlTecnico.DataValueField = "CI";
            ddlTecnico.DataBind();
            ddlTecnico.Items.Insert(0, new ListItem("Seleccione un técnico", ""));
        }

        public void CargarDatos()
        {
            gvOrdenes.DataSource = BaseDeDatos.OrdenesDeTrabajo;
            gvOrdenes.DataBind();
        }


        protected void btnCrearOrden_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                lblError.Text = "La descripción es requerida.";
                lblError.Visible = true;
                return;
            }

            if (ddlCliente.SelectedIndex == 0 || ddlTecnico.SelectedIndex == 0)
            {
                lblError.Text = "Debe seleccionar un cliente y un técnico.";
                lblError.Visible = true;
                return;
            }

            Cliente clienteSeleccionado = BaseDeDatos.Clientes.FirstOrDefault(c => c.CI == ddlCliente.SelectedValue);
            Tecnico tecnicoSeleccionado = BaseDeDatos.Tecnicos.FirstOrDefault(t => t.CI == ddlTecnico.SelectedValue);

            if (clienteSeleccionado == null || tecnicoSeleccionado == null)
            {
                lblError.Text = "Error en la selección de cliente o técnico.";
                lblError.Visible = true;
                return;
            }
            int nuevoNumeroOrden = BaseDeDatos.GenerarNumeroOrden();
            OrdenTrabajo nuevaOrden = new OrdenTrabajo(
                nuevoNumeroOrden,
                clienteSeleccionado,
                tecnicoSeleccionado,
                txtDescripcion.Text,
                Estado.Pendiente
            );
            BaseDeDatos.OrdenesDeTrabajo.Add(nuevaOrden);
            CargarDatos();
            ddlCliente.SelectedIndex = 0;
            ddlTecnico.SelectedIndex = 0;
            txtDescripcion.Text = "";
            lblError.Visible = false;
        }




        protected void gvOrdenes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lblError.Visible = false;

            int numeroOrden = (int)gvOrdenes.DataKeys[e.RowIndex].Value;
            var orden = BaseDeDatos.OrdenesDeTrabajo.FirstOrDefault(o => o.NumeroOrden == numeroOrden);
            if (orden != null)
            {
                var ddlEstado = (DropDownList)gvOrdenes.Rows[e.RowIndex].FindControl("ddlEstado");
                if (ddlEstado != null)
                {

                    if (Enum.TryParse<Estado>(ddlEstado.SelectedValue, out var nuevoEstado))
                    {

                        orden.Estado = nuevoEstado;
                        if (nuevoEstado == Estado.Completada)
                        {
                            orden.FechaCompletada = DateTime.Now;
                        }
                    }
                    else
                    {
                        lblError.Text = "El estado seleccionado no es válido.";
                        lblError.Visible = true;
                        return;
                    }
                }
                gvOrdenes.EditIndex = -1;
                CargarDatos();
            }
        }
        protected void gvOrdenes_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvOrdenes.EditIndex = e.NewEditIndex;

            CargarDatos();
        }

        protected void gvOrdenes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvOrdenes.EditIndex = -1;
            CargarDatos();
        }
    }
}
