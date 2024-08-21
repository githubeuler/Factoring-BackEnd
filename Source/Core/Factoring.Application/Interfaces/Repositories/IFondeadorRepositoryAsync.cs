using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.DTOs.Fondeador.ControlFileFondeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IFondeadorRepositoryAsync
    {
        Task<IReadOnlyList<FondeadorResponseDataTable>> GetListFondeador(FondeadorRequestDataTable model);
        Task<int> AddAsync(FondeadorInsertDto entity);
        Task DeleteAsync(FondeadorDeleteDto entity);
        Task<bool> UpdateAsync(FondeadorUpdateDto entity);
        Task<FondeadorGetByIdDto> GetByIdAsync(int id);
        Task<IReadOnlyList<FondeadorGetByIdDto>> GetByTipoFondeoAsync(int id);
        Task<IReadOnlyList<FileExportFondeadorResponseDto>> GetListFileExport(FileExportFondeadorRequestDto request);
        Task<IReadOnlyList<FondeadorGetAllDto>> GetAllAsync();
    }
}
