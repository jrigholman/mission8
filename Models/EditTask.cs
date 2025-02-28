using System.ComponentModel.DataAnnotations;
using mission8.Models; // Ensure this is present


namespace mission8.Models
{
    public class EditTask
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task name is required.")]
        public string TaskName { get; set; } = string.Empty; 

        
        public DateTime? DueDate { get; set; } 

        [Required(ErrorMessage = "Quadrant selection is required.")]
        public QuadrantType Quadrant { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; } 

        public Category? Category { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();


        public bool Completed { get; set; }


    }
}
