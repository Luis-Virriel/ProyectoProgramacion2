using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoProgramacion2.Models;

namespace ProyectoProgramacion2.Models
{
    public class OrdenTrabajo
    {
        public int NumeroOrden { get; set; }
        public Cliente ClienteAsociado { get; set; }
        public Tecnico TecnicoAsignado { get; set; }
        public string DescripcionProblema { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Estado Estado { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public DateTime? FechaCompletada { get; set; } 

        public OrdenTrabajo(int numeroOrden, Cliente clienteAsociado, Tecnico tecnicoAsignado, string descripcionProblema, Estado estado)
        {
            NumeroOrden = numeroOrden;
            ClienteAsociado = clienteAsociado;
            TecnicoAsignado = tecnicoAsignado;
            DescripcionProblema = descripcionProblema;
            FechaCreacion = DateTime.Now;
            Estado = estado;
            Comentarios = new List<Comentario>();
            FechaCompletada = null; 

        }


       
        public int getNumeroOrden()
        {
            return NumeroOrden;
        }

        public void setNumeroOrden(int numeroOrden)
        {
            NumeroOrden = numeroOrden;
        }

        public Cliente getClienteAsociado()
        {
            return ClienteAsociado;
        }

        public void setClienteAsociado(Cliente clienteAsociado)
        {
            ClienteAsociado = clienteAsociado;
        }

        public Tecnico getTecnicoAsignado()
        {
            return TecnicoAsignado;
        }

        public void setTecnicoAsignado(Tecnico tecnicoAsignado)
        {
            TecnicoAsignado = tecnicoAsignado;
        }

        public string getDescripcionProblema()
        {
            return DescripcionProblema;
        }

        public void setDescripcionProblema(string descripcionProblema)
        {
            DescripcionProblema = descripcionProblema;
        }

        public DateTime getFechaCreacion()
        {
            return FechaCreacion;
        }

        public void setFechaCreacion(DateTime fechaCreacion)
        {
            FechaCreacion = fechaCreacion;
        }

        public Estado getEstado()
        {
            return Estado;
        }

        public void setEstado(Estado estado)
        {
            Estado = estado;
        }
        public List<Comentario> getComentarios()
        {
            return new List<Comentario>(Comentarios);
        }
        public void AgregarComentario(Comentario comentario)
        {
            Comentarios.Add(comentario);
        }
        public void MarcarComoCompletada()
        {
            Estado = Estado.Completada;
            FechaCompletada = DateTime.Now; 
        }
    }
}