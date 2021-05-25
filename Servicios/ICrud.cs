using System.Collections.Generic;

namespace Servicios
{
    interface ICrud<T>
    {
        int Crear(T obj);
        T Modificar(T obj);
        List<T> ObtenerTodos();
        int Borrar(int id);
        T ObtenerPorId(int id);
    }
}
