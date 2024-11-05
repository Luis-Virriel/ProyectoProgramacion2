using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramacion2.Models
{
    public class Tecnico
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CI { get; set; }
        public Especialidad Especialidad { get; set; }

        /*public Tecnico(string nombre, string apellido, string ci, Especialidad especialidad)
        {
            Nombre = nombre;
            Apellido = apellido;
            CI = ci;
            Especialidad = especialidad;
        }*/

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

        public Especialidad getEspecialidad()
        {
            return Especialidad;
        }

        public void setEspecialidad(Especialidad especialidad)
        {
            Especialidad = especialidad;
        }
        public string NombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }




       
    }
}