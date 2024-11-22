using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProyectoProgramacion2.Models
{
    public class Comentario
    {
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }

        public Comentario(string texto, DateTime fecha)
        {
            Texto = texto;
            Fecha = fecha;
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
    }
}