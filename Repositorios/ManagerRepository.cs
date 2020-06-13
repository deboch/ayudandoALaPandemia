namespace Repositorios
{
    public class ManagerRepository
    {
        protected Context contexto;

        public SearchRepository searchRepository;
        public UsuarioRepository usuarioRepository;
        public NecesidadesRepository necesidadesRepository;

        public ManagerRepository()
        {
            this.contexto = new Context();

            this.searchRepository = new SearchRepository(this.contexto);
            this.usuarioRepository = new UsuarioRepository(this.contexto);
            this.necesidadesRepository = new NecesidadesRepository(this.contexto);
        }
    }
}
