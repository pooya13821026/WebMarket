using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMarke_App.Models.ViewModel
{
    public class ValueShowcase
    {
        public FildeValue? Value { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? ProductListValue { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? FieldList { get; set; }
    }
}
