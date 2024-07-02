using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Z.EntityFramework.Plus;

// public static class PaginatedListExtensions
// {

//     public static async Task<PaginatedResponseDto<T>> ToPaginatedListAsync<T>(IQueryable<T> source, int pageIndex, int pageSize, CancellationToken ct)
//     {
//         var items = source.Drinks
// .OrderBy(d => d.Id)
// // .Select(d => new DrinkDto { Id = d.Id, Name = d.Name })
// .AsNoTracking().Future();

//         Guard.Against.NullOrEmpty(source);
//         pageIndex = pageIndex < 1 ? 1 : pageIndex;
//         pageSize = pageSize < 1 ? 10 : pageSize;

//         var futureItemCount = source.DeferredCount().FutureValue();

//         var items = await source
//             .Skip((pageIndex - 1) * pageSize)
//             .Take(pageSize)
//             .ToListAsync(ct);
//         var itemCount = futureItemCount.Value;

//         var totalPages = (int)Math.Ceiling(itemCount / (double)pageSize);

//         return new PaginatedResponseDto<T>
//         {
//             TotalCount = itemCount,
//             PageIndex = pageIndex,
//             PageSize = pageSize,
//             TotalPages = totalPages,
//             HasPreviousPage = pageIndex > 1,
//             HasNextPage = pageIndex < totalPages,
//             Items = items
//         };

//         // Guard.Against.NullOrEmpty(source);
//         // pageIndex = pageIndex < 1 ? 1 : pageIndex;
//         // pageSize = pageSize < 1 ? 10 : pageSize;

//         // var paginatedResult = await source
//         // .GroupBy(e => new { TotalCount = source.Count(x => true) })
//         // .Select(g => new
//         // {
//         //     g.Key.TotalCount,
//         //     items = source.Select(d => new DrinkDto { Id = d.Id, Name = d.Name }).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
//         // })
//         // .FirstOrDefaultAsync(ct);

//         // Guard.Against.Null(paginatedResult);
//         // var totalPages = (int)Math.Ceiling(paginatedResult.TotalCount / (double)pageSize);

//         // return new PaginatedResponseDto<T>
//         // {
//         //     TotalCount = paginatedResult.TotalCount,
//         //     PageIndex = pageIndex,
//         //     PageSize = pageSize,
//         //     TotalPages = totalPages,
//         //     HasPreviousPage = pageIndex > 1,
//         //     HasNextPage = pageIndex < totalPages,
//         //     Items = paginatedResult.items
//         // };
//     }


// // }

// public static async Task<PaginatedResponseDto<T>> Paginated<T>(QueryFutureEnumerable<Drink> items, QueryFutureValue<int> count)
// {
//     Guard.Against.NullOrEmpty(items);
//     Guard.Against.Null(count);

//     var futureDrink = await _context.Drinks.OrderBy(x => x.Id).Take(10).Future();
//     var futureDrinkCount = await _context.Drinks.DeferredCount().FutureValue();

//     // ONE database round trip is required
//     var paginatedItems = items.ToList();
//     var itemCount = count.Value;

//     return new PaginatedResponseDto<T>
//     {
//         TotalCount = itemCount
//         // PageIndex = pageIndex,
//         // PageSize = pageSize,
//         // TotalPages = totalPages,
//         // HasPreviousPage = pageIndex > 1,
//         // HasNextPage = pageIndex < totalPages,
//         // Items = paginatedItems
//     };
// }

// }