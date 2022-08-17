namespace BSynchro.DataAccess.RelationalDb.Abstraction
{
    /// <summary>
    /// Seeds initial data to the database
    /// </summary>
    public interface IDataSeeder<TModelBuilder> 
    {
        /// <summary>
        /// Method to seed data to the database
        /// </summary>
        /// <param name="context">Database context to be seeded with data</param>
        void SeedData(TModelBuilder context);
    }
}
