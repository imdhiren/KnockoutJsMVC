using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutJsMVC.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Deleted { get; set; }
    }
}