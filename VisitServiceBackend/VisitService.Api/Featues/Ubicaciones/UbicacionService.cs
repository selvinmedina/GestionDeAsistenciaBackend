using AutoMapper;
using EntityFramework.Infrastructure.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using VisitService.Api.Featues.Ubicaciones.Dtos;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Featues.Ubicaciones
{
    public class UbicacionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UbicacionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Ubicacion>> GetAllUbicacionesAsync()
        {
            return await _unitOfWork.Repository<Ubicacion>().AsQueryable().ToListAsync();
        }

        public async Task<Ubicacion> GetUbicacionByIdAsync(int id)
        {
            var ubicacion = await _unitOfWork.Repository<Ubicacion>()
                .AsQueryable()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (ubicacion == null)
            {
                throw new KeyNotFoundException($"No se encontró la ubicación con ID {id}.");
            }

            return ubicacion;
        }

        public async Task<Ubicacion> AddUbicacionAsync(UbicacionDto ubicacion, string? userId)
        {
            var ubicacionNueva = _mapper.Map<Ubicacion>(ubicacion);

            ubicacionNueva.FechaCreacion = DateTime.UtcNow;
            ubicacionNueva.UsuarioAgregaId = userId!;

            _unitOfWork.Repository<Ubicacion>().Add(ubicacionNueva);

            await _unitOfWork.SaveAsync();

            return ubicacionNueva;
        }

        public async Task UpdateUbicacionAsync(UbicacionDto ubicacion, int id, string? userId)
        {
            var existingUbicacion = await _unitOfWork.Repository<Ubicacion>()
                .AsQueryable(disableTracking: false)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (existingUbicacion == null)
            {
                throw new KeyNotFoundException($"No se encontró la ubicación con ID {id} para actualizar.");
            }

            existingUbicacion.Nombre = ubicacion.Nombre;
            existingUbicacion.Direccion = ubicacion.Direccion;
            existingUbicacion.Estado = ubicacion.Estado;
            existingUbicacion.FechaModificacion = DateTime.UtcNow;
            existingUbicacion.UsuarioModificaId = userId;

            await _unitOfWork.SaveAsync();
        }

        public async Task ChangeStatusAsync(int id, bool estado, string? userId)
        {
            var existingUbicacion = await _unitOfWork.Repository<Ubicacion>()
                .AsQueryable(disableTracking: false)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (existingUbicacion == null)
            {
                throw new KeyNotFoundException($"No se encontró la ubicación con ID {id} para cambiar estado.");
            }

            existingUbicacion.Estado = estado;
            existingUbicacion.FechaModificacion = DateTime.UtcNow;
            existingUbicacion.UsuarioModificaId = userId;

            await _unitOfWork.SaveAsync();
        }
    }
}
