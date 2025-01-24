using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaReservas.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [DataType(DataType.Time)]
        public string? Hora { get; set; }

        public string? Detalles { get; set; }

        [Range(1, 100)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }
    }
}
