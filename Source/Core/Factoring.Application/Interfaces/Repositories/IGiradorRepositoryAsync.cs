using Factoring.Application.DTOs.Girador;
using Factoring.Application.Features.Girador.Queries;
using Factoring.Application.Wrappers;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IGiradorRepositoryAsync
    {
        Task<Response<int>> AddAsync(GiradorInsertDto entity);
        Task<IReadOnlyList<GiradorResponseDataTable>> GetListGirador(GiradorRequestDataTable model);
        Task<IReadOnlyList<GiradorResponseList>> GetListaGirador();
        Task<GiradorGetByIdDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(GiradorUpdateDto entity);
        Task<GetGiradorDocumentosFileName> GetDocumentosFileName(int IdDocumento, int IdTipo);
    }
}
