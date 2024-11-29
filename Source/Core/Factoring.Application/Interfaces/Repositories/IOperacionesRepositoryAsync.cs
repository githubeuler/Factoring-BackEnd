using Factoring.Application.DTOs.Externo;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IOperacionesRepositoryAsync
    {
        Task<Response<int>> AddAsync(OperacionesInsertDto entity);
        Task<IReadOnlyList<OperacionesResponseDataTable>> GetListOperaciones(OperacionesRequestDataTableDto model);
        Task<OperacionesGetByIdDto> GetByIdAsync(int id);
        Task<Response<int>> UpdateAsync(OperacionesUpdateDto entity);
        Task DeleteAsync(OperacionesDeleteDto entity);
         Task<IReadOnlyList<ReportesGiradorOperacionesDTO>> GetListOperacionesDonwload(OperacionesRequestDataTableDto model);
        Task<DivisoGetFondeador> GetObtenerIversionista(int IdFactura);
        Task<int> GetprocessNumberFacturas();
        Task<string> GetFileBase64(string filename);
        Task<DivisoGetFondeador> GetObtenerIversionistaFSeleccionado(int iIdFondeador);
        Task<DivisoGetFondeador> GetObtenerIversionistaEnvio(int nCategoria, int nFondeador, int nNroEnvio, int nAsignacion);
    }
}
