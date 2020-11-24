using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.ViewModels
{
    public class BugEditDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SubmitTime { get; set; }
    }
}
