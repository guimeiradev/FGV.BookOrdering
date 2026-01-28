using FGV.BookOrdering.Domain.Entities;
using FGV.BookOrdering.Domain.Exceptions;
using FGV.BookOrdering.Service.Interfaces;
using FGV.BookOrdering.Service.Sorting;

namespace FGV.BookOrdering.Service.Services;

public class BooksOrdererService : IBooksOrdererService
{
    private readonly IEnumerable<SortRule> _rules;

    public BooksOrdererService(List<SortRule> rules)
    {
        _rules = rules;
    }
    public IEnumerable<Book> Order(IEnumerable<Book> books)
    {
        if (books == null)
            throw new OrdenacaoException("Conjunto de livros não pode ser nulo.");

        if (!books.Any())
            return books;
        
        Book book = new Book(string.Empty, string.Empty, 1);
        
        

        return books.ApplySorting(_rules);
    }
}