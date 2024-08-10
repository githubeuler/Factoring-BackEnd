using Factoring.Application.DTOs.Fondeador.CavaliFondeador;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IFondeadorCavaliRepositoryAsync
    {
        Task<int> AddAsync(CavaliFondeadorCreateDto entity);
        Task<IReadOnlyList<CavaliFondeadorResponseListDto>> GetAllCavaliByIdFondeador(int id);
        Task DeleteAsync(CavaliFondeadorDeleteDto entity);
    }
}
