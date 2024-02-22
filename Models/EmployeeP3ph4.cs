using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p3p4.Models
{
    [Table("EmployeeP3Ph4")]
    public partial class EmployeeP3ph4
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public double? Salary { get; set; }
    }
}
