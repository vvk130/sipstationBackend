using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
public static class PaginatedListExtensions
{
    public static async Task<PaginatedResponseDto<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize, CancellationToken ct)
    {
        Guard.Against.NullOrEmpty(source);
        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        pageSize = pageSize < 1 ? 10 : pageSize;

        var paginatedResult = await source
        .GroupBy(e => new { TotalCount = source.Count(x => true) })
        .Select(g => new
        {
            g.Key.TotalCount,
            items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
        })
        .FirstOrDefaultAsync(ct);

        Guard.Against.Null(paginatedResult);
        var totalPages = (int)Math.Ceiling(paginatedResult.TotalCount / (double)pageSize);

        return new PaginatedResponseDto<T>
        {
            TotalCount = paginatedResult.TotalCount,
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalPages = totalPages,
            HasPreviousPage = pageIndex > 1,
            HasNextPage = pageIndex < totalPages,
            Items = paginatedResult.items
        };
    }
}