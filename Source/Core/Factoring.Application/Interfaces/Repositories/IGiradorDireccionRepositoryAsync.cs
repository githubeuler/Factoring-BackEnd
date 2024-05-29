using Factoring.Application.DTOs.Girador.UbicacionGirador;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IGiradorDireccionRepositoryAsync
    {
        Task<int> AddAsync(UbicacionGiradorInsertDto entity);
        Task DeleteAsync(UbicacionGiradorDeleteDto entity);
        Task<IReadOnlyList<UbicacionGiradorListDto>> GetAllDireccionByGirador(int id);
        Task<UbicacionGiradorSingleDto> GetUbicacionSingleAsync(string codDep, string codProv, string codDistrito);
        Task<DireccionGiradorSingleDto> GetDireccionSingleAsync(int idGirador, int tipo);
    }
}
