using AutoMapper;
using Factoring.Application.DTOs.MenuAcciones;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.ModuloMenu.Queries
{
    public class GetAccionesRolListAll : IRequest<Response<IReadOnlyList<AccionesResponseDto>>>
    {
        public int nIdRol { get; set; }
        public int nIdMenu { get; set; }
        public class GetAccionesRolListAllHandler : IRequestHandler<GetAccionesRolListAll, Response<IReadOnlyList<AccionesResponseDto>>>
        {
            private readonly IModuloMenuSeguridadRepositoryAsync _moduloMenuSeguridadRepositoryAsync;
            private readonly IMapper _mapper;
            public GetAccionesRolListAllHandler(IModuloMenuSeguridadRepositoryAsync moduloMenuSeguridadRepositoryAsync, IMapper mapper)
            {
                _moduloMenuSeguridadRepositoryAsync = moduloMenuSeguridadRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<IReadOnlyList<AccionesResponseDto>>> Handle(GetAccionesRolListAll query, CancellationToken cancellationToken)
            {
                var rolrequest = _mapper.Map<AccionesRequestDto>(query);
                var adList = await _moduloMenuSeguridadRepositoryAsync.GetListAcciones(rolrequest);

                return new Response<IReadOnlyList<AccionesResponseDto>>(adList);
            }
        }

    }
}


