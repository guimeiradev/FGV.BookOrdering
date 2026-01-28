namespace FGV.BookOrdering.Domain.Entities;

public class Book
{
    public string Title { get; }
    public string AuthorName { get; }
    public int EditionYear { get; }

    public Book(string title, string authorName, int editionYear)
    {
        Title = title;
        AuthorName = authorName;
        EditionYear = editionYear;
    }
}
