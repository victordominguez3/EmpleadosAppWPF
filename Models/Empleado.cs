using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavegacionLateralWPF.Models
{
    public class Empleado
    {
        private string dni;
        private string nombre;
        private string apellidos;
        private string puesto;
        private string urlImagen;
        private Departamento departamento;

        public Empleado(string dni, string nombre, string apellidos, string puesto, string urlImagen, Departamento departamento)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.puesto = puesto;
            this.urlImagen = urlImagen;
            this.departamento = departamento;
        }

        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Puesto { get => puesto; set => puesto = value; }
        public string UrlImagen { get => urlImagen; set => urlImagen = value; }
        public Departamento Departamento { get => departamento; set => departamento = value; }


        public override string ToString()
        {
            return $"{dni} - {nombre} {apellidos}";
        }
    }
}
