using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramacion2.Models
{
    public class OrdenTrabajo
    {
        private int NumeroOrden;
        private Cliente ClienteAsociado;
        private Tecnico TecnicoAsignado;
        private string DescripcionProblema;
        private DateTime FechaCreacion;
        private Estado Estado; //Hay un enum creado para estados
        public List<Comentario> Comentarios;

        public OrdenTrabajo(int numeroOrden, Cliente clienteAsociado, Tecnico tecnicoAsignado, string descripcionProblema, Estado estado)
        {
            NumeroOrden = numeroOrden;
            ClienteAsociado = clienteAsociado;
            TecnicoAsignado = tecnicoAsignado;
            DescripcionProblema = descripcionProblema;
            FechaCreacion = DateTime.Now;
            Estado = estado;
            Comentarios = new List<Comentario>();
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
        public List<Comentario> getrComentarios()
        {
            return new List<Comentario>(Comentarios);
        }
        public void AgregarComentario(Comentario comentario)
        {
            Comentarios.Add(comentario);
        }


    }
}