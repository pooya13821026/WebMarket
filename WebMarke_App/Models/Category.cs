//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel;
//using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebMarke_App.Models
//{
//    public class Category
//    {
//        [Key]
//        public int Id { get; set; }

//        [Required(ErrorMessage = "پر کردن این فیلد اجباریست")]
//        [DisplayName("عنوان دسته")]
//        public string Name { get; set; }
//        public DateTime CreateDateTime { get; set; } = DateTime.Now;

//        [ForeignKey(nameof(Category))]
//        [ValidateNever]
//        public Category? Parent { get; set; }
//    }
//}
