
using Factoring.Application.DTOs.Girador.ContactoGirador;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IGiradorContactoRepositoryAsync
    {
        Task<ResponseContatDto> AddAsync(ContactoGiradorCreateDto entity);
        Task DeleteAsync(ContactoGiradorDeleteDto entity);
        Task<IReadOnlyList<ContactoGiradorResponseListDto>> GetAllContactoByIdGirador(int id);
    }
}
