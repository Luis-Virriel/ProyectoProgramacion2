using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramacion2.Models
{
    public abstract class BaseDeDatos
    {
        public static List<Cliente> Clientes { get; set; } = new List<Cliente>
        {
            new Cliente("Juan", "Pérez", "51742259", "Calle Falsa 123", "555-1234", "juan.perez@easd.com"),
            new Cliente("María", "González", "33896775", "Avenida Siempre Viva 456", "555-5678", "maria.gonzalez@dasdasd.com"),
            new Cliente("Carlos", "Sánchez", "30152485", "Calle Real 789", "555-9101", "carlos.sanchez@sefesf3.com"),
            new Cliente("Ana", "Lopez", "28886967", "Boulevard  101", "555-1213", "ana.lopez@por.com"),
            new Cliente("Pepe", "Martinez", "40579087", "Plaza 202", "555-1415", "luis.martinez@ejimplo.com")
        };

        public static List<Tecnico> Tecnicos { get; set; } = new List<Tecnico>
        {
            new Tecnico("Pedro", "Ramírez", "57211058", Especialidad.ReparacionElectrodomesticos),
            new Tecnico("Lucía", "Cruz", "32100531", Especialidad.Informatica),
            new Tecnico("Luis", "Virriel", "44952182", Especialidad.Informatica),
            new Tecnico("Jorge", "Hernandez", "4214160", Especialidad.Mecanica),
            new Tecnico("Danlee", "Garcia", "65574298", Especialidad.Informatica),
            new Tecnico("Andrés", "Martínez", "20839201", Especialidad.Plomeria)
        };
        public static List<OrdenTrabajo> OrdenesDeTrabajo { get; set; } = new List<OrdenTrabajo>();
        
        public static void AgregarOrden(Cliente cliente, Tecnico tecnico, string descripcionProblema, Estado estado)
        {
            int numeroOrden = GenerarNumeroOrden();
            OrdenTrabajo nuevaOrden = new OrdenTrabajo(numeroOrden, cliente, tecnico, descripcionProblema, estado);


            OrdenesDeTrabajo.Add(nuevaOrden);
        }

        public static int GenerarNumeroOrden()
        {
            if (OrdenesDeTrabajo.Count == 0)
            {
                return 1;
            }
            else
            {
                return OrdenesDeTrabajo.Max(o => o.NumeroOrden) + 1;
            }
        }
        public static void ActualizarOrden(OrdenTrabajo ordenActualizada)
        {
            var ordenExistente = OrdenesDeTrabajo.FirstOrDefault(o => o.NumeroOrden == ordenActualizada.NumeroOrden);
            if (ordenExistente != null)
            {
                ordenExistente.ClienteAsociado = ordenActualizada.ClienteAsociado;
                ordenExistente.TecnicoAsignado = ordenActualizada.TecnicoAsignado;
                ordenExistente.DescripcionProblema = ordenActualizada.DescripcionProblema;
                ordenExistente.Estado = ordenActualizada.Estado;
                ordenExistente.Comentarios = ordenActualizada.Comentarios;
                ordenExistente.FechaCompletada = ordenActualizada.FechaCompletada;
            }
        }


    }
}
