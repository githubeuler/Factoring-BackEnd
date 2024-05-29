using Factoring.Application.DTOs.Adquiriente.UbicacionAdquiriente;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IAdquirienteDireccionRepositoryAsync
    {
        Task<int> AddAsync(UbicacionAdquirienteInsertDto entity);
        Task DeleteAsync(UbicacionAdquirienteDeleteDto entity);
        Task<IReadOnlyList<UbicacionAdquirienteListDto>> GetAllDireccionByIdAdquiriente(int id);

    }
}
