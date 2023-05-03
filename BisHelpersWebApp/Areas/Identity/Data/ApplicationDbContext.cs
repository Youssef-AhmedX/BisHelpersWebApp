using BisHelpersWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BisHelpersWebApp.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<Student>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Reports> Reports { get; set; }
    public DbSet<WeeklyUpdates> WeeklyUpdates { get; set; }
    public DbSet<SQsupport> SQsupport { get; set; }
    public DbSet<AssignmentSupport> AssignmentSupport { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationStudentEntityConfiguration());
    }
}

internal class ApplicationStudentEntityConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        
    }
}