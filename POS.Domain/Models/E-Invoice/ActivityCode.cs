using System.ComponentModel.DataAnnotations;

namespace POS.Domain.Models.E_Invoice
{
    public class ActivityCode : BaseEntity
    {
        public int Id { get; set; }

        // Activity code
        [Required]
        public string Code { get; set; }

        // Description in English
        [Required]
        public string DescriptionEnglish { get; set; }

        // Description in Arabic
        [Required]
        public string DescriptionArabic { get; set; }
    }
}
