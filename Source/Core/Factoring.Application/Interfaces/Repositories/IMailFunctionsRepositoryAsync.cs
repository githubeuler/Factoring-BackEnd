using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IMailFunctionsRepositoryAsync
    {
        Task<string> ObtenerTiempo();
    }
}
