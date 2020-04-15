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
            _net = (Graph)g.Clone();
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

        /// <summary> 
        /// Вернет критический путь и ранние сроки начала работ
        /// </summary>
        public Tuple<int[], int[]> CriticalPath()
        {      
            int count = _net.Matrix.GetUpperBound(0) + 1;
            int[] critical = new int[count];
            List<int> path = new List<int>();

            critical[0] = 0;
            path.Add(1);

            for (int i = 1; i < count; i++)
            {
                int max = 0;
                for (int j = 0; j < i; j++)
                {
                    if(_net.Matrix[j][i] == Int32.MaxValue)
                    {
                        _net.Matrix[j][i] = 0;
                    }
                    else if(_net.Matrix[j][i] > 0 && _net.Matrix[j][i] + critical[j] > max)
                    {
                        max = _net.Matrix[j][i] + critical[j];
                        if(!path.Contains(j+1))
                            path.Add(j + 1);
                    }
                }
                critical[i] = max;
            }

            path.Add(count);

            return new Tuple<int[], int[]>(path.ToArray(), critical);
        }
    }


}
