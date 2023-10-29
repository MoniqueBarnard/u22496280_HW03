using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using u22496280_HW03.Models;
using PagedList; 

namespace u22496280_HW03.Controllers
{
    public class MaintainController : Controller
    {
        private LibraryEntities db = new LibraryEntities();

        public async Task<ActionResult> Index(int? authorPage, int? typePage, int? borrowPage)
        {
            int pageSize = 10;
            int authorPageNumber = authorPage ?? 1;
            int typePageNumber = typePage ?? 1;
            int borrowPageNumber = borrowPage ?? 1;

            var maintainData = new MaintainModel();

            // Get authors with pagination
            var authorsQuery = db.authors.OrderBy(a => a.authorId);
            var authorCount = await authorsQuery.CountAsync();
            var authors = await authorsQuery
                .Skip((authorPageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            maintainData.Authors = new StaticPagedList<authors>(authors, authorPageNumber, pageSize, authorCount);

            // Get types with pagination
            var typesQuery = db.types.OrderBy(t => t.typeId);
            var typeCount = await typesQuery.CountAsync();
            var types = await typesQuery
                .Skip((typePageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            maintainData.Types = new StaticPagedList<types>(types, typePageNumber, pageSize, typeCount);

            // Get borrows with pagination
            var borrowsQuery = db.borrows.OrderBy(b => b.borrowId);
            var borrowCount = await borrowsQuery.CountAsync();
            var borrows = await borrowsQuery
                .Skip((borrowPageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            maintainData.Borrows = new StaticPagedList<borrows>(borrows, borrowPageNumber, pageSize, borrowCount);

            maintainData.Books = await db.books.ToListAsync();
            maintainData.Students = await db.students.ToListAsync();

            return View(maintainData);
        }
    }
}
