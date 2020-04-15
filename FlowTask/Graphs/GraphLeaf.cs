using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTask
{
    /// <summary> 
    /// Ребро графа, содержит вес и пару вершин, которые соединяет
    /// </summary>
    public class GraphLeaf : IComparable<GraphLeaf>, ICloneable, IEquatable<GraphLeaf>
    {
        /// <summary> 
        /// Вершины, которые соединяет ребро
        /// </summary>
        public Tuple<int, int> Link { get; }

        /// <summary> 
        /// Вес ребра
        /// </summary>
        public int Price { get; }

        /// <summary> 
        /// Величина потока
        /// </summary>
        public int Flow { get; set; }

        /// <summary> 
        /// Задаётся направление из a в b и вес ребра 
        /// </summary>
        public GraphLeaf(int a, int b, int cost)
        {
            Link = new Tuple<int, int>(a, b);
            Price = cost;
            Flow = 0;
        }

        public int CompareTo(GraphLeaf obj)
        {
            if (obj.Price > this.Price)
                return -1;
            if (obj.Price == this.Price)
                return 0;
            return 1;
        }

        public object Clone()
        {
            return new GraphLeaf(this.Link.Item1, this.Link.Item2, this.Price);
        }

        public bool Equals(GraphLeaf other)
        {
            if (other == null) return false;
            return (this.Price.Equals(other.Price) && this.Link.Equals(other.Link));
        }
    }
}
