using Microsoft.EntityFrameworkCore;

using BSynchro.DataAccess.RelationalDb.EFCore;
using BSynchro.DataAccess.RelationalDb.Abstraction;
using BSynchro.DataAccess.Models;

namespace BSynchro.DataAccess.Context
{
    public class BSynchroContext : DbContext, IDbContext
    {
        private readonly IDataSeeder<ModelBuilder> _dataSeeder;
        //public BSynchroContext()
        //{
        //}
        public BSynchroContext(DbContextOptions<BSynchroContext> options, IDataSeeder<ModelBuilder> dataSeeder) : base(options)
        {
            this._dataSeeder = dataSeeder;
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this._dataSeeder.SeedData(modelBuilder);
        }
    }
}
