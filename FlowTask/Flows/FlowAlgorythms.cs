using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTask.Flows
{
    /// <summary> 
    /// Объекты класса хранят граф, на котором можно выполнять методы, используемые в задачах сетевого планирования
    /// </summary>
    public class FlowAlgorythms
    {
        private Graph _net;

        /// <summary> 
        /// Задайте граф, на котором будут выполняться алгоритмы
        /// </summary>
        public FlowAlgorythms(Graph g)
        {
            _net = g;
        }

        /// <summary> 
        /// Максимальный поток из первой вершины во вторую, нумерация с 1
        /// </summary>
        public int FordFalkerson(int source, int target)
        {            
            for (int flow = 0; ;)
            {
                int df = findPath(new bool[_net.Matrix.Length], source - 1, target - 1, int.MaxValue);
                if (df == 0)
                    return flow;
                flow += df;
            }
        }

        private int findPath(bool[] visited, int u, int t, int f)
        {
            if (u == t)
                return f;

            int n = _net.Matrix.GetUpperBound(0) + 1;

            visited[u] = true;
            for (int v = 0; v < n; v++)
                if (!visited[v] && _net.Matrix[u][v] > 0)
                {
                    int df = findPath(visited, v, t, Math.Min(f, _net.Matrix[u][v]));
                    if (df > 0)
                    {
                        _net.Matrix[u][v] -= df;
                        _net.Matrix[v][u] += df;
                        return df;
                    }
                }
            return 0;
        }
    }


}
