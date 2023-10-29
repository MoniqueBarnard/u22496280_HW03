using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u22496280_HW03.Models
{
    public class MergedModel
    {
        //public List<books> Book { get; set; } 
        //public List<students> Student { get; set; }
        //public List<string> Bookstatus { get; set; } = new List<string>();
        public IPagedList<students> Student { get; set; }
        public IPagedList<books> Book { get; set; }
        public List<string> Bookstatus { get; set; } = new List<string>();
    }
}
