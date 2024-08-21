using Factoring.Application.DTOs.Adquiriente.UbicacionAdquiriente;
using Factoring.Application.DTOs.Girador.UbicacionGirador;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.AdquirienteDetails.AdquirienteUbicacion.Queries
{
    public class GetAllAdquirienteUbicacionQuery : IRequest<Response<IEnumerable<UbicacionAdquirienteListDto>>>
    {
        public int Id { get; set; }

        public class GetAllAdquirienteUbicacionQueryHandler : IRequestHandler<GetAllAdquirienteUbicacionQuery, Response<IEnumerable<UbicacionAdquirienteListDto>>>
        {
            private readonly IAdquirienteDireccionRepositoryAsync _adquirienteDireccionRepositoryAsync;
            private readonly IGiradorDireccionRepositoryAsync _giradorDireccionRepositoryAsync;

            public GetAllAdquirienteUbicacionQueryHandler(
                IAdquirienteDireccionRepositoryAsync adquirienteDireccionRepositoryAsync,
                IGiradorDireccionRepositoryAsync giradorDireccionRepositoryAsync
                )
            {
                _adquirienteDireccionRepositoryAsync = adquirienteDireccionRepositoryAsync;
                _giradorDireccionRepositoryAsync = giradorDireccionRepositoryAsync;
            }

            public async Task<Response<IEnumerable<UbicacionAdquirienteListDto>>> Handle(GetAllAdquirienteUbicacionQuery query, CancellationToken cancellationToken)
            {
                var ubicacionAdquirienteList = await _adquirienteDireccionRepositoryAsync.GetAllDireccionByIdAdquiriente(query.Id);

                foreach (var item in ubicacionAdquirienteList)
                {
                    UbicacionGiradorSingleJson ub = JsonConvert.DeserializeObject<UbicacionGiradorSingleJson>(item.cFormatoUbigeo);
                    var ubigeoSingle = await _giradorDireccionRepositoryAsync.GetUbicacionSingleAsync(ub.Departamento, ub.Provincia, ub.Distrito);

                    var newUb = new UbicacionGiradorSingleJson
                    {
                        Departamento = ubigeoSingle.cDescripcionDepartamento,
                        Provincia = ubigeoSingle.cDescripcionProvincia,
                        Distrito = ubigeoSingle.cDescripcionDistrito
                    };

                    item.cFormatoUbigeo = JsonConvert.SerializeObject(newUb);
                }
                if (ubicacionAdquirienteList == null) throw new ApiException($"Lista no encontrada.");
                return new Response<IEnumerable<UbicacionAdquirienteListDto>>(ubicacionAdquirienteList);
            }
        }
    }
}