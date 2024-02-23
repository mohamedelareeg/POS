using Microsoft.EntityFrameworkCore;
using POS.Domain.Models;
using POS.Domain.Models.Products;
using POS.ViewModels.Base;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class POSViewModel : BaseProductsViewModel
    {
        private DateTime _purchaseDate = DateTime.Now;
        private DateTime _paymentDate = DateTime.Now;
        public DateTime PurchaseDate
        {
            get { return _purchaseDate; }
            set
            {
                if (_purchaseDate != value)
                {
                    _purchaseDate = value;
                    OnPropertyChanged(nameof(PurchaseDate));
                }
            }
        }

        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set
            {
                if (_paymentDate != value)
                {
                    _paymentDate = value;
                    OnPropertyChanged(nameof(PaymentDate));
                }
            }
        }
        public string GetNextInvoiceNumber(bool filterByCurrentDay)
        {
            string invoiceNumberPrefix = "INV-"; // Prefix for the invoice number

            // Get the highest invoice number
            string highestInvoiceNumber = _dbContext.Invoices
                .Where(i => !filterByCurrentDay || EF.Functions.Like(i.Number, $"{invoiceNumberPrefix}%")) // Filter by current day if required
                .Select(i => i.Number)
                .OrderByDescending(n => n)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(highestInvoiceNumber)) // If no invoice numbers found
            {
                return $"{invoiceNumberPrefix}001"; // Start with 001 for the current day
            }
            else
            {
                // Extract the numeric part of the highest invoice number
                string numericPart = highestInvoiceNumber.Substring(invoiceNumberPrefix.Length);
                int nextNumber = int.Parse(numericPart) + 1; // Increment the number

                return $"{invoiceNumberPrefix}{nextNumber:D3}"; // Format the next invoice number
            }
        }

        private string _billNumber;
        public string BillNumber
        {
            get { return _billNumber; }
            set
            {
                if (_billNumber != value)
                {
                    _billNumber = value;
                    OnPropertyChanged(nameof(BillNumber));
                }
            }
        }
        private ObservableCollection<SaleProduct> _cartItemsList;

        public ObservableCollection<SaleProduct> CartItemsList
        {
            get { return _cartItemsList; }
            set
            {
                if (_cartItemsList != value)
                {
                    _cartItemsList = value;
                    OnPropertyChanged(nameof(CartItemsList));

                }
            }
        }

        private SaleProduct _selectedCartItem;

        public SaleProduct SelectedCartItem
        {
            get { return _selectedCartItem; }
            set
            {
                if (_selectedCartItem != value)
                {
                    _selectedCartItem = value;
                    OnPropertyChanged(nameof(SelectedCartItem));
                    SetSelectedItemValues(SelectedCartItem);
                }
            }
        }
        private void RecalculateTotalAmount()
        {
            TotalQuantity = CartItemsList.Sum(item => item.Quantity);
            SubTotal = CartItemsList.Sum(item => item.SalePrice * item.Quantity);
            TotalAmount = SubTotal + ((Tax / 100) * SubTotal) - Discount;
            // Earnings = (double)(TotalAmount - CartItemsList.Sum(item => item.Product.GetLastPurchasePrice() * item.Quantity));
        }
        public void SetSelectedItemValues(SaleProduct selectedCartItem)
        {
            if (selectedCartItem != null)
            {
                SelectedProduct = ProductList.FirstOrDefault(product => product.Id == selectedCartItem.ProductId && selectedCartItem.WarehouseId == SelectedWarehouse.Id);
                //SelectedCategory = CategoryList.FirstOrDefault(category => category.Name == selectedCartItem.Category);

                ItemName = selectedCartItem.Product.Name;
                ItemBarcode = selectedCartItem.Product.Barcode;
                Quantity = selectedCartItem.Quantity;
                SalePrice = selectedCartItem.SalePrice;
                Notes = selectedCartItem.Details;
                ProductWarehouse = selectedCartItem.Warehouse;
                SelectedReadyProduct = selectedCartItem.ReadyProduct;
            }
        }
        public ICommand AddCommand { get; }
        public ICommand AcceptCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand PaymentCommand { get; }
        public ICommand DeliveryCommand { get; }
        public ICommand SuspendBillCommand { get; }
        public ICommand CancelBillCommand { get; }
        public POSViewModel() : base()
        {
            BillNumber = GetNextInvoiceNumber(false);
            CartItemsList = new ObservableCollection<SaleProduct>();
            AddCommand = new RelayCommand(ExecuteAddCommand);
            AcceptCommand = new RelayCommand(ExecuteAcceptCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
            DeleteCommand = new RelayCommand(ExecuteDeleteCommand);

            PaymentCommand = new RelayCommand(ExecutePayment);
            DeliveryCommand = new RelayCommand(ExecuteDelivery);
            SuspendBillCommand = new RelayCommand(ExecuteSuspendBillCommand);
            CancelBillCommand = new RelayCommand(ExecuteCancelBill);
            #region CartListEvents
            CartList_CurrentCellChangedCommand = new RelayCommand(ExecuteCartList_CurrentCellChangedCommand);
            CartList_SelectionChangedCommand = new RelayCommand(ExecuteCartList_SelectionChangedCommand);
            CartList_MouseDownCommand = new RelayCommand(ExecuteCartList_MouseDownCommand);
            CartList_MouseDoubleClickCommand = new RelayCommand(ExecuteCartList_MouseDoubleClickCommand);
            CartList_DataContextChangedCommand = new RelayCommand(ExecuteCartList_DataContextChangedCommand);
            CartList_SelectedCellsChangedCommand = new RelayCommand(ExecuteCartList_SelectedCellsChangedCommand);
            #endregion
            PropertyChanged += OnInvoiceDetailsChanged;
            IsSale = true;
        }
        private void OnInvoiceDetailsChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Tax) || e.PropertyName == nameof(Discount))
            {
                RecalculateTotalAmount();
            }
        }
        private void ExecuteAddCommand(object parameter)
        {
            if (SelectedProduct != null)
            {
                Quantity++;
            }
        }

        private void ExecuteAcceptCommand(object parameter)
        {
            if (SelectedProduct != null && Quantity > 0 && SalePrice > 0)
            {
                // Check if the item already exists in the cart
                SaleProduct existingCartItem = CartItemsList.FirstOrDefault(item => item.ProductId == SelectedProduct.Id && item.WarehouseId == SelectedWarehouse.Id);

                if (existingCartItem != null)
                {
                    if (SelectedProduct.MinStock > 0)
                    {

                        double availableQuantity = (double)(SelectedProduct.MinStock - existingCartItem.Quantity);
                        if (availableQuantity > 0 && Quantity < availableQuantity)
                        {
                            MessageBoxResult result = MessageBox.Show($"الكمية المدخلة أقل من الحد الأدنى للمخزون. هل ترغب في المتابعة؟", "تحذير", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (result == MessageBoxResult.Yes)
                            {
                                existingCartItem.Quantity += Quantity;
                            }
                            else
                            {

                                MessageBox.Show("تم إلغاء.");
                                return; // Exit the method
                            }

                        }
                    }
                    if (existingCartItem.Quantity + Quantity <= SelectedProduct.Quantity(SelectedWarehouse.Id))
                    {
                        existingCartItem.Quantity += Quantity;
                    }
                    else
                    {
                        // The sum exceeds the maximum quantity, set the quantity to the maximum
                        MessageBox.Show("الكمية المدخلة تتجاوز الكمية المتاحة. تم تعيين الكمية إلى الحد الأقصى.");
                        existingCartItem.Quantity = SelectedProduct.Quantity(SelectedWarehouse.Id);
                    }
                    //existingCartItem.Earned = (double)((existingCartItem.SalePrice * existingCartItem.Quantity) - (existingCartItem.Product.GetLastPurchasePrice() * existingCartItem.Quantity));
                }
                else
                {
                    CartItemsList.Add(new SaleProduct
                    {
                        ProductId = SelectedProduct.Id,
                        Product = SelectedProduct,
                        Quantity = Quantity,
                        SalePrice = SalePrice,
                        CreatedDate = DateTime.Now,
                        Warehouse = SelectedWarehouse,
                        //Earned = (double)(SalePrice - (SelectedProduct.GetLastPurchasePrice() * Quantity)),
                        Details = Notes
                    }); ;
                }
                RecalculateTotalAmount();

                //Quantity = 1;
                //SalePrice = SelectedProduct.Price; // You may need to adjust this based on your requirements

            }

        }


        private void ExecuteCancelCommand(object parameter)
        {
            // Add logic for CancelCommand
        }

        private void ExecuteDeleteCommand(object parameter)
        {
            // Add logic for DeleteCommand
        }
        private void ExecutePayment(object obj)
        {
            // Create and show the payment dialog
            PaymentDialog paymentDialog = new PaymentDialog();
            paymentDialog.viewModel.Total = 100.ToString();
            paymentDialog.viewModel.TotalQuantity = 100.ToString();
            // Show the dialog as a modal window
            bool? result = paymentDialog.ShowDialog();

            // Check the result of the dialog
            if (result.HasValue)
            {
                // Payment dialog was closed, handle the result
                if (paymentDialog.viewModel.PaymentResult == true)
                {
                    AddInvoiceWithSaleProducts();

                }

            }
        }

        private void ExecuteSuspendBillCommand(object parameter)
        {
            // Handle logic for suspending bill
        }





        private void ExecuteDelivery(object obj)
        {
            // Put your delivery logic here
            Console.WriteLine("Delivery command executed");
        }



        private void ExecuteCancelBill(object obj)
        {
            // Put your cancel bill logic here
            Console.WriteLine("Cancel bill command executed");
        }

        private void AddInvoiceWithSaleProducts()
        {
            Invoice newInvoice = new Invoice
            {
                Number = BillNumber,
                Date = PurchaseDate,
                DueDate = PaymentDate,
                Tax = (decimal?)Tax,
                Discount = (decimal?)Discount,
                TotalPrice = (decimal)TotalAmount,
                Subtotal = (decimal)SubTotal,
            };

            // Add the new invoice to the database
            _dbContext.Invoices.Add(newInvoice);
            _dbContext.SaveChanges(); // Save changes to generate the Invoice Id

            foreach (var cartItem in CartItemsList)
            {
                SaleProduct saleProduct = new SaleProduct
                {
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    SalePrice = cartItem.SalePrice,
                    Warehouse = SelectedWarehouse,
                    // Earned = cartItem.Earned,
                    Details = cartItem.Details
                };
                saleProduct.InvoiceId = newInvoice.Id;
                _dbContext.SaleProducts.Add(saleProduct);
                _dbContext.SaveChanges();
            }

            // Save changes to persist the SaleProduct entities associated with the Invoice
            //_dbContext.SaveChanges();

            // Clear the cart items list
            CartItemsList.Clear();

            // Reset selected cart item
            SelectedCartItem = null;

            // Reset other properties
            Quantity = 0;
            SalePrice = 0;
            Notes = null;
            SelectedReadyProduct = null;
            RecalculateTotalAmount();

            // Optionally, update the bill number for the next invoice
            BillNumber = GetNextInvoiceNumber(false);
        }

        #region CartListEvents
        private void ExecuteCartList_CurrentCellChangedCommand(object parameter)
        {
            // Handle CartList_CurrentCellChangedCommand logic here
        }

        private void ExecuteCartList_SelectionChangedCommand(object parameter)
        {
            // Handle CartList_SelectionChangedCommand logic here
        }

        private void ExecuteCartList_MouseDownCommand(object parameter)
        {
            // Handle CartList_MouseDownCommand logic here
        }

        private void ExecuteCartList_MouseDoubleClickCommand(object parameter)
        {
            // Handle CartList_MouseDoubleClickCommand logic here
        }

        private void ExecuteCartList_DataContextChangedCommand(object parameter)
        {
            // Handle CartList_DataContextChangedCommand logic here
        }

        private void ExecuteCartList_SelectedCellsChangedCommand(object parameter)
        {
            // Handle CartList_SelectedCellsChangedCommand logic here
        }



        #endregion

    }
}
