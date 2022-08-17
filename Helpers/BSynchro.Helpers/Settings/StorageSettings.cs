using BSynchro.Helpers.SettingsValidator;
using System.ComponentModel.DataAnnotations;

namespace BSynchro.Helpers.Settings
{
    public class StorageSettings : IValidatable
    {
        /// <summary>
        /// Gets or sets the database type (Postgres or MsSql)
        /// </summary>
        [Required]
        public string DatabaseType { get; set; }
        /// <summary>
        /// Gets or sets the database type (Postgres or MsSql)
        /// </summary>
        [Required]
        public string ConnectionString { get; set; }

        /// <inherit/>
        public void Validate()
        {
            Validator.ValidateObject(this, new ValidationContext(this), true);
        }
    }
}
