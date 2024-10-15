using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramacion2.Models
{
    public class Comentario
    {
        private string Texto;
        private DateTime Fecha;
        private Tecnico Autor;
        public Comentario(string texto, DateTime fecha, Tecnico autor)
        {
            Texto = texto;
            Fecha = fecha;
            Autor = autor;
        }

        public string getTexto()
        {
            return Texto;
        }

        public void setTexto(string texto)
        {
            Texto = texto;
        }

        public DateTime getFecha()
        {
            return Fecha;
        }

        public void setFecha(DateTime fecha)
        {
            Fecha = fecha;
        }

        public Tecnico getAutor()
        {
            return Autor;
        }

        public void setAutor(Tecnico autor)
        {
            Autor = autor;
        }



    }
}