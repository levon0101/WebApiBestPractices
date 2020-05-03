using System;
using Microsoft.EntityFrameworkCore;
using WebApiBestPractices.Entities.Model;

namespace WebApiBestPractices.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Owner> Owners { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c01"),
                    OwnerId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade01"),
                    AccountType = "Tirakal",
                    DateCreated = new DateTime(2020,8,2)

                }
            );

            modelBuilder.Entity<Owner>().HasData(
                new Owner {Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade01"),
                    Name = "Levon Mardanyan",
                    Address = "Earth", 
                    DateOfBirth = new DateTime(1992, 1, 1), },
                new Owner
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade02"),
                    Name = "Grigori Mardanyan",
                    Address = "Earth",
                    DateOfBirth = new DateTime(1956, 1, 1),
                }



            );


            base.OnModelCreating(modelBuilder);

        }
    }
}
