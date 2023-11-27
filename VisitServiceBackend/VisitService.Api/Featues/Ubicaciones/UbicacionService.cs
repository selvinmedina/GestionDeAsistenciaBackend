using EntityFramework.Infrastructure.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using VisitService.Api.Infrastructure.Entities;

namespace VisitService.Api.Featues.Ubicaciones
{
    public class UbicacionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UbicacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public async Task AddUbicacionAsync(Ubicacion ubicacion)
        {
            _unitOfWork.Repository<Ubicacion>().Add(ubicacion);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateUbicacionAsync(Ubicacion ubicacion)
        {
            var existingUbicacion = await _unitOfWork.Repository<Ubicacion>()
                .AsQueryable().FirstOrDefaultAsync(u => u.Id == ubicacion.Id);

            if (existingUbicacion == null)
            {
                throw new KeyNotFoundException($"No se encontró la ubicación con ID {ubicacion.Id} para actualizar.");
            }

            existingUbicacion.Nombre = ubicacion.Nombre;
            existingUbicacion.Direccion = ubicacion.Direccion;
            existingUbicacion.Estado = ubicacion.Estado;
            existingUbicacion.FechaModificacion = DateTime.Now;
            existingUbicacion.UsuarioModificaId = ubicacion.UsuarioModificaId;

            await _unitOfWork.SaveAsync();
        }

        public async Task ChangeStatusAsync(int id, bool estado)
        {
            var existingUbicacion = await _unitOfWork.Repository<Ubicacion>()
                .AsQueryable()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (existingUbicacion == null)
            {
                throw new KeyNotFoundException($"No se encontró la ubicación con ID {id} para cambiar estado.");
            }

            existingUbicacion.Estado = estado;
            existingUbicacion.FechaModificacion = DateTime.Now;
            await _unitOfWork.SaveAsync();
        }
    }
}
