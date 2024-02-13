using System.ComponentModel;

namespace POS.Domain.Models
{
    public class BaseEntity : INotifyPropertyChanged
    {
        private DateTime? createdDate = DateTime.Now;

        public DateTime? CreatedDate
        {
            get => createdDate;
            set
            {
                if (createdDate != value)
                {
                    createdDate = value ?? DateTime.Now;
                    NotifyPropertyChanged(nameof(CreatedDate));
                }
            }
        }


        private string? createdBy;
        public string? CreatedBy
        {
            get => createdBy;
            set
            {
                if (createdBy != value)
                {
                    createdBy = value;
                    NotifyPropertyChanged(nameof(CreatedBy));
                }
            }
        }

        private DateTime? modifiedDate;
        public DateTime? ModifiedDate
        {
            get => modifiedDate;
            set
            {
                if (modifiedDate != value)
                {
                    modifiedDate = value;
                    NotifyPropertyChanged(nameof(ModifiedDate));
                }
            }
        }

        private string? modifiedBy;
        public string? ModifiedBy
        {
            get => modifiedBy;
            set
            {
                if (modifiedBy != value)
                {
                    modifiedBy = value;
                    NotifyPropertyChanged(nameof(ModifiedBy));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
