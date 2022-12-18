using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ToDo.Service.DataModel
{
    public class ToDoDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ToDoDbContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }

        /// <inheritdoc />
        public DbSet<Entities.Task> Task { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = _configuration["ConnectionStrings:Default"];
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
