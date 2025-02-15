using Factoring.Application.DTOs.Account.Request;
using Factoring.Application.DTOs.Account.Response;
using Factoring.Application.DTOs.Usuario;
using Factoring.Application.Wrappers;
using Factoring.Domain.Entities;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IUsuarioRepositoryAsync
    {
        Task<IEnumerable<Rol>> GetByIdRolesForUser(int id);
        Task<AuthenticationResponse> GetUserAuth(AuthenticationRequest userRequest);
        Task<List<MenuResponse>> GetListMenu(AuthenticationRequest userRequest);

        #region CRUD
        Task<Response<int>> AddAsync(UsuarioInsertDto entity);
        Task<Response<int>> UpdateAsync(UsuarioUpdateDto entity);
        Task<UsuarioGetByIdDto> GetByIdAsync(int id);
        Task<Response<int>> DeleteAsync(UsuarioDeleteDto entity);
        Task<IReadOnlyList<UsuarioResponseDataTable>> GetListUsuario(UsuarioRequestDataTable model);

        Task<Response<int>> ChangePassword(ChangePasswordRequest entity);
        Task<AccionRol> GetOpcionRol(string cAccion, int nOpcion);
        #endregion

    }
}
