using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mission8.Models; // Ensure this is present


namespace mission8.Models
{
    public class TaskAppModel
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task name is required.")]
        [StringLength(100)]
        public string TaskName { get; set; } = string.Empty; 

        public DateTime? DueDate { get; set; } 

        [Required(ErrorMessage = "Please select a quadrant.")]
        [EnumDataType(typeof(QuadrantType))]
        public QuadrantType Quadrant { get; set; }

        
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; } 

        public bool Completed { get; set; }


    }

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; } = string.Empty; 
    }
}
