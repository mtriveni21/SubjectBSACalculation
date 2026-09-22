using SubjectBSACalculation.Models;
using Microsoft.EntityFrameworkCore;

namespace SubjectBSACalculation.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Subject> Subjects => Set<Subject>();//in memoery table to hold the subject data
}
