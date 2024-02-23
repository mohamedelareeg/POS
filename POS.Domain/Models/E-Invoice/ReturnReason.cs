using System.ComponentModel.DataAnnotations;

namespace POS.Domain.Models.E_Invoice
{
    public class ReturnReason : BaseEntity
    {
        public int Id { get; set; }

        // Reason code
        [Required]
        public string Code { get; set; }

        // English description
        [Required]
        public string DescriptionEnglish { get; set; }

        // Arabic description
        public string DescriptionArabic { get; set; }
    }
}
