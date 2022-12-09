using Microsoft.AspNetCore.Mvc.Rendering;
using SimplifiedDMV.Models.DomainModels;

namespace SimplifiedDMV.Models.ViewModels
{
    public class DriverViewModel
    {
        public List<SelectListItem>? StatesSelectList { get; set; }

        public Driver DriverModel { get; set; }
    }
}
