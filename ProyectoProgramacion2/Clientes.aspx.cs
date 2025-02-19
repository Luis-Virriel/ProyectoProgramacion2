﻿using ProyectoProgramacion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            if (!IsPostBack)
            {

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
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string cedula = txtCI.Text.Trim();

                string verificoNombreYapellido = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$";
                Regex regex = new Regex(verificoNombreYapellido);

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
                if (!regex.IsMatch(nombre))
                {
                    lblError.Text = "Debe escribir un nombre valido.";
                    lblError.Visible = true;
                    return;
                }
                if (!regex.IsMatch(apellido))
                {
                    lblError.Text = "Debe escribir un apellido valido.";
                    lblError.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(txtCI.Text))
                {
                    lblError.Text = "Debe agregar un número de documento";
                    lblError.Visible = true;
                    return;
                }
                if (!EsCedulaUruguaya(txtCI.Text))
                {
                    lblError.Text = "La cédula ingresada no es válida para Uruguay";
                    lblError.Visible = true;
                    return;
                }
                if (cedula.Contains("-"))
                {
                    lblError.Text = "La cédula no debe contener guiones.";
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

                Cliente miCliente = new Cliente();
                miCliente.setNombre(txtNombre.Text);    
                miCliente.setApellido(txtApellido.Text);  
                miCliente.setCI(txtCI.Text);             
                miCliente.setEmail(txtEmail.Text);       
                miCliente.setDireccion(txtDireccion.Text); 
                miCliente.setTelefono(txtTelefono.Text);   
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
                cliente.setNombre(((TextBox)gvClientes.Rows[index].Cells[1].Controls[0]).Text);
                cliente.setApellido(((TextBox)gvClientes.Rows[index].Cells[2].Controls[0]).Text);
                cliente.setCI(nuevoCI);
                cliente.setDireccion(((TextBox)gvClientes.Rows[index].Cells[4].Controls[0]).Text);
                cliente.setTelefono(((TextBox)gvClientes.Rows[index].Cells[5].Controls[0]).Text);
                cliente.setEmail(((TextBox)gvClientes.Rows[index].Cells[6].Controls[0]).Text);

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