using Microsoft.EntityFrameworkCore;
using System;

using BSynchro.DataAccess.RelationalDb.EFCore;
using BSynchro.DataAccess.Models;

namespace BSynchro.DataAccess.Seed
{
    /// <inheritdoc/>
    public class BSynchroDataSeeder : IEFCoreDataSeeder
    {
        /// <inheritdoc/>
        public void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    CustomerId = Guid.NewGuid().ToString(),
                    FirstName = "Charbel",
                    LastName = "Elia",
                    Email = "charbelelia@outlook.com",
                    PhoneNumber = "+96171613322",
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow
                }
            );
        }
    }
}