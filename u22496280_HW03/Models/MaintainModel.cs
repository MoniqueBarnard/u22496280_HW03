using PagedList;
using System;
using System.Collections.Generic;

namespace u22496280_HW03.Models
{
    public class MaintainModel
    {
        public IPagedList<authors> Authors { get; set; }
        public IPagedList<types> Types { get; set; }
        public IPagedList<borrows> Borrows { get; set; }
        public IEnumerable<books> Books { get; set; }
        public IEnumerable<students> Students { get; set; }
    }
}
