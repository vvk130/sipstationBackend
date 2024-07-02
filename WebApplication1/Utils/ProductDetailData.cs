using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Z.EntityFramework.Plus;

public static class GetStatisticsExtension
{
    // public static async Task<PaginatedResponseDto<TDto>> GetStatistics<TEntity, TDto>(DbSet<TEntity> source, IQueryable<TDto> sentItems, int pageIndex = 1, int pageSize = 10, CancellationToken cT = default) where TEntity : class
    // {
    //     var items = sentItems.Take(10).Future();
    //     var count = source.DeferredCount().FutureValue();

    //     Guard.Against.NullOrEmpty(items);
    //     Guard.Against.Null(source);

    //     var paginatedItems = await items.ToListAsync(cT);
    //     var itemCount = count.Value;

    //     var totalPages = (int)Math.Ceiling(itemCount / (double)pageSize);

    //     return new ProductDetailDto<TDto>
    //     {
    //         Item = item,
    //          
    //         SimilarItemsMoreExpensive = moreExpensive,
    //         DifferenceToAvgPriceOfItem = pageSize
    //     };
    // }
}

// How many drink are more expensive?
// var moreExpensive = 
// Is it above or below the average price drinks? 
// var differenceToAvgPriceOfDrinks = 