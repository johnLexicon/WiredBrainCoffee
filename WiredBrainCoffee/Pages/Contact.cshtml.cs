using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffee.Models;
using WiredBrainCoffee.Services;

namespace WiredBrainCoffee.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; }

        public string Message { get; private set; }

        public ContactModel(IEmailService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _service.SendEmail(Contact);
                return new RedirectToPageResult("Confirmation", "Contact");
            }
            return Page();
        }

        /// <summary>
        /// For the second form in the contact page. The email address form in the right column.
        /// </summary>
        /// <param name="address">the value from the input field.</param>
        public IActionResult OnPostSubscribe(string address)
        {
            _service.SendEmail(address);
            return new RedirectToPageResult("Confirmation", "Subscribe");
        }

        private IEmailService _service;
    }
}
