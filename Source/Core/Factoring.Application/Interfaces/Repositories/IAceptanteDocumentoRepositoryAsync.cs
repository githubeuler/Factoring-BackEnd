using Factoring.Application.DTOs.DocumentosAceptante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IAceptanteDocumentoRepositoryAsync
    {
        Task<int> AddAsync(DocumentosAceptanteInsertDto entity);
        Task DeleteAsync(DocumentosAceptanteDeleteDto entity);
        Task<IReadOnlyList<DocumentosAceptanteListDto>> GetAllDocumentosByIdAceptante(int id);
    }
}
