using System;
using System.Collections.Generic;
using System.Linq;

public static class PaginationExtensions
{
    private const int pageNumber = 1;
    private  const int pageSize = 10;

    public static IQueryable<T> Paginate<T>(this  IQueryable<T> source, int page = pageNumber)
    {
        if(page<=0){
            page=pageNumber;
        }
        return source.Skip((page - 1) * pageSize).Take(pageSize);
    }
}
