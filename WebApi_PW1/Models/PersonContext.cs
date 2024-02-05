using Microsoft.EntityFrameworkCore;

namespace WebApi_PW1.Models;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions<PersonContext> options) : base(options)
    {
    }

    public PersonContext()
    {
        //default constructor for entityframework sake
    }

    public DbSet<Person?> PersonItems { get; set; } = null!;
}