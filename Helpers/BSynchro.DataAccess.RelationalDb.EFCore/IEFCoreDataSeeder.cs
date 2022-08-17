using BSynchro.DataAccess.RelationalDb.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BSynchro.DataAccess.RelationalDb.EFCore
{
    public interface IEFCoreDataSeeder: IDataSeeder<ModelBuilder>
    {
        
    }
}