using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMarke_App.Models
{
    public class FildeValue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("مقدار")]
        public string Value { get; set; }

        [DisplayName("فیلد")]
        public int? FildeId { get; set; }

        [ForeignKey(nameof(FildeId))]
        [ValidateNever]
        public Field? FieldValue { get; set; }

        [DisplayName("محصول")]
        public int? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [ValidateNever]
        public Product? ProductValue { get; set; }
    }
}
