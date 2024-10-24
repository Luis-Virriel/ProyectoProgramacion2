using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramacion2.Models
{
    public abstract class BaseDeDatos
    {
        public static List<Cliente> Clientes = new List<Cliente>();
        public static List<Tecnico> Tecnicos = new List<Tecnico>();
        public static List<OrdenTrabajo> OrdenesDeTrabajo = new List<OrdenTrabajo>();

        static BaseDeDatos()
        {
            
           // Clientes.Add(new Cliente {  Nombre = "Juan", Apellido = "Sanaco" , CI = "65574298", Direccion = "Las Larailas 69",  Telefono = "123456789" , Email = "soyemiliomanolo@gmail.com" });
            //Clientes.Add(new Cliente { Nombre = "Maria", Apellido = "Perice" ,CI = "05091265" , Direccion = "Las 69", Telefono = "123656789", Email = "soyemiliomanolo@gmail.com" });

            
            //Tecnicos.Add(new Tecnico {Nombre = "Carlos", Apellido = "Sanaco", CI = "65574298", Especialidad = "Mecánica" });
            //Tecnicos.Add(new Tecnico {Nombre = "Lucía", Apellido = "Perez", CI = "1334298", Especialidad = "Electrónica" });

            
            //OrdenesDeTrabajo.Add(new OrdenTrabajo { NumeroOrden = 1, Cliente = 1, TecnicoId = 1, Descripcion = "Revisión de motor" });
        }


        public static int GenerarNumeroOrden()  // Hay que ver si sirve para crear un número de orden único
        {
            return OrdenesDeTrabajo.Count + 1;
        }
    }
}