using AutoMapper;
using Factoring.Application.DTOs.Girador.ContactoGirador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.GiradorDetails.Contacto.Commands.CreateContactoGirador
{
    public class CreateGiradorContactoCommand : IRequest<Response<int>>
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public int IdGirador { get; set; }
        public int IdTipoContacto { get; set; }
    }

    public class CreateGiradorCommandHandler : IRequestHandler<CreateGiradorContactoCommand, Response<int>>
    {
        private readonly IGiradorContactoRepositoryAsync _giradorContactoRepositoryAsync;
        //private readonly IMailFunctionsRepositoryAsync _mailFunctionsRepositoryAsync;
        private readonly IMapper _mapper;
        //private readonly IEmailService _emailService;
        //public CreateGiradorCommandHandler(IGiradorContactoRepositoryAsync giradorContactoRepositoryAsync,
        //    IMailFunctionsRepositoryAsync mailFunctionsRepositoryAsync, IMapper mapper, IEmailService emailService)
        //{
        //    _giradorContactoRepositoryAsync = giradorContactoRepositoryAsync;
        //    _mailFunctionsRepositoryAsync = mailFunctionsRepositoryAsync;
        //    _mapper = mapper;
        //    _emailService = emailService;
        //}
        public CreateGiradorCommandHandler(IGiradorContactoRepositoryAsync giradorContactoRepositoryAsync, IMapper mapper)
        {
            _giradorContactoRepositoryAsync = giradorContactoRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateGiradorContactoCommand request, CancellationToken cancellationToken)
        {
            var contacto = _mapper.Map<ContactoGiradorCreateDto>(request);
            var res = await _giradorContactoRepositoryAsync.AddAsync(contacto);

            if (res.IdUsuario > 0 && request.IdTipoContacto == 1)
            {
                //var giradorTemplate = await _mailFunctionsRepositoryAsync.GetByCodigoTemplateAsync("CU001");
                //giradorTemplate.cCuerpo = giradorTemplate.cCuerpo.Replace("{idusuario}", res.IdUsuario.ToString());
                //List<string> olist = new List<string>();
                //olist.Add(request.Email);
                //await _emailService.SendAsync(new DTOs.Email.EmailRequest
                //{
                //    Body = giradorTemplate.cCuerpo,
                //    Subject = giradorTemplate.Asunto,
                //    Destinatarios = olist, //paramEmail.cDestinatarios.Split(',').ToList(),
                //    CcUser = olist//paramEmail.cCopia.Split(',').ToList()
                //});
            }
            return new Response<int>(res.IdGiradorContacto, Constantes.SUCCEDED_REGISTER_DETAIL);
        }
    }
}