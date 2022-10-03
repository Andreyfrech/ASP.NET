using System.ComponentModel.DataAnnotations;


namespace Asp_Rocky.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
   

    }
}
