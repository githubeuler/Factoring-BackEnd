using AutoMapper;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.Features.Adquiriente.Commands;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.Aceptante.Commands
{
    public class CreateAceptanteCommand : IRequest<Response<int>>
    {
        public int IdPais { get; set; }
        public string? RegUnicoEmpresa { get; set; }
        public string? RazonSocial { get; set; }
        public int IdSector { get; set; }
        public int IdGrupoEconomico { get; set; }
        public string? UsuarioCreador { get; set; }
    }
    public class CreateAceptanteCommandHandler : IRequestHandler<CreateAdquirienteCommand, Response<int>>
    {
        private readonly IAceptanteRepositoryAsync _aceptanteRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateAceptanteCommandHandler(IAceptanteRepositoryAsync aceptanteRepositoryAsync, IMapper mapper)
        {
            _aceptanteRepositoryAsync = aceptanteRepositoryAsync;;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateAdquirienteCommand request, CancellationToken cancellationToken)
        {
            var girador = _mapper.Map<AdquirienteInsertDto>(request);
            var res = await _aceptanteRepositoryAsync.AddAsync(girador);
            return res;
        }
    }
}

