using Factoring.Application.DTOs.Catalogo;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface ICatalogoRepositoryAsync
    {
        Task<IReadOnlyList<CatalogoResponseListDto>> GetListCatalogo(CatalogoListDto model);
        Task<IReadOnlyList<CatalogoResponseListDto>> GetListCategoriaCatalogo(CatalogoListDto model);
    }
}
