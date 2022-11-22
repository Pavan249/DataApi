using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApi.Core.Model
{
    public class StudentData
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNum { get; set; }
        public string Password { get; set; }
        public string ReTypePassword { get; set; }
        public int? LocationId { get; set; }
        public string? Location { get; set; }
    }
}
