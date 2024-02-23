namespace POS.Domain.Models.Products
{
    public class ReadyProduct : BaseEntity
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }
        public int ProductCount => Products?.Count ?? 0;
        public ICollection<ReadyProductItem>? Products { get; set; }

        public ICollection<SaleProduct>? SaleProducts { get; set; }

    }
}
