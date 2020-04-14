using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTask
{
    public class GraphNode : ICloneable, IComparer<GraphNode>, IEquatable<GraphNode>
    {
        public int Value { get; set; }       

        public GraphNode(int val)
        {
            Value = val;           
        }

        public object Clone()
        {
            return new GraphNode(this.Value);
        }

        public int Compare(GraphNode x, GraphNode y)
        {
            if(x.Value == y.Value) return 0;
            if (x.Value > y.Value) return 1;
            return -1;
        }

        public bool Equals(GraphNode other)
        {
            if (other == null) return false;
            return (this.Value.Equals(other.Value));
        }
    }
}
