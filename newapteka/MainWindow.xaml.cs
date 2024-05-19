using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace newapteka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PostgresContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new PostgresContext();
            LoadTableNames();
        }
        private void LoadTableNames()
        {
            // Добавляем новые имена таблиц
            searchtables.Items.Add("Clients");
            searchtables.Items.Add("Couriers");
            searchtables.Items.Add("Discounts");
            searchtables.Items.Add("DiscountsForCustomers");
            searchtables.Items.Add("Employees1");
            searchtables.Items.Add("Manufacturers");
            searchtables.Items.Add("OrderDetails");
            searchtables.Items.Add("OrderForHomes");
            searchtables.Items.Add("Positions");
            searchtables.Items.Add("Procurements");
            searchtables.Items.Add("Products");
            searchtables.Items.Add("ProductAccordingToRecipes");
            searchtables.Items.Add("Providers");
            searchtables.Items.Add("PurchaseDetails");
            searchtables.Items.Add("Reviews");
            searchtables.Items.Add("Salaries");
            searchtables.Items.Add("Sales");
            searchtables.Items.Add("Stocks");
            searchtables.Items.Add("StolenProducts");
            searchtables.Items.Add("SuppliesOfGoods");
            searchtables.Items.Add("Supplies");
            searchtables.Items.Add("TradingPlans");
            searchtables.Items.Add("Users");
        }

        private void searchtables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (searchtables.SelectedItem == null) return;

                string selectedTable = searchtables.SelectedItem.ToString();
                LoadTableData(selectedTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выборе таблицы: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadTableData(string tableName)
        {
            try
            {
                switch (tableName)
                {
                    case "Clients":
                        _context.Clients.Load();
                        bdapteka.ItemsSource = _context.Clients.Local.ToList();
                        break;
                    case "Couriers":
                        _context.Couriers.Load();
                        bdapteka.ItemsSource = _context.Couriers.Local.ToList();
                        break;
                    case "Discounts":
                        _context.Discounts.Load();
                        bdapteka.ItemsSource = _context.Discounts.Local.ToList();
                        break;
                    case "DiscountsForCustomers":
                        _context.DiscountsForCustomers.Load();
                        bdapteka.ItemsSource = _context.DiscountsForCustomers.Local.ToList();
                        break;
                    case "Employees":
                        _context.Employees.Load();
                        bdapteka.ItemsSource = _context.Employees.Local.ToList();
                        break;
                    case "Employees1":
                        _context.Employees1.Load();
                        bdapteka.ItemsSource = _context.Employees1.Local.ToList();
                        break;
                    case "Manufacturers":
                        _context.Manufacturers.Load();
                        bdapteka.ItemsSource = _context.Manufacturers.Local.ToList();
                        break;
                    case "OrderDetails":
                        _context.OrderDetails.Load();
                        bdapteka.ItemsSource = _context.OrderDetails.Local.ToList();
                        break;
                    case "OrderForHomes":
                        _context.OrderForHomes.Load();
                        bdapteka.ItemsSource = _context.OrderForHomes.Local.ToList();
                        break;
                    case "Pharmacies":
                        _context.Pharmacies.Load();
                        bdapteka.ItemsSource = _context.Pharmacies.Local.ToList();
                        break;
                    case "Positions":
                        _context.Positions.Load();
                        bdapteka.ItemsSource = _context.Positions.Local.ToList();
                        break;
                    case "Procurements":
                        _context.Procurements.Load();
                        bdapteka.ItemsSource = _context.Procurements.Local.ToList();
                        break;
                    case "Products":
                        _context.Products.Load();
                        bdapteka.ItemsSource = _context.Products.Local.ToList();
                        break;
                    case "ProductAccordingToRecipes":
                        _context.ProductAccordingToRecipes.Load();
                        bdapteka.ItemsSource = _context.ProductAccordingToRecipes.Local.ToList();
                        break;
                    case "Providers":
                        _context.Providers.Load();
                        bdapteka.ItemsSource = _context.Providers.Local.ToList();
                        break;
                    case "PurchaseDetails":
                        _context.PurchaseDetails.Load();
                        bdapteka.ItemsSource = _context.PurchaseDetails.Local.ToList();
                        break;
                    case "Reviews":
                        _context.Reviews.Load();
                        bdapteka.ItemsSource = _context.Reviews.Local.ToList();
                        break;
                    case "Salaries":
                        _context.Salaries.Load();
                        bdapteka.ItemsSource = _context.Salaries.Local.ToList();
                        break;
                    case "Sales":
                        _context.Sales.Load();
                        bdapteka.ItemsSource = _context.Sales.Local.ToList();
                        break;
                    case "Stocks":
                        _context.Stocks.Load();
                        bdapteka.ItemsSource = _context.Stocks.Local.ToList();
                        break;
                    case "StolenProducts":
                        _context.StolenProducts.Load();
                        bdapteka.ItemsSource = _context.StolenProducts.Local.ToList();
                        break;
                    case "SuppliesOfGoods":
                        _context.SuppliesOfGoods.Load();
                        bdapteka.ItemsSource = _context.SuppliesOfGoods.Local.ToList();
                        break;
                    case "Supplies":
                        _context.Supplies.Load();
                        bdapteka.ItemsSource = _context.Supplies.Local.ToList();
                        break;
                    case "TotalPurchasePeriods":
                        _context.TotalPurchasePeriods.Load();
                        bdapteka.ItemsSource = _context.TotalPurchasePeriods.Local.ToList();
                        break;
                    case "TradingPlans":
                        _context.TradingPlans.Load();
                        bdapteka.ItemsSource = _context.TradingPlans.Local.ToList();
                        break;
                    case "Users":
                        _context.Users.Load();
                        bdapteka.ItemsSource = _context.Users.Local.ToList();
                        break;
                    default:
                        bdapteka.ItemsSource = null;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    

}