using Factoring.Application.DTOs.EvaluacionOperaciones;
using Factoring.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IEvaluacionOperacionesRepositoryAsync
    {
        Task<Response<int>> AddAsync(EvaluacionOperacionesInsertDto entity,string guid = "");
        Task<Response<int>> AddFacturaAsync(EvaluacionOperacionesInsertDto entity);
        Task<Response<int>> UpdateFacturaAsync(EvaluacionOperacionesCalculoInsertDto entity);
        Task<int> AddFacturaEvaluacionAsync(EvaluacionOperacionesInsertDto entity);
        Task<Response<int>> GenerateCalculoFacturaAsync(EvaluacionOperacionesCalculoInsertDto entity);
    }
}
