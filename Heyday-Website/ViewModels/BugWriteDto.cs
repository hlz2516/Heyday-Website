using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.ViewModels
{
    public class BugWriteDto
    {
        [Required(ErrorMessage ="请填写标题")]
        public string Title { get; set; }
        [Required(ErrorMessage ="请填写内容")]
        public string Content { get; set; }
        public DateTime SubmitTime { get; set; }

    }
}
