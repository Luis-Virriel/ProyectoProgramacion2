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
            new Cliente { Nombre = "Juan", Apellido = "Pérez", CI = "12345678", Direccion = "Calle Falsa 123", Telefono = "555-1234", Email = "juan.perez@easd.com" },
            new Cliente { Nombre = "María", Apellido = "González", CI = "87654321", Direccion = "Avenida Siempre Viva 456", Telefono = "555-5678", Email = "maria.gonzalez@dasdasd.com" },
            new Cliente { Nombre = "Carlos", Apellido = "Sánchez", CI = "11223344", Direccion = "Calle Real 789", Telefono = "555-9101", Email = "carlos.sanchez@sefesf3.com" },
            new Cliente { Nombre = "Ana", Apellido = "Lopez", CI = "22334455", Direccion = "Boulevard de los Sueños 101", Telefono = "555-1213", Email = "ana.lopez@por.com" },
            new Cliente { Nombre = "Luis", Apellido = "Martinez", CI = "33445566", Direccion = "Plaza Mayor 202", Telefono = "555-1415", Email = "luis.martinez@ejimplo.com" }
        };
        public static List<Tecnico> Tecnicos { get; set; } = new List<Tecnico>
        {
            new Tecnico { Nombre = "Pedro", Apellido = "Ramírez", CI = "99887766", Especialidad = Especialidad.ReparacionElectrodomesticos },
            new Tecnico { Nombre = "Lucía", Apellido = "Cruz", CI = "88776655", Especialidad = Especialidad.Informatica },
            new Tecnico { Nombre = "Jorge", Apellido = "Hernandez", CI = "77665544", Especialidad = Especialidad.Mecanica },
            new Tecnico { Nombre = "Sofía", Apellido = "Morales", CI = "66554433", Especialidad = Especialidad.Electricidad },
            new Tecnico { Nombre = "Andrés", Apellido = "Martínez", CI = "55443322", Especialidad = Especialidad.Plomeria }
        };
        
        public static List<OrdenTrabajo> OrdenesDeTrabajo { get; set; } = new List<OrdenTrabajo>();


        public static int GenerarNumeroOrden()
        {
            return OrdenesDeTrabajo.Count + 1;
        }
    
    }
}
