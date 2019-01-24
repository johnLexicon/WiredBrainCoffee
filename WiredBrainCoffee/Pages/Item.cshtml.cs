using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffee.Models;
using WiredBrainCoffee.Services;

namespace WiredBrainCoffee.Pages
{
    public class ItemModel : PageModel
    {
        public MenuItem Item { get; private set; }

        public void OnGet(int id)
        {
            var service = new MenuService();
            Item = service.GetMenuItems().FirstOrDefault(i => i.Id == id);
        }
    }
}
