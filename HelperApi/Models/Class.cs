using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelperApi.Models
{
    public class Class
    {
        [Key]
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
