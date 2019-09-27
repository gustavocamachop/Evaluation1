using System.Data.Entity;

namespace Evaluation.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }
    }
}