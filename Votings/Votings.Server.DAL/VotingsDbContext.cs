using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Votings.Server.DAL.Models;

namespace Votings.Server.DAL
{
    public class VotingsDbContext : IdentityDbContext<User>
    {
        public VotingsDbContext(DbContextOptions options) : base(options)
        {

        
        }

        public DbSet<Choice> Choices { get; set; }

        public DbSet<Voting> Votings { get; set; }

        public DbSet<Option> Options { get; set; }

        protected override void OnModelCreating(ModelBuilder blder)
        {
            blder.Entity<Voting>()
                .HasMany(i => i.Options)
                .WithOne(i => i.Voting)
                .IsRequired(true)
                .HasForeignKey(i => i.VotingId);

            blder.Entity<Voting>()
                .HasOne(i => i.Author)
                .WithMany(i => i.CreatedVotings)
                .HasForeignKey(i => i.AuthorId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            blder.Entity<Voting>()
                .Property(i => i.StartDate)
                .ValueGeneratedOnAdd();

            blder.Entity<Voting>()
                .Property(i => i.Description)
                .IsRequired(true);

            blder.Entity<Voting>()
                .Property(i => i.StartDate)
                .ValueGeneratedOnAdd();            

            blder.Entity<Option>()
                .Property(i => i.Description)
                .IsRequired(true);

            blder.Entity<UserVotingStatus>()
                .HasKey(i => new { i.UserId, i.VotingId });

            blder.Entity<UserVotingStatus>()
                .HasOne(i => i.User)
                .WithMany(i => i.UserVotings)
                .HasForeignKey(i => i.UserId);

            blder.Entity<UserVotingStatus>()
                .HasOne(i => i.Voting)
                .WithMany(i => i.UserVotings)
                .HasForeignKey(i => i.VotingId);

            blder.Entity<UserVotingStatus>()
                .Property(i => i.UserStatus)
                .HasConversion<int>();

            blder.Entity<Choice>()
                .HasKey(i => new { i.UserId, i.OptionId });

            blder.Entity<Choice>()
                .HasOne(i => i.Option)
                .WithMany(i => i.Choices)
                .HasForeignKey(i => i.OptionId);

            blder.Entity<Choice>()
                .HasOne(i => i.User)
                .WithMany(i => i.Choices)
                .HasForeignKey(i => i.UserId);

            blder.Seed();

            base.OnModelCreating(blder);
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder blder)
        {
        }
    }
}
