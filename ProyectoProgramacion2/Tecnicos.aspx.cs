using ProyectoProgramacion2.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            lblError.Text = "Tecnico creado correctamente";
            lblError.Visible = true;
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtCI.Text = string.Empty;
            txtEspecialidad.Text = string.Empty;
            
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            lblError.Text = "Tecnico actualizado correctamente.";
            lblError.Visible = true;
        }
        protected void gvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTecnicos.EditIndex = e.NewEditIndex;
            gvTecnicos.DataSource = BaseDeDatos.Tecnicos;
            gvTecnicos.DataBind();
        }

        protected void gvTecnicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTecnicos.EditIndex = -1;
            gvTecnicos.DataSource = BaseDeDatos.Tecnicos;
            gvTecnicos.DataBind();
        }

        protected void gvTecnicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= 0 && index < BaseDeDatos.Tecnicos.Count)
            {
                Tecnico tecnico = BaseDeDatos.Tecnicos[index];


                tecnico.Nombre = ((TextBox)gvTecnicos.Rows[index].Cells[1].Controls[0]).Text;
                tecnico.Apellido = ((TextBox)gvTecnicos.Rows[index].Cells[2].Controls[0]).Text;
                tecnico.CI = ((TextBox)gvTecnicos.Rows[index].Cells[3].Controls[0]).Text;
                tecnico.Especialidad = convertirAespecialidad(((DropDownList)gvTecnicos.Rows[index].Cells[4].Controls[0]).Text);


                gvTecnicos.EditIndex = -1;
                CargarTecnicos();
            }
        }

       
    }
}