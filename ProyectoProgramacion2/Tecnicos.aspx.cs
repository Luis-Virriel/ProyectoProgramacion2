using ProyectoProgramacion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoProgramacion2
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdVer_Click(object sender, EventArgs e)
        {
            Tecnico tecnicoEncontrado = BaseDeDatos.Tecnicos.Find(c => c.CI == txtCI.Text);
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                lblError.Text = "Debe agregar un nombre";
                lblError.Visible = true;

            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                lblError.Text = "Debe agregar un apellido";
                lblError.Visible = true;
            }
            else if (string.IsNullOrEmpty(txtCI.Text))
            {
                lblError.Text = "Debe agregar un número de documento";
                lblError.Visible = true;
            }
            else if (string.IsNullOrEmpty(dEspecialidad.Text))
            {
                lblError.Text = "Debe agregar una Especialidad. ";
                lblError.Visible = true;

            }
            else if (tecnicoEncontrado != null)
            {
                lblError.Text = "Ya existe un tecnico con la misma Cedula. ";
                lblError.Visible = true;

            }

            else
            {
                //miCliente.CI = Convert.ToInt32(txtCI.Text);
                Convert.ToInt32(txtCI.Text);
                lblError.Visible = true;
                Tecnico miTecnico = new Tecnico();

                miTecnico.Nombre = txtNombre.Text;
                miTecnico.Apellido = txtApellido.Text;
                miTecnico.CI = txtCI.Text;
                //miTecnico.Especialidad = dEspecialidad.Text;
                lblError.Text = "Tecnico Agregado creado correctamente";

                BaseDeDatos.Tecnicos.Add(miTecnico);

                gvTecnicos.DataSource = BaseDeDatos.Tecnicos;
                gvTecnicos.DataBind();

                /*cboClientes.DataSource = Especialidad.Especialidad;
                cboClientes.DataTextField = "Nombre";
                cboClientes.DataBind();*/
                txtCI.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                dEspecialidad.Text = "";

            }
        }
    }
}