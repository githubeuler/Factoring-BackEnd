using Factoring.Application.DTOs.Ubigeo;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IUbigeoRepositoryAsync
    {
        Task<IReadOnlyList<UbigeoGetDto>> GetUbigeoAsync(int IdPais, int Tipo, string Codigo);
        Task<IReadOnlyList<UbigeoDataPeru>> GetUbigeoDataPeruAsync(string codDep, string codProv, string distrito);
    }
}
