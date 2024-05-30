using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.EvaluacionOperaciones
{
    public class EvaluacionOperacionesResponseDataTable
    {
        public int nIdEvaluacionOperaciones { get; set; }
        public int nIdOperaciones { get; set; }
        public string? nNroOperacion { get; set; }
        public string? cRazonSocialGirador { get; set; }
        public string? cRazonSocialAdquiriente { get; set; }
        public DateTime dFechaCreacion { get; set; }
        public int nIdCatalogoEstado { get; set; }
        public string? NombreEstado { get; set; }
        public int TotalRecords { get; set; }

    }

    public class EvaluacionOperacionesRequestDataTable
    {
        public int Pageno { get; set; }
        public string? FilterNroOperacion { get; set; }
        public string? FilterRazonGirador { get; set; }
        public string? FilterRazonAdquiriente { get; set; }
        public string FilterEstado { get; set; }
        public string? FilterFecCrea { get; set; }
        public int PageSize { get; set; }
        public string? Sorting { get; set; }
        public string SortOrder { get; set; }


    }
    public class EvaluacionOperacionesInsertDto
    {
        public int IdOperaciones { get; set; }
        public int IdOperacionesFactura { get; set; }
        public int IdCatalogoEstado { get; set; }
        public string UsuarioCreador { get; set; }
        public string? Comentario { get; set; }
    }


    public class EvaluacionOperacionesComentariosDto
    {
        public int nIdOperaciones { get; set; }
        public DateTime dFechaCreacion { get; set; }
        public int nIdEvaluacionOperaciones { get; set; }
        public int nIdCatalaogoEstado { get; set; }
        public string NombreCatalogoEstado { get; set; }
        public string ComentarioEvaluacion { get; set; }

    }

    public class EvaluacionOperacionesSingleDto
    {
        public int nIdEvaluacionOperaciones { get; set; }
        public int nIdOperaciones { get; set; }
        public int nIdGirador { get; set; }
        public string RucGirador { get; set; }
        public int nIdAdquiriente { get; set; }
        public string RucAdquiriente { get; set; }
        public DateTime dFechaCreacion { get; set; }
        public string cUsuarioCreador { get; set; }
        public int nIdCatalogoEstado { get; set; }
        public string NombrenIdCatalogoEstado { get; set; }
        public string nNroOperacion { get; set; }
    }

    public class EstadoOperacionUpdateDto
    {
        public int nIdOperaciones { get; set; }
        public int IdEstadoGiradorEvaluacion { get; set; }
        public int IdEstadoAquirienteEvaluacion { get; set; }
        public int IdEstadoOperacionEvaluacion { get; set; }
        public string UsuarioActualizacion { get; set; }
    }

    public class SolicitudEvaluacionOperacionComercialInsertDto
    {
        public int nIdOperacion { get; set; }
        public string cMotivoTransaccion { get; set; }
        public string cSustentoComercial { get; set; }
        public decimal nPorcentajeFinanciamiento { get; set; }
        public decimal nImporteTotalPlanilla { get; set; }
        public decimal nComisionEstructuracion { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public decimal nTEM { get; set; }
        public int nPlazo { get; set; }
        public decimal nPorcentajeRetencion { get; set; }
        public int nResultado { get; set; }
        public string cUsuarioCreador { get; set; }
        public string cUsuarioActualizacion { get; set; }
        public int nIdGirador { get; set; }
        public int nIdAdquiriente { get; set; }
        public int nIdCategoria { get; set; }
        public int nIdTipoMoneda { get; set; }


    }

    public class SolicitudEvaluacionOperacionRiesgosInsertDto
    {
        public int nIdOperacion { get; set; }
        public string cMotivoTransaccion { get; set; }
        public string cSustentoComercial { get; set; }
        public decimal nPorcentajeFinanciamiento { get; set; }
        public decimal nImporteTotalPlanilla { get; set; }
        public decimal nComisionEstructuracion { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public decimal nTEM { get; set; }
        public int nPlazo { get; set; }
        public decimal nPorcentajeRetencion { get; set; }
        public string cUsuarioCreador { get; set; }
        public string cUsuarioActualizacion { get; set; }

        public int nIdGirador { get; set; }
        public int nIdAdquiriente { get; set; }
        public int nIdCategoria { get; set; }
        public int nIdTipoMoneda { get; set; }
    }

    public class OperacionesFacturasResCavaliListDto
    {
        public int nacqResponse { get; set; }
        public DateTime cacqResponseDate { get; set; }

    }

    public class CondicionesInsertDto
    {
        public int nIdOperacion { get; set; }
        public string cDescripcion { get; set; }
        public string cUsuarioCreador { get; set; }
    }

    public class CondicionesListDto
    {
        public int nIdSolSolEvalOperacionCondiciones { get; set; }
        public int nIdOperacion { get; set; }
        public string cDescripcion { get; set; }
    }

    public class SolicitudEvaluacionOperacionRiesgosListDto
    {
        public int nIdSolEvalOperacionRiesgos { get; set; }
        public int nIdOperacion { get; set; }
        public int nResultado { get; set; }
    }


    public class ResultadoEvaluacionRiesgosDto
    {
        public int nIdOperaciones { get; set; }
        public int nEstado { get; set; }
        public string cComentario { get; set; }
    }


    public class SolicitudValidacionOperacionRiesgosInsertDto
    {
        public int nIdOperacion { get; set; }
        public int nResultado { get; set; }
        public string cUsuarioCreador { get; set; }
    }

}
