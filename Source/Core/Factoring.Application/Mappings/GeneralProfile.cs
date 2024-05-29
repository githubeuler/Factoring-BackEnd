using AutoMapper;
using Factoring.Application.DTOs.Account.Request;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.DTOs.Adquiriente.UbicacionAdquiriente;
using Factoring.Application.DTOs.Catalogo;
using Factoring.Application.DTOs.Girador;
using Factoring.Application.DTOs.Girador.UbicacionGirador;
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
using Factoring.Application.Features.Operaciones.Queries.OperacionesSearchDataTable;
using Factoring.Application.Features.OperacionesFacturas.Commands;
using Factoring.Application.Features.Usuario.Commands;

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
            CreateMap<GetOperacionesGetDataTableQuery, OperacionesRequestDataTableDto>();
            CreateMap<CatalogoListCategoriaQuery, CatalogoListDto>();
        }
    }
}
