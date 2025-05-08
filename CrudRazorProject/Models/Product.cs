using System;
using System.ComponentModel.DataAnnotations;

namespace CrudRazorProject.Models
{
    /// <summary>
    /// Representa un producto en el sistema.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Identificador único del producto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Descripción detallada del producto.
        /// </summary>
        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        /// <summary>
        /// Precio del producto.
        /// </summary>
        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 10000, ErrorMessage = "El precio debe estar entre 0.01 y 10000")]
        [DataType(DataType.Currency)]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        /// <summary>
        /// Cantidad disponible en almacén.
        /// </summary>
        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, 1000, ErrorMessage = "El stock debe estar entre 0 y 1000")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        /// <summary>
        /// Fecha y hora de creación del registro.
        /// </summary>
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Creación")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}