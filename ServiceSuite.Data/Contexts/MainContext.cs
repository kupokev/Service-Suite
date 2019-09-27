using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceSuite.Data.Models;

namespace ServiceSuite.Data.Contexts
{
    public class MainContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public MainContext(DbContextOptions<MainContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Rename Identity Model Tables
            modelBuilder.Entity<IdentityUserClaim<int>>(b =>
            {
                b.ToTable("ApplicationUserClaim");
            });

            modelBuilder.Entity<IdentityUserLogin<int>>(b =>
            {
                b.ToTable("ApplicationUserLogin");
            });

            modelBuilder.Entity<IdentityUserToken<int>>(b =>
            {
                b.ToTable("ApplicationUserToken");
            });

            modelBuilder.Entity<IdentityRoleClaim<int>>(b =>
            {
                b.ToTable("ApplicationRoleClaim");
            });

            modelBuilder.Entity<IdentityUserRole<int>>(b =>
            {
                b.ToTable("ApplicationUserRole");
            });

            // Custom Models
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("ApplicationUser");

                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne()
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.ToTable("ApplicationRole");

                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });

            modelBuilder.Entity<TicketChangeLog>(b =>
            {
                b.HasKey(x => new { x.ChangeKey, x.TicketId });
            });
        }

        // Custom Entities
        public DbSet<ApplicationEnum> ApplicationEnums { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<TicketChangeLog> TicketChangeLogs { get; set; }
    }
}
