using Factoring.Application.DTOs.Adquiriente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IAdquirienteRepositoryAsync
    {
        Task<IReadOnlyList<AdquirienteResponseLista>> GetListaAdquiriente();
    }
}
