using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PostLand.Domain;
using System.Data;
using Microsoft.Data.SqlClient;
namespace PostLand.Presistence
{
    public class PostDbContext :DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public PostDbContext(DbContextOptions<PostDbContext> options, IConfiguration configuration)
         : base(options)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("PostConnectionString");
        }
   
        public DbSet<Post> Posts { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categoryGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var postGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = categoryGuid,
                Name = "Technology"
            });

            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = postGuid,
                Title = "Introduction to CQRS and Mediator Patterns",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat",
                ImageUrl = "https://api.khalidessaadani.com/uploads/articles_bg.jpg",
                CategoryId = categoryGuid
            });

        }

        public IDbConnection CreateConnection()
           => new SqlConnection(_connectionString);

    }
}
