using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asc_college_operations.Abstractions
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
