using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyConsole
{
    class TreeModel
    {

        public TreeModel()
        {
            Childs = new List<TreeModel>();
        }

        public int ID { get; set; }
        public int ParentID { get; set; } = -1;
        public string Name { get; set; }

        public TreeModel Parent { get; set; }
        public List<TreeModel> Childs { get; set; }



        private static List<TreeModel> _flatList = new List<TreeModel>
        {
            new TreeModel{ ID = 0, Name = "root" },

            new TreeModel{ ID = 10, Name = "Products", ParentID = 0},
            new TreeModel{ ID = 11, Name = "AddProduct", ParentID = 10 },
            new TreeModel{ ID = 12, Name = "GetProduct", ParentID = 10 },

            new TreeModel{ ID = 20, Name = "Cetegories", ParentID = 0 },
            new TreeModel{ ID = 21, Name = "GetCategory", ParentID =20},
            new TreeModel{ ID = 22, Name = "AddCategory", ParentID =20}
        };
        public static List<TreeModel> GetFlatList() => _flatList;

        public static List<TreeModel> CreateTreeModel(List<TreeModel> flatList)
        {
            var tree = new TreeModel();

            var dictionary = new Dictionary<int, TreeModel>();
            flatList.ForEach(item => dictionary.Add(item.ID, item));
            foreach (var item in flatList)
            {
                if (dictionary.TryGetValue(item.ParentID,out TreeModel parentOfItem))
                {
                    parentOfItem.Childs.Add(item);
                    item.Parent = parentOfItem;
                }
            }

            var all = dictionary.Values.Where(item => item.ParentID == -1);
            return all.ToList();
        }
    }
}
