using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.Models
{
    public class Solution
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BugId { get; set; }
        public string Context { get; set; }
        public string Solver { get; set; }
        [ForeignKey("BugId")]
        public Bug Bug { get; set; }
    }
}
