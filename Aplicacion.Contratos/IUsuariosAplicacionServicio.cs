﻿using Aplicacion.EntidadesDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Contratos
{
    public interface IUsuariosAplicacionServicio
    {
        Task<List<UsuariosDto>> GetUsuariosList();
    }
}
