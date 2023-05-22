using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.Shared;

/// <summary>
/// Type of phone number of a person.
/// </summary>
[Table("PhoneNumberType", Schema = "Person")]
public partial class PhoneNumberType
{
    /// <summary>
    /// Primary key for telephone number type records.
    /// </summary>
    [Key]
    [Column("PhoneNumberTypeID")]
    public int PhoneNumberTypeId { get; set; }

    /// <summary>
    /// Name of the telephone number type
    /// </summary>
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("PhoneNumberType")]
    public virtual ICollection<PersonPhone> PersonPhones { get; } = new List<PersonPhone>();
}
