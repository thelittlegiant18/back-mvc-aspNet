using System;
using System.ComponentModel.DataAnnotations;

namespace back_mvc_aspNet.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo 'Code' es requerido.")]
        public string Code { get; set; } = null!;

        [Required(ErrorMessage = "El campo 'Name' es requerido.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "El campo 'Description' es requerido.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "El campo 'Cost' es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El 'Costo' debe ser mayor que 0.")]
        public decimal Cost { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "El campo 'IsActive' es requerido.")]
        public bool IsActive { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
