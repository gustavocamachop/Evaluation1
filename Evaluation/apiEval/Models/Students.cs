using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apiEval.Models
{
    public class Students
    {
        [Key]
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public string Birthday { get; set; }
    [Required]
    public virtual ICollection<Grades> Grades { get; set; }
}

