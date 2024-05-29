using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IOperacionesFacturaRepositoryAsync
    {
        Task<int> AddAsync(OperacionesFacturaInsertDto entity);
        Task DeleteAsync(OperacionesFacturaDeleteDto entity);
        Task EditAsync(OperacionesFacturaEditDto entity);
        Task<OperacionesFacturaListDto> FindByNumberAsync(int IdGirador, int IdAdquiriente, string NroFactura);
        Task<IReadOnlyList<OperacionesFacturaListDto>> GetAllFacturasByOperaciones(int id);

    }
}
