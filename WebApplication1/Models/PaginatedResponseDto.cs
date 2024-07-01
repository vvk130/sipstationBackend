using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models;

public partial class PaginatedResponseDto<T>
{
    public required int TotalCount { get; set; }
    public required int PageIndex { get; set; }
    public required int PageSize { get; set; }
    public required int TotalPages { get; set; }
    public required bool HasPreviousPage { get; set; }
    public required bool HasNextPage { get; set; }
    public required List<T> Items { get; set; }
}