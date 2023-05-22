using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.Shared;

/// <summary>
/// Product subcategories. See ProductCategory table.
/// </summary>
[Table("ProductSubcategory", Schema = "Production")]
[Index("Name", Name = "AK_ProductSubcategory_Name", IsUnique = true)]
public partial class ProductSubcategory
{
    /// <summary>
    /// Primary key for ProductSubcategory records.
    /// </summary>
    [Key]
    [Column("ProductSubcategoryID")]
    public int ProductSubcategoryId { get; set; }

    /// <summary>
    /// Product category identification number. Foreign key to ProductCategory.ProductCategoryID.
    /// </summary>
    [Column("ProductCategoryID")]
    public int ProductCategoryId { get; set; }

    /// <summary>
    /// Subcategory description.
    /// </summary>
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [ForeignKey("ProductCategoryId")]
    [InverseProperty("ProductSubcategories")]
    public virtual ProductCategory ProductCategory { get; set; } = null!;

    [InverseProperty("ProductSubcategory")]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
