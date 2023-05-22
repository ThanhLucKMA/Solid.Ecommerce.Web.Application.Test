using Microsoft.AspNetCore.Mvc.Rendering;

namespace Solid.Ecommerce.Web.Pages.Base;
public abstract class BasePageModel<TEntity, TPageModel> : PageModel
    where TEntity : class, new()
{
    protected IDataService<TEntity> DataService { get; set; }
    protected int? Id { get; set; }
    [ViewData]
    protected string Title { get; init; }
  
    
    protected TEntity Entity { get; set; }
    public SelectList LookupValues { get; set; }

    public string Error { get; set; }
    public string ErrorMessage { get; set; }
    public string SuccessMessage { get; set; }
    protected BasePageModel( IDataService<TEntity> dataService, string pageTitle)
    {

        DataService = dataService;
        Title = pageTitle;
    }
    
    protected async Task GetLookupValuesAsync<TLookupEntity>(
        IDataService<TLookupEntity> lookupService, string lookupKey, string lookupDisplay)
        where TLookupEntity : class, new()
    {
        LookupValues = new(await lookupService.GetAllAsync(), lookupKey, lookupDisplay);
    }
    protected async Task GetOneAsync(int? id)
    {
        if (!id.HasValue)
        {
            Error = "Invalid request";
            Entity = null;
            return;
        }

        Entity = await DataService.GetOneAsync(id.Value);

        Id = id.Value;
        if (Entity == null)
        {
            Error = "Not found";
            return;
        }

        Error = string.Empty;
    }

    protected virtual async Task<IActionResult> SaveOneAsync(Func<TEntity, Task> persistenceTask)
    {
        if (!ModelState.IsValid)
        {
            
            return Page();
        }

        try
        {
            await persistenceTask(Entity);
            
        }
        catch (Exception ex)
        {
            Error = ex.Message;
            ModelState.AddModelError(string.Empty, ex.Message);
            return Page();
        }

        return RedirectToPage("./Index");
    }
    protected virtual async Task<IActionResult> SaveWithLookupAsync<TLookupEntity>(
        Func<TEntity, Task> persistenceTask,
        IDataService<TLookupEntity> lookupService, string lookupKey, string lookupDisplay)
        where TLookupEntity : class, new()
    {
        if (!ModelState.IsValid)
        {
            await GetLookupValuesAsync(lookupService, lookupKey, lookupDisplay);
           
            return Page();
        }

        try
        {
         await persistenceTask(Entity);
        }
        catch (Exception ex)
        {
            Error = ex.Message;
            ModelState.AddModelError(string.Empty, ex.Message);
            await GetLookupValuesAsync(lookupService, lookupKey, lookupDisplay);
            return Page();
        }

        return RedirectToPage("./Details", new {id=Id});
    }
    public async Task<IActionResult> DeleteOneAsync(int? id)
    {

        if (!id.HasValue || id.Value != Id)
        {
            Error = "Bad Request";
            return Page();
        }

        try
        {
            Entity = await DataService.GetOneAsync(id.Value);
            await DataService.DeleteAysnc(Entity);
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            ModelState.Clear();

            Entity = await DataService.GetOneAsync(id.Value);
            Error = ex.Message;
            return Page();
        }

    }


    protected async Task<SelectList> GetLookupValuesByModelAsync<TLookupEntity>(
      IDataService<TLookupEntity> lookupService, string lookupKey, string lookupDisplay)
      where TLookupEntity : class, new()
    {
        return  new(await lookupService.GetAllAsync(), lookupKey, lookupDisplay);
    }
}
