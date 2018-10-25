using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        void Add(Product newProduct);
        void Update(Product updateProduct);
        void Delete(Product deleteProduct);
    }
}
