using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarketMasked.Models
{
    public class Item 
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string? Name { get; set; }
        
        [Required]
        [StringLength(255)]
        public string? Description { get; set; }
        
        [Required]
        public int Price { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Image Name")]
        public string? ImageName { get; set; }

        [NotMapped]
        [Display(Name = "Upload Gambar")]
        public IFormFile? ImageFile { get; set; }
    }
}