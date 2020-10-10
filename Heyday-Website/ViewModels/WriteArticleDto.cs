using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.ViewModels
{
    public class WriteArticleDto
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SaveTime { get; set; }
    }
}
