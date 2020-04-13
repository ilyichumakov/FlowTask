using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlowTask;

namespace Tests
{
    [TestFixture]
    public class GraphTests
    {
        [Test]
        public void FloydTest()
        {
            int[][] matrixx = new int[5][];
            
            matrixx[0] = new int[] { 0, 1, 3, Int32.MaxValue, Int32.MaxValue };
            matrixx[1] = new int[] { 1, 0, Int32.MaxValue, 2, Int32.MaxValue };
            matrixx[2] = new int[] { 3, Int32.MaxValue, 0, 2, 7 };
            matrixx[3] = new int[] { Int32.MaxValue, 2, 2, 0, 4 };
            matrixx[4] = new int[] { Int32.MaxValue, Int32.MaxValue, 7, 4, 0 };

            int[][] minimal = new int[5][];

            minimal[0] = new int[] { 0, 1, 3, 3, 7 };
            minimal[1] = new int[] { 1, 0, 4, 2, 6 };
            minimal[2] = new int[] { 3, 4, 0, 2, 6 };
            minimal[3] = new int[] { 3, 2, 2, 0, 4 };
            minimal[4] = new int[] { 7, 6, 6, 4, 0 };

            Graph g = new Graph(matrixx);

            Graph minimalG = Graph.ImproveFloyd(g, g.Floyd());

            Graph realMinimalG = new Graph(minimal);

            Assert.AreEqual(minimalG.Matrix, realMinimalG.Matrix);

        }
    }
}
