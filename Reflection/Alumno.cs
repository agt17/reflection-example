using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Alumno
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }

        public Alumno()
        {

        }
        public Alumno(int IdAlumno, string Nombre, string Apellidos, string Dni)
        {
            this.IdAlumno = IdAlumno;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.Dni = Dni;
        }
    }
}
