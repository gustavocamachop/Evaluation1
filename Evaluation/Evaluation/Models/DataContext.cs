using System.Data.Entity;

namespace Evaluation.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Evaluation.Models.Students> Students { get; set; }

        public System.Data.Entity.DbSet<Evaluation.Models.Grades> Grades { get; set; }
    }
}