using ProyectoProgramacion2.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services.Description;

namespace ProyectoProgramacion2
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Console.WriteLine("Cargando tecnicos...");
                CargarTecnicos();
            }

        }
        private void CargarTecnicos()
        {
            gvTecnicos.DataSource = BaseDeDatos.Tecnicos;
            gvTecnicos.DataBind();
        }
        private Especialidad convertirAespecialidad(string txtEspecialidad)
        {

            Enum.TryParse(txtEspecialidad, true, out Especialidad especialidad);
            
            return especialidad;
            

        }

       

        protected void cmdCrearTecnico_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;



            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                lblError.Text = "Debe agregar un nombre";
                lblError.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                lblError.Text = "Debe agregar un apellido";
                lblError.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(txtCI.Text))
            {
                lblError.Text = "Debe agregar un número de documento";
                lblError.Visible = true;
                return;
            }
            

            if (!int.TryParse(txtCI.Text, out _))
            {
                lblError.Text = "El número de documento debe ser un valor numérico";
                lblError.Visible = true;
                return;
            }



            Tecnico tecnicoEncontrado = BaseDeDatos.Tecnicos.Find(c => c.CI == txtCI.Text);
            if (tecnicoEncontrado != null)
            {
                lblError.Text = "Ya existe un tecnico con la misma cédula.";
                lblError.Visible = true;
                return;
            }
           
            

            Tecnico miTecnico = new Tecnico
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                CI = txtCI.Text,
                Especialidad = convertirAespecialidad(txtEspecialidad.Text)
            };
            BaseDeDatos.Tecnicos.Add(miTecnico);
            CargarTecnicos();

            gvTecnicos.DataSource = BaseDeDatos.Tecnicos;
            gvTecnicos.DataBind();
            lblError.Visible = true;
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCI.Text = "";
            txtEspecialidad.Text = "";
            
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            lblError.Text = "Tecnico actualizado correctamente.";
            lblError.Visible = true;
        }
        protected void EditarTecnicos(object sender, GridViewEditEventArgs e)
        {
            gvTecnicos.EditIndex = e.NewEditIndex;
            CargarTecnicos();
        }


        protected void CanceloEditarTecnicos(object sender, GridViewCancelEditEventArgs e)
        {
            gvTecnicos.EditIndex = -1;
            gvTecnicos.DataSource = BaseDeDatos.Tecnicos;
            gvTecnicos.DataBind();
        }

        protected void ActualizarTecnicos(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= 0 && index < BaseDeDatos.Tecnicos.Count)
            {
                GridViewRow row = gvTecnicos.Rows[index];
                Tecnico tecnico = BaseDeDatos.Tecnicos[index];

                tecnico.Nombre = ((TextBox)row.Cells[1].Controls[0]).Text;
                tecnico.Apellido = ((TextBox)row.Cells[2].Controls[0]).Text;
                tecnico.CI = ((TextBox)row.Cells[0].Controls[0]).Text;

                DropDownList ddlEspecialidad = (DropDownList)row.FindControl("ddlEspecialidad");
                if (ddlEspecialidad != null && Enum.TryParse(ddlEspecialidad.SelectedValue, out Especialidad especialidad))
                {
                    tecnico.Especialidad = especialidad;
                }
                else
                {
                    lblError.Text = "Especialidad seleccionada no válida.";
                    lblError.Visible = true;
                    return;
                }

                gvTecnicos.EditIndex = -1;
                CargarTecnicos();
            }
        }

        protected void BorrarTecnicos(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0 && index < BaseDeDatos.Tecnicos.Count)
            {
                BaseDeDatos.Tecnicos.RemoveAt(index);
                CargarTecnicos();
            }
        }


    }
}