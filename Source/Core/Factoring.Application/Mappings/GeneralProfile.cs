using AutoMapper;
using Factoring.Application.DTOs.Account.Request;
using Factoring.Application.Features.Usuario.Commands;

namespace Factoring.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<AuthenticateCommand, AuthenticationRequest>();
        }
    }
}
