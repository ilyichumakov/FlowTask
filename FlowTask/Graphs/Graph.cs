using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTask
{
    public class Graph
    {
        private List<GraphNode> nodes;
        private List<GraphLeaf> leaves;
        private int[][] matrixGraph;

        public int[][] Matrix
        {
            get
            {
                return this.matrixGraph;
            }
        }

        public Graph(List<GraphNode> nodes, List<GraphLeaf> leaves)
        {
            this.leaves = leaves;
            this.nodes = nodes;

            this.leaves.Sort();

            int n = nodes.Count;
            matrixGraph = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrixGraph[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (i == j) continue;

                    Tuple<int, int> t1 = new Tuple<int, int>(i, j);
                    Tuple<int, int> t2 = new Tuple<int, int>(j, i);

                    foreach (GraphLeaf l in leaves)
                    {
                        if (l.Link == t1 || l.Link == t2)
                        {
                            matrixGraph[i][j] = l.Price;
                            break;
                        }
                    }
                    if(matrixGraph[i][j] == 0)
                    {
                        matrixGraph[i][j] = Int32.MaxValue;
                    }
                }
            }
        }

        public Graph(int[][] matrix)
        {
            nodes = new List<GraphNode>();
            leaves = new List<GraphLeaf>();
            int n = matrix.GetUpperBound(0) + 1;
            matrixGraph = matrix;
         
            for (int i = 0; i < n; i++)
            {
                GraphNode node = new GraphNode(i + 1);
                nodes.Add(node);
                for (int j = i + 1; j < n; j++)
                {                   
                    Tuple<int, int> t1 = new Tuple<int, int>(i, j);
                    
                    leaves.Add(new GraphLeaf(i, j, matrix[i][j]));
                }
            }
        }

        public Graph Dijkstra(int start)
        {
            throw new NotImplementedException();
        }

        public Graph Floyd()
        {
            int n = nodes.Count;           

            var copy2d = matrixGraph.Select(a => a.ToArray()).ToArray();
            int[][] d = copy2d;

            for (int k = 0; k < n; k++)
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j) continue;

                        int sum = d[i][k] + d[k][j];
                        if (sum < 0) sum = Int32.MaxValue; // overflow handling
                        d[i][j] = Math.Min(d[i][j], sum);
                    }

            return new Graph(d);
        }

        public static Graph ImproveFloyd(Graph a, Graph b)
        {            
            bool flag = true;
            int n = a.nodes.Count;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (a.matrixGraph[i][j] != b.matrixGraph[i][j])
                        flag = false;

            if (flag) return a;
            else return ImproveFloyd(b, b.Floyd());
        }
    }
}
