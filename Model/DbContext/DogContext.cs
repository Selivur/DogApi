using DogApi.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DogApi.Model.DbContext
{
    public class DogContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DogContext() { }
        public DogContext(DbContextOptions<DogContext> options) : base(options) { }
        public virtual DbSet<Dog> Dogs { get; set; }
    }
}
