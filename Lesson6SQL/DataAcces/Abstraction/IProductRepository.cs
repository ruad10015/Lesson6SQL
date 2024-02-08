using Lesson6SQL.DataAcces.Abstraction;
using Lesson6SQL.DataAcces.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6SQL.DataAcces.Abstraction
{
    public interface IProductRepository: IRepostories<Product>
    {
        void UpdateProduct(Product data);

    }

}
