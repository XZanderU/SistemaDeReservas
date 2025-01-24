using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaReservas.Data;
using SistemaReservas.Models;

namespace SistemaDeReservas.Pages_Reservas
{
    public class IndexModel : PageModel
    {
        private readonly SistemaReservas.Data.SistemaReservasContext _context;

        public IndexModel(SistemaReservas.Data.SistemaReservasContext context)
        {
            _context = context;
        }

        public IList<Reserva> Reserva { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; } // Cadena de búsqueda por nombre o correo

        public SelectList? Detalles { get; set; } // Lista desplegable para filtrar por detalles específicos de la reserva

        [BindProperty(SupportsGet = true)]
        public string? ReservaDetalle { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? SearchDate { get; set; } // Fecha de reserva seleccionada

        // Detalle de reserva seleccionado

        public async Task OnGetAsync()
        {
            var reservas = from r in _context.Reserva select r;

            // Filtrar por cadena de búsqueda
            if (!string.IsNullOrEmpty(SearchString))
            {
                reservas = reservas.Where(r =>
                    r.Nombre.Contains(SearchString) || r.Email.Contains(SearchString)
                );
            }

            // Asignar la lista de resultados a la propiedad Reserva
            Reserva = await reservas.ToListAsync();
        }
    }
}
