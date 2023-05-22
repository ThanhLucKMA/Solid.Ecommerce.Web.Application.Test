using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.Shared;

/// <summary>
/// Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts.
/// </summary>
[Table("Person", Schema = "Person")]
[Index("LastName", "FirstName", "MiddleName", Name = "IX_Person_LastName_FirstName_MiddleName")]
public partial class Person
{
    /// <summary>
    /// Primary key for Person records.
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact
    /// </summary>
    [StringLength(2)]
    public string PersonType { get; set; } = null!;

    /// <summary>
    /// 0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.
    /// </summary>
    public bool NameStyle { get; set; }

    /// <summary>
    /// A courtesy title. For example, Mr. or Ms.
    /// </summary>
    [StringLength(8)]
    public string? Title { get; set; }

    /// <summary>
    /// First name of the person.
    /// </summary>
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Middle name or middle initial of the person.
    /// </summary>
    [StringLength(50)]
    public string? MiddleName { get; set; }

    /// <summary>
    /// Last name of the person.
    /// </summary>
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Surname suffix. For example, Sr. or Jr.
    /// </summary>
    [StringLength(10)]
    public string? Suffix { get; set; }

    /// <summary>
    /// 0 = Contact does not wish to receive e-mail promotions, 1 = Contact does wish to receive e-mail promotions from AdventureWorks, 2 = Contact does wish to receive e-mail promotions from AdventureWorks and selected partners. 
    /// </summary>
    public int EmailPromotion { get; set; }

    [ForeignKey("BusinessEntityId")]
    [InverseProperty("Person")]
    public virtual BusinessEntity BusinessEntity { get; set; } = null!;

    [InverseProperty("Person")]
    public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; } = new List<BusinessEntityContact>();

    [InverseProperty("Person")]
    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<EmailAddress> EmailAddresses { get; } = new List<EmailAddress>();

    [InverseProperty("BusinessEntity")]
    public virtual Employee? Employee { get; set; }

    [InverseProperty("BusinessEntity")]
    public virtual Password? Password { get; set; }

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<PersonCreditCard> PersonCreditCards { get; } = new List<PersonCreditCard>();

    [InverseProperty("BusinessEntity")]
    public virtual ICollection<PersonPhone> PersonPhones { get; } = new List<PersonPhone>();
}
