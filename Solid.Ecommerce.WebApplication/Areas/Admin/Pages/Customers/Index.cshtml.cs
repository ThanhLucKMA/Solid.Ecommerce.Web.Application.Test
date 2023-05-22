
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Solid.Ecommerce.Application.ViewModels.Persons;


namespace Solid.Ecommerce.Web.Areas.Admin.Pages.Customers;

public class IndexModel : PageModel
{
    private readonly IRazorRenderService _renderService;
    private readonly IPersonService _personService;

    public IEnumerable<Person> Persons { get; set; }
    public IndexModel(IPersonService personService, IRazorRenderService renderService)
    {
        
        _renderService = renderService;
        _personService = personService;
    }

  
    public async Task<PartialViewResult> OnGetViewAllPartial()
    {
    

        Persons = await _personService.GetAllAsync();

        return new PartialViewResult
        {
            ViewName = "_ViewAll",
            ViewData = new ViewDataDictionary<IEnumerable<Person>>(ViewData, Persons)
        };
    }
    public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
    {
        var htmlTest = await _renderService.ToStringAsync("_CreateOrEdit", new PersonModel());
  
        if (id == 0)
            
            return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", new PersonModel()) });
        else
        {
            var person = await _personService.GetOneAsync(id);

            var thisPerson = _personService.Map<Person, PersonModel>(person);
            return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", thisPerson) });
        }
    }
    public async Task<JsonResult> OnPostCreateOrEditAsync(int id, Person person)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                await _personService.AddAsync(person);
                
            }
            else
            {
                await _personService.UpdateAsync(person);
               
            }
            Persons = await _personService.GetAllAsync();
            var html = await _renderService.ToStringAsync("_ViewAll", Persons);
            return new JsonResult(new { isValid = true, html = html });
        }
        else
        {
            var html = await _renderService.ToStringAsync("_CreateOrEdit", Persons);
            return new JsonResult(new { isValid = false, html = html });
        }
    }
}
