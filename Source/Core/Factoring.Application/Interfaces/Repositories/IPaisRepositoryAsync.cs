using Factoring.Application.DTOs.Pais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IPaisRepositoryAsync
    {
        Task<IReadOnlyList<GrupoListDto>> GetListGrupo(int tipo, int? idPais);
        Task<IReadOnlyList<SectorListDto>> GetListSector(int tipo, int? idPais);
    }
}
