using Factoring.Application.DTOs.Girador.Documentos;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IGiradorDocumentoRepositoryAsync
    {
        Task<int> AddAsync(DocumentosGiradorInsertDto entity);
        Task DeleteAsync(DocumentosGiradorDeleteDto entity);
        Task<IReadOnlyList<DocumentosGiradorListDto>> GetAllDocumentosByIdGirador(int id);
    }
}
