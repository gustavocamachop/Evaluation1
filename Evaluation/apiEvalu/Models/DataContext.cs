using System.Data.Entity;

namespace apiEvalu.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection") 
            { 
            }

        public System.Data.Entity.DbSet<apiEvalu.Models.Students> Students { get; set; }

        public System.Data.Entity.DbSet<apiEvalu.Models.Grades> Grades { get; set; }
    }
}