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
        public Denuncias toDenunciasEntity(DenunciaDto denunciaDto, int userId)
        {
            Denuncias nuevaDenuncia = new Denuncias();
            //nuevaDenuncia.IdNecesidad = necesidadId;
            MotivoDenuncia motivo = new MotivoDenuncia();
            motivo.IdMotivoDenuncia = denunciaDto.MotivoDenuncia;
            nuevaDenuncia.MotivoDenuncias.Add(motivo);
            nuevaDenuncia.Comentarios = denunciaDto.Comentarios;
            nuevaDenuncia.IdUsuario = userId;
            nuevaDenuncia.FechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));
            nuevaDenuncia.Estado = denunciaDto.Estado;
            return nuevaDenuncia;
        }
    }
}