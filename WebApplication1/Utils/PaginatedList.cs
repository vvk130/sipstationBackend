using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;

public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        AddRange(items);
    }

    public bool HasPreviousPage => PageIndex > 1;

    public bool HasNextPage => PageIndex < TotalPages;

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize, CancellationToken ct)
    {
        Guard.Against.NullOrEmpty(source);
        // TODO add guards against max values
        // Guard.Against.OutOfRange(pageIndex, nameof(pageIndex), 1, int.MaxValue);
        // Guard.Against.OutOfRange(pageSize, nameof(pageSize), 1, int.MaxValue);

        var count = await source.CountAsync(ct);
        var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(ct);
        

        return new PaginatedList<T>(items, count, pageIndex, pageSize);
    }
}