using Factoring.Application.DTOs.ContactoAceptante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IAceptanteContactoRepositoryAsync
    {
        Task<int> AddAsync(ContactoAdquirienteCreateDto entity);
        Task DeleteAsync(ContactoAdquirienteDeleteDto entity);
        Task<IReadOnlyList<ContactoAdquirienteResponseListDto>> GetAllContactoByIdAdquiriente(int id);
    }
}
