using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOTMonthExamMVC.Models
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string UName { get; set; }
        public string UPass { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Status { get; set; }
        public int DepartId { get; set; }
        public string Name { get; set; }
    }
}