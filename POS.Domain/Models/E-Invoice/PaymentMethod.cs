using System.ComponentModel.DataAnnotations;

namespace POS.Domain.Models.E_Invoice
{
    public class PaymentMethod : BaseEntity
    {
        public int Id { get; set; }

        // Payment method code
        [Required]
        public string Code { get; set; }

        // English description of the payment method
        [Required]
        public string DescriptionEnglish { get; set; }
    }
}
