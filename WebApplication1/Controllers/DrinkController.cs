using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using WebApplication1.Data;
using WebApplication1.Models;
using Z.EntityFramework.Plus;
using Zomp.EFCore.WindowFunctions;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/v1/[controller]")]
    public class DrinkController : ControllerBase
    {
        private readonly ILogger<DrinkController> _logger;
        private readonly PostgresContext _context;

        public DrinkController(ILogger<DrinkController> logger, PostgresContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Retrieves a paginated list of DrinkDtos.
        /// </summary>
        /// <param name="pageIndex">The page index (starting at 1).</param>
        /// <param name="pageSize">The size of the page (number of items per page).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A paginated response containing a list of DTO items.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Drinks?pageIndex=1&amp;pageSize=10
        ///
        /// This endpoint returns a paginated list of DrinkDtos. The default page index is 1, 
        /// and the default page size is 10. The response includes metadata about the pagination such as the total count, 
        /// page index, page size, total pages, and indicators if there are previous or next pages available.
        /// </remarks>
        /// <response code="200">Returns the paginated list of items.</response>
        /// <response code="404">If no items are found.</response>
        /// <seealso cref="PaginatedResponseDto{TDto}"/>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="sentItems"/> is null or empty.</exception>
        [HttpGet]
        public async Task<IActionResult> GetDrinks(int pageIndex = 1, int pageSize = 10, CancellationToken cT = default)
        {
            var items = _context.Drinks.OrderBy(x => x.Id).Select(d => new DrinkDto { Id = d.Id, Name = d.Name });

            var post = await PaginatedListExtensions.Paginated(_context.Drinks, items, pageIndex, pageSize, cT);
            return post == null ? NotFound() : Ok(post);
        }

        [HttpDelete("{drinkId}")]
        public async Task<IActionResult> DeleteDrinkById([FromRoute] Guid drinkId, CancellationToken cancellationToken)
        {
            var deletedRows = await _context.Drinks.Where(d => d.Id == drinkId).ExecuteDeleteAsync(cancellationToken);
            return deletedRows == 0 ? NotFound() : NoContent();
        }

        /// <summary>
        /// Retrieves a Drink by its ID.
        /// </summary>
        /// <param name="id">The ID of the Drink to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The requested Drink if found; otherwise, a 404 Not Found response with a custom message.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Drink/{id}
        ///
        /// </remarks>
        /// <response code="200">Returns the requested Drink</response>
        /// <response code="404">If the Drink is not found</response>
        [HttpGet("{id}")]
        // [HttpGet("sum")]
        public async Task<IActionResult> GetSum([FromRoute]
        Guid id, CancellationToken cancellationToken)

        {
            if (id == null) return NotFound();

            var data = await (from d in _context.Drinks
                              where d.Id == id // stationId comes from the incoming request
                              select new
                              {
                                  drinkId = d.Id,
                                  name = d.Name,
                                  price = d.Price,
            //                     // price = d.Price,

                                drinkCount = _context.Drinks.Count(x => true),
                                  totalNumberOfDrinksPriceOver5 = _context.Drinks.Where(x => x.Price > 5).Count(),
                                  totalNumberOfDrinksPriceUnder5 = _context.Drinks.Where(x => x.Price < 5).Count(),
                                  totalNumberOfDrinksPriceOver9 = _context.Drinks.Where(x => x.Price > 9).Count()
                              }).AsNoTracking().FirstOrDefaultAsync(cancellationToken);


            return data == null ? NotFound() : Ok(data);
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPut("{drinkId}")]
        public async Task<IActionResult> UpdateDrink([FromRoute] Guid drinkId, CancellationToken cancellationToken)
        {
            decimal newPrice = 4.00M;
            var UpdatedRows = await _context.Drinks.Where(d => d.Id == drinkId).ExecuteUpdateAsync(updates => updates.SetProperty(d => d.Price, newPrice), cancellationToken);
            return UpdatedRows == 0 ? NotFound(UpdatedRows) : Ok(UpdatedRows);
        }

    }
}
