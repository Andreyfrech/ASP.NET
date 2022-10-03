using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Asp_Rocky.Models.ViewModel
{
    public class OrderVM
    {
        public Orders Orders { get; set; }
        public IEnumerable<SelectListItem> OrdersSelectList { get; set; }
    }
}
