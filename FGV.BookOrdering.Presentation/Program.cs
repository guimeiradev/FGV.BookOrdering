// See https://aka.ms/new-console-template for more information

using FGV.BookOrdering.Configuration;
using Microsoft.Extensions.DependencyInjection;

using FGV.BookOrdering.Domain.Entities;
using FGV.BookOrdering.Service.Interfaces;

var container = DependencyInjection.Configure();

var sorter = container.GetRequiredService<IBooksOrdererService>();

List<Book> books = new List<Book>
{
    new("Java How to Program", "Deitel & Deitel", 2007),
    new("Patterns of Enterprise Application Architecture", "Martin Fowler", 2002),
    new("Head First Design Patterns", "Elisabeth Freeman", 2004),
    new("Internet & World Wide Web: How to Program", "Deitel & Deitel", 2007)
};


var orderedBooks = sorter.Order(books);

foreach (var book in orderedBooks)
{
    Console.WriteLine(book.Title);
}

