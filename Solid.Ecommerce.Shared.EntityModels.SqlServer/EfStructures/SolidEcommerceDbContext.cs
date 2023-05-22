using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Solid.Ecommerce.Shared;

public partial class SolidEcommerceDbContext : DbContext
{
    public SolidEcommerceDbContext()
    {
    }

    public SolidEcommerceDbContext(DbContextOptions<SolidEcommerceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AddressType> AddressTypes { get; set; }

    public virtual DbSet<BusinessEntity> BusinessEntities { get; set; }

    public virtual DbSet<BusinessEntityAddress> BusinessEntityAddresses { get; set; }

    public virtual DbSet<BusinessEntityContact> BusinessEntityContacts { get; set; }

    public virtual DbSet<ContactType> ContactTypes { get; set; }

    public virtual DbSet<CreditCard> CreditCards { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<CurrencyRate> CurrencyRates { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<EmailAddress> EmailAddresses { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }

    public virtual DbSet<EmployeePayHistory> EmployeePayHistories { get; set; }

    public virtual DbSet<JobCandidate> JobCandidates { get; set; }

    public virtual DbSet<Password> Passwords { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonCreditCard> PersonCreditCards { get; set; }

    public virtual DbSet<PersonPhone> PersonPhones { get; set; }

    public virtual DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductPhoto> ProductPhotos { get; set; }

    public virtual DbSet<ProductProductPhoto> ProductProductPhotos { get; set; }

    public virtual DbSet<ProductStatus> ProductStatuses { get; set; }

    public virtual DbSet<ProductSubcategory> ProductSubcategories { get; set; }

    public virtual DbSet<ProductVendor> ProductVendors { get; set; }

    public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

    public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }

    public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

    public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

    public virtual DbSet<SalesPerson> SalesPeople { get; set; }

    public virtual DbSet<SalesTaxRate> SalesTaxRates { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<ShipMethod> ShipMethods { get; set; }

    public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    public virtual DbSet<SpecialOffer> SpecialOffers { get; set; }

    public virtual DbSet<SpecialOfferProduct> SpecialOfferProducts { get; set; }

    public virtual DbSet<UnitMeasure> UnitMeasures { get; set; }

    public virtual DbSet<VAdditionalContactInfo> VAdditionalContactInfos { get; set; }

    public virtual DbSet<VEmployee> VEmployees { get; set; }

    public virtual DbSet<VEmployeeDepartment> VEmployeeDepartments { get; set; }

    public virtual DbSet<VEmployeeDepartmentHistory> VEmployeeDepartmentHistories { get; set; }

    public virtual DbSet<VIndividualCustomer> VIndividualCustomers { get; set; }

    public virtual DbSet<VJobCandidate> VJobCandidates { get; set; }

    public virtual DbSet<VJobCandidateEducation> VJobCandidateEducations { get; set; }

    public virtual DbSet<VJobCandidateEmployment> VJobCandidateEmployments { get; set; }

    public virtual DbSet<VPersonDemographic> VPersonDemographics { get; set; }

    public virtual DbSet<VProductModelCatalogDescription> VProductModelCatalogDescriptions { get; set; }

    public virtual DbSet<VProductModelInstruction> VProductModelInstructions { get; set; }

    public virtual DbSet<VSalesPerson> VSalesPeople { get; set; }

    public virtual DbSet<VSalesPersonSalesByFiscalYear> VSalesPersonSalesByFiscalYears { get; set; }

    public virtual DbSet<VStoreWithAddress> VStoreWithAddresses { get; set; }

    public virtual DbSet<VStoreWithContact> VStoreWithContacts { get; set; }

    public virtual DbSet<VStoreWithDemographic> VStoreWithDemographics { get; set; }

    public virtual DbSet<VVendorWithAddress> VVendorWithAddresses { get; set; }

    public virtual DbSet<VVendorWithContact> VVendorWithContacts { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_Address_AddressID");

            entity.ToTable("Address", "Person", tb => tb.HasComment("Street address information for customers, employees, and vendors."));

            entity.Property(e => e.AddressId).HasComment("Primary key for Address records.");
            entity.Property(e => e.AddressLine1).HasComment("First street address line.");
            entity.Property(e => e.AddressLine2).HasComment("Second street address line.");
            entity.Property(e => e.City).HasComment("Name of the city.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.PostalCode).HasComment("Postal code for the street address.");
        });

        modelBuilder.Entity<AddressType>(entity =>
        {
            entity.HasKey(e => e.AddressTypeId).HasName("PK_AddressType_AddressTypeID");

            entity.ToTable("AddressType", "Person", tb => tb.HasComment("Types of addresses stored in the Address table. "));

            entity.Property(e => e.AddressTypeId).HasComment("Primary key for AddressType records.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.Name).HasComment("Address type description. For example, Billing, Home, or Shipping.");
        });

        modelBuilder.Entity<BusinessEntity>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_BusinessEntity_BusinessEntityID");

            entity.ToTable("BusinessEntity", "Person", tb => tb.HasComment("Source of the ID that connects vendors, customers, and employees with address and contact information."));

            entity.Property(e => e.BusinessEntityId).HasComment("Primary key for all customers, vendors, and employees.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
        });

        modelBuilder.Entity<BusinessEntityAddress>(entity =>
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.AddressId, e.AddressTypeId }).HasName("PK_BusinessEntityAddress_BusinessEntityID_AddressID_AddressTypeID");

            entity.ToTable("BusinessEntityAddress", "Person", tb => tb.HasComment("Cross-reference table mapping customers, vendors, and employees to their addresses."));

            entity.Property(e => e.BusinessEntityId).HasComment("Primary key. Foreign key to BusinessEntity.BusinessEntityID.");
            entity.Property(e => e.AddressId).HasComment("Primary key. Foreign key to Address.AddressID.");
            entity.Property(e => e.AddressTypeId).HasComment("Primary key. Foreign key to AddressType.AddressTypeID.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.HasOne(d => d.Address).WithMany(p => p.BusinessEntityAddresses).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.AddressType).WithMany(p => p.BusinessEntityAddresses).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.BusinessEntityAddresses).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<BusinessEntityContact>(entity =>
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.PersonId, e.ContactTypeId }).HasName("PK_BusinessEntityContact_BusinessEntityID_PersonID_ContactTypeID");

            entity.ToTable("BusinessEntityContact", "Person", tb => tb.HasComment("Cross-reference table mapping stores, vendors, and employees to people"));

            entity.Property(e => e.BusinessEntityId).HasComment("Primary key. Foreign key to BusinessEntity.BusinessEntityID.");
            entity.Property(e => e.PersonId).HasComment("Primary key. Foreign key to Person.BusinessEntityID.");
            entity.Property(e => e.ContactTypeId).HasComment("Primary key.  Foreign key to ContactType.ContactTypeID.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.BusinessEntityContacts).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ContactType).WithMany(p => p.BusinessEntityContacts).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Person).WithMany(p => p.BusinessEntityContacts).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ContactType>(entity =>
        {
            entity.HasKey(e => e.ContactTypeId).HasName("PK_ContactType_ContactTypeID");

            entity.ToTable("ContactType", "Person", tb => tb.HasComment("Lookup table containing the types of business entity contacts."));

            entity.Property(e => e.ContactTypeId).HasComment("Primary key for ContactType records.");
            entity.Property(e => e.Name).HasComment("Contact type description.");
        });

        modelBuilder.Entity<CreditCard>(entity =>
        {
            entity.HasKey(e => e.CreditCardId).HasName("PK_CreditCard_CreditCardID");

            entity.ToTable("CreditCard", "Sales", tb => tb.HasComment("Customer credit card information."));

            entity.Property(e => e.CreditCardId).HasComment("Primary key for CreditCard records.");
            entity.Property(e => e.CardNumber).HasComment("Credit card number.");
            entity.Property(e => e.CardType).HasComment("Credit card name.");
            entity.Property(e => e.ExpMonth).HasComment("Credit card expiration month.");
            entity.Property(e => e.ExpYear).HasComment("Credit card expiration year.");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.CurrencyCode).HasName("PK_Currency_CurrencyCode");

            entity.ToTable("Currency", "Sales", tb => tb.HasComment("Lookup table containing standard ISO currencies."));

            entity.Property(e => e.CurrencyCode)
                .IsFixedLength()
                .HasComment("The ISO code for the Currency.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.Name).HasComment("Currency name.");
        });

        modelBuilder.Entity<CurrencyRate>(entity =>
        {
            entity.HasKey(e => e.CurrencyRateId).HasName("PK_CurrencyRate_CurrencyRateID");

            entity.ToTable("CurrencyRate", "Sales", tb => tb.HasComment("Currency exchange rates."));

            entity.Property(e => e.CurrencyRateId).HasComment("Primary key for CurrencyRate records.");
            entity.Property(e => e.AverageRate).HasComment("Average exchange rate for the day.");
            entity.Property(e => e.CurrencyRateDate).HasComment("Date and time the exchange rate was obtained.");
            entity.Property(e => e.EndOfDayRate).HasComment("Final exchange rate for the day.");
            entity.Property(e => e.FromCurrencyCode)
                .IsFixedLength()
                .HasComment("Exchange rate was converted from this currency code.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.ToCurrencyCode)
                .IsFixedLength()
                .HasComment("Exchange rate was converted to this currency code.");

            entity.HasOne(d => d.FromCurrencyCodeNavigation).WithMany(p => p.CurrencyRateFromCurrencyCodeNavigations).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ToCurrencyCodeNavigation).WithMany(p => p.CurrencyRateToCurrencyCodeNavigations).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK_Customer_CustomerID");

            entity.ToTable("Customer", "Sales", tb => tb.HasComment("Current customer information. Also see the Person and Store tables."));

            entity.Property(e => e.CustomerId).HasComment("Primary key.");
            entity.Property(e => e.AccountNumber)
                .HasComputedColumnSql("(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))", false)
                .HasComment("Unique number identifying the customer assigned by the accounting system.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.PersonId).HasComment("Foreign key to Person.BusinessEntityID");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK_Department_DepartmentID");

            entity.ToTable("Department", "HumanResources", tb => tb.HasComment("Lookup table containing the departments within the Adventure Works Cycles company."));

            entity.Property(e => e.DepartmentId).HasComment("Primary key for Department records.");
            entity.Property(e => e.GroupName).HasComment("Name of the group to which the department belongs.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.Name).HasComment("Name of the department.");
        });

        modelBuilder.Entity<EmailAddress>(entity =>
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.EmailAddressId }).HasName("PK_EmailAddress_BusinessEntityID_EmailAddressID");

            entity.ToTable("EmailAddress", "Person", tb => tb.HasComment("Where to send a person email."));

            entity.Property(e => e.BusinessEntityId).HasComment("Primary key. Person associated with this email address.  Foreign key to Person.BusinessEntityID");
            entity.Property(e => e.EmailAddressId)
                .ValueGeneratedOnAdd()
                .HasComment("Primary key. ID of this email address.");
            entity.Property(e => e.EmailAddress1).HasComment("E-mail address for the person.");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.EmailAddresses).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_Employee_BusinessEntityID");

            entity.ToTable("Employee", "HumanResources", tb =>
                {
                    tb.HasComment("Employee information such as salary, department, and title.");
                    tb.HasTrigger("dEmployee");
                });

            entity.Property(e => e.BusinessEntityId)
                .ValueGeneratedNever()
                .HasComment("Primary key for Employee records.  Foreign key to BusinessEntity.BusinessEntityID.");
            entity.Property(e => e.BirthDate).HasComment("Date of birth.");
            entity.Property(e => e.CurrentFlag)
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Inactive, 1 = Active");
            entity.Property(e => e.Gender)
                .IsFixedLength()
                .HasComment("M = Male, F = Female");
            entity.Property(e => e.HireDate).HasComment("Employee hired on this date.");
            entity.Property(e => e.JobTitle).HasComment("Work title such as Buyer or Sales Representative.");
            entity.Property(e => e.LoginId).HasComment("Network login.");
            entity.Property(e => e.MaritalStatus)
                .IsFixedLength()
                .HasComment("M = Married, S = Single");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.NationalIdnumber).HasComment("Unique national identification number such as a social security number.");
            entity.Property(e => e.OrganizationLevel)
                .HasComputedColumnSql("([OrganizationNode].[GetLevel]())", false)
                .HasComment("The depth of the employee in the corporate hierarchy.");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
            entity.Property(e => e.SalariedFlag)
                .HasDefaultValueSql("((1))")
                .HasComment("Job classification. 0 = Hourly, not exempt from collective bargaining. 1 = Salaried, exempt from collective bargaining.");
            entity.Property(e => e.SickLeaveHours).HasComment("Number of available sick leave hours.");
            entity.Property(e => e.VacationHours).HasComment("Number of available vacation hours.");

            entity.HasOne(d => d.BusinessEntity).WithOne(p => p.Employee).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmployeeDepartmentHistory>(entity =>
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.StartDate, e.DepartmentId, e.ShiftId }).HasName("PK_EmployeeDepartmentHistory_BusinessEntityID_StartDate_DepartmentID");

            entity.ToTable("EmployeeDepartmentHistory", "HumanResources", tb => tb.HasComment("Employee department transfers."));

            entity.Property(e => e.BusinessEntityId).HasComment("Employee identification number. Foreign key to Employee.BusinessEntityID.");
            entity.Property(e => e.StartDate).HasComment("Date the employee started work in the department.");
            entity.Property(e => e.DepartmentId).HasComment("Department in which the employee worked including currently. Foreign key to Department.DepartmentID.");
            entity.Property(e => e.ShiftId).HasComment("Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.");
            entity.Property(e => e.EndDate).HasComment("Date the employee left the department. NULL = Current department.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.EmployeeDepartmentHistories).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Department).WithMany(p => p.EmployeeDepartmentHistories).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Shift).WithMany(p => p.EmployeeDepartmentHistories).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmployeePayHistory>(entity =>
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.RateChangeDate }).HasName("PK_EmployeePayHistory_BusinessEntityID_RateChangeDate");

            entity.ToTable("EmployeePayHistory", "HumanResources", tb => tb.HasComment("Employee pay history."));

            entity.Property(e => e.BusinessEntityId).HasComment("Employee identification number. Foreign key to Employee.BusinessEntityID.");
            entity.Property(e => e.RateChangeDate).HasComment("Date the change in pay is effective");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.PayFrequency).HasComment("1 = Salary received monthly, 2 = Salary received biweekly");
            entity.Property(e => e.Rate).HasComment("Salary hourly rate.");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.EmployeePayHistories).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<JobCandidate>(entity =>
        {
            entity.HasKey(e => e.JobCandidateId).HasName("PK_JobCandidate_JobCandidateID");

            entity.ToTable("JobCandidate", "HumanResources", tb => tb.HasComment("Résumés submitted to Human Resources by job applicants."));

            entity.Property(e => e.JobCandidateId).HasComment("Primary key for JobCandidate records.");
            entity.Property(e => e.BusinessEntityId).HasComment("Employee identification number if applicant was hired. Foreign key to Employee.BusinessEntityID.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.Resume).HasComment("Résumé in XML format.");
        });

        modelBuilder.Entity<Password>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_Password_BusinessEntityID");

            entity.ToTable("Password", "Person", tb => tb.HasComment("One way hashed authentication information"));

            entity.Property(e => e.BusinessEntityId).ValueGeneratedNever();
            entity.Property(e => e.PasswordHash).HasComment("Password for the e-mail account.");
            entity.Property(e => e.PasswordSalt).HasComment("Random value concatenated with the password string before the password is hashed.");

            entity.HasOne(d => d.BusinessEntity).WithOne(p => p.Password).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_Person_BusinessEntityID");

            entity.ToTable("Person", "Person", tb =>
                {
                    tb.HasComment("Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts.");
                    tb.HasTrigger("iuPerson");
                });

            entity.Property(e => e.BusinessEntityId)
                .ValueGeneratedNever()
                .HasComment("Primary key for Person records.");
            entity.Property(e => e.EmailPromotion).HasComment("0 = Contact does not wish to receive e-mail promotions, 1 = Contact does wish to receive e-mail promotions from AdventureWorks, 2 = Contact does wish to receive e-mail promotions from AdventureWorks and selected partners. ");
            entity.Property(e => e.FirstName).HasComment("First name of the person.");
            entity.Property(e => e.LastName).HasComment("Last name of the person.");
            entity.Property(e => e.MiddleName).HasComment("Middle name or middle initial of the person.");
            entity.Property(e => e.NameStyle).HasComment("0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.");
            entity.Property(e => e.PersonType)
                .IsFixedLength()
                .HasComment("Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact");
            entity.Property(e => e.Suffix).HasComment("Surname suffix. For example, Sr. or Jr.");
            entity.Property(e => e.Title).HasComment("A courtesy title. For example, Mr. or Ms.");

            entity.HasOne(d => d.BusinessEntity).WithOne(p => p.Person).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PersonCreditCard>(entity =>
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.CreditCardId }).HasName("PK_PersonCreditCard_BusinessEntityID_CreditCardID");

            entity.ToTable("PersonCreditCard", "Sales", tb => tb.HasComment("Cross-reference table mapping people to their credit card information in the CreditCard table. "));

            entity.Property(e => e.BusinessEntityId).HasComment("Business entity identification number. Foreign key to Person.BusinessEntityID.");
            entity.Property(e => e.CreditCardId).HasComment("Credit card identification number. Foreign key to CreditCard.CreditCardID.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.PersonCreditCards).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.CreditCard).WithMany(p => p.PersonCreditCards).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PersonPhone>(entity =>
        {
            entity.HasKey(e => new { e.BusinessEntityId, e.PhoneNumber, e.PhoneNumberTypeId }).HasName("PK_PersonPhone_BusinessEntityID_PhoneNumber_PhoneNumberTypeID");

            entity.ToTable("PersonPhone", "Person", tb => tb.HasComment("Telephone number and type of a person."));

            entity.Property(e => e.BusinessEntityId).HasComment("Business entity identification number. Foreign key to Person.BusinessEntityID.");
            entity.Property(e => e.PhoneNumber).HasComment("Telephone number identification number.");
            entity.Property(e => e.PhoneNumberTypeId).HasComment("Kind of phone number. Foreign key to PhoneNumberType.PhoneNumberTypeID.");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.PersonPhones).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PhoneNumberType).WithMany(p => p.PersonPhones).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PhoneNumberType>(entity =>
        {
            entity.HasKey(e => e.PhoneNumberTypeId).HasName("PK_PhoneNumberType_PhoneNumberTypeID");

            entity.ToTable("PhoneNumberType", "Person", tb => tb.HasComment("Type of phone number of a person."));

            entity.Property(e => e.PhoneNumberTypeId).HasComment("Primary key for telephone number type records.");
            entity.Property(e => e.Name).HasComment("Name of the telephone number type");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Product_ProductID");

            entity.ToTable("Product", "Production", tb => tb.HasComment("Products sold or used in the manfacturing of sold products."));

            entity.Property(e => e.ProductId).HasComment("Primary key for Product records.");
            entity.Property(e => e.Class)
                .IsFixedLength()
                .HasComment("H = High, M = Medium, L = Low");
            entity.Property(e => e.Color).HasComment("Product color.");
            entity.Property(e => e.DiscontinuedDate).HasComment("Date the product was discontinued.");
            entity.Property(e => e.DiscountPercent).HasDefaultValueSql("((10))");
            entity.Property(e => e.ListPrice).HasComment("Selling price.");
            entity.Property(e => e.MakeFlag)
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Product is purchased, 1 = Product is manufactured in-house.");
            entity.Property(e => e.Name).HasComment("Name of the product.");
            entity.Property(e => e.ProductLine)
                .IsFixedLength()
                .HasComment("R = Road, M = Mountain, T = Touring, S = Standard");
            entity.Property(e => e.ProductNumber).HasComment("Unique product identification number.");
            entity.Property(e => e.ProductSubcategoryId).HasComment("Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. ");
            entity.Property(e => e.SellEndDate).HasComment("Date the product was no longer available for sale.");
            entity.Property(e => e.SellStartDate).HasComment("Date the product was available for sale.");
            entity.Property(e => e.Size).HasComment("Product size.");
            entity.Property(e => e.SizeUnitMeasureCode)
                .IsFixedLength()
                .HasComment("Unit of measure for Size column.");
            entity.Property(e => e.StandardCost).HasComment("Standard cost of the product.");
            entity.Property(e => e.Style)
                .IsFixedLength()
                .HasComment("W = Womens, M = Mens, U = Universal");
            entity.Property(e => e.Weight).HasComment("Product weight.");
            entity.Property(e => e.WeightUnitMeasureCode)
                .IsFixedLength()
                .HasComment("Unit of measure for Weight column.");

            entity.HasOne(d => d.Status).WithMany(p => p.Products).HasConstraintName("FK__Product__StatusI__5090EFD7");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK_ProductCategory_ProductCategoryID");

            entity.ToTable("ProductCategory", "Production", tb => tb.HasComment("High-level product categorization."));

            entity.Property(e => e.ProductCategoryId).HasComment("Primary key for ProductCategory records.");
            entity.Property(e => e.Name).HasComment("Category description.");
        });

        modelBuilder.Entity<ProductPhoto>(entity =>
        {
            entity.HasKey(e => e.ProductPhotoId).HasName("PK_ProductPhoto_ProductPhotoID");

            entity.ToTable("ProductPhoto", "Production", tb => tb.HasComment("Product images."));

            entity.Property(e => e.ProductPhotoId).HasComment("Primary key for ProductPhoto records.");
            entity.Property(e => e.LargePhoto).HasComment("Large image of the product.");
            entity.Property(e => e.LargePhotoFileName).HasComment("Large image file name.");
            entity.Property(e => e.ThumbNailPhoto).HasComment("Small image of the product.");
            entity.Property(e => e.ThumbnailPhotoFileName).HasComment("Small image file name.");
        });

        modelBuilder.Entity<ProductProductPhoto>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.ProductPhotoId })
                .HasName("PK_ProductProductPhoto_ProductID_ProductPhotoID")
                .IsClustered(false);

            entity.ToTable("ProductProductPhoto", "Production", tb => tb.HasComment("Cross-reference table mapping products and product photos."));

            entity.Property(e => e.ProductId).HasComment("Product identification number. Foreign key to Product.ProductID.");
            entity.Property(e => e.ProductPhotoId).HasComment("Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.");
            entity.Property(e => e.Primary).HasComment("0 = Photo is not the principal image. 1 = Photo is the principal image.");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductProductPhotos).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductPhoto).WithMany(p => p.ProductProductPhotos).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("pk_StatusId");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ProductSubcategory>(entity =>
        {
            entity.HasKey(e => e.ProductSubcategoryId).HasName("PK_ProductSubcategory_ProductSubcategoryID");

            entity.ToTable("ProductSubcategory", "Production", tb => tb.HasComment("Product subcategories. See ProductCategory table."));

            entity.Property(e => e.ProductSubcategoryId).HasComment("Primary key for ProductSubcategory records.");
            entity.Property(e => e.Name).HasComment("Subcategory description.");
            entity.Property(e => e.ProductCategoryId).HasComment("Product category identification number. Foreign key to ProductCategory.ProductCategoryID.");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.ProductSubcategories).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductVendor>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.BusinessEntityId }).HasName("PK_ProductVendor_ProductID_BusinessEntityID");

            entity.ToTable("ProductVendor", "Purchasing", tb => tb.HasComment("Cross-reference table mapping vendors with the products they supply."));

            entity.Property(e => e.ProductId).HasComment("Primary key. Foreign key to Product.ProductID.");
            entity.Property(e => e.BusinessEntityId).HasComment("Primary key. Foreign key to Vendor.BusinessEntityID.");
            entity.Property(e => e.AverageLeadTime).HasComment("The average span of time (in days) between placing an order with the vendor and receiving the purchased product.");
            entity.Property(e => e.LastReceiptCost).HasComment("The selling price when last purchased.");
            entity.Property(e => e.LastReceiptDate).HasComment("Date the product was last received by the vendor.");
            entity.Property(e => e.MaxOrderQty).HasComment("The minimum quantity that should be ordered.");
            entity.Property(e => e.MinOrderQty).HasComment("The maximum quantity that should be ordered.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.OnOrderQty).HasComment("The quantity currently on order.");
            entity.Property(e => e.StandardPrice).HasComment("The vendor's usual selling price.");
            entity.Property(e => e.UnitMeasureCode)
                .IsFixedLength()
                .HasComment("The product's unit of measure.");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.ProductVendors).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVendors).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UnitMeasureCodeNavigation).WithMany(p => p.ProductVendors).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PurchaseOrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.PurchaseOrderId, e.PurchaseOrderDetailId }).HasName("PK_PurchaseOrderDetail_PurchaseOrderID_PurchaseOrderDetailID");

            entity.ToTable("PurchaseOrderDetail", "Purchasing", tb =>
                {
                    tb.HasComment("Individual products associated with a specific purchase order. See PurchaseOrderHeader.");
                    tb.HasTrigger("iPurchaseOrderDetail");
                    tb.HasTrigger("uPurchaseOrderDetail");
                });

            entity.Property(e => e.PurchaseOrderId).HasComment("Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.");
            entity.Property(e => e.PurchaseOrderDetailId)
                .ValueGeneratedOnAdd()
                .HasComment("Primary key. One line number per purchased product.");
            entity.Property(e => e.DueDate).HasComment("Date the product is expected to be received.");
            entity.Property(e => e.LineTotal)
                .HasComputedColumnSql("(isnull([OrderQty]*[UnitPrice],(0.00)))", false)
                .HasComment("Per product subtotal. Computed as OrderQty * UnitPrice.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.OrderQty).HasComment("Quantity ordered.");
            entity.Property(e => e.ProductId).HasComment("Product identification number. Foreign key to Product.ProductID.");
            entity.Property(e => e.ReceivedQty).HasComment("Quantity actually received from the vendor.");
            entity.Property(e => e.RejectedQty).HasComment("Quantity rejected during inspection.");
            entity.Property(e => e.StockedQty)
                .HasComputedColumnSql("(isnull([ReceivedQty]-[RejectedQty],(0.00)))", false)
                .HasComment("Quantity accepted into inventory. Computed as ReceivedQty - RejectedQty.");
            entity.Property(e => e.UnitPrice).HasComment("Vendor's selling price of a single product.");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseOrderDetails).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.PurchaseOrderDetails).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PurchaseOrderHeader>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderId).HasName("PK_PurchaseOrderHeader_PurchaseOrderID");

            entity.ToTable("PurchaseOrderHeader", "Purchasing", tb =>
                {
                    tb.HasComment("General purchase order information. See PurchaseOrderDetail.");
                    tb.HasTrigger("uPurchaseOrderHeader");
                });

            entity.Property(e => e.PurchaseOrderId).HasComment("Primary key.");
            entity.Property(e => e.EmployeeId).HasComment("Employee who created the purchase order. Foreign key to Employee.BusinessEntityID.");
            entity.Property(e => e.Freight)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Shipping cost.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Purchase order creation date.");
            entity.Property(e => e.RevisionNumber).HasComment("Incremental number to track changes to the purchase order over time.");
            entity.Property(e => e.ShipDate).HasComment("Estimated shipment date from the vendor.");
            entity.Property(e => e.ShipMethodId).HasComment("Shipping method. Foreign key to ShipMethod.ShipMethodID.");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("((1))")
                .HasComment("Order current status. 1 = Pending; 2 = Approved; 3 = Rejected; 4 = Complete");
            entity.Property(e => e.SubTotal)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Purchase order subtotal. Computed as SUM(PurchaseOrderDetail.LineTotal)for the appropriate PurchaseOrderID.");
            entity.Property(e => e.TaxAmt)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Tax amount.");
            entity.Property(e => e.TotalDue)
                .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", true)
                .HasComment("Total due to vendor. Computed as Subtotal + TaxAmt + Freight.");
            entity.Property(e => e.VendorId).HasComment("Vendor with whom the purchase order is placed. Foreign key to Vendor.BusinessEntityID.");

            entity.HasOne(d => d.Employee).WithMany(p => p.PurchaseOrderHeaders).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ShipMethod).WithMany(p => p.PurchaseOrderHeaders).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Vendor).WithMany(p => p.PurchaseOrderHeaders).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesOrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.SalesOrderId, e.SalesOrderDetailId }).HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

            entity.ToTable("SalesOrderDetail", "Sales", tb =>
                {
                    tb.HasComment("Individual products associated with a specific sales order. See SalesOrderHeader.");
                    tb.HasTrigger("iduSalesOrderDetail");
                });

            entity.Property(e => e.SalesOrderId).HasComment("Primary key. Foreign key to SalesOrderHeader.SalesOrderID.");
            entity.Property(e => e.SalesOrderDetailId)
                .ValueGeneratedOnAdd()
                .HasComment("Primary key. One incremental unique number per product sold.");
            entity.Property(e => e.CarrierTrackingNumber).HasComment("Shipment tracking number supplied by the shipper.");
            entity.Property(e => e.LineTotal)
                .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", false)
                .HasComment("Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.OrderQty).HasComment("Quantity ordered per product.");
            entity.Property(e => e.ProductId).HasComment("Product sold to customer. Foreign key to Product.ProductID.");
            entity.Property(e => e.SpecialOfferId).HasComment("Promotional code. Foreign key to SpecialOffer.SpecialOfferID.");
            entity.Property(e => e.UnitPrice).HasComment("Selling price of a single product.");
            entity.Property(e => e.UnitPriceDiscount).HasComment("Discount amount.");

            entity.HasOne(d => d.SpecialOfferProduct).WithMany(p => p.SalesOrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID");
        });

        modelBuilder.Entity<SalesOrderHeader>(entity =>
        {
            entity.HasKey(e => e.SalesOrderId).HasName("PK_SalesOrderHeader_SalesOrderID");

            entity.ToTable("SalesOrderHeader", "Sales", tb =>
                {
                    tb.HasComment("General sales order information.");
                    tb.HasTrigger("uSalesOrderHeader");
                });

            entity.Property(e => e.SalesOrderId).HasComment("Primary key.");
            entity.Property(e => e.AccountNumber).HasComment("Financial accounting number reference.");
            entity.Property(e => e.BillToAddressId).HasComment("Customer billing address. Foreign key to Address.AddressID.");
            entity.Property(e => e.Comment).HasComment("Sales representative comments.");
            entity.Property(e => e.CreditCardApprovalCode).HasComment("Approval code provided by the credit card company.");
            entity.Property(e => e.CreditCardId).HasComment("Credit card identification number. Foreign key to CreditCard.CreditCardID.");
            entity.Property(e => e.CurrencyRateId).HasComment("Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.");
            entity.Property(e => e.CustomerId).HasComment("Customer identification number. Foreign key to Customer.BusinessEntityID.");
            entity.Property(e => e.DueDate).HasComment("Date the order is due to the customer.");
            entity.Property(e => e.Freight)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Shipping cost.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.OnlineOrderFlag)
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Order placed by sales person. 1 = Order placed online by customer.");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Dates the sales order was created.");
            entity.Property(e => e.PurchaseOrderNumber).HasComment("Customer purchase order number reference. ");
            entity.Property(e => e.RevisionNumber).HasComment("Incremental number to track changes to the sales order over time.");
            entity.Property(e => e.SalesOrderNumber)
                .HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))", false)
                .HasComment("Unique sales order identification number.");
            entity.Property(e => e.SalesPersonId).HasComment("Sales person who created the sales order. Foreign key to SalesPerson.BusinessEntityID.");
            entity.Property(e => e.ShipDate).HasComment("Date the order was shipped to the customer.");
            entity.Property(e => e.ShipMethodId).HasComment("Shipping method. Foreign key to ShipMethod.ShipMethodID.");
            entity.Property(e => e.ShipToAddressId).HasComment("Customer shipping address. Foreign key to Address.AddressID.");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("((1))")
                .HasComment("Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled");
            entity.Property(e => e.SubTotal)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.");
            entity.Property(e => e.TaxAmt)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Tax amount.");
            entity.Property(e => e.TotalDue)
                .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", false)
                .HasComment("Total due from customer. Computed as Subtotal + TaxAmt + Freight.");

            entity.HasOne(d => d.BillToAddress).WithMany(p => p.SalesOrderHeaderBillToAddresses).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesOrderHeaders).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ShipMethod).WithMany(p => p.SalesOrderHeaders).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ShipToAddress).WithMany(p => p.SalesOrderHeaderShipToAddresses).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesPerson>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_SalesPerson_BusinessEntityID");

            entity.ToTable("SalesPerson", "Sales", tb => tb.HasComment("Sales representative current information."));

            entity.Property(e => e.BusinessEntityId)
                .ValueGeneratedNever()
                .HasComment("Primary key for SalesPerson records. Foreign key to Employee.BusinessEntityID");
            entity.Property(e => e.Bonus)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Bonus due if quota is met.");
            entity.Property(e => e.CommissionPct)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Commision percent received per sale.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
            entity.Property(e => e.SalesLastYear)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Sales total of previous year.");
            entity.Property(e => e.SalesQuota).HasComment("Projected yearly sales.");
            entity.Property(e => e.SalesYtd)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Sales total year to date.");

            entity.HasOne(d => d.BusinessEntity).WithOne(p => p.SalesPerson).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesTaxRate>(entity =>
        {
            entity.HasKey(e => e.SalesTaxRateId).HasName("PK_SalesTaxRate_SalesTaxRateID");

            entity.ToTable("SalesTaxRate", "Sales", tb => tb.HasComment("Tax rate lookup table."));

            entity.Property(e => e.SalesTaxRateId).HasComment("Primary key for SalesTaxRate records.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.Name).HasComment("Tax rate description.");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
            entity.Property(e => e.TaxRate)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Tax rate amount.");
            entity.Property(e => e.TaxType).HasComment("1 = Tax applied to retail transactions, 2 = Tax applied to wholesale transactions, 3 = Tax applied to all sales (retail and wholesale) transactions.");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK_Shift_ShiftID");

            entity.ToTable("Shift", "HumanResources", tb => tb.HasComment("Work shift lookup table."));

            entity.Property(e => e.ShiftId)
                .ValueGeneratedOnAdd()
                .HasComment("Primary key for Shift records.");
            entity.Property(e => e.EndTime).HasComment("Shift end time.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.Name).HasComment("Shift description.");
            entity.Property(e => e.StartTime).HasComment("Shift start time.");
        });

        modelBuilder.Entity<ShipMethod>(entity =>
        {
            entity.HasKey(e => e.ShipMethodId).HasName("PK_ShipMethod_ShipMethodID");

            entity.ToTable("ShipMethod", "Purchasing", tb => tb.HasComment("Shipping company lookup table."));

            entity.Property(e => e.ShipMethodId).HasComment("Primary key for ShipMethod records.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.Name).HasComment("Shipping company name.");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
            entity.Property(e => e.ShipBase)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Minimum shipping charge.");
            entity.Property(e => e.ShipRate)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Shipping charge per pound.");
        });

        modelBuilder.Entity<ShoppingCartItem>(entity =>
        {
            entity.HasKey(e => e.ShoppingCartItemId).HasName("PK_ShoppingCartItem_ShoppingCartItemID");

            entity.ToTable("ShoppingCartItem", "Sales", tb => tb.HasComment("Contains online customer orders until the order is submitted or cancelled."));

            entity.Property(e => e.ShoppingCartItemId).HasComment("Primary key for ShoppingCartItem records.");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date the time the record was created.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.ProductId).HasComment("Product ordered. Foreign key to Product.ProductID.");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("((1))")
                .HasComment("Product quantity ordered.");
            entity.Property(e => e.ShoppingCartId).HasComment("Shopping cart identification number.");

            entity.HasOne(d => d.Product).WithMany(p => p.ShoppingCartItems).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SpecialOffer>(entity =>
        {
            entity.HasKey(e => e.SpecialOfferId).HasName("PK_SpecialOffer_SpecialOfferID");

            entity.ToTable("SpecialOffer", "Sales", tb => tb.HasComment("Sale discounts lookup table."));

            entity.Property(e => e.SpecialOfferId).HasComment("Primary key for SpecialOffer records.");
            entity.Property(e => e.Category).HasComment("Group the discount applies to such as Reseller or Customer.");
            entity.Property(e => e.Description).HasComment("Discount description.");
            entity.Property(e => e.DiscountPct)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Discount precentage.");
            entity.Property(e => e.EndDate).HasComment("Discount end date.");
            entity.Property(e => e.MaxQty).HasComment("Maximum discount percent allowed.");
            entity.Property(e => e.MinQty).HasComment("Minimum discount percent allowed.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
            entity.Property(e => e.StartDate).HasComment("Discount start date.");
            entity.Property(e => e.Type).HasComment("Discount type category.");
        });

        modelBuilder.Entity<SpecialOfferProduct>(entity =>
        {
            entity.HasKey(e => new { e.SpecialOfferId, e.ProductId }).HasName("PK_SpecialOfferProduct_SpecialOfferID_ProductID");

            entity.ToTable("SpecialOfferProduct", "Sales", tb => tb.HasComment("Cross-reference table mapping products to special offer discounts."));

            entity.Property(e => e.SpecialOfferId).HasComment("Primary key for SpecialOfferProduct records.");
            entity.Property(e => e.ProductId).HasComment("Product identification number. Foreign key to Product.ProductID.");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.HasOne(d => d.Product).WithMany(p => p.SpecialOfferProducts).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SpecialOffer).WithMany(p => p.SpecialOfferProducts).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<UnitMeasure>(entity =>
        {
            entity.HasKey(e => e.UnitMeasureCode).HasName("PK_UnitMeasure_UnitMeasureCode");

            entity.ToTable("UnitMeasure", "Production", tb => tb.HasComment("Unit of measure lookup table."));

            entity.Property(e => e.UnitMeasureCode)
                .IsFixedLength()
                .HasComment("Primary key.");
            entity.Property(e => e.Name).HasComment("Unit of measure description.");
        });

        modelBuilder.Entity<VAdditionalContactInfo>(entity =>
        {
            entity.ToView("vAdditionalContactInfo", "Person");
        });

        modelBuilder.Entity<VEmployee>(entity =>
        {
            entity.ToView("vEmployee", "HumanResources");
        });

        modelBuilder.Entity<VEmployeeDepartment>(entity =>
        {
            entity.ToView("vEmployeeDepartment", "HumanResources");
        });

        modelBuilder.Entity<VEmployeeDepartmentHistory>(entity =>
        {
            entity.ToView("vEmployeeDepartmentHistory", "HumanResources");
        });

        modelBuilder.Entity<VIndividualCustomer>(entity =>
        {
            entity.ToView("vIndividualCustomer", "Sales");
        });

        modelBuilder.Entity<VJobCandidate>(entity =>
        {
            entity.ToView("vJobCandidate", "HumanResources");

            entity.Property(e => e.JobCandidateId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VJobCandidateEducation>(entity =>
        {
            entity.ToView("vJobCandidateEducation", "HumanResources");

            entity.Property(e => e.JobCandidateId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VJobCandidateEmployment>(entity =>
        {
            entity.ToView("vJobCandidateEmployment", "HumanResources");

            entity.Property(e => e.JobCandidateId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VPersonDemographic>(entity =>
        {
            entity.ToView("vPersonDemographics", "Sales");
        });

        modelBuilder.Entity<VProductModelCatalogDescription>(entity =>
        {
            entity.ToView("vProductModelCatalogDescription", "Production");

            entity.Property(e => e.ProductModelId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VProductModelInstruction>(entity =>
        {
            entity.ToView("vProductModelInstructions", "Production");

            entity.Property(e => e.ProductModelId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VSalesPerson>(entity =>
        {
            entity.ToView("vSalesPerson", "Sales");
        });

        modelBuilder.Entity<VSalesPersonSalesByFiscalYear>(entity =>
        {
            entity.ToView("vSalesPersonSalesByFiscalYears", "Sales");
        });

        modelBuilder.Entity<VStoreWithAddress>(entity =>
        {
            entity.ToView("vStoreWithAddresses", "Sales");
        });

        modelBuilder.Entity<VStoreWithContact>(entity =>
        {
            entity.ToView("vStoreWithContacts", "Sales");
        });

        modelBuilder.Entity<VStoreWithDemographic>(entity =>
        {
            entity.ToView("vStoreWithDemographics", "Sales");
        });

        modelBuilder.Entity<VVendorWithAddress>(entity =>
        {
            entity.ToView("vVendorWithAddresses", "Purchasing");
        });

        modelBuilder.Entity<VVendorWithContact>(entity =>
        {
            entity.ToView("vVendorWithContacts", "Purchasing");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_Vendor_BusinessEntityID");

            entity.ToTable("Vendor", "Purchasing", tb =>
                {
                    tb.HasComment("Companies from whom Adventure Works Cycles purchases parts or other goods.");
                    tb.HasTrigger("dVendor");
                });

            entity.Property(e => e.BusinessEntityId)
                .ValueGeneratedNever()
                .HasComment("Primary key for Vendor records.  Foreign key to BusinessEntity.BusinessEntityID");
            entity.Property(e => e.AccountNumber).HasComment("Vendor account (identification) number.");
            entity.Property(e => e.ActiveFlag)
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Vendor no longer used. 1 = Vendor is actively used.");
            entity.Property(e => e.CreditRating).HasComment("1 = Superior, 2 = Excellent, 3 = Above average, 4 = Average, 5 = Below average");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
            entity.Property(e => e.Name).HasComment("Company name.");
            entity.Property(e => e.PreferredVendorStatus)
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Do not use if another vendor is available. 1 = Preferred over other vendors supplying the same product.");
            entity.Property(e => e.PurchasingWebServiceUrl).HasComment("Vendor URL.");

            entity.HasOne(d => d.BusinessEntity).WithOne(p => p.Vendor).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
