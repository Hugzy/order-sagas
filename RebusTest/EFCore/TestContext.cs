using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RebusTest.EFCore.Models.DbModels;

namespace RebusTest.EFCore
{
    public class TestContext : DbContextBase
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Foo> Foos { get; set; }
        public DbSet<PrincipalEntity> PrincipalEntities { get; set; }
        public DbSet<DependantEntity> DependantEntities { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Foo>().HasKey(f => f.Id);

            modelBuilder.Entity<Foo>()
                .HasOne(t => t.Test)
                .WithOne(t => t.Foo)
                .HasForeignKey<Foo>(t => t.TestId);

            modelBuilder.Entity<DependantEntity>()
                .HasOne(x => x.PrincipalEntity)
                .WithOne(x => x.DependantEntities)
                .HasForeignKey<DependantEntity>(x => x.PrincipalEntityId);
        }
    }
}