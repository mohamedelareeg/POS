using System.ComponentModel.DataAnnotations;

namespace POS.Domain.Models.E_Invoice
{
    public class TaxType : BaseEntity
    {
        public int Id { get; set; }

        // Tax code
        [Required]
        public string Code { get; set; }

        // English description
        [Required]
        public string DescriptionEnglish { get; set; }

        // Arabic description
        public string DescriptionArabic { get; set; }

        public ICollection<TaxSubtype> TaxSubtypes { get; set; }
        private List<TaxType> GetTaxTypes()
        {
            return new List<TaxType>
            {
                new TaxType { Code = "T1", DescriptionEnglish = "Value added tax", DescriptionArabic = "ضريبه القيمه المضافه" },
                new TaxType { Code = "T2", DescriptionEnglish = "Table tax (percentage)", DescriptionArabic = "ضريبه الجدول (نسبيه)" },
                new TaxType { Code = "T3", DescriptionEnglish = "Table tax (Fixed Amount)", DescriptionArabic = "ضريبه الجدول (قطعيه)" },
                new TaxType { Code = "T4", DescriptionEnglish = "Withholding tax (WHT)", DescriptionArabic = "الخصم تحت حساب الضريبه" },
                new TaxType { Code = "T5", DescriptionEnglish = "Stamping tax (percentage)", DescriptionArabic = "ضريبه الدمغه (نسبيه)" },
                new TaxType { Code = "T6", DescriptionEnglish = "Stamping Tax (amount)", DescriptionArabic = "ضريبه الدمغه (قطعيه بمقدار ثابت )" },
                new TaxType { Code = "T7", DescriptionEnglish = "Entertainment tax", DescriptionArabic = "ضريبة الملاهى" },
                new TaxType { Code = "T8", DescriptionEnglish = "Resource development fee", DescriptionArabic = "رسم تنميه الموارد" },
                new TaxType { Code = "T9", DescriptionEnglish = "Table tax (percentage)", DescriptionArabic = "رسم خدمة" },
                new TaxType { Code = "T10", DescriptionEnglish = "Municipality Fees", DescriptionArabic = "رسم المحليات" },
                new TaxType { Code = "T11", DescriptionEnglish = "Medical insurance fee", DescriptionArabic = "رسم التامين الصحى" },
                new TaxType { Code = "T12", DescriptionEnglish = "Other fees", DescriptionArabic = "رسوم أخري" }
            };
        }
    }

}
