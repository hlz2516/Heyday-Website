using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Heyday_Website.Models
{
    public class Warp
    {
        /// <summary>
        /// 唯一id
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 提交的坐标X
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// 坐标Y
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// 坐标Z
        /// </summary>
        public double Z { get; set; }
        /// <summary>
        /// 提交者email
        /// </summary>
        public string Submitter { get; set; }
        /// <summary>
        /// 提交原因
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 审核人email
        /// </summary>
        public string Reviewer { get; set; }
    }
}
