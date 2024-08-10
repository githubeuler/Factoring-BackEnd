using Factoring.Application.DTOs.Girador.UbicacionGirador;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using Newtonsoft.Json;

namespace Factoring.Application.Features.GiradorDetails.GiradorUbicacion.Queries.GetAllUbicacionByGiradorQuery
{
    public class GetAllUbicacionByGiradorQuery : IRequest<Response<IEnumerable<UbicacionGiradorListDto>>>
    {
        public int Id { get; set; }
        public class GetAllUbicacionByGiradorQueryHandler : IRequestHandler<GetAllUbicacionByGiradorQuery, Response<IEnumerable<UbicacionGiradorListDto>>>
        {
            private readonly IGiradorDireccionRepositoryAsync _giradorDireccionRepositoryAsync;

            public GetAllUbicacionByGiradorQueryHandler(IGiradorDireccionRepositoryAsync giradorDireccionRepositoryAsync)
            {
                _giradorDireccionRepositoryAsync = giradorDireccionRepositoryAsync;
            }

            public async Task<Response<IEnumerable<UbicacionGiradorListDto>>> Handle(GetAllUbicacionByGiradorQuery query, CancellationToken cancellationToken)
            {
                var giradorDirecciones = await _giradorDireccionRepositoryAsync.GetAllDireccionByGirador(query.Id);

                foreach (var item in giradorDirecciones)
                {
                    UbicacionGiradorSingleJson ub = JsonConvert.DeserializeObject<UbicacionGiradorSingleJson>(item.cFormatoUbigeo);
                    var ubigeoSingle = await _giradorDireccionRepositoryAsync.GetUbicacionSingleAsync(ub.Departamento, ub.Provincia, ub.Distrito);

                    if (ubigeoSingle == null)
                    {
                        ubigeoSingle = await _giradorDireccionRepositoryAsync.GetUbicacionSingleAsync(ub.Departamento, string.Concat(ub.Departamento, ub.Provincia), string.Concat(ub.Departamento, ub.Provincia, ub.Distrito));
                    }

                    var newUb = new UbicacionGiradorSingleJson
                    {
                        Departamento = ubigeoSingle.cDescripcionDepartamento,
                        Provincia = ubigeoSingle.cDescripcionProvincia,
                        Distrito = ubigeoSingle.cDescripcionDistrito
                    };



                    item.cFormatoUbigeo = JsonConvert.SerializeObject(newUb);
                }

                if (giradorDirecciones == null) throw new ApiException($"Lista no encontrada.");
                return new Response<IEnumerable<UbicacionGiradorListDto>>(giradorDirecciones);
            }
        }
    }
}