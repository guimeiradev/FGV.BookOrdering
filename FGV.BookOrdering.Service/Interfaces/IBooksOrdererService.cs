using FGV.BookOrdering.Domain.Entities;

namespace FGV.BookOrdering.Service.Interfaces;

public interface IBooksOrdererService
{
    IEnumerable<Book> Order(IEnumerable<Book> books); 
}