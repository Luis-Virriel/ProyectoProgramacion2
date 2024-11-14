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

            // Validaciones
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
            if (!int.TryParse(txtCI.Text.Replace(".", "").Replace("-", ""), out _))
            {
                lblError.Text = "El número de documento debe ser un valor numérico";
                lblError.Visible = true;
                return;
            }
            if (!EsCedulaUruguaya(txtCI.Text))
            {
                lblError.Text = "La cédula ingresada no es válida para Uruguay";
                lblError.Visible = true;
                return;
            }

            Tecnico nuevoTecnico = new Tecnico
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                CI = txtCI.Text,
                Especialidad = convertirAespecialidad(txtEspecialidad.SelectedValue)
            };
            BaseDeDatos.Tecnicos.Add(nuevoTecnico);
            LimpiarCampos();
            CargarTecnicos(); 
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
                    lblError.Text = "Técnico actualizado correctamente.";
                    lblError.CssClass = "text-success"; // Cambiar estilo para éxito
                    lblError.Visible = true;
                }
                else
                {
                    lblError.Text = "Especialidad seleccionada no válida.";
                    lblError.CssClass = "text-danger";
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
        private bool EsCedulaUruguaya(string ci)
        {

            ci = ci.Replace(".", "").Replace("-", "");
            if (ci.Length < 7 || ci.Length > 8) return false;

            int[] coeficientes = { 2, 9, 8, 7, 6, 3, 4 };
            int suma = 0;
            if (ci.Length == 7)
                ci = "0" + ci;
            for (int i = 0; i < 7; i++)
            {
                suma += (ci[i] - '0') * coeficientes[i];
            }
            int digitoVerificador = (10 - (suma % 10)) % 10;
            return digitoVerificador == (ci[7] - '0');
        }


    }
}