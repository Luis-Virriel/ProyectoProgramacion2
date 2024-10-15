using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramacion2.Models
{
    public class Cliente
    {
        private string Nombre;
        private string Apellido;
        private string CI;
        private string Direccion;
        private string Telefono;
        private string Email;

        public Cliente(string nombre, string apellido, string ci, string direccion, string telefono, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            CI = ci;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
        }

        public string getNombre()
        {
            return Nombre;
        }

        public void setNombre(string nombre)
        {
            Nombre = nombre;
        }

        public string getApellido()
        {
            return Apellido;
        }

        public void setApellido(string apellido)
        {
            Apellido = apellido;
        }

        public string getCI()
        {
            return CI;
        }

        public void setCI(string ci)
        {
            CI = ci;
        }

        public string getDireccion()
        {
            return Direccion;
        }

        public void setDireccion(string direccion)
        {
            Direccion = direccion;
        }

        public string GetTelefono()
        {
            return Telefono;
        }

        public void setTelefono(string telefono)
        {
            Telefono = telefono;
        }

        public string getEmail()
        {
            return Email;
        }

        public void setEmail(string email)
        {
            Email = email;
        }




    }
}