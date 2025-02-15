using AutoMapper;
using Factoring.Application.DTOs.Account.Request;
using Factoring.Application.DTOs.Account.Response;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Domain.Settings;
using Factoring.Domain.Util;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Factoring.Application.Features.Usuario.Commands
{
    public partial class AcctionCommand:IRequest<Response<AccionRol>>
    {
        public string? cAccion { get; set; }
        public int nOpcion { get; set; }
    }
    public class AcctionCommandHandler : IRequestHandler<AcctionCommand, Response<AccionRol>>
    {
        private readonly IUsuarioRepositoryAsync _usuarioRepositoryAsync;
        private readonly IMapper _mapper;

        public AcctionCommandHandler(
            IUsuarioRepositoryAsync usuarioRepositoryAsync,
            IMapper mapper
            )
        {
            _usuarioRepositoryAsync = usuarioRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<AccionRol>> Handle(AcctionCommand request, CancellationToken cancellationToken)
        {
            var action = await _usuarioRepositoryAsync.GetOpcionRol(request.cAccion,request.nOpcion);
            return new Response<AccionRol>(action);
        }

    }
}

