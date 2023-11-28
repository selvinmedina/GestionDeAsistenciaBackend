using AutoMapper;
using VisitService.Api.Features.TiposTransportes.Dtos;
using VisitService.Api.Features.Ubicaciones.Dtos;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Infrastructure
{
    public class Mapeos : Profile
    {
        public Mapeos()
        {
            CreateMap<UbicacionDto, Ubicacion>().ReverseMap();
            CreateMap<TipoTransporteDto, TipoTransporte>().ReverseMap();
        }
    }
}
