using AutoMapper;
using EntityFramework.Infrastructure.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
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
            var visita = _mapper.Map<Visita>(visitaDto);
            visita.UsuarioAgregaId = userId;
            visita.Estado = true;

            // Agregar detalles de la visita (personas)
            foreach (var detalleDto in visitaDto.DetallesVisita)
            {
                var detalle = _mapper.Map<DetalleVisita>(detalleDto);
                detalle.UsuarioAgregaId = userId;
                detalle.FechaCreacion = DateTime.UtcNow;
                visita.DetalleVisita.Add(detalle);
            }

            // Agregar asignaciones de transporte (vehículos, etc)
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

        public async Task CambiarEstadoVisitaAsync(int id, bool nuevoEstado, string userId)
        {
            var visita = await _unitOfWork.Repository<Visita>()
                .AsQueryable(disableTracking: false)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (visita == null)
            {
                throw new KeyNotFoundException($"No se encontró la visita con ID {id}.");
            }

            visita.Estado = nuevoEstado;
            visita.FechaModificacion = DateTime.UtcNow;
            visita.UsuarioModificaId = userId;

            await _unitOfWork.SaveAsync();
        }

        public async Task<Visita?> ObtenerVisita(int id)
        {
            var visita = await _unitOfWork.Repository<Visita>()
                .AsQueryable()
                .Where(v => v.Id == id)
                .FirstOrDefaultAsync();

            return visita;
        }

        public async Task<List<Visita>> ObtenerVisitasPendientes()
        {
            var visitasPendientes = await _unitOfWork.Repository<Visita>()
                .AsQueryable()
                .Where(v => v.Estado && v.FechaSalida == null)
                .ToListAsync();

            return visitasPendientes;
        }

        public async Task RegistrarEntrada(int id, string userId, string? comentarioPersonaQueRecibe)
        {
            var visita = await _unitOfWork.Repository<Visita>()
                .AsQueryable(disableTracking: false)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (visita == null)
            {
                throw new KeyNotFoundException($"No se encontró la visita con ID {id}.");
            }

            visita.FechaEntrada = DateTime.UtcNow;
            visita.HoraEntrada = DateTime.UtcNow.TimeOfDay;
            visita.UsuarioApruebaId = userId;
            visita.ComentarioPersonaQueRecibe = comentarioPersonaQueRecibe;

            await _unitOfWork.SaveAsync();
        }

        public async Task RegistrarSalida(int id)
        {
            var visita = await _unitOfWork.Repository<Visita>()
                .AsQueryable(disableTracking: false)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (visita == null)
            {
                throw new KeyNotFoundException($"No se encontró la visita con ID {id}.");
            }

            visita.FechaSalida = DateTime.UtcNow;
            visita.HoraSalida = DateTime.UtcNow.TimeOfDay;

            await _unitOfWork.SaveAsync();
        }
    }
}
