using Aplicacion.Contratos;
using Aplicacion.EntidadesDto;
using Dominio.Servicios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicio
{
   public  class UsuarioAplicacionServicio : IUsuariosAplicacionServicio
    {
        private IUsuarioDominioServicio usuariosDominioServicio;

        public UsuarioAplicacionServicio(IUsuarioDominioServicio _usuariosDominioServicio)
        {
            this.usuariosDominioServicio = _usuariosDominioServicio;
        }
        public async  Task<List<UsuariosDto>> GetUsuariosList()
        {
            var usuarioslist = await usuariosDominioServicio.GetMenuList();

            UsuariosDto dto = new UsuariosDto();

            List<UsuariosDto> usuariosDtosList = new List<UsuariosDto>();

            foreach (var item in usuarioslist)
            {
                dto.Iduser = item.Iduser;
                dto.Nombres = item.Nombres;
                dto.Apellido1  = item.Apellido1;
                usuariosDtosList.Add(dto);
            }
          
                    return usuariosDtosList;

        }
    }
}


//private IProbabilidadDominioServicios ProbabilidadDominioServicio;
//private readonly IMapper _mapper;
//public ProbabilidadAplicacionServicio(IProbabilidadDominioServicios _ProbabilidadDominioServicio, IMapper _mapper)
//{
//    this.ProbabilidadDominioServicio = _ProbabilidadDominioServicio;
//    this._mapper = _mapper;
//}
//var probabilidades = await ProbabilidadDominioServicio.ObteneerTodos();
//var probabilidadesdto = _mapper.Map<List<ProbabilidadesDto>>(probabilidades);

//            return probabilidadesdto;
