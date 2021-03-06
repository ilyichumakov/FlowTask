﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTask
{
    /// <summary> 
    /// Объекты класса представляют граф, на котором можно выполнять некоторые алгоритмы
    /// </summary>
    public class Graph : ICloneable
    {
        private List<GraphNode> nodes;
        private List<GraphLeaf> leaves;
        private int[][] matrixGraph;

        /// <summary> 
        /// Матрица инцидентности графа
        /// </summary>
        public int[][] Matrix
        {
            get
            {
                return this.matrixGraph;
            }
        }

        /// <summary> 
        /// Принимает список вершин и ребер
        /// </summary>
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

                    Tuple<int, int> t1 = new Tuple<int, int>(i + 1, j + 1);
                    //Tuple<int, int> t2 = new Tuple<int, int>(j + 1, i + 1);

                    foreach (GraphLeaf l in leaves)
                    {
                        //if (l.Link.Equals(t1) || l.Link.Equals(t2))
                        if (l.Link.Equals(t1))
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

        /// <summary> 
        /// Принимает матрицу инцидентности
        /// </summary>
        public Graph(int[][] matrix)
        {
            nodes = new List<GraphNode>();
            leaves = new List<GraphLeaf>();
            int n = matrix.GetUpperBound(0) + 1;
            matrixGraph = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrixGraph[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    matrixGraph[i][j] = matrix[i][j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                GraphNode node = new GraphNode(i + 1);
                nodes.Add(node);
                for (int j = i + 1; j < n; j++)
                {                   
                    Tuple<int, int> t1 = new Tuple<int, int>(i, j);
                    
                    leaves.Add(new GraphLeaf(i + 1, j + 1, matrix[i][j]));
                }
            }
        }

        public Graph Dijkstra(int start)
        {
            throw new NotImplementedException();
        }

        /// <summary> 
        /// Возвращает граф, на котором ребра представляют кратчайший путь из одной вершины в другую
        /// </summary>
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

        /// <summary> 
        /// Возвращает минимальное остовное дерево (граф), полученное алгоритмом Прима
        /// </summary>
        public Graph PrimAlgorythm()
        {
            List<GraphNode> usedNodes = new List<GraphNode>();
            List<GraphNode> notUsedNodes = nodes.Select(item => (GraphNode)item.Clone()).ToList();
            List<GraphLeaf> notUsedLeaves = leaves.Select(item => (GraphLeaf)item.Clone()).ToList();
            List<GraphLeaf> MST = new List<GraphLeaf>();

            usedNodes.Add(new GraphNode(1));
            notUsedNodes.Remove(new GraphNode(1));

            while(notUsedNodes.Count > 0)
            {
                int minPrice = -1;
                GraphLeaf optimal = new GraphLeaf(0, 0, 0);
                                    
                foreach (GraphLeaf l in notUsedLeaves)
                {
                    if (usedNodes.Contains(new GraphNode(l.Link.Item1)) && 
                        notUsedNodes.Contains(new GraphNode(l.Link.Item2)) ||
                        usedNodes.Contains(new GraphNode(l.Link.Item2)) &&
                        notUsedNodes.Contains(new GraphNode(l.Link.Item1))
                    )
                    {
                        if(minPrice == -1)
                        {
                            minPrice = l.Price;
                            optimal = l;
                        }
                        else if(l.Price < minPrice)
                        {
                            minPrice = l.Price;
                            optimal = l;
                        }
                    }
                }
                MST.Add(optimal);

                if (!usedNodes.Contains(new GraphNode(optimal.Link.Item1)))
                    usedNodes.Add(new GraphNode(optimal.Link.Item1));

                if (!usedNodes.Contains(new GraphNode(optimal.Link.Item2)))
                    usedNodes.Add(new GraphNode(optimal.Link.Item2));

                notUsedLeaves.Remove(optimal);
                notUsedNodes.Remove(new GraphNode(optimal.Link.Item1));
                notUsedNodes.Remove(new GraphNode(optimal.Link.Item2));
            }

            return new Graph(usedNodes, MST);
        }

        public object Clone()
        {
            int n = matrixGraph.GetUpperBound(0) + 1;
            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = matrixGraph[i][j];
                }
            }

            return new Graph(matrix);
        }
    }
}
