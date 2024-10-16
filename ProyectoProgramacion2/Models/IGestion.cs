using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacion2.Models
{
    internal interface IGestion<clase>
    {

        void agregar();

        void editar(List<clase> lista , string CI);

        void eliminar(List<clase> lista ,string CI);


    }
}
