using AutoMapper;
using Factoring.Application.DTOs.Account.Request;
using Factoring.Application.DTOs.Catalogo;
using Factoring.Application.Features.Catalogo.Query.CatalogoListQuery;
using Factoring.Application.Features.Usuario.Commands;

namespace Factoring.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<AuthenticateCommand, AuthenticationRequest>();
            CreateMap<CatalogoListQuery, CatalogoListDto>();
        }
    }
}
