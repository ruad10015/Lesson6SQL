using Lesson6SQL.Command;
using Lesson6SQL.DataAcces.SqlServer;
using Lesson6SQL.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lesson6SQL.Domain.Views;
using System.Windows.Controls;
using System.Windows;

namespace Lesson6SQL.Domain.ViewModels
{

    public class DataViewModel: BaseViewModel
    {
        private readonly ProductService _productService;

        private readonly OrderServices _orderService;


        public DataViewModel()
        {
            _productService = new ProductService();

            _orderService = new OrderServices();

            AllProduct = _productService.GetProducts(false);
            AllOrder = _orderService.GetProducts(false);

            
        }

        private ObservableCollection<Product> allProduct;

        public ObservableCollection<Product> AllProduct
        {
            get { return allProduct; }
            set { allProduct = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Order> allOrder;

        public ObservableCollection<Order> AllOrder
        {
            get { return allOrder; }
            set { allOrder = value; OnPropertyChanged(); }
        }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }

        public RelayCommand UpdateCommandProduct => new RelayCommand(UpdateProduct);

        private void UpdateProduct()
        {
            if (SelectedProduct != null)
            {
                // Implement the logic to update the selected product in your ProductService
                _productService.UpdateProduct(SelectedProduct);

                // Refresh the data after updating
                AllProduct = _productService.GetProducts(false);
            }
            else
            {
                MessageBox.Show("Please select a product to update.");
            }
        }




    }
}

