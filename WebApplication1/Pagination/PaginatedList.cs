using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Z.EntityFramework.Plus;

public static class PaginatedListExtensions
{
    public static async Task<PaginatedResponseDto<TDto>> Paginated<TEntity, TDto>(DbSet<TEntity> source, IQueryable<TDto> sentItems, int pageIndex = 1, int pageSize = 10, CancellationToken cT = default) where TEntity : class
    {
        var items = sentItems.Take(10).Future();
        var count = source.DeferredCount().FutureValue();

        Guard.Against.NullOrEmpty(items);
        Guard.Against.Null(source);

        // ONE database round trip is required
        var paginatedItems = await items.ToListAsync(cT);
        var itemCount = count.Value;

        var totalPages = (int)Math.Ceiling(itemCount / (double)pageSize);

        return new PaginatedResponseDto<TDto>
        {
            TotalCount = itemCount,
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalPages = totalPages,
            HasPreviousPage = pageIndex > 1,
            HasNextPage = pageIndex < totalPages,
            Items = paginatedItems
        };
    }

}