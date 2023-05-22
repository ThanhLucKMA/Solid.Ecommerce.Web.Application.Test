using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.Shared;

/// <summary>
/// Source of the ID that connects vendors, customers, and employees with address and contact information.
/// </summary>
[Table("BusinessEntity", Schema = "Person")]
public partial class BusinessEntity
{
    /// <summary>
    /// Primary key for all customers, vendors, and employees.
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; } = new List<BusinessEntityAddress>();

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; } = new List<BusinessEntityContact>();

    [InverseProperty("BusinessEntity")]
    public virtual Person? Person { get; set; }

    [InverseProperty("BusinessEntity")]
    public virtual Vendor? Vendor { get; set; }
}
