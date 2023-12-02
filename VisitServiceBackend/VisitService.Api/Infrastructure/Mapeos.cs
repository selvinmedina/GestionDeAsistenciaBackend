using AutoMapper;
using VisitService.Api.Features.TiposTransportes.Dtos;
using VisitService.Api.Features.Ubicaciones.Dtos;
using VisitService.Api.Features.Visitas.Dtos;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Infrastructure
{
    public class Mapeos : Profile
    {
        public Mapeos()
        {
            CreateMap<UbicacionDto, Ubicacion>().ReverseMap();
            CreateMap<TipoTransporteDto, TipoTransporte>().ReverseMap();
            CreateMap<VisitaDto, Visita>().ReverseMap();
            CreateMap<AsignacionTransporteDto, AsignacionTransporte>().ReverseMap();
            CreateMap<DetalleVisitaDto, DetalleVisita>().ReverseMap();
        }
    }
}
