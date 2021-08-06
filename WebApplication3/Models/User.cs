using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        public string Role { get; set; }

    }
}
