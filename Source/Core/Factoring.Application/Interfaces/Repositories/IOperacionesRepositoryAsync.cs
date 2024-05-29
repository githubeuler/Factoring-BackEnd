using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IOperacionesRepositoryAsync
    {
        Task<Response<int>> AddAsync(OperacionesInsertDto entity);
        Task<IReadOnlyList<OperacionesResponseDataTable>> GetListOperaciones(OperacionesRequestDataTableDto model);
        Task<OperacionesGetByIdDto> GetByIdAsync(int id);
    }
}
