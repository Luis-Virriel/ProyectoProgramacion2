using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProyectoProgramacion2.Models
{
    public class Comentario
    {
        public int ComentarioID { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }

        public Comentario(int comentarioID, string texto, DateTime fecha)
        {
            ComentarioID = comentarioID;
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