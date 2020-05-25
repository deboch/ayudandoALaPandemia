﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios.DAL;

namespace Repositorios
{
    public class ManagerRepository
    {
        public Repositorios.DAL.Contexts contexto;

        // Aca cargar todos los repositorios
        public SearchRepository searchRepository;
        public UsuarioRepository usuarioRepository;
        public NecesidadesRepository necesidadesRepository;

        public ManagerRepository()
        {
            this.contexto = new Repositorios.DAL.Contexts();
            this.contexto.Configuration.LazyLoadingEnabled = false;

            this.searchRepository = new SearchRepository(this.contexto);
            this.usuarioRepository = new UsuarioRepository(this.contexto);
            this.necesidadesRepository = new NecesidadesRepository(this.contexto);
        }
    }
}
