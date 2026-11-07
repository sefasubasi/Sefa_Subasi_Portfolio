using Microsoft.EntityFrameworkCore;
using Sefa_Subasi_Portfolio.DAL.Entities;

namespace Sefa_Subasi_Portfolio.DAL.Context
{
    public class PortfolioContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Portfolio;integrated security=true;Trusted_Connection=True;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillItem> SkillItems { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTechnology>ProjectTechnologies { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
