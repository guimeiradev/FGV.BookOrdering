using FGV.BookOrdering.Domain.Entities;
using FGV.BookOrdering.Domain.Enum;
using FGV.BookOrdering.Domain.Exceptions;
using FGV.BookOrdering.Service.Services;
using FGV.BookOrdering.Service.Sorting;
using FGV.BookOrdering.Tests.Fixtures;

namespace FGV.BookOrdering.Tests.Tests;

public class BookTest
{
    [Fact]
    public void Order_ByTitleAsc_ShouldReturnExpectedOrder()
    {
        // Arrange
        var books = BookFixture.CreateDefault();

        var rules = new List<SortRule>
        {
            new() { Field = "Title", Direction = SortDirectionEnum.Asc }
        };

        var service = new BooksOrdererService(rules);

        // Act
        var result = service.Order(books).ToList();

        // Assert
        Assert.Equal("Head First Design Patterns", result[0].Title);
        Assert.Equal("Internet & World Wide Web: How to Program", result[1].Title);
        Assert.Equal("Java How to Program", result[2].Title);
        Assert.Equal("Patterns of Enterprise Application Architecture", result[3].Title);
    }
    
    [Fact]
    public void Order_ByAuthorAsc_ShouldReturnExpectedOrder()
    {
        var books = BookFixture.CreateDefault();

        var rules = new List<SortRule>
        {
            new SortRule { Field = "AuthorName", Direction = SortDirectionEnum.Asc }
        };

        var service = new BooksOrdererService(rules);

        var result = service.Order(books).ToList();

        Assert.Equal("Java How to Program", result[0].Title);
        Assert.Equal("Internet & World Wide Web: How to Program", result[1].Title);
        Assert.Equal("Head First Design Patterns", result[2].Title);
        Assert.Equal("Patterns of Enterprise Application Architecture", result[3].Title);
    }

    [Fact]
    public void Order_ByAuthorAsc_ThenTitleDesc_ShouldReturnExpectedOrder()
    {
        var books = BookFixture.CreateDefault();

        var rules = new List<SortRule>
        {
            new() { Field = "AuthorName", Direction = SortDirectionEnum.Asc },
            new() { Field = "Title", Direction = SortDirectionEnum.Desc }
        };

        var service = new BooksOrdererService(rules);

        var result = service.Order(books).ToList();

        Assert.Equal("Java How to Program", result[0].Title);
        Assert.Equal("Internet & World Wide Web: How to Program", result[1].Title);
        Assert.Equal("Head First Design Patterns", result[2].Title);
        Assert.Equal("Patterns of Enterprise Application Architecture", result[3].Title);
    }

    
    [Fact]
    public void Order_ByEditionDesc_AuthorDesc_TitleAsc_ShouldReturnExpectedOrder()
    {
        var books = BookFixture.CreateDefault();

        var rules = new List<SortRule>
        {
            new() { Field = "EditionYear", Direction = SortDirectionEnum.Desc },
            new() { Field = "AuthorName", Direction = SortDirectionEnum.Desc },
            new() { Field = "Title", Direction = SortDirectionEnum.Asc }
        };

        var service = new BooksOrdererService(rules);

        var result = service.Order(books).ToList();

        Assert.Equal("Internet & World Wide Web: How to Program", result[0].Title);
        Assert.Equal("Java How to Program", result[1].Title);
        Assert.Equal("Head First Design Patterns", result[2].Title);
        Assert.Equal("Patterns of Enterprise Application Architecture", result[3].Title);
    }
    
    [Fact]
    public void Order_WhenBooksIsNull_ShouldThrowOrdenacaoException()
    {
        var rules = new List<SortRule>
        {
            new SortRule { Field = "Title", Direction = SortDirectionEnum.Asc }
        };

        var service = new BooksOrdererService(rules);

        Assert.Throws<OrdenacaoException>(() => service.Order(null));
    }
    
    [Fact]
    public void Order_WhenBooksIsEmpty_ShouldReturnEmpty()
    {
        var books = new List<Book>();

        var rules = new List<SortRule>
        {
            new() { Field = "Title", Direction = SortDirectionEnum.Asc }
        };

        var service = new BooksOrdererService(rules);

        var result = service.Order(books);

        Assert.Empty(result);
    }
}