using Lesson6SQL.DataAcces.Abstraction;
using Lesson6SQL.DataAcces.Concreate;
using Lesson6SQL.DataAcces.SqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6SQL.Domain.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repostories;

        public ProductService()
        {
            _repostories = new ProductReposirt();
        }

        public ObservableCollection<Product> GetProducts(bool isProduct)
        {
            IOrderedEnumerable<Product> items = null;
            if (!isProduct)
            {
                items = from p in _repostories.GetAll()
                        orderby p.UnitPrice descending
                        select p;
            }

            return new ObservableCollection<Product>(items);
        }

        public void UpdateProduct(Product product)
        {
            _repostories.UpdateProduct(product);
        }
    }
}
