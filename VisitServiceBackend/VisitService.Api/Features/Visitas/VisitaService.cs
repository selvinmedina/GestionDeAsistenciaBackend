using AutoMapper;
using EntityFramework.Infrastructure.Core.UnitOfWork;
using VisitService.Api.Features.Visitas.Dtos;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Features.Visitas
{
    public class VisitaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VisitaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Visita> AgregarVisitaAsync(VisitaDto visitaDto, string userId)
        {
            // Crear la visita
            var visita = _mapper.Map<Visita>(visitaDto);
            visita.UsuarioAgregaId = userId;
            visita.FechaEntrada = visitaDto.FechaEntrada;
            visita.HoraEntrada = visitaDto.HoraEntrada;

            // Agregar detalles de la visita
            foreach (var detalleDto in visitaDto.DetallesVisita)
            {
                var detalle = _mapper.Map<DetalleVisita>(detalleDto);
                detalle.UsuarioAgregaId = userId;
                detalle.FechaCreacion = DateTime.UtcNow;
                visita.DetalleVisita.Add(detalle);
            }

            // Agregar asignaciones de transporte
            foreach (var asignacionDto in visitaDto.AsignacionesTransporte)
            {
                var asignacion = _mapper.Map<AsignacionTransporte>(asignacionDto);
                asignacion.FechaAsignacion = DateTime.UtcNow;
                visita.AsignacionesTransporte.Add(asignacion);
            }

            _unitOfWork.Repository<Visita>().Add(visita);
            await _unitOfWork.SaveAsync();

            return visita;
        }

        // Métodos para ver visitas, notificar entrada y notificar salida
        // ...
    }
}
