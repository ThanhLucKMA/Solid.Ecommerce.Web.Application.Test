using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.Shared;

/// <summary>
/// Unit of measure lookup table.
/// </summary>
[Table("UnitMeasure", Schema = "Production")]
[Index("Name", Name = "AK_UnitMeasure_Name", IsUnique = true)]
public partial class UnitMeasure
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key]
    [StringLength(3)]
    public string UnitMeasureCode { get; set; } = null!;

    /// <summary>
    /// Unit of measure description.
    /// </summary>
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("SizeUnitMeasureCodeNavigation")]
    public virtual ICollection<Product> ProductSizeUnitMeasureCodeNavigations { get; } = new List<Product>();

    [InverseProperty("UnitMeasureCodeNavigation")]
    public virtual ICollection<ProductVendor> ProductVendors { get; } = new List<ProductVendor>();

    [InverseProperty("WeightUnitMeasureCodeNavigation")]
    public virtual ICollection<Product> ProductWeightUnitMeasureCodeNavigations { get; } = new List<Product>();
}
