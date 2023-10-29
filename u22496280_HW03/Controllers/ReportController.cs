using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Rotativa;
using u22496280_HW03.Models;

namespace u22496280_HW03.Controllers
{
    public class ReportController : Controller
    {
        private LibraryEntities db = new LibraryEntities();

        public ActionResult Index()
        {
            var topBooks = db.borrows
                .GroupBy(b => b.bookId)
                .Select(g => new TopBorrowedBooks
                {
                    BookId = (int)g.Key,
                    BorrowCount = g.Count()
                })
                .OrderByDescending(b => b.BorrowCount)
                .Take(10)
                .ToList();

            // Retrieve book names for the top books
            foreach (var book in topBooks)
            {
                var bookInfo = db.books.Find(book.BookId);
                if (bookInfo != null)
                {
                    book.BookTitle = bookInfo.bookId.ToString();
                }
            }

            return View(topBooks);
        }
        public ActionResult ManageReports()
        {
            return View();
        }
    }
}