using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaReservas.Data;
using SistemaReservas.Models;

namespace SistemaDeReservas.Pages_Reservas
{
    public class DeleteModel : PageModel
    {
        private readonly SistemaReservas.Data.SistemaReservasContext _context;

        public DeleteModel(SistemaReservas.Data.SistemaReservasContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reserva Reserva { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FirstOrDefaultAsync(m => m.Id == id);

            if (reserva is not null)
            {
                Reserva = reserva;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva != null)
            {
                Reserva = reserva;
                _context.Reserva.Remove(Reserva);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
