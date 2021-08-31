using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RebusTest.EFCore.Models;

namespace RebusTest.EFCore
{
    public abstract class DbContextBase : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Persist Security Info=False;User ID=sa;Password=Xsw2zaq1;Initial Catalog=master;Data Source=localhost");
            
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();

            var markedAsCreated = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);

            foreach (var item in markedAsCreated)
            {
                if (item.Entity is ModelBase entity)
                {
                    // Only update the UpdatedAt flag - only this will get sent to the Db
                    entity.CreatedAt = DateTime.UtcNow;
                }
            }

            var markedAsUpdated = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            foreach (var item in markedAsUpdated)
            {
                if (item.Entity is ModelBase entity)
                {
                    // Only update the UpdatedAt flag - only this will get sent to the Db
                    entity.UpdatedAt = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}