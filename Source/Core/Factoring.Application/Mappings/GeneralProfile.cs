using AutoMapper;
using Factoring.Application.DTOs.Account.Request;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.DTOs.Adquiriente.UbicacionAdquiriente;
using Factoring.Application.DTOs.Catalogo;
using Factoring.Application.DTOs.Girador;
using Factoring.Application.DTOs.Girador.UbicacionGirador;
using Factoring.Application.DTOs.EvaluacionOperaciones;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Features.Adquiriente.Commands;
using Factoring.Application.Features.Adquiriente.Queries;
using Factoring.Application.Features.AdquirienteDetails.AdquirienteUbicacion.Commands;
using Factoring.Application.Features.Catalogo.Query.CatalogoListQuery;
using Factoring.Application.Features.Girador.Commands;
using Factoring.Application.Features.Girador.Queries;
using Factoring.Application.Features.GiradorDetails.GiradorUbicacion.Commands;
using Factoring.Application.Features.Operaciones.Commands;
//using Factoring.Application.Features.Operaciones.Commands;
using Factoring.Application.Features.Operaciones.Queries.OperacionesSearchDataTable;
using Factoring.Application.Features.OperacionesFacturas.Commands;
using Factoring.Application.Features.Usuario.Commands;
using Factoring.Application.Features.Operaciones.Commands.UpdateOperacion;
using Factoring.Application.Features.Operaciones.Commands.DeleteOperacion;
using Factoring.Application.Features.Operaciones.Queries.OperacionesReport;
using Factoring.Application.Features.GiradorDetails.Contacto.Commands.CreateContactoGirador;
using Factoring.Application.Features.GiradorDetails.Contacto.Commands.DeleteContactoGirador;
using Factoring.Application.Features.GiradorDetails.Documentos.Commands.GiradorDocumentoInsertCommand;
using Factoring.Application.Features.GiradorDetails.Documentos.Commands.GiradorDocumentoDeleteCommand;
using Factoring.Application.DTOs.Girador.ContactoGirador;
using Factoring.Application.DTOs.Girador.Documentos;
using Factoring.Application.Features.Fondeador.Queries.FondeadorSearch;
using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.Features.Fondeador.Commands;
using Factoring.Application.Features.Fondeador.Commands.UpdateFondeador;
using Factoring.Application.Features.FondeadorDetails.Cavali.Commands.CreateCavaliFondeador;
using Factoring.Application.Features.FondeadorDetails.Cavali.Commands.DeleteCavaliFondeador;
using Factoring.Application.DTOs.Fondeador.CavaliFondeador;
using Factoring.Application.Features.FondeadorDetails.Documentos.Commands.CreateDocumentoFondeador;
using Factoring.Application.Features.FondeadorDetails.Documentos.Commands.DeleteDocumentoFondeador;
using Factoring.Application.DTOs.Fondeador.DocumentoFondeador;
using Factoring.Application.Features.FondeadorDetails.Documentos.Querys.GetAllFondeadorByIdFondeador;
using Factoring.Application.Features.Aceptante.Commands;
using Factoring.Application.Features.DocumentosAceptante.Commands;
using Factoring.Application.DTOs.DocumentosAceptante;
using Factoring.Application.Features.AceptanteContacto.Commands;
using Factoring.Application.DTOs.ContactoAceptante;

namespace Factoring.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<AuthenticateCommand, AuthenticationRequest>();
            CreateMap<CatalogoListQuery, CatalogoListDto>();
            CreateMap<GetAdquirienteListAll, AdquirienteRequestDataTable>();
            CreateMap<GetGiradorListAll, GiradorRequestDataTable>();
            CreateMap<CreateGiradorCommand, GiradorInsertDto>();
            CreateMap<CreateAdquirienteCommand, AdquirienteInsertDto>();
            CreateMap<CreateOperacionCommand, OperacionesInsertDto>();
            CreateMap<CreateOperacionFacturaCommand, OperacionesFacturaInsertDto>();
            CreateMap<CreateGiradorUbicacionCommand, UbicacionGiradorInsertDto>();
            CreateMap<CreateAdquirienteUbicacionCommand, UbicacionAdquirienteInsertDto>();
            CreateMap<DeleteGiradorUbicacionCommand, UbicacionGiradorDeleteDto>();
            CreateMap<GetOperacionesGetDataTableQuery, OperacionesRequestDataTableDto>();
            CreateMap<CatalogoListCategoriaQuery, CatalogoListDto>();
            CreateMap<CreateEvaluacionOperacionCommand, EvaluacionOperacionesInsertDto>();
            CreateMap<CreateEstadoFacturaOperacionCommand, EvaluacionOperacionesInsertDto>();
            CreateMap<UpdateOperacionCommand, OperacionesUpdateDto>();
            CreateMap<DeleteOperacionFacturaCommand, OperacionesFacturaDeleteDto>();
            CreateMap<DeleteOperacionByIdCommand, OperacionesDeleteDto>();
            CreateMap<GetOperacionesGetDataTableDonwloadQuery, OperacionesRequestDataTableDto>();
            CreateMap<EditOperacionFacturaCommand, OperacionesFacturaEditDto>();
            CreateMap<UpdateEvaluacionOperacionCalculoCommand, EvaluacionOperacionesCalculoInsertDto>();
            CreateMap<EditOperacionFacturaMontoCommand, OperacionesFacturaEditMontoDto>();

            CreateMap<CreateGiradorContactoCommand, ContactoGiradorCreateDto>();
            CreateMap<DeleteContactoGiradorCommand, ContactoGiradorDeleteDto>();
            CreateMap<GiradorDocumentoInsertCommand, DocumentosGiradorInsertDto>();
            CreateMap<GiradorDocumentoDeleteCommand, DocumentosGiradorDeleteDto>();
            CreateMap<UpdateGiradorCommand, GiradorUpdateDto>();
            CreateMap<GetFondeadorListAll, FondeadorRequestDataTable>();
            CreateMap<CreateFondeadorCommand, FondeadorInsertDto>();
            CreateMap<UpdateFondeadorCommand, FondeadorUpdateDto>();
            CreateMap<CreateFondeadorCavaliCommand, CavaliFondeadorCreateDto>();
            CreateMap<DeleteCavaliFondeadorCommand, CavaliFondeadorDeleteDto>();
            CreateMap<CreateFondeadorDocumentoCommand, DocumentosFondeadorCreateDto>();
            CreateMap<DeleteDocumentoFondeadorCommand, DocumentosFondeadorDeleteDto>();
            CreateMap<GetAllDocumentoByIdFondeadorQuery, DocumentosFondeadorResponseListDto>();

            CreateMap<CreateAceptanteCommand, AdquirienteInsertDto>();
            CreateMap<AceptanteDocumentoInsertCommand, DocumentosAceptanteInsertDto>();
            CreateMap<AceptanteDocumentoDeleteCommand, DocumentosAceptanteDeleteDto>();
            CreateMap<UpdateAceptanteCommand, AdquirienteUpdateDto>();
            CreateMap <CreateContactoAceptanteCommand, ContactoAdquirienteCreateDto>();
            CreateMap<DeleteContactoAceptanteCommand, ContactoAdquirienteDeleteDto>();
            
                

        }
    }
}
