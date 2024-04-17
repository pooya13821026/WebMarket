using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMarke_App.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان اجباریست")]
        [DisplayName("عنوان")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "توضیحات اجباریست")]
        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [Required(ErrorMessage = "قیمت اجباریست")]
        [DisplayName("قیمت")]
        public double Price { get; set; }

        [Required(ErrorMessage = "رنگ اجباریست")]
        [DisplayName("رنگ")]
        public string Color { get; set; }

        [Required]
        [DisplayName("عکس")]
        [ValidateNever]
        public string Img { get; set; }

        [DisplayName("دسته")]
        [ValidateNever]
        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [ValidateNever]
        public Category? Category { get; set; }
    }
}
