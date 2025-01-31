using Factoring.Application.DTOs.MenuAcciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IModuloMenuSeguridadRepositoryAsync
    {
        Task<IReadOnlyList<MenuAccionesResponseDto>> GetListNenuModulo(int nRol);
        Task<IReadOnlyList<PerfilResponseDto>> GetListRol(PerfilRequestDto model);
        Task<int> AddAsync(ModuloDTO entity);
        Task<PerfilResponseEditDto> GetListRolEdit(int nIdRol);

        Task<int> UpdateAsync(int nIdRol);
    }
}
