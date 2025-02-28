using System.ComponentModel.DataAnnotations;
using mission8.Models; // Ensure this is present


namespace mission8.Models
{
    public class EditTask
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string TaskName { get; set; } = string.Empty; 

        [Required]
        public DateTime DueDate { get; set; } 

        [Required]
        public QuadrantType Quadrant { get; set; }

        [Required]
        public int CategoryId { get; set; } 

        public Category? Category { get; set; } 

        public bool Completed { get; set; }
    }
}
