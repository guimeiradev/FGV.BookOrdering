using FGV.BookOrdering.Domain.Enum;

namespace FGV.BookOrdering.Service.Sorting;

public class SortRule
{
    public string Field { get; set; }
    public SortDirectionEnum Direction { get; set; }
}