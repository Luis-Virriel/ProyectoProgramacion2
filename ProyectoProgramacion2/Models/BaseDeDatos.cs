using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramacion2.Models
{
    public abstract class BaseDeDatos
    {
        public static List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public static List<Tecnico> Tecnicos = new List<Tecnico>();
        public static List<OrdenTrabajo> OrdenesDeTrabajo = new List<OrdenTrabajo>();


        public static int GenerarNumeroOrden()  // Hay que ver si sirve para crear un número de orden único
        {
            return OrdenesDeTrabajo.Count + 1;
        }
    }
}