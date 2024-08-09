using Factoring.Application.DTOs.Aceptante;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.Wrappers;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IAdquirienteRepositoryAsync
    {
        Task<Response<int>> AddAsync(AdquirienteInsertDto entity);
        Task<IReadOnlyList<AdquirienteResponseDataTable>> GetListAdquiriente(AdquirienteRequestDataTable model);
        Task<IReadOnlyList<AdquirienteResponseLista>> GetListaAdquiriente();  
    }
}
