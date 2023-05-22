using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.Shared;

/// <summary>
/// Product images.
/// </summary>
[Table("ProductPhoto", Schema = "Production")]
public partial class ProductPhoto
{
    /// <summary>
    /// Primary key for ProductPhoto records.
    /// </summary>
    [Key]
    [Column("ProductPhotoID")]
    public int ProductPhotoId { get; set; }

    /// <summary>
    /// Small image of the product.
    /// </summary>
    public byte[]? ThumbNailPhoto { get; set; }

    /// <summary>
    /// Small image file name.
    /// </summary>
    [StringLength(50)]
    public string? ThumbnailPhotoFileName { get; set; }

    /// <summary>
    /// Large image of the product.
    /// </summary>
    public byte[]? LargePhoto { get; set; }

    /// <summary>
    /// Large image file name.
    /// </summary>
    [StringLength(50)]
    public string? LargePhotoFileName { get; set; }

    [InverseProperty("ProductPhoto")]
    public virtual ICollection<ProductProductPhoto> ProductProductPhotos { get; } = new List<ProductProductPhoto>();
}
