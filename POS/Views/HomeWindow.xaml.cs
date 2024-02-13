using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using POS.CustomControl;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace POS.Views
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public class MenuItem
        {
            public string Name { get; set; }
            public string Identifier { get; set; }
            public PackIconKind Icon { get; set; }
            public ObservableCollection<MenuItem> Children { get; set; } = new ObservableCollection<MenuItem>();

            // Add a property to hold the required claim type or value for this menu item
            public string RequiredClaim { get; set; }
            public bool IsClickable { get; set; } = true;
        }
        AuthenticationService authenticationService = App.ServiceProvider.GetRequiredService<AuthenticationService>();
        private ObservableCollection<string> messages;
        private DispatcherTimer timer;
        public HomeWindow()
        {

            InitializeComponent();
            // menuToggleButton.Content = new PackIcon { Kind = PackIconKind.ReorderHorizontal, Foreground = Brushes.Gray, Width = 30, Height = 30 };
            _ = SetupMenu();
            UserName.Text = authenticationService.CurrentUser.FullName;
            UserNameDialog.Text = authenticationService.CurrentUser.FullName;


            InitializeMessages();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5); // Change the interval as needed
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void InitializeMessages()
        {

            messages = new ObservableCollection<string>
            {
                "مرحبًا بك في نظام نقاط البيع الخاص بنا. يرجى الاتصال بفريق الدعم إذا كنت بحاجة إلى مساعدة.",
                "تمت معالجة الطلب بنجاح. لا تتردد في إرسال أي استفسارات أو ملاحظات.",
                "تنبيه: يتوجب عليك تحديث الأسعار والمخزون بانتظام لتحسين كفاءة النظام.",
                "تذكير: يرجى الاحتفاظ بنسخة احتياطية للبيانات بانتظام لضمان سلامة المعلومات.",
                "شكرًا لاستخدامك نظام نقاط البيع الخاص بنا. نتطلع إلى خدمتك مرة أخرى قريبًا.",
            };




        }

        private Random random = new Random();

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Generate a random index within the range of the messages collection
            int randomIndex = random.Next(messages.Count);

            // Set the text of the TextBlock to the randomly selected message
            MessageSlider.Text = messages[randomIndex];
        }

        public async Task SetupMenu()
        {
            var salesAndInvoices = new MenuItem { Name = "البيع والفواتير", Identifier = "salesAndInvoices", Icon = PackIconKind.ShoppingOutline, IsClickable = false, RequiredClaim = "salesScreen" };
            salesAndInvoices.Children.Add(new MenuItem { Name = "شاشة البيع", Identifier = "salesScreen", Icon = PackIconKind.CartOutline, RequiredClaim = "salesScreen" });
            salesAndInvoices.Children.Add(new MenuItem { Name = "فواتير البيع", Identifier = "salesInvoices", Icon = PackIconKind.FileDocumentOutline, RequiredClaim = "salesInvoices" });

            var inventoryAndPurchases = new MenuItem { Name = "المخزن والمشتريات", Identifier = "inventoryAndPurchases", Icon = PackIconKind.StoreOutline, IsClickable = false };
            inventoryAndPurchases.Children.Add(new MenuItem { Name = "المخزن", Identifier = "inventory", Icon = PackIconKind.PackageVariant, RequiredClaim = "inventory" });
            inventoryAndPurchases.Children.Add(new MenuItem { Name = "شراء بضاعة", Identifier = "purchaseGoods", Icon = PackIconKind.Shopping, RequiredClaim = "purchaseGoods" });
            inventoryAndPurchases.Children.Add(new MenuItem { Name = "حركة بضاعة", Identifier = "goodsMovement", Icon = PackIconKind.Truck, RequiredClaim = "goodsMovement" });
            inventoryAndPurchases.Children.Add(new MenuItem { Name = "تقرير المخزن", Identifier = "inventoryReport", Icon = PackIconKind.ChartBar, RequiredClaim = "inventoryReport" });
            inventoryAndPurchases.Children.Add(new MenuItem { Name = "فواتير الشراء", Identifier = "purchaseInvoices", Icon = PackIconKind.FileDocumentOutline, RequiredClaim = "purchaseInvoices" });

            var treasury = new MenuItem { Name = "الخزينة", Identifier = "treasury", Icon = PackIconKind.Cash, IsClickable = false };
            treasury.Children.Add(new MenuItem { Name = "الوارد", Identifier = "incoming", Icon = PackIconKind.ArrowTopRight });
            treasury.Children.Add(new MenuItem { Name = "الصادر", Identifier = "outgoing", Icon = PackIconKind.ArrowBottomLeft });
            treasury.Children.Add(new MenuItem { Name = "تقرير الخزينة", Identifier = "treasuryReport", Icon = PackIconKind.ChartBar });

            var customersAndInstallments = new MenuItem { Name = "العملاء والاقساط", Identifier = "customersAndInstallments", Icon = PackIconKind.AccountGroupOutline, IsClickable = false };
            customersAndInstallments.Children.Add(new MenuItem { Name = "العملاء", Identifier = "customers", Icon = PackIconKind.AccountMultipleOutline });
            customersAndInstallments.Children.Add(new MenuItem { Name = "الاقساط", Identifier = "installments", Icon = PackIconKind.CreditCardOutline });
            customersAndInstallments.Children.Add(new MenuItem { Name = "اضافة عميل", Identifier = "addCustomer", Icon = PackIconKind.AccountPlusOutline }); // Added "اضافة عميل"

            var suppliersAndDebts = new MenuItem { Name = "الموردين والمديونيات", Identifier = "suppliersAndDebts", Icon = PackIconKind.TruckDelivery, IsClickable = false };//, RequiredClaim = "TestPermission"
            suppliersAndDebts.Children.Add(new MenuItem { Name = "الموردين", Identifier = "suppliers", Icon = PackIconKind.TruckCheck });
            suppliersAndDebts.Children.Add(new MenuItem { Name = "المديونيات", Identifier = "debts", Icon = PackIconKind.CreditCardClock });
            suppliersAndDebts.Children.Add(new MenuItem { Name = "اضافة مورد", Identifier = "addSupplier", Icon = PackIconKind.TruckPlus }); // Added "اضافة مورد"

            var expenses = new MenuItem { Name = "المصروفات", Identifier = "expenses", Icon = PackIconKind.CashOff, IsClickable = false };
            expenses.Children.Add(new MenuItem { Name = "اضافة مصاريف", Identifier = "addExpenses", Icon = PackIconKind.PlusCircleOutline });
            expenses.Children.Add(new MenuItem { Name = "تقرير بالمصروفات", Identifier = "expensesReport", Icon = PackIconKind.ChartBar });

            var settings = new MenuItem { Name = "الاعدادات", Identifier = "settings", Icon = PackIconKind.CogOutline, IsClickable = false };
            settings.Children.Add(new MenuItem { Name = "اعدادات الحسابات", Identifier = "accountSettings", Icon = PackIconKind.AccountSettingsOutline });
            settings.Children.Add(new MenuItem { Name = "اعدادات النظام", Identifier = "systemSettings", Icon = PackIconKind.CogOutline });
            settings.Children.Add(new MenuItem { Name = "نسخ احتياطي", Identifier = "backup", Icon = PackIconKind.CloudUploadOutline });
            settings.Children.Add(new MenuItem { Name = "الأدوار", Identifier = "roles", Icon = PackIconKind.AccountGroupOutline });
            var homePage = new MenuItem { Name = "الصفحة الرئيسية", Identifier = "homePage", Icon = PackIconKind.Home };

            var menuItems = new ObservableCollection<MenuItem>
            {
                homePage,
                salesAndInvoices,
                inventoryAndPurchases,
                treasury,
                customersAndInstallments,
                suppliersAndDebts,
                expenses,
                settings
            };




            var currentUserClaims = await authenticationService.GetUserRoleClaimsAsync();
            var permittedMenuItems = menuItems.Where(item => string.IsNullOrEmpty(item.RequiredClaim) || currentUserClaims.Any(claim => claim == item.RequiredClaim)).ToList();

            menuTreeView.ItemsSource = permittedMenuItems;

            var homeItem = permittedMenuItems.FirstOrDefault(item => item.Identifier == "homePage");
            if (homeItem != null)
            {
                SelectItem(menuTreeView, homeItem);
            }
        }




        private void SelectItem(TreeView treeView, MenuItem itemToSelect)
        {
            if (treeView.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
            {
                var container = (TreeViewItem)treeView.ItemContainerGenerator.ContainerFromItem(itemToSelect);
                if (container != null)
                {
                    container.IsSelected = true;
                    return;
                }
            }

            treeView.ItemContainerGenerator.StatusChanged += (sender, e) =>
            {
                if (treeView.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                {
                    var container = (TreeViewItem)treeView.ItemContainerGenerator.ContainerFromItem(itemToSelect);
                    if (container != null)
                    {
                        container.IsSelected = true;
                    }
                }
            };
        }
        private bool isMenuOpen = true;

        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the visibility of the sideMenu control
            if (!isMenuOpen)
            {
                // Change the icon to indicate menu is open
                menuToggleButton.Content = new PackIcon { Kind = PackIconKind.ReorderHorizontal, Foreground = Brushes.Gray, Width = 30, Height = 30 };
                isMenuOpen = true;

                sideMenu.Visibility = Visibility.Visible;
                // Check if there are at least two columns defined in the RenderPages grid
                if (RenderPages.ColumnDefinitions.Count >= 2)
                {
                    // Expand the second column to fill the remaining space
                    RenderPages.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
                }
            }
            else
            {
                // Change the icon to indicate menu is closed
                menuToggleButton.Content = new PackIcon { Kind = PackIconKind.ArrowCollapseLeft, Foreground = Brushes.Gray, Width = 30, Height = 30 };
                isMenuOpen = false;

                sideMenu.Visibility = Visibility.Collapsed;
                // Check if there are at least two columns defined in the RenderPages grid
                if (RenderPages.ColumnDefinitions.Count >= 2)
                {
                    // Collapse the second column
                    RenderPages.ColumnDefinitions[1].Width = new GridLength(0);
                }
            }
        }
        private void NotificationButton_Click(object sender, RoutedEventArgs e)
        {
            notificationPopup.IsOpen = true;
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            profilePopup.IsOpen = true;
        }


        private void menuTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (menuTreeView.SelectedItem != null && menuTreeView.SelectedItem is MenuItem selectedMenuItem)
            {
                /*
                    inventoryAndPurchases.Children.Add(new MenuItem { Name = "شراء بضاعة", Identifier = "purchaseGoods", Icon = PackIconKind.Shopping });
                    inventoryAndPurchases.Children.Add(new MenuItem { Name = "حركة بضاعة", Identifier = "goodsMovement", Icon = PackIconKind.Truck });
                 */
                // Check if the selected menu item is clickable
                if (selectedMenuItem.IsClickable)
                {
                    RenderPages.Children.Clear();
                    switch (selectedMenuItem.Identifier)
                    {
                        //addCustomer
                        //addSupplier
                        case "homePage":
                            RenderPages.Children.Add(new Dashboard());
                            break;
                        case "salesScreen":
                            RenderPages.Children.Add(new POS_UserControl());
                            break;
                        case "inventory":
                            RenderPages.Children.Add(new Inventory_UserControl());
                            break;
                        case "purchaseGoods":
                            RenderPages.Children.Add(new Purchase_Products_UserControl());
                            break;
                        case "goodsMovement":
                            RenderPages.Children.Add(new Moving_Products_UserControl());
                            break;
                        case "addCustomer":
                            RenderPages.Children.Add(new Customer_Add_UserControl());
                            break;
                        case "addSupplier":
                            RenderPages.Children.Add(new Supplier_Add_UserControl());
                            break;
                        //backup
                        //roles
                        case "backup":
                            RenderPages.Children.Add(new Backup_UserControl());
                            break;
                        case "roles":
                            RenderPages.Children.Add(new Roles_UserControl());
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    // Menu item is not clickable, handle accordingly (e.g., display a message or disable functionality)
                    // Example: MessageBox.Show("This menu item is not clickable.");
                }
            }
        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //RenderPages.Children.Clear();
            //RenderPages.Children.Add(new Dashboard());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void ShowHideKeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the visibility of the keyboard container
            if (keyboardContainer.Visibility == Visibility.Collapsed)
            {
                keyboardContainer.Visibility = Visibility.Visible;
            }
            else
            {
                keyboardContainer.Visibility = Visibility.Collapsed;
            }
        }

        private void ShowHideCalculatorButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the visibility of the calculator container
            if (calculatorContainer.Visibility == Visibility.Collapsed)
            {
                calculatorContainer.Visibility = Visibility.Visible;
            }
            else
            {
                calculatorContainer.Visibility = Visibility.Collapsed;
            }
        }


    }
}
