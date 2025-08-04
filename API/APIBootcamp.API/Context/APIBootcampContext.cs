using APIBootcamp.API.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace APIBootcamp.API.Context
{
    public class APIBootcampContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-OHO9G30\\SQLEXPRESS;initial Catalog=YummyBootcampDB;integrated Security=True;");
            optionsBuilder.UseSqlServer("Data Source=CAN-TOKHAY-MASA\\CANTOKHAY;initial Catalog=YummyBootcampDB;integrated Security=True;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<YummyEvent> YummyEvents { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<About> Abouts { get; set; }
    }
}
