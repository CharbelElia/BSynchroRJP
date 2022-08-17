using System;
using System.ComponentModel.DataAnnotations;

namespace BSynchro.DataAccess.Abstraction.Models
{
    /// <summary>
    /// A base class for entity
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Entity primary key 
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Date and time of entity created
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Date and time of entity updated
        /// </summary>
        public DateTime? UpdatedOn { get; set; }
    }
}