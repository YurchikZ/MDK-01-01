using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Models
{
    public class ProductsModel
    {
        public List<Product> Users { get; }

        public ProductsModel()
        {
            Users = new List<Product>();

            Users.Add(new Product
            {
                Name = "Иван",
                Surname = "Иванов",
                DateBirth = new System.DateTime(1996, 11, 1)
            });
        }
    }
}
