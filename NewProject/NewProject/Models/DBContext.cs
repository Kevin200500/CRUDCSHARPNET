using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class DBContext : DbContext
    {
        public DBContext () : base("SqlConnection")
            {
                
            }
        public DbSet<OBJETOS> ObjetosDB { get; set; }
             
    }
}