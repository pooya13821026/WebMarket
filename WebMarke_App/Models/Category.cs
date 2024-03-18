using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMarke_App.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("عنوان دسته")]
        public string Name { get; set; }

        [DisplayName("عنوان دسته")]
        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        [ValidateNever]
        public Category? Parent { get; set; }
    }
}
