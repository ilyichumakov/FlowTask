using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTask
{
    public class GraphLeaf : IComparable<GraphLeaf>
    {
        public Tuple<int, int> Link { get; }

        public int Price { get; }

        public GraphLeaf(int a, int b, int cost)
        {
            Link = new Tuple<int, int>(a, b);
            Price = cost;
        }

        public int CompareTo(GraphLeaf obj)
        {
            if (obj.Price > this.Price)
                return -1;
            if (obj.Price == this.Price)
                return 0;
            return 1;
        }
    }
}
