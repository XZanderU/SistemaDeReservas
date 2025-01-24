using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaReservas.Data;
using SistemaReservas.Models;

namespace SistemaDeReservas.Pages_Reservas
{
    public class CreateModel : PageModel
    {
        private readonly SistemaReservas.Data.SistemaReservasContext _context;

        public CreateModel(SistemaReservas.Data.SistemaReservasContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Reserva Reserva { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reserva.Add(Reserva);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
