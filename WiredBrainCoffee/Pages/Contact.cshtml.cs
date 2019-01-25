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

        public void OnPost()
        {
            _service.SendEmail(Contact);
            Message = "Email has been sent!";
        }

        private IEmailService _service;
    }
}
