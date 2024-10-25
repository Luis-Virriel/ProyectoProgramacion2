using ProyectoProgramacion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoProgramacion2
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdVer_Click(object sender, EventArgs e)
        {
            Cliente clienteEncontrado = BaseDeDatos.Clientes.Find(c => c.CI == txtCI.Text);
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
            else if(clienteEncontrado != null)
            {
                lblError.Text = "Ya existe un cliente con la misma Cedula. ";
                lblError.Visible = true;

            }

            else
            {
                //miCliente.CI = Convert.ToInt32(txtCI.Text);
                Convert.ToInt32(txtCI.Text);
                lblError.Visible = true;
                Cliente miCliente = new Cliente();

                miCliente.Nombre = txtNombre.Text;
                miCliente.Apellido = txtApellido.Text;
                miCliente.CI =txtCI.Text;
                lblError.Text = "Cliente creado correctamente";

                BaseDeDatos.Clientes.Add(miCliente);

                gvClientes.DataSource = BaseDeDatos.Clientes;
                gvClientes.DataBind();

                cboClientes.DataSource = BaseDeDatos.Clientes;
                cboClientes.DataTextField = "Nombre";
                cboClientes.DataBind();
                txtCI.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                
            }

            }
        }
    }