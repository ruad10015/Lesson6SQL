using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6SQL.DataAcces.Abstraction
{
    public interface IRepostories<T>
    {
        T GetData(int id);

        ObservableCollection<T> GetAll();

        void AddData(T data);

        void UpdateProduct(T data);

        void UpdateOrder(T data);
    }
}
