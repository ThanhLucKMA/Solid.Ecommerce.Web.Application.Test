namespace Solid.Ecommerce.Web.Utils;

public class PaginatedList<T>: List<T> where T : class, new()

{
    
    public static int PageSize { get; } = 10;
    //Current page
    public int? PageIndex { get;  set; }
    public int TotalPages { get; private set; }
    public bool HasPreviousPage => (PageIndex > 1);

    public bool HasNextPage => (PageIndex < TotalPages);
    public PaginatedList(List<T> items, int count, int? pageIndex)
    {
        TotalPages = (int)Math.Ceiling(count / (double)PageSize);
        PageIndex = (pageIndex is > 0 && pageIndex.Value <= TotalPages)? pageIndex : 1;
        
        this.AddRange(items);
    }

    public static  PaginatedList<T> Create(IQueryable<T> source, int pageIndex)
    {
        var count = source.Count();

        var items = source.Skip((pageIndex - 1) * PageSize).Take(PageSize).ToList();

        return new PaginatedList<T>(items, count, pageIndex);
    }
}
