using Factoring.Application.DTOs.Fondeo;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IFondeoRepositoryAsync
    {
        Task<IReadOnlyList<FondeoResponseDataTable>> GetListFondeo(FondeoRequestDataTable model);
        Task<IReadOnlyList<FondeoGetAllDto>> GetAllAsync();
        Task<bool> UpdateAsync(FondeoUpdateDto entity);
        Task<bool> InsertAsync(FondeoInsertDto entity);
        Task<bool> UpdateStateAsync(FondeoUpdateStateDto entity);
        Task<IReadOnlyList<ReporteFondeoDTO>> GetListFondeoDonwload(FondeoRequestDataTable model);
    }
}
