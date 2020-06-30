using System.Web.Mvc;
using Repositorios;
using Servicios;

namespace ayudandoALaPandemia.Controllers
{
    public class BaseController : Controller
    {
        // Instanciar los servicios
        public SearchServicios searchServicios;
        public LoginServicios loginServicios;
        public HomeServicios homeServicios;
        public NecesidadesServicios necesidadesServicios;
        public RegistroServicios registroServicios;
        public DonacionesMonetariasServicios donacionesMonetariasServicios;
        public DonacionesInsumosServicios donacionesInsumosServicios;
        public EmailServicios emailServicios;
        public DenunciasServicios denunciasServicio;

        public BaseController()
        {
            this.searchServicios = new SearchServicios();
            this.loginServicios = new LoginServicios();
            this.homeServicios = new HomeServicios();
            this.necesidadesServicios = new NecesidadesServicios();
            this.registroServicios = new RegistroServicios();
            this.donacionesMonetariasServicios = new DonacionesMonetariasServicios();
            this.donacionesInsumosServicios = new DonacionesInsumosServicios();
            this.emailServicios = new EmailServicios();
            this.denunciasServicio = new DenunciasServicios();
        }
    }
}