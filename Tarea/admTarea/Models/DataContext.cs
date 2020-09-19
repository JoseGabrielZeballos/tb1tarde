using System.Data.Entity;

namespace admTarea.Models
{
      
        public class DataContext : DbContext
        {
            public DataContext() : base("DefaultConnection")
            {
            
            

            
            }

        public System.Data.Entity.DbSet<admTarea.Models.Zeballos> Zeballos { get; set; }
    }
    
}