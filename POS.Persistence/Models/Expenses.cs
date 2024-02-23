using POS.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Persistence.Models
{
    public class Expenses : BaseEntity
    {

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged(nameof(Id));
                }
            }
        }

        private ExpenseType _type;
        [Required]
        public ExpenseType Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    NotifyPropertyChanged(nameof(Type));
                }
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    NotifyPropertyChanged(nameof(Description));
                }
            }
        }

        private decimal _amount;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    NotifyPropertyChanged(nameof(Amount));
                }
            }
        }

        private DateTime _date;
        [Required]
        public DateTime Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    NotifyPropertyChanged(nameof(Date));
                }
            }
        }

        private string? _employeeId;
        public string? EmployeeId
        {
            get => _employeeId;
            set
            {
                if (_employeeId != value)
                {
                    _employeeId = value;
                    NotifyPropertyChanged(nameof(EmployeeId));
                }
            }
        }

        private ApplicationUser? _employee;
        public ApplicationUser? Employee
        {
            get => _employee;
            set
            {
                if (_employee != value)
                {
                    _employee = value;
                    NotifyPropertyChanged(nameof(Employee));
                }
            }
        }


    }

    // Enum for expense types
    public enum ExpenseType
    {
        // Common expenses
        Payroll, // دفع المرتبات
        Rent, // الإيجار
        MaintenanceAndRepairs, // صيانة وإصلاحات
        OfficeSupplies, // مستلزمات المكتب
        CleaningSupplies, // مستلزمات التنظيف
        LegalAndProfessionalFees, // الرسوم القانونية والمهنية
        TransportationAndDelivery, // النقل والتوصيل

        // Additional expenses
        InternetAndPhoneBills, // فواتير الإنترنت والهاتف
        ElectricityWaterAndGas, // الكهرباء والمياه والغاز
    }


}
