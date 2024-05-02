using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMarke_App.Models.ViewModel
{
    public class CategoryShowcase
    {
        public Category? Category { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? CategoryList { get; set; }

        [ValidateNever]
        public List<Category> Categoryy { get; set; } = [];
    }
}
