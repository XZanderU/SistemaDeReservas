using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaReservas.Models;

namespace SistemaReservas.Data
{
    public class SistemaReservasContext : DbContext
    {
        public SistemaReservasContext(DbContextOptions<SistemaReservasContext> options)
            : base(options) { }

        public DbSet<SistemaReservas.Models.Reserva> Reserva { get; set; } = default!;
    }
}
