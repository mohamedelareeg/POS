using System.ComponentModel.DataAnnotations;

namespace POS.Domain.Models.E_Invoice
{
    public class NonTaxableType : BaseEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }

        [Required]
        public string DescriptionEnglish { get; set; }

        public string DescriptionArabic { get; set; }

        private List<NonTaxableType> GetNonTaxableTypes()
        {
            return new List<NonTaxableType>
            {
                new NonTaxableType { Code = "T13", DescriptionEnglish = "Stamping tax (percentage)", DescriptionArabic = "ضريبه الدمغه (نسبيه)" },
                new NonTaxableType { Code = "T14", DescriptionEnglish = "Stamping Tax (amount)", DescriptionArabic = "ضريبه الدمغه (قطعيه بمقدار ثابت )" },
                new NonTaxableType { Code = "T15", DescriptionEnglish = "Entertainment tax", DescriptionArabic = "ضريبة الملاهى" },
                new NonTaxableType { Code = "T16", DescriptionEnglish = "Resource development fee", DescriptionArabic = "رسم تنميه الموارد" },
                new NonTaxableType { Code = "T17", DescriptionEnglish = "Table tax (percentage)", DescriptionArabic = "رسم خدمة" },
                new NonTaxableType { Code = "T18", DescriptionEnglish = "Municipality Fees", DescriptionArabic = "رسم المحليات" },
                new NonTaxableType { Code = "T19", DescriptionEnglish = "Medical insurance fee", DescriptionArabic = "رسم التامين الصحى" },
                new NonTaxableType { Code = "T20", DescriptionEnglish = "Other fees", DescriptionArabic = "رسوم أخرى" }
            };
        }
    }
}
