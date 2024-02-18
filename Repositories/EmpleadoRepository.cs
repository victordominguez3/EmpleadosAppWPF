using NavegacionLateralWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavegacionLateralWPF.Repositories
{
    internal class EmpleadoRepository: CrudInterface<Empleado>
    {

        private List<Empleado> empleados = new List<Empleado>
        { 
            new Empleado("53715931Y", "Victor", "Dominguez Gomez", "Programador", "https://www.nationalgeographic.com.es/medio/2022/12/12/ardilla-2_d0a43045_221212154055_310x310.jpg", new Departamento("1", "Marketing")),
            new Empleado("53715932Y", "Victor", "Dominguez", "Programador", "https://img.freepik.com/foto-gratis/resumen-bombilla-creativa-sobre-fondo-azul-brillante-ia-generativa_188544-8090.jpg", new Departamento("0", "Desarrollo")),
            new Empleado("53715933Y", "Victor", "Dominguez", "Programador", "https://www.nationalgeographic.com.es/medio/2022/12/12/ardilla-2_d0a43045_221212154055_310x310.jpg", new Departamento("1", "Diseño")),
            new Empleado("53715934Y", "Victor", "Dominguez", "Programador", "https://www.nationalgeographic.com.es/medio/2022/12/12/ardilla-2_d0a43045_221212154055_310x310.jpg", new Departamento("1", "Marketing")),
            new Empleado("53715935Y", "Victor", "Dominguez", "Programador", "https://www.nationalgeographic.com.es/medio/2022/12/12/ardilla-2_d0a43045_221212154055_310x310.jpg", new Departamento("0", "Desarrollo")),
            new Empleado("53715936Y", "Victor", "Dominguez", "Programador", "https://www.nationalgeographic.com.es/medio/2022/12/12/ardilla-2_d0a43045_221212154055_310x310.jpg", new Departamento("3", "Diseño")),
            new Empleado("53715937Y", "Victor", "Dominguez", "Programador", "https://www.nationalgeographic.com.es/medio/2022/12/12/ardilla-2_d0a43045_221212154055_310x310.jpg", new Departamento("1", "Marketing")),
            new Empleado("53715938Y", "Victor", "Dominguez", "Programador", "https://www.nationalgeographic.com.es/medio/2022/12/12/ardilla-2_d0a43045_221212154055_310x310.jpg", new Departamento("0", "Desarrollo")),
            new Empleado("53715939Y", "Victor", "Dominguez", "Programador", "https://www.nationalgeographic.com.es/medio/2022/12/12/ardilla-2_d0a43045_221212154055_310x310.jpg", new Departamento("1", "Marketing")),
            new Empleado("537159310Y", "Victor", "Dominguez", "Programador", "https://www.nationalgeographic.com.es/medio/2022/12/12/ardilla-2_d0a43045_221212154055_310x310.jpg", new Departamento("0", "Desarrollo")),
            new Empleado("537159311Y", "Victor", "Dominguez", "Programador", "https://www.nationalgeographic.com.es/medio/2022/12/12/ardilla-2_d0a43045_221212154055_310x310.jpg", new Departamento("1", "Marketing")),
            new Empleado("537159312Y", "Victor", "Dominguez", "Programador", "https://www.nationalgeographic.com.es/medio/2022/12/12/ardilla-2_d0a43045_221212154055_310x310.jpg", new Departamento("2", "Recursos humanos")),
            new Empleado("537159313Y", "Victor", "Dominguez", "Programador", "https://img.freepik.com/foto-gratis/resumen-bombilla-creativa-sobre-fondo-azul-brillante-ia-generativa_188544-8090.jpg", new Departamento("1", "Marketing")),
            new Empleado("537159312Y", "Victor", "Dominguez", "Programador", "https://www.nationalgeographic.com.es/medio/2022/12/12/ardilla-2_d0a43045_221212154055_310x310.jpg", new Departamento("2", "Recursos humanos"))
        };

        public void Registrar(Empleado empleado)
        {
            if (empleados.Exists(it => it.Dni == empleado.Dni))
            {
                Actualizar(empleado);
            }
            else
            {
                Agregar(empleado);
            }
        }

        private void Actualizar(Empleado item)
        {
            empleados[empleados.FindIndex(it => it.Dni == item.Dni)] = item;
        }

        private void Agregar(Empleado item)
        {
            empleados.Add(item);
        }

        public void Eliminar(Empleado item)
        {
            empleados.Remove(item);
        }

        public void EliminarTodos()
        {
            empleados.Clear();
        }

        public Empleado? GetById(string id)
        {
            return empleados.Find(it => it.Dni == id);
        }

        public List<Empleado> ListarTodos()
        {
            return empleados;
        }

    }
}
