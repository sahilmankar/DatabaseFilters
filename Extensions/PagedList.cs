namespace FarmersAPI.Extensions;

public class PagedList<T> : List<T>
{
    private const int pageSize = 2;
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int TotalCount { get; private set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PagedList(List<T> items, int count, int pageNumber)
    {
        TotalCount = count;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        AddRange(items);
    }

    public static PagedList<T> ToPagedList(IQueryable<T> query, int pageNumber = 1)
    {
        var count = query.Count();
        var totalPages = (int)Math.Ceiling(count / (double)pageSize);
    
        if (pageNumber <= 0)
        {
            pageNumber = 1;
        }
        if(pageNumber> totalPages && totalPages!=0){
            pageNumber=totalPages;
        }

        var items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return new PagedList<T>(items, count, pageNumber);
    }
}
