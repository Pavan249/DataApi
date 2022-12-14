// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataApi.Entity.Models
{
    public partial class PhoneDetail
    {
        public PhoneDetail()
        {
            StudentDetails = new HashSet<StudentDetails>();
        }

        [Key]
        public int LocationId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Location { get; set; }
        public bool Is_deleted { get; set; }

        [InverseProperty("Location")]
        public virtual ICollection<StudentDetails> StudentDetails { get; set; }
    }
}