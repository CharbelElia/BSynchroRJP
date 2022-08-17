using System;
using System.Linq;
using System.Reflection;
using BSynchro.DataAccess.Abstraction.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BSynchro.DataAccess.RelationalDb.EFCore
{
    /// <summary>
    /// class for migration extension 
    /// </summary>
    public static class MigrationExtension
    {
        /// <summary>
        /// update database  tables sequence number 
        /// </summary>
        /// <param name="migrationBuilder">Migration builder</param>
        /// <param name="currentAssembly">Assembly </param>
        /// <returns></returns>
        public static MigrationBuilder UpdateSequenceNumbers(this MigrationBuilder migrationBuilder, Assembly currentAssembly)
        {
            UpdateSequenceValues(migrationBuilder, currentAssembly);
            return migrationBuilder;
        }
        /// <summary>
        /// update  sequance value for each table extends BaseEntity
        /// </summary>
        /// <param name="migrationBuilder">Migration builder </param>
        /// <param name="currentAssembly"> Assebly</param>
        private static void UpdateSequenceValues(MigrationBuilder migrationBuilder, Assembly currentAssembly)
        {
            var databaseModels = currentAssembly.GetTypes().Where(x =>
                    x.Namespace?.Contains("DataAccess.Models", StringComparison.InvariantCultureIgnoreCase) ?? false)
                .Where(x => ClassExtends(x, nameof(BaseEntity)))
                .ToList();

            var tablesToUpdate = databaseModels.Where(x => databaseModels.Any(m => m.Name.Equals(x.Name))).ToList();
            tablesToUpdate.ForEach(t =>
            {
                migrationBuilder.Sql(
                    $"SELECT setval('\"{t.Name}_Id_seq\"', COALESCE((SELECT MAX(\"Id\")+1 FROM \"{t.Name}\"), 1), false);");
            });
        }
        /// <summary>
        /// check is this class extent another class 
        /// </summary>
        /// <param name="type">class type</param>
        /// <param name="s">class name to check if class extend it </param>
        /// <returns>extent or no</returns>
        private static bool ClassExtends(Type type, string s)
        {
            if (type.BaseType == null) return false;
            if (type.BaseType.Name.Equals(s)) return true;
            return ClassExtends(type.BaseType, s);
        }
    }
    
    
}