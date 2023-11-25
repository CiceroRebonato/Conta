using DespesasControlApp.Infra.Database;
using DespesasControlApp.Models.Despesass;
using Microsoft.EntityFrameworkCore;

namespace DespesasControlApp.Services
{
    public class DespesasService : IDespesasService
    {
        private readonly DespesasControlContext _dbContext;
        public DespesasService(DespesasControlContext context)
        {
            _dbContext = context;
        }

        public async Task Create(DTOs.CreateDespesasDTO createDespesasDTO)
        {
            await _dbContext.Despesass.AddAsync(new Despesas()
            {
                Description = createDespesasDTO.Description,
                Date = createDespesasDTO.Date,
                Value = createDespesasDTO.Value
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Despesas>> FindBy(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new Exception("Data final deve ser maior que data inicial.");

            var items = await _dbContext.Despesass.Where(e => e.Date >= startDate && e.Date <= endDate).AsNoTracking()
                .ToListAsync();

            return items;
        }
    }
}
