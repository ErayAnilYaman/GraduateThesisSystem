using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Db
{
    public class ThesesContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=GraduateThesesDBOS;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Author> AUTHORS { get; set; }
        public DbSet<CoSupervisorThesis> COSUPERVISORTHESIS { get; set; }
        public DbSet<Institute> INSTITUTES { get; set; }
        public DbSet<Keyword> KEYWORDS{ get; set; }
        public DbSet<SubjectTopic> SUBJECTTOPICS{ get; set; }
        public DbSet<Supervisor> SUPERVISORS{ get; set; }
        public DbSet<Thesis> THESES{ get; set; }
        public DbSet<ThesisKeyword> THESISKEYWORD { get; set; }
        public DbSet<ThesisSubjectTopic> THESISSUBJECTTOPIC{ get; set; }
        public DbSet<University> UNIVERSITIES{ get; set; }

    }
}
