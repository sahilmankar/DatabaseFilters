namespace FarmersAPI.Extensions;

public class PagedList<T> : List<T>
{
    private const int pageSize = 10;
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

    public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber = 1)
    {
        var count = source.Count();

        if (pageNumber <= 0)
        {
            pageNumber = 1;
        }
    
        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        return new PagedList<T>(items, count, pageNumber);
    }
}
