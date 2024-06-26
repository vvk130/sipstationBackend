using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models;

public partial class PaginatedResponseDto<T>
{
    public int TotalCount { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
    public required List<T> Items { get; set; }
}