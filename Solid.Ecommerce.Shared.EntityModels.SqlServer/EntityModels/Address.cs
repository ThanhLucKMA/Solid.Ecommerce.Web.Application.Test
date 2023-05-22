using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.Shared;

/// <summary>
/// Street address information for customers, employees, and vendors.
/// </summary>
[Table("Address", Schema = "Person")]
public partial class Address
{
    /// <summary>
    /// Primary key for Address records.
    /// </summary>
    [Key]
    [Column("AddressID")]
    public int AddressId { get; set; }

    /// <summary>
    /// First street address line.
    /// </summary>
    [StringLength(60)]
    public string AddressLine1 { get; set; } = null!;

    /// <summary>
    /// Second street address line.
    /// </summary>
    [StringLength(60)]
    public string? AddressLine2 { get; set; }

    /// <summary>
    /// Name of the city.
    /// </summary>
    [StringLength(30)]
    public string City { get; set; } = null!;

    /// <summary>
    /// Postal code for the street address.
    /// </summary>
    [StringLength(15)]
    public string PostalCode { get; set; } = null!;

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("Address")]
    public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; } = new List<BusinessEntityAddress>();

    [InverseProperty("BillToAddress")]
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddresses { get; } = new List<SalesOrderHeader>();

    [InverseProperty("ShipToAddress")]
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddresses { get; } = new List<SalesOrderHeader>();
}
