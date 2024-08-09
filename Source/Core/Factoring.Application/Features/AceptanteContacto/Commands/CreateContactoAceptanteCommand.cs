using AutoMapper;
using Factoring.Application.DTOs.ContactoAceptante;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.AceptanteContacto.Commands
{
    public class CreateContactoAceptanteCommand : IRequest<Response<int>>
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public int IdAdquiriente { get; set; }
        public int IdTipoContacto { get; set; }

        public class CreateContactoAceptanteCommandHandler : IRequestHandler<CreateContactoAceptanteCommand, Response<int>>
        {
            private readonly IAceptanteContactoRepositoryAsync _aceptanteContactoRepositoryAsync;
            private readonly IMapper _mapper;

            public CreateContactoAceptanteCommandHandler(IAceptanteContactoRepositoryAsync aceptanteContactoRepositoryAsync, IMapper mapper)
            {
                _aceptanteContactoRepositoryAsync = aceptanteContactoRepositoryAsync;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(CreateContactoAceptanteCommand request, CancellationToken cancellationToken)
            {
                var contacto = _mapper.Map<ContactoAdquirienteCreateDto>(request);
                var res = await _aceptanteContactoRepositoryAsync.AddAsync(contacto);
                return new Response<int>(res, Constantes.SUCCEDED_REGISTER_DETAIL);
            }
        }
    }
}
