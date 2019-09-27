using System.ComponentModel.DataAnnotations;

namespace Evaluation.Models
{
    public class Grades
    {
        [Key]
        public int NID { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public int Grade { get; set; }
        [Required]
        public int ID { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public Students Students { get; set; }
    }

}