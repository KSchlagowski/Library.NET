using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Author")]
        public string Author { get; set; }

        [Required]
        [MaxLength(13)]
        [DisplayName("ISBN")]
        public string ISBN { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Category")]
        public string Category { get; set; }

        [DisplayName("Available")]
        public bool Available { get; set; }
    }
}
