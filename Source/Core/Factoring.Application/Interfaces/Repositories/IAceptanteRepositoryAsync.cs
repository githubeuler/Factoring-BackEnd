using Factoring.Application.DTOs.Aceptante;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IAceptanteRepositoryAsync
    {
        Task<AceptanteGetByIdDto> GetByIdAsync(int id);
        Task DeleteAsync(AdquirienteDeleteDto entity);
        Task<Response<int>> UpdateAsync(AdquirienteUpdateDto entity);
    }
}
