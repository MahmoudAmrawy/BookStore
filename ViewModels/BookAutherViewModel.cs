using BookStore.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class BookAutherViewModel
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(150, MinimumLength =5)]
        public string Description { get; set; }
        public int AutherId { get; set; }
        public List<Auther> authers { get; set; }

        public IFormFile File { get; set; }

        public string ImgUrl { get; set; }
    }
}
