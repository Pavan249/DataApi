using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApi.Core.Model
{
    public partial class Phone
    {
        public int LocationId { get; set; }

        public string Location { get; set; }
        public bool? Is_deleted { get; set; }
    }
    
}
