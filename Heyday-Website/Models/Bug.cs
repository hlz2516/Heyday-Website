using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.Models
{
    public enum BugState
    {
        pending,  //待处理
        reject,    //拒绝处理，通常拒绝处理的情况是提交者提交的bug经管理员审核为非Bug
        processing,  //处理中
        throwback,  //抛回，意为管理员已经处理过这个Bug但未成功并且放弃处理
        delivered,   //已交付
        solved    //已解决
    };

    public class Bug
    {
        [Key]
        public Guid Id { get; set; }
        public string SubmitterEmail { get; set; }
        public string  Title { get; set; }
        public string Content { get; set; }
        public BugState BugState { get; set; }
        public DateTime SubmitTime { get; set; }

    }
}
