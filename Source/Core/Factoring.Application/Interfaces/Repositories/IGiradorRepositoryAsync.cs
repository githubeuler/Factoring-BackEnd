using Factoring.Application.DTOs.Girador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IGiradorRepositoryAsync
    {
        Task<IReadOnlyList<GiradorResponseList>> GetListaGirador();
    }
}
