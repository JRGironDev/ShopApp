using Microsoft.EntityFrameworkCore;
using ShopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess;

public class ShopOutDbContext : DbContext
{
    public DbSet<CompraItem> Compras { get; set; }

    private readonly IDatabaseRutaService _databaseRuta;

    public ShopOutDbContext(IDatabaseRutaService databaseRuta)
    {
        _databaseRuta = databaseRuta;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = $"Filename={_databaseRuta.Get("shopdatabase.db")}";
        optionsBuilder.UseSqlite(connectionString);
    }
}

public record CompraItem(int ClientId, int ProductId, int Cantidad, decimal Precio)
{
    public int Id { get; set; }
}


