﻿namespace Entity.Pagination;

public class PaginationSet<T>
{

    public int CurrentPage { get; set; }

    public int? Count
    {
        get
        {
            return (Items != null) ? Items.Count() : 0;
        }
    }
    public int? TotalPages { get; set; }
    public int? TotalCount { get; set; }
    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
}
