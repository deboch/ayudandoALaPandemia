using System.Collections.Generic;

namespace Servicios
{
    interface ICrud<T>
    {
        int Crear(T obj);
        T Modificar(T obj);
        List<T> ObtenerTodos();
        int Borrar(T obj);
        T ObtenerPorId(int id);
    }
}
