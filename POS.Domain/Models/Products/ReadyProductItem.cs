using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Models.Products
{
    public class ReadyProductItem
    {
        public int Id { get; set; }
        public int ReadyProductId { get; set; }

        [ForeignKey("ReadyProductId")]
        public ReadyProduct ReadyProduct { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        private int _quantity;
        private double _price;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
