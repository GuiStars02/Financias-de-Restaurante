using RestauranteAPI.Data;
using RestauranteAPI.Data.Models;
using RestauranteAPI.Repositories;
using RestauranteAPI.Repositories.Interface;
using RestauranteAPI.Services.Interfaces;

namespace RestauranteAPI.Services
{
    public class PratoService : IPratoService
    {
        private readonly IRepositoryTotalFlexBase<Prato> _repository;

        public PratoService(IRepositoryTotalFlexBase<Prato> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Prato>> GetAll()
        {
            var pratos = await _repository.GetAllAsync();
            return pratos;
        }

        public async Task<Prato> GetPratoById(int id)
        {
            var prato = await _repository.GetFirstOrDefaultAsync(x => x.IdPrato == id);
            return prato;
        }

        public async Task<Prato> CreatePrato(Prato prato)
        {
            _repository.Create(prato);
            await _repository.SaveChangesAsync();
            return prato;
        }

        public async Task UpdatePrato(Prato prato)
        {
            _repository.Update(prato);
            await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeletePrato(int id)
        {
            var prato = await _repository.GetFirstOrDefaultAsync(x => x.IdPrato == id);

            if(prato is null)
            {
                return false;
            }

            _repository.Delete(prato);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
