using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;

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
            modelBuilder.Entity<Entities.Task>()
            .ToTable("Tasks")
            .HasKey(t => t.Id);
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
