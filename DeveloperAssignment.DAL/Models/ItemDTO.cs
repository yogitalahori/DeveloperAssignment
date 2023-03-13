using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperAssignment.DAL.Models
{
    [Table("Item")]
    public class ItemDTO
    {
        [Key]
        [Column("ItemId")]
        public int ItemId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less than 100 characters")]
        public string Name { get; set; }
        [Required]
        public decimal Value { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual CategoryDTO Category { get; set; }
    }
}
