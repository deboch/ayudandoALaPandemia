﻿using System;

namespace Repositorios
{
    public class ManagerRepository
    {
        protected Context contexto;

        public SearchRepository searchRepository;
        public UsuarioRepository usuarioRepository;
        public NecesidadesRepository necesidadesRepository;
        public DonacionesMonetariasRepository donacionesMonetariasRepository;
        public DonacionesInsumosRepository donacionesInsumosRepository;

        public ManagerRepository()
        {
            this.contexto = new Context();

            this.searchRepository = new SearchRepository(this.contexto);
            this.usuarioRepository = new UsuarioRepository(this.contexto);
            this.necesidadesRepository = new NecesidadesRepository(this.contexto);
            this.donacionesMonetariasRepository = new DonacionesMonetariasRepository(this.contexto);
            this.donacionesInsumosRepository = new DonacionesInsumosRepository(this.contexto);
        }

        public bool verificoActivo(bool activo)
        {
            throw new NotImplementedException();
        }
    }
}
