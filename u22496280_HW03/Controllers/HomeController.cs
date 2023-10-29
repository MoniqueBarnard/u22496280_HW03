using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using u22496280_HW03.Models;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace u22496280_HW03.Controllers
{
    public class HomeController : Controller
    {
        private LibraryEntities db = new LibraryEntities();

        public async Task<ActionResult> Index(int? studentPage, int? bookPage)
        {
            int pageSize = 10;
            int studentPageNumber = studentPage ?? 1; // Default to page 1 if no page is specified
            int bookPageNumber = bookPage ?? 1; // Default to page 1 if no page is specified

            var mergedData = new MergedModel();

            // Get students with pagination
            var studentsQuery = db.students.OrderBy(s => s.studentId);
            var studentCount = await studentsQuery.CountAsync();
            var students = await studentsQuery
                .Skip((studentPageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            mergedData.Student = new StaticPagedList<students>(students, studentPageNumber, pageSize, studentCount);

            // Get books with pagination
            var booksQuery = db.books.OrderBy(b => b.bookId);
            var bookCount = await booksQuery.CountAsync();
            var books = await booksQuery
                .Skip((bookPageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            mergedData.Book = new StaticPagedList<books>(books, bookPageNumber, pageSize, bookCount);

            foreach (var book in books)
            {
                var borrowRecord = await db.borrows.FirstOrDefaultAsync(b => b.bookId == book.bookId && b.broughtDate == null);
                if (borrowRecord != null)
                {
                    mergedData.Bookstatus.Add("Out");
                }
                else
                {
                    mergedData.Bookstatus.Add("Available");
                }
            }

            return View(mergedData);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
