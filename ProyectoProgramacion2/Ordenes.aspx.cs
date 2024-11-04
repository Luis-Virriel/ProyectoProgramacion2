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
        private static List<OrdenTrabajo> OrdenesTrabajo = new List<OrdenTrabajo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            /*var clientes = new List<Cliente>
            {
                new Cliente { Nombre = "Romina" },
                new Cliente { Nombre = "Pepe" },
                new Cliente { Nombre = "Alberto" }
            };
            var tecnicos = new List<Tecnico>
            {
                new Tecnico { Nombre = "Luis" },
                new Tecnico { Nombre = "Danlee" },
                new Tecnico { Nombre = "Carlitos" }
            };
            OrdenesTrabajo = new List<OrdenTrabajo>
            {
                new OrdenTrabajo(1, clientes[0], tecnicos[0], "Problema con licuadora", Estado.Pendiente),
                new OrdenTrabajo(2, clientes[1], tecnicos[1], "Problema con pc", Estado.EnProgreso),
                new OrdenTrabajo(3, clientes[2], tecnicos[2], "Problema con la vida", Estado.Completada)
            };*/
            gvOrdenes.DataSource = OrdenesTrabajo;
            gvOrdenes.DataBind();
        }

        protected void btnCrearOrden_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                lblError.Text = "La descripción es requerida.";
                lblError.Visible = true;
                return;
            }
            int nuevoNumeroOrden = OrdenesTrabajo.Count > 0 ? OrdenesTrabajo.Max(o => o.NumeroOrden) + 1 : 1;

            Cliente clienteSeleccionado = new Cliente { Nombre = ddlCliente.SelectedItem.Text };
            Tecnico tecnicoSeleccionado = new Tecnico { Nombre = ddlTecnico.SelectedItem.Text };

            OrdenTrabajo nuevaOrden = new OrdenTrabajo(nuevoNumeroOrden, clienteSeleccionado, tecnicoSeleccionado, txtDescripcion.Text, Estado.Pendiente);

            OrdenesTrabajo.Add(nuevaOrden);
            txtDescripcion.Text = "";
            lblError.Visible = false;
            CargarDatos();
        }

        protected void gvOrdenes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvOrdenes.EditIndex = e.NewEditIndex;
            CargarDatos();
        }

        protected void gvOrdenes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int numeroOrden = (int)gvOrdenes.DataKeys[e.RowIndex].Value;


            var orden = OrdenesTrabajo.FirstOrDefault(o => o.NumeroOrden == numeroOrden);
            if (orden != null)
            {
                orden.setClienteAsociado(new Cliente { Nombre = ddlCliente.SelectedItem.Text }); 
                orden.setTecnicoAsignado(new Tecnico { Nombre = ddlTecnico.SelectedItem.Text });
                orden.setDescripcionProblema(((TextBox)gvOrdenes.Rows[e.RowIndex].FindControl("txtDescripcion")).Text);
                gvOrdenes.EditIndex = -1;
                CargarDatos();
            }
        }

        protected void gvOrdenes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvOrdenes.EditIndex = -1;
            CargarDatos();
        }
    }
}
