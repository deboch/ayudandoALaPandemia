﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
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
