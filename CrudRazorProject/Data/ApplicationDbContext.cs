using Microsoft.EntityFrameworkCore;
using CrudRazorProject.Models;

namespace CrudRazorProject.Data
{
    /// <summary>
    /// Contexto de base de datos para la aplicación.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor que configura el contexto con las opciones proporcionadas.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Colección de productos en la base de datos.
        /// </summary>
        public DbSet<Product> Products { get; set; } = default!;

        /// <summary>
        /// Configura el modelo de datos utilizando Fluent API.
        /// </summary>
        /// <param name="modelBuilder">Constructor de modelos para configurar el esquema.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para la entidad Product
            modelBuilder.Entity<Product>(entity =>
            {
                // Establece la precisión del campo Price
                entity.Property(p => p.Price)
                    .HasPrecision(18, 2);

                // Configura por defecto la fecha de creación
                entity.Property(p => p.CreatedAt)
                    .HasDefaultValueSql("GETDATE()");
            });

            // Datos iniciales
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop HP",
                    Description = "Laptop HP Pavilion 15 con procesador Intel i5 de última generación",
                    Price = 999.99m,
                    Stock = 20,
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    Id = 2,
                    Name = "Monitor Dell",
                    Description = "Monitor profesional de 27 pulgadas con resolución 4K",
                    Price = 449.99m,
                    Stock = 35,
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    Id = 3,
                    Name = "Teclado Logitech",
                    Description = "Teclado mecánico con retroiluminación RGB",
                    Price = 129.99m,
                    Stock = 50,
                    CreatedAt = DateTime.Now
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}