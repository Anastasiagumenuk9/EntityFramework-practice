using ConsoleApp6.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        
        public static void GetBooksByAgeRestriction(BookShopDB context, string command)
        {

            var sb = new StringBuilder();

            var books = context.Books.Where(p => p.AgeRestriction == (AgeRestriction)0).OrderBy(p => p.Title).ToList();
            var books1 = context.Books.Where(p => p.AgeRestriction == (AgeRestriction)1).OrderBy(p=>p.Title).ToList();
            var books2 = context.Books.Where(p => p.AgeRestriction == (AgeRestriction)2).OrderBy(p => p.Title).ToList();

            if (command.Equals(Convert.ToString((AgeRestriction)0)))
            {
                foreach (var b in books)
                {
                    Console.WriteLine(b.Title);

                }
            }

            else if (command == Convert.ToString((AgeRestriction)1))
            {
                foreach (var b in books1)
                {
                    Console.WriteLine(b.Title);

                }
            }
            else if (command == Convert.ToString((AgeRestriction)2))
            {
                foreach (var b in books2)
                {
                    Console.WriteLine(b.Title);

                }
            }





        }

        public static string GetGoldenBooks(BookShopDB context)
        {
            var sb = new StringBuilder();

            var goldenBookTitles = context.Books
                .Where(b => b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            goldenBookTitles.ForEach(b => sb.AppendLine(b));

            return sb.ToString().Trim();
        }


        public static string GetBooksByPrice(BookShopDB context)
        {
            var sb = new StringBuilder();

            var booksWithPrice = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            booksWithPrice.ForEach(b => sb.AppendLine($"{b.Title} - {b.Price:f2}"));

            return sb.ToString().Trim();
        }

        public static string GetBooksNotRealeasedIn(BookShopDB context, int year)
        {
            var sb = new StringBuilder();

            var bookTitles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            bookTitles.ForEach(b => sb.AppendLine(b));

            return sb.ToString().Trim();
        }

        public static string GetBooksByCategory(BookShopDB context, string input)
        {
            var sb = new StringBuilder();

            var categoryNames = input.ToLower().Split();

            var bookTitles = context.Books
                .Where(b => b.BookCategories.Any(c => categoryNames.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            bookTitles.ForEach(b => sb.AppendLine(b));

            return sb.ToString().Trim();
        }

        public static string GetBooksReleasedBefore(BookShopDB context, string date)
        {
            var sb = new StringBuilder();
            var format = "dd-MM-yyyy";
            //var currentDate = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
            var currentDat = Convert.ToDateTime(date);
            var currentDate = currentDat.ToString("HH:mm:ss",  CultureInfo.InvariantCulture);
            var d = Convert.ToDateTime(currentDate);
            var books = context.Books
                .Where(b => b.ReleaseDate != null && b.ReleaseDate.Value < d)
                .OrderByDescending(b => b.ReleaseDate.Value)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            books.ForEach(b => sb.AppendLine($"{b.Title} - {b.EditionType} - {b.Price:F2}"));
            return sb.ToString().Trim();
        }


        public static string GetAuthorNamesEndingIn(BookShopDB context, string input)
        {
            var sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " "+ a.LastName
                })
              .ToList();

            authors.ForEach(a => sb.AppendLine(a.FullName));

            return sb.ToString().Trim();
        }

        public static string GetBookTitlesContaining(BookShopDB context, string input)
        {
            var sb = new StringBuilder();

            var titles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new
                {
                    Title = b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            titles.ForEach(b => sb.AppendLine(b.Title));

            return sb.ToString().Trim();
        }

        public static string GetBooksByAuthor(BookShopDB context, string input)
        {
            var sb = new StringBuilder();

            var titles = context.Books
                .OrderBy(b => b.BookId)
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    Title = b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                })
                .ToList();

            titles.ForEach(b => sb.AppendLine($"{b.Title} ({b.AuthorName})"));

            return sb.ToString().Trim();
        }

        public static int CountBooks(BookShopDB context, int lengthCheck)
        {
            var bookCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return bookCount;
        }

        public static string CountCopiesByAuthor(BookShopDB context)
        {
            var sb = new StringBuilder();

            var authorBooks = context
                .Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " +  a.LastName,
                    BookCopies = a.Books.Sum(b => b.Copies)

                })
                .OrderByDescending(a => a.BookCopies)
                .ToList();

            authorBooks.ForEach(a => sb.AppendLine($"{a.AuthorName} - {a.BookCopies}"));

            return sb.ToString().Trim();
        }


        public static string GetTotalProfitByCategory(BookShopDB context)
        {
            var sb = new StringBuilder();

            var categoryProfits = context
                .Categories
                .Select(c => new
                {
                    Name = c.Name,
                    Profit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToList();

            categoryProfits.ForEach(c => sb.AppendLine($"{c.Name} {c.Profit}"));

            return sb.ToString().Trim();
        }


        public static string GetMostRecentBooks(BookShopDB context)
        {
            var sb = new StringBuilder();

            var categories = context
                .Categories
                .OrderBy(c => c.CategoryBooks.Count)
                .ThenBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Book = c.CategoryBooks
                    .OrderByDescending(b => b.Book.ReleaseDate)
                    .Take(3)
                    .Select(b => new
                    {
                        BookTitle = b.Book.Title,
                        ReleaseYear = b.Book.ReleaseDate.Value.Year
                    })
                    .ToList()
                })
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");
                category.Book.ForEach(b => sb.AppendLine($"{b.BookTitle} ({b.ReleaseYear})"));
            }

            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopDB context)
        {
            var currentBooks = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            currentBooks.ForEach(b => b.Price = b.Price + 5);
            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopDB context)
        {
            var currentBooks = context
                .Books
                .Where(b => b.Copies < 5)
                .ToList();

            context.Books.RemoveRange(currentBooks);
            context.SaveChanges();
            return currentBooks.Count;
        }

        static void Main(string[] args)
        {

            using (BookShopDB context = new BookShopDB())
            {
                int n;
                Console.Write("Input n : ");
                n = Convert.ToInt32(Console.ReadLine());

                switch (n)
                {
                    case 1 :
                        {
                            string com = "Teen";
                            GetBooksByAgeRestriction(context, com);
                            break;
                        }
                    case 2:
                        {
                            Console.Write(GetGoldenBooks(context));
                            break;
                        }
                    case 3:
                        {
                            Console.Write(GetBooksByPrice(context));
                            break;
                        }
                    case 4:
                        {
                            Console.Write(GetBooksNotRealeasedIn(context, 2017));
                            break;
                        }
                    case 5:
                        {
                            Console.Write(GetBooksByCategory(context , "Фантастика Художня"));
                            break;
                        }
                    case 6:
                        {
                            Console.Write(GetBooksReleasedBefore( context, "2017-10-04"));
                            break;
                        }
                    case 7:
                        {
                            Console.Write(GetAuthorNamesEndingIn(context, "р"));
                            break;
                        }
                    case 8:
                        {
                            Console.Write(GetBookTitlesContaining(context, "ра"));
                            break;
                        }
                    case 9:
                        {
                            Console.Write(GetBooksByAuthor(context, "Д"));
                            break;
                        }
                    case 10:
                        {
                            Console.Write(CountBooks(context, 17));
                            break;
                        }
                    case 11:
                        {
                            Console.Write(CountCopiesByAuthor(context));
                            break;
                        }
                    case 12:
                        {
                            Console.Write(GetTotalProfitByCategory(context));
                            break;
                        }
                    case 13:
                        {
                            Console.Write(GetMostRecentBooks(context));
                            break;
                        }
                    case 14:
                        {
                          IncreasePrices(context);
                            break;
                        }
                    case 15:
                        {
                            Console.Write(RemoveBooks(context));
                            break;
                        }
                    default: 
                        {

                            Console.WriteLine("Input Error!");
                            break;
                        }
                }
                
               
            }

            Console.ReadKey();
        }
    }
}
