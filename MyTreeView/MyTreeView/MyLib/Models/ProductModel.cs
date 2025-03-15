
using System.Collections.Generic;
using MyTreeView;

namespace MyLib.Models
{
    public class ProductModel
    {
        public List<Product> Product_ { get; }
        
        public ProductModel()
        {
            Product_ = new List<Product>();
            Product_.Add (new Product{ name = "Кола", cost = "120", producer = "Добрый"});
            Product_.Add(new Product { name = "Coca Cola", cost = "220", producer = "Cola Corp. Official" });
            Product_.Add(new Product { name = "Сола", cost = "35", producer = "Красная цена" });
            Product_.Add(new Product { name = "Fanta", cost = "189", producer = "Cola Corp. Offcial" });
            Product_.Add(new Product { name = "Апельсиновый Добрый", cost = "120", producer = "Добрый" });
            Product_.Add(new Product { name = "Апельсинка", cost = "69", producer = "Злой" });
            Product_.Add(new Product { name = "Sprite", cost = "199", producer = "Cola Corp. Offcial" });
            Product_.Add(new Product { name = "Лаймовый Добрый", cost = "120", producer = "Добрый" });
            Product_.Add(new Product { name = "Мохито", cost = "75", producer = "Злой" });
        }
        public Product GetExampleByName(string name)
        {
            return Product_.Find(e => e.name == name);
        }
    }
}
