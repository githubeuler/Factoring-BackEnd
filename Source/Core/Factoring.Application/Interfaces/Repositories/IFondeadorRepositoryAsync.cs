using Factoring.Application.DTOs.Fondeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IFondeadorRepositoryAsync
    {
        Task<IReadOnlyList<FondeadorGetAllDto>> GetAllAsync();
    }
}
