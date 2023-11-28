using AutoMapper;
using EntityFramework.Infrastructure.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using VisitService.Api.Features.TiposTransportes.Dtos;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Features.TiposTransportes
{
    public class TipoTransporteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoTransporteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoTransporte>> GetAllTipoTransportesAsync()
        {
            return await _unitOfWork.Repository<TipoTransporte>().AsQueryable().ToListAsync();
        }

        public async Task<TipoTransporte> GetTipoTransporteByIdAsync(int id)
        {
            var tipoTransporte = await _unitOfWork.Repository<TipoTransporte>()
                .AsQueryable()
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tipoTransporte == null)
            {
                throw new KeyNotFoundException($"No se encontró el tipo de transporte con ID {id}.");
            }

            return tipoTransporte;
        }

        public async Task<TipoTransporte> AddTipoTransporteAsync(TipoTransporteDto tipoTransporteDto, string userId)
        {
            var tipoTransporteNuevo = _mapper.Map<TipoTransporte>(tipoTransporteDto);

            tipoTransporteNuevo.FechaCreacion = DateTime.UtcNow;
            tipoTransporteNuevo.UsuarioAgregaId = userId;

            _unitOfWork.Repository<TipoTransporte>().Add(tipoTransporteNuevo);
            await _unitOfWork.SaveAsync();

            return tipoTransporteNuevo;
        }

        public async Task UpdateTipoTransporteAsync(TipoTransporteDto tipoTransporteDto, int id, string userId)
        {
            var existingTipoTransporte = await _unitOfWork.Repository<TipoTransporte>()
                .AsQueryable(disableTracking: false)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (existingTipoTransporte == null)
            {
                throw new KeyNotFoundException($"No se encontró el tipo de transporte con ID {id} para actualizar.");
            }

            _mapper.Map(tipoTransporteDto, existingTipoTransporte);
            existingTipoTransporte.FechaModificacion = DateTime.UtcNow;
            existingTipoTransporte.UsuarioModificaId = userId;

            await _unitOfWork.SaveAsync();
        }

        public async Task ChangeStatusAsync(int id, bool estado, string userId)
        {
            var existingTipoTransporte = await _unitOfWork.Repository<TipoTransporte>()
                .AsQueryable(disableTracking: false)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (existingTipoTransporte == null)
            {
                throw new KeyNotFoundException($"No se encontró el tipo de transporte con ID {id} para cambiar estado.");
            }

            existingTipoTransporte.Estado = estado;
            existingTipoTransporte.FechaModificacion = DateTime.UtcNow;
            existingTipoTransporte.UsuarioModificaId = userId;

            await _unitOfWork.SaveAsync();
        }
    }

}
