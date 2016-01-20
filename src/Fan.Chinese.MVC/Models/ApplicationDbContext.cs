using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Fan.Chinese.MVC.Models;

namespace Fan.Chinese.MVC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Topic> Topic { get; set; }
        public DbSet<Vocabulary> Vocabulary { get; set; }

        public DbSet<TopicVocabulary> TopicVocabularies { get; set; } 

        public ApplicationDbContext()
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TopicVocabulary>().HasKey(x=> new {x.TopicId, x.VocabularyId});
            base.OnModelCreating(builder);
          
        }
    }
}
