using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramacion2.Models
{
    public class Tecnico : IGestion
    {
        private string Nombre;
        private string Apellido;
        private string CI;
        private Especialidad Especialidad;//Hay un enum creado para la especialidad.

        public Tecnico(string nombre, string apellido, string ci, Especialidad especialidad)
        {
            Nombre = nombre;
            Apellido = apellido;
            CI = ci;
            Especialidad = especialidad;
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

        public Especialidad getEspecialidad()
        {
            return Especialidad;
        }

        public void setEspecialidad(Especialidad especialidad)
        {
            Especialidad = especialidad;
        }


        public void agregar(List<Tecnico> Tecnicos)
        {

            //Aca se debe ir , los reads y demas para agregar a un tecnico

            Clientes.Add(new Cliente(3, "Carlos Mendoza", "Calle 789"));
        }

        public void editar(List<Tecnico> Tecnicos, string ci)
        {

            //Aca se debe comprobar que la persona se encuentra por el CI


        }

        public void eliminar(List<Tecnico> Tecnicos, string ci)
        {

            //Aca se debe comprobar que la persona se encuentra por el CI
            //y se debe eliminar de la lista de tecnicos


        }



    }
}