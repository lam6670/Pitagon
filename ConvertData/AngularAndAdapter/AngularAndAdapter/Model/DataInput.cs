using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAndAdapter.Model
{
    public class DataInput
    {
        [Required]
        public string stringInput { get; set; }
    }
}
