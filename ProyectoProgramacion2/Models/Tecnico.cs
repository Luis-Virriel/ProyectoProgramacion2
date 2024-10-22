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


        public bool verificarCedula(List<Tecnico> Tecnicos, string ci)
        {
            bool verificacion = false;
            foreach (Tecnico t in Tecnicos)
            {
                if (t.CI == ci)
                {
                    verificacion = true;
                    return verificacion;
                }
                
            }

            return verificacion;

        }


        public void agregar(List<Tecnico> Tecnicos ,string nombre , string apellido, string ci, Especialidad especialidad)
        {

            if( verificarCedula(Tecnicos, ci))
            {
                // 
            }
            else
            {
               
                Tecnicos.Add(new Tecnico(nombre , apellido , ci , especialidad));
            }

            
        }

        public void editar(List<Tecnico> Tecnicos, string nombre, string apellido, string ci, Especialidad especialidad)
        {
            Tecnico tecnicoExistente = tecnicos.FirstOrDefault(t => t.Ci == ci);
            if (tecnicoExistente != null)
            {
                // Actualiza los atributos del técnico encontrado
                tecnicoExistente.Nombre = nombre;
                tecnicoExistente.Apellido = apellido;
                tecnicoExistente.Especialidad = especialidad;
            }
            else
            {
                
                //Error
                
            }
        }

        public void eliminar(List<Tecnico> Tecnicos, string ci)
        {

            Tecnico tecnicoExistente = tecnicos.FirstOrDefault(t => t.Ci == ci);
            if (tecnicoExistente != null)
            {
                Tecnicos.Remove(tecnicoExistente);
            }
            else
            {

                //Error

            }

        }



    }
}