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
    public class OrderRepository : IOrderRepository
    {
        private readonly DataClassesProductandOrderDataContext _data;
        public OrderRepository()
        {
            _data = new DataClassesProductandOrderDataContext();
        }


        public void AddData(Order data)
        {
            _data.Orders.InsertOnSubmit(data);
            _data.SubmitChanges();
        }

        public ObservableCollection<Order> GetAll()
        {
            var orders = from o in _data.Orders
                           select o;

            return new ObservableCollection<Order>(orders);
        }

        public Order GetData(int id)
        {
            return _data.Orders.SingleOrDefault(x => x.OrderID == id);
        }

        public void UpdateOrder(Order data)
        {
            var item = _data.Orders.SingleOrDefault(x => x.OrderID == data.OrderID);
            if (item != null)
            {
                item.OrderID = data.OrderID;
                item.CustomerID = data.CustomerID;
                item.EmployeeID = data.EmployeeID;
                item.OrderDate = data.OrderDate;
                item.RequiredDate = data.RequiredDate;
                item.ShippedDate = data.ShippedDate;
                item.ShipVia = data.ShipVia;
                item.Freight = data.Freight;
                item.ShipName = data.ShipName;
                item.ShipAddress = data.ShipAddress;
                item.ShipCity = data.ShipCity;
                item.ShipRegion = data.ShipRegion;
                item.ShipPostalCode = data.ShipPostalCode;
                item.ShipCountry = data.ShipCountry;
            }
        }

        public void UpdateOrder(Product data)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Order data)
        {
            throw new NotImplementedException();
        }
    }
}
