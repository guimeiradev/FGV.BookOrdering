using FGV.BookOrdering.Domain.Entities;
using FGV.BookOrdering.Domain.Enum;
using FGV.BookOrdering.Domain.Exceptions;

namespace FGV.BookOrdering.Service.Sorting;

public static class BookSortExtensions
{
    // Aplicando ordenacao
    public static IEnumerable<Book> ApplySorting(
        this IEnumerable<Book> books,
        IEnumerable<SortRule> rules)
    {
        IOrderedEnumerable<Book>? ordered = null;

        foreach (var rule in rules)
        {
            Func<Book, object> keySelector = rule.Field switch
            {
                "Title" => b => b.Title,
                "AuthorName" => b => b.AuthorName,
                "EditionYear" => b => b.EditionYear,
                _ => throw new OrdenacaoException($"Campo inválido: {rule.Field}")
            };

            ordered = ordered == null
                ? ApplyFirst(books, rule, keySelector)
                : ApplyNext(ordered, rule, keySelector);
        }

        return ordered ?? books;
    }

    private static IOrderedEnumerable<Book> ApplyFirst(
        IEnumerable<Book> source,
        SortRule rule,
        Func<Book, object> key)
        => rule.Direction == SortDirectionEnum.Asc
            ? source.OrderBy(key)
            : source.OrderByDescending(key);

    private static IOrderedEnumerable<Book> ApplyNext(
        IOrderedEnumerable<Book> source,
        SortRule rule,
        Func<Book, object> key)
        => rule.Direction == SortDirectionEnum.Asc
            ? source.ThenBy(key)
            : source.ThenByDescending(key);
}