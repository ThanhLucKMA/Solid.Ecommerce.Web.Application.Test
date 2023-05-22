using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.Shared;

[Table("ProductStatus", Schema = "Production")]
public partial class ProductStatus
{
    [Key]
    public int StatusId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? StatusName { get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
