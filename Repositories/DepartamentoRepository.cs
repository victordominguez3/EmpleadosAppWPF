using NavegacionLateralWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavegacionLateralWPF.Repositories
{
    internal class DepartamentoRepository: CrudInterface<Departamento>
    {

        private List<Departamento> departamentos = new List<Departamento>
        {
            
        };

        public DepartamentoRepository() { }

        public void Registrar(Departamento departamento)
        {
            if (departamentos.Exists(it => it.Id == departamento.Id))
            {
                Actualizar(departamento);
            }
            else
            {
                Agregar(departamento);
            }
        }

        private void Actualizar(Departamento item)
        {
            departamentos[departamentos.FindIndex(it => it.Id == item.Id)] = item;
        }

        private void Agregar(Departamento item)
        {
            departamentos.Add(item);
        }

        public void Eliminar(Departamento item)
        {
            departamentos.Remove(item);
        }

        public void EliminarTodos()
        {
            departamentos.Clear();
        }

        public Departamento? GetById(string id)
        {
            return departamentos.Find(it => it.Id == id);
        }

        public List<Departamento> ListarTodos()
        {
            return departamentos;
        }

    }
}
