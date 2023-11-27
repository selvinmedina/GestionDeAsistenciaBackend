using AutoMapper;
using VisitService.Api.Featues.Ubicaciones.Dtos;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Infrastructure
{
    public class Mapeos : Profile
    {
        public Mapeos()
        {
            CreateMap<UbicacionDto, Ubicacion>().ReverseMap();
        }
    }
}
