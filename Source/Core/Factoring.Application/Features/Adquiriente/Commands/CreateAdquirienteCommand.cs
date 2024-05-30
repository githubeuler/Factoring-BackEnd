using AutoMapper;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Adquiriente.Commands
{
    public class CreateAdquirienteCommand : IRequest<Response<int>>
    {
        public int IdPais { get; set; }
        public string? RegUnicoEmpresa { get; set; }
        public string? RazonSocial { get; set; }
        public int IdSector { get; set; }
        public int IdGrupoEconomico { get; set; }
        public string? UsuarioCreador { get; set; }
    }
    public class CreateAdquirienteCommandHandler : IRequestHandler<CreateAdquirienteCommand, Response<int>>
    {
        private readonly IAdquirienteRepositoryAsync _adquirienteRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateAdquirienteCommandHandler(IAdquirienteRepositoryAsync adquirienteRepositoryAsync, IMapper mapper)
        {
            _adquirienteRepositoryAsync = adquirienteRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateAdquirienteCommand request, CancellationToken cancellationToken)
        {
            var girador = _mapper.Map<AdquirienteInsertDto>(request);
            var res = await _adquirienteRepositoryAsync.AddAsync(girador);
            return res;
        }
    }
}
