using Microsoft.EntityFrameworkCore;

namespace BudgetCoreDAO.Context
{
    public sealed class BudgetContext : DbContext
    {
        public BudgetContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            optionsBuilder.UseSqlServer(@"Server=TROLL-PC\SQLEXPRESS;Database=budget;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-52KQOT0\SQLEXPRESS;Database=budget;Trusted_Connection=True;");
        }
        
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Modifier> Modifiers { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<ReceiptProperty> ReceiptProperties { get; set; }
    }
}