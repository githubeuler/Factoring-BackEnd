using AutoMapper;
using Factoring.Application.DTOs.Girador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Girador.Commands
{
    public class CreateGiradorCommand : IRequest<Response<int>>
    {
        public int IdPais { get; set; }
        public string?  RegUnicoEmpresa { get; set; }
        public string? RazonSocial { get; set; }
        public int IdSector { get; set; }
        public decimal Venta { get; set; }
        public decimal Compra { get; set; }
        public int IdGrupoEconomico { get; set; }
        public string? UsuarioCreador { get; set; }
    }

    public class CreateGiradorCommandHandler : IRequestHandler<CreateGiradorCommand, Response<int>>
    {
        private readonly IGiradorRepositoryAsync _giradorRepositoryAsync;
        /*private readonly IMailFunctionsRepositoryAsync _mailFunctionsRepositoryAsync;
        private readonly IEmailService _emailService;*/
        private readonly IMapper _mapper;

        public CreateGiradorCommandHandler(IGiradorRepositoryAsync giradorRepositoryAsync,
            IMapper mapper
           /* ,
           IEmailService emailService,
            IMailFunctionsRepositoryAsync mailFunctionsRepositoryAsync*/
           )
        {
            _giradorRepositoryAsync = giradorRepositoryAsync;
            _mapper = mapper/*;
            _mailFunctionsRepositoryAsync = mailFunctionsRepositoryAsync;
            _emailService = emailService*/;
        }

        public async Task<Response<int>> Handle(CreateGiradorCommand request, CancellationToken cancellationToken)
        {
            var girador = _mapper.Map<GiradorInsertDto>(request);
            var res = await _giradorRepositoryAsync.AddAsync(girador);

            /*var giradorTemplate = await _mailFunctionsRepositoryAsync.GetByCodigoTemplateAsync("ALGR01");

            giradorTemplate.cCuerpo = giradorTemplate.cCuerpo
                .Replace("{0}", request.RegUnicoEmpresa)
                .Replace("{{razon}}", request.RazonSocial)
                .Replace("{{representante}}", "")
                .Replace("{{id-url}}", $"/api/v1/Girador/{res.Data}");

            await _emailService.SendAsync(new DTOs.Email.EmailRequest
            {
                Body = giradorTemplate.cCuerpo,
                Subject = giradorTemplate.Asunto,
                Destinatarios = giradorTemplate.cDestinatarios.Split(",").ToList(),
                CcUser = giradorTemplate.cCopia.Split(",").ToList()
            });*/

            return res;
        }
    }
}
