using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperAssignment.DAL.Models
{
    [Table("Category")]
    public  class CategoryDTO
    {
        [Key]
        [Column("CategoryId")]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less than 100 characters")]
        public string Name { get; set; }

    }
}
