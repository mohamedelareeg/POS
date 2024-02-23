using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Models.E_Invoice
{
    public class TaxSubtype
    {
        public int Id { get; set; }
        public string Code { get; set; }

        [Required]
        public string DescriptionEnglish { get; set; }

        public string DescriptionArabic { get; set; }

        [ForeignKey("TaxType")]
        public string TaxtypeReference { get; set; }

        public TaxType TaxType { get; set; }

        private List<TaxSubtype> GetTaxSubTypes()
        {
            return new List<TaxSubtype>
            {
                new TaxSubtype { Code = "V001", DescriptionEnglish = "Export", DescriptionArabic = "تصدير للخارج", TaxtypeReference = "T1" },
                new TaxSubtype { Code = "V002", DescriptionEnglish = "Export to free areas and other areas", DescriptionArabic = "تصدير مناطق حرة وأخرى", TaxtypeReference = "T1" },
                new TaxSubtype { Code = "V003", DescriptionEnglish = "Exempted good or service", DescriptionArabic = "سلعة أو خدمة معفاة", TaxtypeReference = "T1" },
                new TaxSubtype { Code = "V004", DescriptionEnglish = "A non-taxable good or service", DescriptionArabic = "سلعة أو خدمة غير خاضعة للضريبة", TaxtypeReference = "T1" },
                new TaxSubtype { Code = "V005", DescriptionEnglish = "Exemptions for diplomats, consulates and embassies", DescriptionArabic = "إعفاءات دبلوماسين والقنصليات والسفارات", TaxtypeReference = "T1" },
                new TaxSubtype { Code = "V006", DescriptionEnglish = "Defence and National security Exemptions", DescriptionArabic = "إعفاءات الدفاع والأمن القومى", TaxtypeReference = "T1" },
                new TaxSubtype { Code = "V007", DescriptionEnglish = "Agreements exemptions", DescriptionArabic = "إعفاءات اتفاقيات", TaxtypeReference = "T1" },
                new TaxSubtype { Code = "V008", DescriptionEnglish = "Special Exemptios and other reasons", DescriptionArabic = "إعفاءات خاصة و أخرى", TaxtypeReference = "T1" },
                new TaxSubtype { Code = "V009", DescriptionEnglish = "General Item sales", DescriptionArabic = "سلع عامة", TaxtypeReference = "T1" },
                new TaxSubtype { Code = "V010", DescriptionEnglish = "Other Rates", DescriptionArabic = "نسب ضريبة أخرى", TaxtypeReference = "T1" },
                new TaxSubtype { Code = "Tbl01", DescriptionEnglish = "Table tax (percentage)", DescriptionArabic = "ضريبه الجدول (نسبيه)", TaxtypeReference = "T2" },
                new TaxSubtype { Code = "Tbl02", DescriptionEnglish = "Table tax (Fixed Amount)", DescriptionArabic = "ضريبه الجدول (النوعية)", TaxtypeReference = "T3" },
                new TaxSubtype { Code = "W001", DescriptionEnglish = "Contracting", DescriptionArabic = "المقاولات", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W002", DescriptionEnglish = "Supplies", DescriptionArabic = "التوريدات", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W003", DescriptionEnglish = "Purachases", DescriptionArabic = "المشتريات", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W004", DescriptionEnglish = "Services", DescriptionArabic = "الخدمات", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W005", DescriptionEnglish = "Sumspaid by the cooperative societies for car transportation to their members", DescriptionArabic = "المبالغالتي تدفعها الجميعات التعاونية للنقل بالسيارات لاعضائها", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W006", DescriptionEnglish = "Commissionagency & brokerage", DescriptionArabic = "الوكالةبالعمولة والسمسرة", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W007", DescriptionEnglish = "Discounts& grants & additional exceptional incentives granted by smoke &cement companies", DescriptionArabic = "الخصوماتوالمنح والحوافز الاستثنائية ةالاضافية التي تمنحها شركات الدخان والاسمنت ", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W008", DescriptionEnglish = "Alldiscounts & grants & commissions granted by petroleum &telecommunications & other companies", DescriptionArabic = "جميعالخصومات والمنح والعمولات  التيتمنحها  شركات البترول والاتصالات ...وغيرها من الشركات المخاطبة بنظام الخصم", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W009", DescriptionEnglish = "Supporting export subsidies", DescriptionArabic = "مساندة دعم الصادرات التي يمنحها صندوق تنمية الصادرات ", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W010", DescriptionEnglish = "Professional fees", DescriptionArabic = "اتعاب مهنية", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W011", DescriptionEnglish = "Commission & brokerage _A_57", DescriptionArabic = "العمولة والسمسرة _م_57", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W012", DescriptionEnglish = "Hospitals collecting from doctors", DescriptionArabic = "تحصيل المستشفيات من الاطباء", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W013", DescriptionEnglish = "Royalties", DescriptionArabic = "الاتاوات", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W014", DescriptionEnglish = "Customs clearance", DescriptionArabic = "تخليص جمركي ", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W015", DescriptionEnglish = "Exemption", DescriptionArabic = "أعفاء", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "W016", DescriptionEnglish = "advance payments", DescriptionArabic = "دفعات مقدمه", TaxtypeReference = "T4" },
                new TaxSubtype { Code = "ST01", DescriptionEnglish = "Stamping tax (percentage)", DescriptionArabic = "ضريبه الدمغه (نسبيه)", TaxtypeReference = "T5" },
                new TaxSubtype { Code = "ST02", DescriptionEnglish = "Stamping Tax (amount)", DescriptionArabic = "ضريبه الدمغه (قطعيه بمقدار ثابت)", TaxtypeReference = "T6" },
                new TaxSubtype { Code = "Ent01", DescriptionEnglish = "Entertainment tax (rate)", DescriptionArabic = "ضريبة الملاهى (نسبة)", TaxtypeReference = "T7" },
                new TaxSubtype { Code = "Ent02", DescriptionEnglish = "Entertainment tax (amount)", DescriptionArabic = "ضريبة الملاهى (قطعية)", TaxtypeReference = "T7" },
                new TaxSubtype { Code = "RD01", DescriptionEnglish = "Resource development fee (rate)", DescriptionArabic = "رسم تنميه الموارد (نسبة)", TaxtypeReference = "T8" },
                new TaxSubtype { Code = "RD02", DescriptionEnglish = "Resource development fee (amount)", DescriptionArabic = "رسم تنميه الموارد (قطعية)", TaxtypeReference = "T8" },
                new TaxSubtype { Code = "SC01", DescriptionEnglish = "Service charges (rate)", DescriptionArabic = "رسم خدمة (نسبة)", TaxtypeReference = "T9" },
                new TaxSubtype { Code = "SC02", DescriptionEnglish = "Service charges (amount)", DescriptionArabic = "رسم خدمة (قطعية)", TaxtypeReference = "T9" },
                new TaxSubtype { Code = "Mn01", DescriptionEnglish = "Municipality Fees (rate)", DescriptionArabic = "رسم المحليات (نسبة)", TaxtypeReference = "T10" },
                new TaxSubtype { Code = "Mn02", DescriptionEnglish = "Municipality Fees (amount)", DescriptionArabic = "رسم المحليات (قطعية)", TaxtypeReference = "T10" },
                new TaxSubtype { Code = "MI01", DescriptionEnglish = "Medical insurance fee (rate)", DescriptionArabic = "رسم التامين الصحى (نسبة)", TaxtypeReference = "T11" },
                new TaxSubtype { Code = "MI02", DescriptionEnglish = "Medical insurance fee (amount)", DescriptionArabic = "رسم التامين الصحى (قطعية)", TaxtypeReference = "T11" },
                new TaxSubtype { Code = "OF01", DescriptionEnglish = "Other fees (rate)", DescriptionArabic = "رسوم أخرى (نسبة)", TaxtypeReference = "T12" },
                new TaxSubtype { Code = "OF02", DescriptionEnglish = "Other fees (amount)", DescriptionArabic = "رسوم أخرى (قطعية)", TaxtypeReference = "T12" },
                new TaxSubtype { Code = "ST03", DescriptionEnglish = "Stamping tax (percentage)", DescriptionArabic = "ضريبه الدمغه (نسبيه)", TaxtypeReference = "T13" },
                new TaxSubtype { Code = "ST04", DescriptionEnglish = "Stamping Tax (amount)", DescriptionArabic = "ضريبه الدمغه (قطعيه بمقدار ثابت)", TaxtypeReference = "T14" },
                new TaxSubtype { Code = "Ent03", DescriptionEnglish = "Entertainment tax (rate)", DescriptionArabic = "ضريبة الملاهى (نسبة)", TaxtypeReference = "T15" },
                new TaxSubtype { Code = "Ent04", DescriptionEnglish = "Entertainment tax (amount)", DescriptionArabic = "ضريبة الملاهى (قطعية)", TaxtypeReference = "T15" },
                new TaxSubtype { Code = "RD03", DescriptionEnglish = "Resource development fee (rate)", DescriptionArabic = "رسم تنميه الموارد (نسبة)", TaxtypeReference = "T16" },
                new TaxSubtype { Code = "RD04", DescriptionEnglish = "Resource development fee (amount)", DescriptionArabic = "رسم تنميه الموارد (قطعية)", TaxtypeReference = "T16" },
                new TaxSubtype { Code = "SC03", DescriptionEnglish = "Service charges (rate)", DescriptionArabic = "رسم خدمة (نسبة)", TaxtypeReference = "T17" },
                new TaxSubtype { Code = "SC04", DescriptionEnglish = "Service charges (amount)", DescriptionArabic = "رسم خدمة (قطعية)", TaxtypeReference = "T17" },
                new TaxSubtype { Code = "Mn03", DescriptionEnglish = "Municipality Fees (rate)", DescriptionArabic = "رسم المحليات (نسبة)", TaxtypeReference = "T18" },
                new TaxSubtype { Code = "Mn04", DescriptionEnglish = "Municipality Fees (amount)", DescriptionArabic = "رسم المحليات (قطعية)", TaxtypeReference = "T18" },
                new TaxSubtype { Code = "MI03", DescriptionEnglish = "Medical insurance fee (rate)", DescriptionArabic = "رسم التامين الصحى (نسبة)", TaxtypeReference = "T19" },
                new TaxSubtype { Code = "MI04", DescriptionEnglish = "Medical insurance fee (amount)", DescriptionArabic = "رسم التامين الصحى (قطعية)", TaxtypeReference = "T19" },
                new TaxSubtype { Code = "OF03", DescriptionEnglish = "Other fees (rate)", DescriptionArabic = "رسوم أخرى (نسبة)", TaxtypeReference = "T20" },
                new TaxSubtype { Code = "OF04", DescriptionEnglish = "Other fees (amount)", DescriptionArabic = "رسوم أخرى (قطعية)", TaxtypeReference = "T20" }
            };
        }
    }
}
