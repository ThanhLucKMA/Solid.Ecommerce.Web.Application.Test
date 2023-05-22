using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.Shared;

/// <summary>
/// Current customer information. Also see the Person and Store tables.
/// </summary>
[Table("Customer", Schema = "Sales")]
[Index("AccountNumber", Name = "AK_Customer_AccountNumber", IsUnique = true)]
public partial class Customer
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    /// <summary>
    /// Foreign key to Person.BusinessEntityID
    /// </summary>
    [Column("PersonID")]
    public int? PersonId { get; set; }

    /// <summary>
    /// Unique number identifying the customer assigned by the accounting system.
    /// </summary>
    [StringLength(10)]
    [Unicode(false)]
    public string AccountNumber { get; set; } = null!;

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("Customers")]
    public virtual Person? Person { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; } = new List<SalesOrderHeader>();
}
