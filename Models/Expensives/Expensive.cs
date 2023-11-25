using System.ComponentModel.DataAnnotations;

namespace DespesasControlApp.Models.Despesass
{
    public class Despesas
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public double Value { get; set; }

        public DateTime Date { get; set; }
    }
}
