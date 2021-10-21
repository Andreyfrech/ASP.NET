using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Rocky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Порядок отображения больше 0")]
        public int DysplayOrder { get; set; }

    }
}
