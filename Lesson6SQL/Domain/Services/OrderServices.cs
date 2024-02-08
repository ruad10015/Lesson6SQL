using Lesson6SQL.DataAcces.Abstraction;
using Lesson6SQL.DataAcces.Concreate;
using Lesson6SQL.DataAcces.SqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Lesson6SQL.Domain.Services
{
    public class OrderServices
    {
        private readonly IOrderRepository _repostories;

        public OrderServices()
        {
            _repostories = new OrderRepository();
        }

        public ObservableCollection<Order> GetProducts(bool isOrder)
        {
            IOrderedEnumerable<Order> items = null;
            if (!isOrder)
            {
                items = from o in _repostories.GetAll()
                        orderby o.OrderDate
                        select o;
            }

            return new ObservableCollection<Order>(items);
        }

        public void UpdateOrder(Order order)
        {
            _repostories.UpdateOrder(order);
        }
    }
}
