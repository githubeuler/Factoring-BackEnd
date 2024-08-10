using Factoring.Application.DTOs.Fondeador.DocumentoFondeador;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IFondeadorDocumentoRepositoryAsync
    {
        Task<int> AddAsync(DocumentosFondeadorCreateDto entity);
        Task DeleteAsync(DocumentosFondeadorDeleteDto entity);
        Task<IReadOnlyList<DocumentosFondeadorResponseListDto>> GetAllDocumentosByIdGirador(int id);
    }
}
