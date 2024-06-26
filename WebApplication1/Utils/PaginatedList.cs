using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
public static class PaginatedListExtensions
{
    public static async Task<PaginatedResponseDto<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize, CancellationToken ct)
    {
        Guard.Against.NullOrEmpty(source);
        // TODO add guards against max values
        // Guard.Against.OutOfRange(pageIndex, nameof(pageIndex), 1, int.MaxValue);
        // Guard.Against.OutOfRange(pageSize, nameof(pageSize), 1, int.MaxValue);

        var count = await source.CountAsync(ct);
        var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(ct);
        var totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return new PaginatedResponseDto<T>
        {
            TotalCount = count,
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalPages = totalPages,
            HasPreviousPage = pageIndex > 1,
            HasNextPage = pageIndex < totalPages,
            Items = items
        };
    }
}