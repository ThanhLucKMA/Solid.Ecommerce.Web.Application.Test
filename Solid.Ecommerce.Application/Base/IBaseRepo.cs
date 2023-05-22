namespace Solid.Ecommerce.Application.Base;
public interface IBaseRepo<T> where T : class
{
    DbSet<T> Entities { get; }
    IApplicationDBContext ApplicationDBContext { get; } //Has
}


