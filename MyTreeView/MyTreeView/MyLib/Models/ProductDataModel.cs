using System.Collections.Generic;

namespace MyLib.Models
{
    public class ProductDataModel
    {
        public List<TreeNodeModel> treeData { get; }

        public ProductDataModel()
        {
            treeData = new List<TreeNodeModel>();

            // Газировка
            {
                treeData.Add(new TreeNodeModel("Газировка"));
                var SodaNode = treeData[0];
                var Cola = SodaNode.AddChildNode("Кола");
                Cola.AddChildNode("Кола Добрый");
                Cola.AddChildNode("Coca Cola");
                Cola.AddChildNode("Кола");

                var Fanta = SodaNode.AddChildNode("Апельсиновая");
                Fanta.AddChildNode("Fanta");
                Fanta.AddChildNode("Апельсиновый Добрый");
                Fanta.AddChildNode("Апельсинка");

                var Sprite = SodaNode.AddChildNode("Лаймовая");
                Sprite.AddChildNode("Sprite");
                Sprite.AddChildNode("Лаймовый Добрый");
                Sprite.AddChildNode("Мохито");
            }

            // Кроссовер
            {
                treeData.Add(new TreeNodeModel("Чипсы"));
                var CrossNode = treeData[1];
                var SourCreamGreens = CrossNode.AddChildNode("Сметана и зелень");
                SourCreamGreens.AddChildNode("Lays");
                SourCreamGreens.AddChildNode("Twister");
                SourCreamGreens.AddChildNode("Московский картофель");

                var Paprika = CrossNode.AddChildNode("Паприка");
                Paprika.AddChildNode("Lays");
                Paprika.AddChildNode("Twister");
                Paprika.AddChildNode("Чипсоны");

                var Crab = CrossNode.AddChildNode("Краб");
                Crab.AddChildNode("Lays");
                Crab.AddChildNode("Чипсоны");
                Crab.AddChildNode("Лукошки");
            }
        }
    }
}
