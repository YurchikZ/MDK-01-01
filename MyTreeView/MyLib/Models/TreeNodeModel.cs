using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Models
{
    public class TreeNodeModel
    {
        public string Name { get; set; } //имя узла

        public List<TreeNodeModel> Children { get; } // список дочерних узлов

        public TreeNodeModel(string name)
        {
            Name = name;
            Children = new List<TreeNodeModel>();
        }

        public TreeNodeModel AddChildNode(string text)
        {
            TreeNodeModel node = new TreeNodeModel(text);
            Children.Add(node);

            return node;
        }
}
