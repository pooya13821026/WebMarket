using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMarke_App.Models.ViewModel
{
    public class ProductVM
    {
        public Product? Product { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? CategoryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? ProductList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? FieldList { get; set; }
        public Category? Category { get; set; }
        public Field? Field { get; set; }
        public FildeValue? Value { get; set; }
    }
}
