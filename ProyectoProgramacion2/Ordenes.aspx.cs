﻿using System;
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
                CargarClientes();
                CargarTecnicos();
                CargarDatos();
            }
            if (BaseDeDatos.OrdenesDeTrabajo.Count == 0)
            {
                AgregarOrdenesDeTrabajo();
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

        private void CargarDatos()
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

            int nuevoNumeroOrden = OrdenesTrabajo.Count > 0 ? OrdenesTrabajo.Max(o => o.NumeroOrden) + 1 : 1;

            if (ddlCliente.SelectedIndex == 0 || ddlTecnico.SelectedIndex == 0)
            {
                lblError.Text = "Debe seleccionar un cliente y un técnico.";
                lblError.Visible = true;
                return;
            }

            Cliente clienteSeleccionado = new Cliente { Nombre = ddlCliente.SelectedItem.Text };
            Tecnico tecnicoSeleccionado = new Tecnico { Nombre = ddlTecnico.SelectedItem.Text };

            OrdenTrabajo nuevaOrden = new OrdenTrabajo(nuevoNumeroOrden, clienteSeleccionado, tecnicoSeleccionado, txtDescripcion.Text, Estado.Pendiente);
            OrdenesTrabajo.Add(nuevaOrden);
            BaseDeDatos.OrdenesDeTrabajo.Add(nuevaOrden);
            
            txtDescripcion.Text = "";
            CargarDatos();
        }
        private void AgregarOrdenesDeTrabajo()
        {
            
            BaseDeDatos.OrdenesDeTrabajo.Add(new OrdenTrabajo(
                BaseDeDatos.GenerarNumeroOrden(),
                BaseDeDatos.Clientes.FirstOrDefault(c => c.CI == "12345678"), 
                BaseDeDatos.Tecnicos.FirstOrDefault(t => t.CI == "99887766"), 
                "Reparación de electrodoméstico - nevera",
                Estado.Pendiente
            ));

           
        }

        protected void gvOrdenes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvOrdenes.EditIndex = e.NewEditIndex;
            CargarDatos();
        }

        protected void gvOrdenes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lblError.Visible = false;

            int numeroOrden = (int)gvOrdenes.DataKeys[e.RowIndex].Value;

            var orden = OrdenesTrabajo.FirstOrDefault(o => o.NumeroOrden == numeroOrden);
            if (orden != null)
            {
                var ddlEstado = (DropDownList)gvOrdenes.Rows[e.RowIndex].FindControl("ddlEstado");
                if (ddlEstado != null)
                {
                    if (Enum.TryParse<Estado>(ddlEstado.SelectedValue, out var nuevoEstado))
                    {
                        orden.Estado = nuevoEstado;
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


        protected void gvOrdenes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvOrdenes.EditIndex = -1;
            CargarDatos();
        }

        protected void gvOrdenes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ddlEstado = (DropDownList)e.Row.FindControl("ddlEstado");
                if (ddlEstado != null)
                {
                    ddlEstado.DataSource = Enum.GetValues(typeof(Estado))
                        .Cast<Estado>()
                        .Select(estados => new
                        {
                            Value = estados.ToString(),
                            Text = estados.ToString()
                        })
                        .ToList();

                    ddlEstado.DataTextField = "Text";
                    ddlEstado.DataValueField = "Value";
                    ddlEstado.DataBind();

                    var orden = e.Row.DataItem as OrdenTrabajo;
                    if (orden != null)
                    {
                        ddlEstado.SelectedValue = orden.Estado.ToString();
                    }

                }
            }

        }

        
    }
}
