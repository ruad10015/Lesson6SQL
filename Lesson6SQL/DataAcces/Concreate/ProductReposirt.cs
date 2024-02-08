using Lesson6SQL.DataAcces.Abstraction;
using Lesson6SQL.DataAcces.SqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6SQL.DataAcces.Concreate
{
    public class ProductReposirt : IProductRepository
    {
        private readonly DataClassesProductandOrderDataContext _data;

        public ProductReposirt()
        {
            _data = new DataClassesProductandOrderDataContext();
        }

        public void AddData(Product data)
        {
            _data.Products.InsertOnSubmit(data);
            _data.SubmitChanges();
        }

        public ObservableCollection<Product> GetAll()
        {
            var products = from p in _data.Products
                           select p;

            return new ObservableCollection<Product>(products);
        }

        public Product GetData(int id)
        {
            return _data.Products.SingleOrDefault(x => x.ProductID == id);
        }

        public void UpdateOrder(Product data)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product data)
        {
            var item = _data.Products.SingleOrDefault(x => x.ProductID == data.ProductID);
            if (item != null)
            {
                item.ProductName = data.ProductName;
                item.SupplierID = data.SupplierID;
                item.CategoryID = data.CategoryID;
                item.QuantityPerUnit = data.QuantityPerUnit;
                item.UnitPrice = data.UnitPrice;
                item.UnitsInStock = data.UnitsInStock;
                item.UnitsOnOrder = data.UnitsOnOrder;
                item.ReorderLevel = data.ReorderLevel;
                item.Discontinued = data.Discontinued;
                _data.SubmitChanges();
            }
        }
    }
}
