using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EmployeeAPI.Extensions;

public static class PaginationHeaderHelper{

    public static void AddPaginationHeader<T>(this HttpResponse response,PagedList<T> list){
          var metadata = new
        {
            list.TotalCount,
            list.CurrentPage,
            list.TotalPages,
            list.HasNext,
            list.HasPrevious
        };
        response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
    }

}