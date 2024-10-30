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
        private object clientes;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Console.WriteLine("Cargando clientes...");
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            gvClientes.DataSource = BaseDeDatos.Clientes;
            gvClientes.DataBind();
        }



        protected void cmdVer_Click(object sender, EventArgs e)
        {
            if (gvClientes.EditIndex == -1)
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
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    lblError.Text = "Debe ingresar un correo electrónico válido";
                    lblError.Visible = true;
                    return;
                }
                string verificoMail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, verificoMail))
                {
                    lblError.Text = "Formato de correo electrónico no válido";
                    lblError.Visible = true;
                    return;
                }

                if (!int.TryParse(txtCI.Text, out _))
                {
                    lblError.Text = "El número de documento debe ser un valor numérico";
                    lblError.Visible = true;
                    return;
                }

                Cliente clienteEncontrado = BaseDeDatos.Clientes.Find(c => c.CI == txtCI.Text);
                if (clienteEncontrado != null)
                {
                    lblError.Text = "Ya existe un cliente con la misma cédula.";
                    lblError.Visible = true;
                    return;
                }

                Cliente miCliente = new Cliente
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    CI = txtCI.Text,
                    Email = txtEmail.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text
                };
                BaseDeDatos.Clientes.Add(miCliente);
                CargarClientes();

                lblError.Visible = false;
                LimpiarCampos();
            }
            else
            {
                lblError.Text = "Completa la edición del cliente antes de agregar uno nuevo.";
                lblError.Visible = true;
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCI.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            lblError.Text = "Cliente actualizado correctamente.";
            lblError.Visible = true;
        }
        protected void EditarClientes(object sender, GridViewEditEventArgs e)
        {
            gvClientes.EditIndex = e.NewEditIndex;
            gvClientes.DataSource = BaseDeDatos.Clientes;
            gvClientes.DataBind();
        }

        protected void CanceloEditarClientes(object sender, GridViewCancelEditEventArgs e)
        {
            gvClientes.EditIndex = -1;
            gvClientes.DataSource = BaseDeDatos.Clientes;
            gvClientes.DataBind();
        }

        protected void ActualizarClientes(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0 && index < BaseDeDatos.Clientes.Count)
            {

                string nuevoCI = ((TextBox)gvClientes.Rows[index].Cells[3].Controls[0]).Text;
                string originalCI = BaseDeDatos.Clientes[index].CI;


                if (BaseDeDatos.Clientes.Any(c => c.CI == nuevoCI && c.CI != originalCI))
                {
                    lblError.Text = "Ya existe un cliente con la misma cédula.";
                    lblError.Visible = true;
                    return;
                }
                Cliente cliente = BaseDeDatos.Clientes[index];
                cliente.Nombre = ((TextBox)gvClientes.Rows[index].Cells[1].Controls[0]).Text;
                cliente.Apellido = ((TextBox)gvClientes.Rows[index].Cells[2].Controls[0]).Text;
                cliente.CI = nuevoCI;
                cliente.Direccion = ((TextBox)gvClientes.Rows[index].Cells[4].Controls[0]).Text;
                cliente.Telefono = ((TextBox)gvClientes.Rows[index].Cells[5].Controls[0]).Text;
                cliente.Email = ((TextBox)gvClientes.Rows[index].Cells[6].Controls[0]).Text;

                gvClientes.EditIndex = -1;
                CargarClientes();

                lblError.Text = "Cliente actualizado correctamente.";
                lblError.Visible = true;
            }
            else
            {
                lblError.Text = "Error al actualizar el cliente.";
                lblError.Visible = true;
            }
        }


        protected void BorrarClientes(object sender, GridViewDeleteEventArgs e)
        {

            int index = e.RowIndex;
            BaseDeDatos.Clientes.RemoveAt(index);
            gvClientes.DataSource = BaseDeDatos.Clientes;
            gvClientes.DataBind();
        }


    }

















}