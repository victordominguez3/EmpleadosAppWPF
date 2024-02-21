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
