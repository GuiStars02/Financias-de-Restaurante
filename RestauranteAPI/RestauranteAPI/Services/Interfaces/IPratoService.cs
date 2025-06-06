using RestauranteAPI.Data.Models;

namespace RestauranteAPI.Services.Interfaces
{
    public interface IPratoService
    {
        Task<IEnumerable<Prato>> GetAll();
        Task<Prato> GetPratoById(int idPrato);
        Task<Prato> CreatePrato(Prato prato);
        Task UpdatePrato(Prato prato);
        Task<bool> DeletePrato(int idPrato);
    }
}
