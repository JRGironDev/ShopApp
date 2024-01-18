using Microsoft.EntityFrameworkCore;

namespace ShopApp.DataAccess;

public class ShopDbContex : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ShopComputer");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category(1, "Electronicos"),
            new Category(2, "Computadoras"),
            new Category(3, "Teléfonos Moviles"),
            new Category(4, "Dispositivos de Escritorio"),
            new Category(5, "Micrófonos y Audio"),
            new Category(6, "Artefactos del Hogar"),
            new Category(7, "Juguetes y Juegos")
         );

        modelBuilder.Entity<Product>().HasData(
            new Product(1, "Radio Digital", "Es un radio de banda ancha", 100, 1),
            new Product(2, "Reloj electrónico Honda", "Reloj de muy buena calidad", 50, 1),
            new Product(3, "Laptop HP", "Laptor para escritorio y manejo de effice", 900, 2),
            new Product(4, "Laptop Acer", "Laptor para escritorio y manejo de effice", 1200, 2),
            new Product(5, "Laptop Apple", "Laptor para escritorio y manejo de effice", 1500, 2),
            new Product(6, "Laptop Galaxy 2", "Laptor para escritorio y manejo de effice", 1800, 3),
            new Product(7, "Iphone 4", "Apple dispositivo de gran capacidad", 1500, 3)
        );
    }

    public record Category(int Id, string Mombre);

    public record Product(int Id, string Nombre, string Descripcion, decimal Precio, int CategoryId)
    {
        public Category Category { get; set; }
    }

    public record Client(int Id, string Nombre, string Direccion);
}

