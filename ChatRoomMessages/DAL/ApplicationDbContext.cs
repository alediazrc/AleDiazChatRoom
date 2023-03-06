using ChatRoomMessages.ChatObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ChatRoomMessages.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=ChatRoomProject;Initial Catalog=AuthorDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
