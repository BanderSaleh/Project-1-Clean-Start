using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project1_TA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();

            // Instance created
            SampleDataContext employee = new SampleDataContext();


            // MessageBox.Show("Hello World!");
            //MessageBox.Show("Hello World!");
            //Filled our WPF Object named "GridView1" with data from our instance
            GridView1.ItemsSource = employee.DimEmployees;


            //Page_Load();
            /*GridView1.ItemsSource = from DimEmployees in employee.DimEmployees
                                    join DimGeography in employee.DimGeographies on DimEmployees.SalesTerritoryKey equals employee.DimSalesTerritories //on DimEmployee.ReferenceEquals equals employee.DimGeographies
                                    select employee;*/

            //employee.DimGeographies;

            //Currently Adding SQL Code (below)
            /*GridView1.ItemsSource = from DimEmployee in employee.DimEmployees
                                    join DimGeography on 
                                    select employee;*/



        }

     

        public class ViewModel
        {
            public ViewModel() => dbEmployees.Source = GetData();

            CollectionViewSource dbEmployees = new CollectionViewSource(); // Initialized Instance
            public ICollectionView View { get => dbEmployees.View; }
            private ObservableCollection<Data> GetData()
            {
                var colA = LoadA();
                var colB = LoadB();
                var colC = LoadC();
                var query = from DimEmployee in colA
                            join DimGeography in colB on DimEmployee.SalesTerritoryKey equals DimGeography.SalesTerritoryKey
                            join DimSalesTerritory in colC on DimEmployee.SalesTerritoryKey equals DimSalesTerritory.SalesTerritoryKey
                            select new Data() { A = $"{DimEmployee.SalesTerritoryKey}", B = $"{DimGeography.GeographyKey}", C = $"{DimSalesTerritory.SalesTerritoryKey}" };
                return new ObservableCollection<Data>(query);
            }

            private ObservableCollection<DimEmployee> LoadA()
            {
                ObservableCollection<DimEmployee> col = new ObservableCollection<DimEmployee>();
                for (int i = 1; i < col.Count; i++)
                {
                    string v = $"SalesTerritoryKey{i}";
                    col.Add(new DimEmployee() { EmployeeKey = i, SalesTerritoryKey = v, EmployeePhoto = $"EmployeePhoto{i}", FirstName = $"FirstName{i}", LastName = $"LastName{i}", Title = $"Title{i}", Phone = $"Phone{i}" });
                }

                return col;
            }

            private ObservableCollection<DimGeography> LoadB()
            {
                ObservableCollection<DimGeography> col = new ObservableCollection<DimGeography>();
                for (int i = 1; i < col.Count; i++)
                {
                    string v = $"SalesTerritoryKey{i}";
                    col.Add(new DimGeography() { GeographyKey = i, SalesTerritoryKey = v, City = $"City{i}" });
                }
                return col;
            }

            private ObservableCollection<DimSalesTerritory> LoadC()
            {
                ObservableCollection<DimSalesTerritory> col = new ObservableCollection<DimSalesTerritory>();
                for (int i = 1; i < col.Count; i++)
                {
                    string v = $"SalesTerritoryKey{i}";
                    col.Add(new DimSalesTerritory() { SalesTerritoryKey = v, SalesTerritoryCountry = $"SalesTerritoryCountry{i}" });
                }
                return col;
            }




        }
     


        // Method?
        public class Data
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }

        }

        internal class DimEmployee
        {
            //internal int AuthorID { get; internal set; }
            internal int EmployeeKey { get; set; }
            internal string SalesTerritoryKey { get; set; }
            internal string EmployeePhoto { get; set; }
            internal string FirstName { get; set; }
            internal string LastName { get; set; }
            internal string Title { get; set; }
            internal string Phone { get; set; }
            

        }
        internal class DimGeography
        {
            internal int GeographyKey { get; set; }
            internal string SalesTerritoryKey { get; set; }
            internal string City { get; set; }
        }
        internal class DimSalesTerritory
        {
            internal string SalesTerritoryKey { get; set; }
            internal string SalesTerritoryCountry { get; set; }
        }


        /*void Page_Load()
        {
            SampleDataContext dbContext = new SampleDataContext();
            GridView1.ItemsSource = from DimEmployees in employee.DimEmployees
                                    join DimGeography in employee.DimGeographies on DimEmployees.SalesTerritoryKey equals employee.DimSalesTerritories //on DimEmployee.ReferenceEquals equals employee.DimGeographies
                                    select employee;

        }*/



        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
