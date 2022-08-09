using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("Authers")]
    public class Auther
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "IdAuther")]
        public int IdAuther { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "NameAuther")]
        public string NameAuther { get; set; }
    }
}
