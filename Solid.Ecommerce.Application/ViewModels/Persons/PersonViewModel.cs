namespace Solid.Ecommerce.Application.ViewModels.Persons;
public class PersonViewModel: IMapFrom<Person>
{
    public int BusinessEntityId { get; set; }
    public string PersonType { get; set; } = null!;
    public bool NameStyle { get; set; }
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = null!;
    public int EmailPromotion { get; set; }
}
