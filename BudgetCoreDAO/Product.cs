using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetCoreDAO
{
    public class Product
    {
        public int Id { get; set; }

        /// <summary>Наименование товара.</summary>
        public string Name { get; set; }
    }
}