using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavegacionLateralWPF.Repositories
{
    public interface CrudInterface<T>
    {
        List<T> ListarTodos();
        T? GetById(string id);
        void Eliminar(T item);
        void Registrar(T item);
        void EliminarTodos();

    }
}
