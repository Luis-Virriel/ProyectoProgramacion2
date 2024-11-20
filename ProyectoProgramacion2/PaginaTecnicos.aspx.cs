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

            /*Tecnico variable = BaseDeDatos.Tecnicos.FirstOrDefault(t => t.CI == tecnicoCI);
            string textNombre = variable.getNombre();
            lblNombre.Text = textNombre;*/

            var ordenesFiltradas = BaseDeDatos.OrdenesDeTrabajo
                .Where(o => o.TecnicoAsignado.CI == tecnicoCI)
                .ToList();

            gvOrdenes.DataSource = BaseDeDatos.OrdenesDeTrabajo;
            gvOrdenes.DataBind();
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