using System.ComponentModel.DataAnnotations;

namespace POS.Domain.Models.E_Invoice
{
    public class CurrencyCode : BaseEntity
    {
        public int Id { get; set; }

        // Currency code
        [Required]
        public string Code { get; set; }

        // Currency description in English
        [Required]
        public string DescriptionEnglish { get; set; }
    }
}
