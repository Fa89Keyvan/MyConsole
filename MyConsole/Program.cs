using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var tree = Tools.BuildTreeAndGetRoots(flatList).ToList();
            var tree = TreeModel.CreateTreeModel(TreeModel.GetFlatList());
            Console.ReadLine();
        }
    }
}
