using DespesasControlApp.Models.Despesass;

namespace DespesasControlApp.Services
{
    public interface IDespesasService
    {
        Task Create(DTOs.CreateDespesasDTO createDespesasDTO);

        Task<List<Despesas>> FindBy(DateTime startDate, DateTime endDate);
    }
}
