using DeveloperAssignment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DeveloperAssignment.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        private IDbContextTransaction dbContextTransaction;

        public ApplicationDbContext()
        { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<ItemDTO> Items { get; set; }
        public DbSet<CategoryDTO> Categories { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public void BeginTransaction()
        {
            dbContextTransaction = Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Commit();
            }
        }
        public void RollbackTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Rollback();
            }
        }
        public void DisposeTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Dispose();
            }
        }
    }
}
