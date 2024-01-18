using Microsoft.EntityFrameworkCore;

namespace ShopApp.DataAccess;

public class ShopDbContex : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Client> Clients { get; set; }
}

public record Category(int Id, string Nombre);
public record Product(int Id, string Nombre, string Descripcion, decimal Precio, int CategoryId)
{
    public Category Category { get; set; }
}
public record Client(int Id, string Nombre, string Direccion);



