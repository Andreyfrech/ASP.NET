using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp_Rocky.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OrderNo { get; set; }   

        public DateTime DateOrder { get; set; }

        public string Products { get; set; }
        [Display(Name = "Status Type")]
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
    }
}
