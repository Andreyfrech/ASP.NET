using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Rocky.Models
{
    public class Reservation
    {
        
        public int Id { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        [Display(Name = "Взрослые")]
        public int Adults  { get; set; }
        public int Children { get; set; }
    }
}
