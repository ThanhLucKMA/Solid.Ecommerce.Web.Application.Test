using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.Shared;

/// <summary>
/// Products sold or used in the manfacturing of sold products.
/// </summary>
[Table("Product", Schema = "Production")]
[Index("Name", Name = "AK_Product_Name", IsUnique = true)]
[Index("ProductNumber", Name = "AK_Product_ProductNumber", IsUnique = true)]
public partial class Product
{
    /// <summary>
    /// Primary key for Product records.
    /// </summary>
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    /// <summary>
    /// Name of the product.
    /// </summary>
    [StringLength(50)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Unique product identification number.
    /// </summary>
    [StringLength(25)]
    public string ProductNumber { get; set; } = null!;

    /// <summary>
    /// 0 = Product is purchased, 1 = Product is manufactured in-house.
    /// </summary>
    [Required]
    public bool? MakeFlag { get; set; }

    /// <summary>
    /// Product color.
    /// </summary>
    [StringLength(15)]
    public string? Color { get; set; }

    /// <summary>
    /// Standard cost of the product.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal StandardCost { get; set; }

    /// <summary>
    /// Selling price.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal ListPrice { get; set; }

    /// <summary>
    /// Product size.
    /// </summary>
    [StringLength(5)]
    public string? Size { get; set; }

    /// <summary>
    /// Unit of measure for Size column.
    /// </summary>
    [StringLength(3)]
    public string? SizeUnitMeasureCode { get; set; }

    /// <summary>
    /// Unit of measure for Weight column.
    /// </summary>
    [StringLength(3)]
    public string? WeightUnitMeasureCode { get; set; }

    /// <summary>
    /// Product weight.
    /// </summary>
    [Column(TypeName = "decimal(8, 2)")]
    public decimal? Weight { get; set; }

    /// <summary>
    /// R = Road, M = Mountain, T = Touring, S = Standard
    /// </summary>
    [StringLength(2)]
    public string? ProductLine { get; set; }

    /// <summary>
    /// H = High, M = Medium, L = Low
    /// </summary>
    [StringLength(2)]
    public string? Class { get; set; }

    /// <summary>
    /// W = Womens, M = Mens, U = Universal
    /// </summary>
    [StringLength(2)]
    public string? Style { get; set; }

    /// <summary>
    /// Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. 
    /// </summary>
    [Column("ProductSubcategoryID")]
    public int? ProductSubcategoryId { get; set; }

    /// <summary>
    /// Date the product was available for sale.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime SellStartDate { get; set; }

    /// <summary>
    /// Date the product was no longer available for sale.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? SellEndDate { get; set; }

    /// <summary>
    /// Date the product was discontinued.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? DiscontinuedDate { get; set; }

    [StringLength(400)]
    public string? Description { get; set; }

    public int? StatusId { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? DiscountPercent { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<ProductProductPhoto> ProductProductPhotos { get; } = new List<ProductProductPhoto>();

    [ForeignKey("ProductSubcategoryId")]
    [InverseProperty("Products")]
    public virtual ProductSubcategory? ProductSubcategory { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<ProductVendor> ProductVendors { get; } = new List<ProductVendor>();

    [InverseProperty("Product")]
    public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; } = new List<PurchaseOrderDetail>();

    [InverseProperty("Product")]
    public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; } = new List<ShoppingCartItem>();

    [ForeignKey("SizeUnitMeasureCode")]
    [InverseProperty("ProductSizeUnitMeasureCodeNavigations")]
    public virtual UnitMeasure? SizeUnitMeasureCodeNavigation { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<SpecialOfferProduct> SpecialOfferProducts { get; } = new List<SpecialOfferProduct>();

    [ForeignKey("StatusId")]
    [InverseProperty("Products")]
    public virtual ProductStatus? Status { get; set; }

    [ForeignKey("WeightUnitMeasureCode")]
    [InverseProperty("ProductWeightUnitMeasureCodeNavigations")]
    public virtual UnitMeasure? WeightUnitMeasureCodeNavigation { get; set; }
}
