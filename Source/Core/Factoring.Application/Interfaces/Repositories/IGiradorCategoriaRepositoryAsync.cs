using Factoring.Application.DTOs.Girador.Confirming;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IGiradorCategoriaRepositoryAsync
    {
        Task<IReadOnlyList<GiradorConfirmingDto>> GetAllCategoriaByIdGirador(int id);
    }
}
