using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tarea.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DefaultConnection") 
        {

        }

        public System.Data.Entity.DbSet<Tarea.Models.Zeballos> Zeballos { get; set; }
    }
}