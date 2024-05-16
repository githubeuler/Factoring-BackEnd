using Factoring.Application.DTOs.Account.Request;
using Factoring.Application.DTOs.Account.Response;
using Factoring.Domain.Entities;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IUsuarioRepositoryAsync
    {
        Task<IEnumerable<Rol>> GetByIdRolesForUser(int id);
        Task<AuthenticationResponse> GetUserAuth(AuthenticationRequest userRequest);
        Task<List<MenuResponse>> GetListMenu(AuthenticationRequest userRequest);
    }
}
