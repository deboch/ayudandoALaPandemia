using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayudandoALaPandemia.ViewModels;
using Repositorios;


namespace ayudandoALaPandemia.Builder
{
    public class DenunciaBuilder
    {
        public Denuncias toDenunciasEntity(DenunciaNecesidadDto denunciaDto)
        {
            Denuncias nuevaDenuncia = new Denuncias();
            nuevaDenuncia.Comentarios = denunciaDto.comentarios;
            nuevaDenuncia.IdNecesidad = denunciaDto.necesidadId;
            nuevaDenuncia.IdMotivo = denunciaDto.motivoDenunciaId;
            nuevaDenuncia.IdUsuario = denunciaDto.usuarioId;
            nuevaDenuncia.FechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));
            nuevaDenuncia.Estado = 0;
            return nuevaDenuncia;
        }
    }
}