using FGV.BookOrdering.Domain.Entities;

namespace FGV.BookOrdering.Tests.Fixtures;

public static class BookFixture
{
    public static List<Book> CreateDefault()
    {
        return new List<Book>
        {
            new ("Java How to Program", "Deitel & Deitel", 2007),
            new ("Patterns of Enterprise Application Architecture", "Martin Fowler", 2002),
            new ("Head First Design Patterns", "Elisabeth Freeman", 2004),
            new ("Internet & World Wide Web: How to Program", "Deitel & Deitel", 2007)
        };
    }
}