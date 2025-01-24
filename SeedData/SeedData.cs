using Microsoft.EntityFrameworkCore;
using SistemaReservas.Data;

namespace SistemaReservas.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (
            var context = new SistemaReservasContext(
                serviceProvider.GetRequiredService<DbContextOptions<SistemaReservasContext>>()
            )
        )
        {
            if (context == null || context.Reserva == null)
            {
                throw new ArgumentNullException("Null SistemaReservasContext");
            }

            // Verificar si ya hay reservas en la base de datos.
            if (context.Reserva.Any())
            {
                return; // La base de datos ya contiene datos iniciales.
            }

            // Datos iniciales de reservas.
            context.Reserva.AddRange(
                new Reserva
                {
                    Nombre = "Juan Pérez",
                    Email = "juan.perez@example.com",
                    Fecha = DateTime.Parse("2025-01-25"),
                    Hora = "10:00 AM",
                    Detalles = "Reserva para sala de juntas, 2 horas.",
                    Precio = 50.00M, // Precio en formato decimal
                },
                new Reserva
                {
                    Nombre = "Ana López",
                    Email = "ana.lopez@example.com",
                    Fecha = DateTime.Parse("2025-01-26"),
                    Hora = "02:00 PM",
                    Detalles = "Reserva para espacio coworking, 4 horas.",
                    Precio = 80.00M,
                },
                new Reserva
                {
                    Nombre = "Carlos Martínez",
                    Email = "carlos.martinez@example.com",
                    Fecha = DateTime.Parse("2025-01-27"),
                    Hora = "09:00 AM",
                    Detalles = "Reserva para evento corporativo.",
                    Precio = 150.00M,
                },
                new Reserva
                {
                    Nombre = "Luisa Gómez",
                    Email = "luisa.gomez@example.com",
                    Fecha = DateTime.Parse("2025-01-28"),
                    Hora = "01:00 PM",
                    Detalles = "Reserva para oficina privada, 3 horas.",
                    Precio = 70.00M,
                }
            );

            context.SaveChanges();
        }
    }
}
