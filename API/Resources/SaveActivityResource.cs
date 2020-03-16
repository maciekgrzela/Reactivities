using System;
using System.ComponentModel.DataAnnotations;

namespace API.Resources
{
    public class SaveActivityResource
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Category { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        [MaxLength(100)]
        public string Venue { get; set; }
    }
}