using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.Shared;

/// <summary>
/// High-level product categorization.
/// </summary>
[Table("ProductCategory", Schema = "Production")]
[Index("Name", Name = "AK_ProductCategory_Name", IsUnique = true)]
public partial class ProductCategory
{
    /// <summary>
    /// Primary key for ProductCategory records.
    /// </summary>
    [Key]
    [Column("ProductCategoryID")]
    public int ProductCategoryId { get; set; }

    /// <summary>
    /// Category description.
    /// </summary>
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("ProductCategory")]
    public virtual ICollection<ProductSubcategory> ProductSubcategories { get; } = new List<ProductSubcategory>();
}
