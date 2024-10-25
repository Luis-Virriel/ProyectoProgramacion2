using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramacion2.Models
{
    public class Comentario
    {
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public Tecnico Autor { get; set; }
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