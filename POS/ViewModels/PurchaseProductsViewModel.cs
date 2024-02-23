using POS.Domain.Models;
using POS.Domain.Models.Products;
using POS.ViewModels.Base;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace POS.ViewModels
{
    public class PurchaseProductsViewModel : BaseProductsViewModel
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
        private ObservableCollection<PurchaseProduct> _cartItemsList;

        public ObservableCollection<PurchaseProduct> CartItemsList
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

        private PurchaseProduct _selectedCartItem;

        public PurchaseProduct SelectedCartItem
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
            SubTotal = CartItemsList.Sum(item => item.PurchasePrice * item.Quantity);
            TotalAmount = SubTotal + ((Tax / 100) * SubTotal) - Discount;
            //Earnings = (double)(TotalAmount - CartItemsList.Sum(item => item.Product.GetLastPurchasePrice() * item.Quantity));
        }
        public void SetSelectedItemValues(PurchaseProduct selectedCartItem)
        {
            if (selectedCartItem != null)
            {
                SelectedProduct = ProductList.FirstOrDefault(product => product.Id == selectedCartItem.ProductId && selectedCartItem.WarehouseId == SelectedWarehouse.Id);
                //SelectedCategory = CategoryList.FirstOrDefault(category => category.Name == selectedCartItem.Category);

                ItemName = selectedCartItem.Product.Name;
                ItemBarcode = selectedCartItem.Product.Barcode;
                Quantity = selectedCartItem.Quantity;
                ProductWarehouse = selectedCartItem.Warehouse;
                PurchasePrice = selectedCartItem.PurchasePrice;
                Notes = selectedCartItem.Details;
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
        public PurchaseProductsViewModel() : base()
        {
            CartItemsList = new ObservableCollection<PurchaseProduct>();
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
            List<string> missingFields = new List<string>();

            if (SelectedProduct == null)
            {
                missingFields.Add("المنتج المحدد");
            }

            if (Quantity <= 0)
            {
                missingFields.Add("الكمية");
            }

            if (PurchasePrice <= 0)
            {
                missingFields.Add("سعر الشراء");
            }

            if (missingFields.Count > 0)
            {
                // Construct the warning message with the names of the missing fields
                string missingFieldsMessage = "يرجى ملء الحقول الضرورية: " + string.Join(", ", missingFields);

                // Display the warning message
                MessageBox.Show(missingFieldsMessage, "تحذير", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // Exit the method if there are missing fields
            }


            // Check if the item already exists in the cart
            PurchaseProduct existingCartItem = CartItemsList.FirstOrDefault(item => item.ProductId == SelectedProduct.Id && item.WarehouseId == SelectedWarehouse.Id);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity = Quantity;
            }
            else
            {
                CartItemsList.Add(new PurchaseProduct
                {
                    ProductId = SelectedProduct.Id,
                    Product = SelectedProduct,
                    Quantity = Quantity,
                    PurchasePrice = PurchasePrice,
                    Warehouse = SelectedWarehouse,
                    CreatedDate = DateTime.Now,
                    Details = Notes,


                });
            }
            RecalculateTotalAmount();

            //Quantity = 1;
            //PurchasePrice = SelectedProduct.Price; // You may need to adjust this based on your requirements


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
                    AddInvoiceWithPurchaseProducts();

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
        private string _purchaseInvoiceNumber;

        public string PurchaseInvoiceNumber
        {
            get { return _purchaseInvoiceNumber; }
            set
            {
                if (_purchaseInvoiceNumber != value)
                {
                    _purchaseInvoiceNumber = value;
                    OnPropertyChanged(nameof(PurchaseInvoiceNumber));
                }
            }
        }
        private void AddInvoiceWithPurchaseProducts()
        {
            Purchase newInvoice = new Purchase
            {
                Number = PurchaseInvoiceNumber,
                Date = PurchaseDate,
                DueDate = PaymentDate,
                Tax = (decimal?)Tax,
                Discount = (decimal?)Discount,
                TotalPrice = (decimal)TotalAmount,
                Subtotal = (decimal)SubTotal,
            };

            // Add the new invoice to the database
            _dbContext.Purchases.Add(newInvoice);
            _dbContext.SaveChanges(); // Save changes to generate the Invoice Id

            foreach (var cartItem in CartItemsList)
            {
                PurchaseProduct PurchaseProduct = new PurchaseProduct
                {
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    PurchasePrice = cartItem.PurchasePrice,
                    Warehouse = SelectedWarehouse,
                    Details = cartItem.Details
                };
                PurchaseProduct.PurchaseId = newInvoice.Id;
                _dbContext.PurchaseProducts.Add(PurchaseProduct);
                _dbContext.SaveChanges();
            }

            // Save changes to persist the PurchaseProduct entities associated with the Invoice
            //_dbContext.SaveChanges();

            // Clear the cart items list
            CartItemsList.Clear();

            // Reset selected cart item
            SelectedCartItem = null;

            // Reset other properties
            Quantity = 0;
            PurchasePrice = 0;
            Notes = null;
            SelectedReadyProduct = null;
            RecalculateTotalAmount();
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
