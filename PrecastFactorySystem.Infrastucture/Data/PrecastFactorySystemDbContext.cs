namespace PrecastFactorySystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class PrecastFactorySystemDbContext : IdentityDbContext
    {
        public PrecastFactorySystemDbContext(DbContextOptions<PrecastFactorySystemDbContext> options)
            : base(options)
        {

        }
    }
}
