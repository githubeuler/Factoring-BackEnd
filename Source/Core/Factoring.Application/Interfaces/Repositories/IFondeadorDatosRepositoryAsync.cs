
using Factoring.Application.Features.Fondeador.DatosFondeador;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IFondeadorDatosRepositoryAsync
    {
        Task<int> AddAsync(DatosFondeadorCreateDto entity);
        Task<IReadOnlyList<DatosFondeadorResponseListDto>> GetAllDatosByIdFondeador(int id);
        Task DeleteAsync(DatosFondeadorDeleteDto entity);
        Task<int> AddPrestamoAsync(DatosFondeadorPrestamoCreateDto entity);
        Task<IReadOnlyList<FondeadorPrestamoResponseListDto>> GetAllPrestamoByIdFondeador(int id);
        Task DeletePrestamoAsync(FondeadorPrestamoDeleteDto entity);
    }
}
