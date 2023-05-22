

namespace Solid.Ecommerce.Application.Interfaces.Services;

public interface IRazorRenderService
{
    Task<string> ToStringAsync<T>(string viewName, T model);
}