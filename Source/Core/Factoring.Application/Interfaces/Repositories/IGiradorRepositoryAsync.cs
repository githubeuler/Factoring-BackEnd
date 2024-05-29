using Factoring.Application.DTOs.Girador;
using Factoring.Application.Wrappers;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IGiradorRepositoryAsync
    {
        Task<Response<int>> AddAsync(GiradorInsertDto entity);
        Task<IReadOnlyList<GiradorResponseDataTable>> GetListGirador(GiradorRequestDataTable model);
        Task<IReadOnlyList<GiradorResponseList>> GetListaGirador();
    }
}
