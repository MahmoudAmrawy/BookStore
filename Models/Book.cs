using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "IdBook")]
        public int IdBook { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "ImgUrl")]
        public string ImgUrl { get; set; }
        public Auther Auther { get; set; }
    }
}
