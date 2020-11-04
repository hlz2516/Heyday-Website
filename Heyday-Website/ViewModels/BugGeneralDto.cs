using Heyday_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.ViewModels
{
    public class BugGeneralDto
    {
        public IEnumerable<Bug> Bugs { get; set; }
        public int TotalPage { get; set; }
        public int PageIndex { get; set; }
    }
}
