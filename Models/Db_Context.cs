using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;

namespace OnlineQuize.Models
{
    public class Db_Context:DbContext
    {
        public Db_Context():base("conn")
        {


        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Scholar> Scholars{ get; set; }
        public DbSet<Set_Exam> Set_Exams { get; set; }
    }
}