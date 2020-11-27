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
            // optionsBuilder.UseSqlServer(@"Server=KYIRA-PC\SQLEXPRESS;Database=budget;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=KYIRA-PC\SQLEXPRESS;Database=budget-test;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
        
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Modifier> Modifiers { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<ReceiptProperty> ReceiptProperties { get; set; }
    }
}