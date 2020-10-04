using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Name { get; set; }
        //方便起见，这里用0表示普通用户，1表示管理员
        public bool? Role { get; set; }

    }
}
