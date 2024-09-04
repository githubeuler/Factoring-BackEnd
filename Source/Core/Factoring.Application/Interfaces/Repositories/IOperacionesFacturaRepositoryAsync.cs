using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Wrappers;

namespace Factoring.Application.Interfaces.Repositories
{
    public interface IOperacionesFacturaRepositoryAsync
    {
        Task<int> AddAsync(OperacionesFacturaInsertDto entity);
        Task DeleteAsync(OperacionesFacturaDeleteDto entity);
        Task EditAsync(OperacionesFacturaEditDto entity);
        Task<OperacionesFacturaListDto> FindByNumberAsync(int IdGirador, int IdAdquiriente, string NroFactura);
        Task<IReadOnlyList<OperacionesFacturaListDto>> GetAllFacturasByOperaciones(int id);
        Task<IReadOnlyList<OperacionesFacturaListDto>> GetAllFacturasByOperacionesFacturas(int id);
        Task EditMontoAsync(OperacionesFacturaEditMontoDto entity);
        Task<IReadOnlyList<OperacionesFacturaResponseDataTable>> GetListFacturasBandeja(OperacionesFacturaRequestDataTableDto model);
        Task<Response<int>> ValidateEstadoOperacionesFacturasAsync(int IdOperacionFactura, int tipoOperacion);
        Task<IReadOnlyList<FondeadorGetPermisos>> GetValidateFondeadoresAsync(string facturas);
        Task<IReadOnlyList<FondeadorGetPermisos>> GetListadoFondeadoresAsync(string facturas);
        Task<OperacionesFacturaListDto> GetFacturaById(int id);
        Task<int> AddInvoicesLogCavaliAsync(OperacionesFacturaInsertCavaliDto entity);
        Task<IReadOnlyList<FacturasGetRegistro>> GetListaFacturasRegistradasAsync(string facturas, int nTipo);
        Task<int> AddDocumentoSolicitudOperacionesAsync(DocumentosSolicitudperacionesInsertDto entity);
        Task<IReadOnlyList<DocumentoSolicitudOperacionListDto>> GetDocumentoBySolicitud(int id);
        Task<IReadOnlyList<DocumentoSolicitudOperacionListIdDto>> GetAllDocumentoSolicitudByOperaciones(int id);
        Task DeleteDocumentoAsync(OperacionesSolicitudDeleteDto entity);
    }
}
