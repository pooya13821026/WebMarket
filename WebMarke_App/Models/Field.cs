using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMarke_App.Models
{
    public class Field
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("نام فیلد")]
        public string Filde { get; set; }

        [DisplayName("نام دسته بندی")]
        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [ValidateNever]
        public Category? CategoryFild { get; set; }
    }
}
