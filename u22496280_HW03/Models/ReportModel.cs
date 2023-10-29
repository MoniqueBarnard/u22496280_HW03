using System;
using System.Collections.Generic;

namespace u22496280_HW03.Models
{
    public class ReportModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
    }

    public class TopBorrowedBooks
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int BorrowCount { get; set; }
    }
}
