using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.Shared;

/// <summary>
/// Customer credit card information.
/// </summary>
[Table("CreditCard", Schema = "Sales")]
[Index("CardNumber", Name = "AK_CreditCard_CardNumber", IsUnique = true)]
public partial class CreditCard
{
    /// <summary>
    /// Primary key for CreditCard records.
    /// </summary>
    [Key]
    [Column("CreditCardID")]
    public int CreditCardId { get; set; }

    /// <summary>
    /// Credit card name.
    /// </summary>
    [StringLength(50)]
    public string CardType { get; set; } = null!;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [StringLength(25)]
    public string CardNumber { get; set; } = null!;

    /// <summary>
    /// Credit card expiration month.
    /// </summary>
    public byte ExpMonth { get; set; }

    /// <summary>
    /// Credit card expiration year.
    /// </summary>
    public short ExpYear { get; set; }

    [InverseProperty("CreditCard")]
    public virtual ICollection<PersonCreditCard> PersonCreditCards { get; } = new List<PersonCreditCard>();

    [InverseProperty("CreditCard")]
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; } = new List<SalesOrderHeader>();
}
