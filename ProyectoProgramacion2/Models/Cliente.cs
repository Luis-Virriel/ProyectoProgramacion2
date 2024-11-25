using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramacion2.Models
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CI { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public Cliente() { }
        
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

        public string getTelefono()
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
        public string NombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }


    }
    }