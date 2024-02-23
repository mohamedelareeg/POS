using System.ComponentModel.DataAnnotations;

namespace POS.Domain.Models.E_Invoice
{
    public class CountryCode : BaseEntity
    {
        public int Id { get; set; }

        // Country code
        [Required]
        public string Code { get; set; }

        // Country name in English
        [Required]
        public string NameEnglish { get; set; }

        // Country name in Arabic
        [Required]
        public string NameArabic { get; set; }
    }
}
