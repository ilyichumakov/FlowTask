using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlowTask;
using FlowTask.Flows;

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

            Graph minimalG = g.Floyd();

            Graph realMinimalG = new Graph(minimal);

            Assert.AreEqual(minimalG.Matrix, realMinimalG.Matrix);
        }

        [Test]
        public void PrimTest()
        {
            int[][] matrixx = new int[5][];

            matrixx[0] = new int[] { 0, 1, 3, Int32.MaxValue, Int32.MaxValue };
            matrixx[1] = new int[] { 1, 0, Int32.MaxValue, 2, Int32.MaxValue };
            matrixx[2] = new int[] { 3, Int32.MaxValue, 0, 2, 7 };
            matrixx[3] = new int[] { Int32.MaxValue, 2, 2, 0, 4 };
            matrixx[4] = new int[] { Int32.MaxValue, Int32.MaxValue, 7, 4, 0 };

            int[][] mstMatrix = new int[5][];

            mstMatrix[0] = new int[] { 0, 1, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue };
            mstMatrix[1] = new int[] { Int32.MaxValue, 0, Int32.MaxValue, 2, Int32.MaxValue };
            mstMatrix[2] = new int[] { Int32.MaxValue, Int32.MaxValue, 0, 2, Int32.MaxValue };
            mstMatrix[3] = new int[] { Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, 0, 4 };
            mstMatrix[4] = new int[] { Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, 0 };

            Graph g = new Graph(matrixx);
            Graph MST = g.PrimAlgorythm();

            Graph realMST = new Graph(mstMatrix);

            Assert.AreEqual(realMST.Matrix, MST.Matrix);
        }

        [Test]
        public void FordFalkerson1Test()
        {
            int[][] matrixx = new int[5][];

            matrixx[0] = new int[] { 0, 1, 3, 0, 0 };
            matrixx[1] = new int[] { 1, 0, 0, 2, 0 };
            matrixx[2] = new int[] { 3, 0, 0, 2, 7 };
            matrixx[3] = new int[] { 0, 2, 2, 0, 4 };
            matrixx[4] = new int[] { 0, 0, 7, 4, 0 };

            FlowAlgorythms a = new FlowAlgorythms(new Graph(matrixx));
            int flow = 4;
            Assert.AreEqual(flow, a.FordFalkerson(1, 3)); // numeration from 1
        }

        [Test]
        public void FordFalkerson2Test()
        {
            int[][] matrixx = new int[5][];

            matrixx[0] = new int[] { 0, 1, 3, 0, 0 };
            matrixx[1] = new int[] { 1, 0, 0, 2, 0 };
            matrixx[2] = new int[] { 3, 0, 0, 2, 7 };
            matrixx[3] = new int[] { 0, 2, 2, 0, 4 };
            matrixx[4] = new int[] { 0, 0, 7, 4, 0 };

            FlowAlgorythms a = new FlowAlgorythms(new Graph(matrixx));
            int flow = 3;
            Assert.AreEqual(flow, a.FordFalkerson(1, 2)); // numeration from 1
        }

        [Test]
        public void FordFalkerson3Test()
        {
            int[][] matrixx = new int[5][];

            matrixx[0] = new int[] { 0, 1, 3, 0, 0 };
            matrixx[1] = new int[] { 1, 0, 0, 2, 0 };
            matrixx[2] = new int[] { 3, 0, 0, 2, 7 };
            matrixx[3] = new int[] { 0, 2, 2, 0, 4 };
            matrixx[4] = new int[] { 0, 0, 7, 4, 0 };

            FlowAlgorythms a = new FlowAlgorythms(new Graph(matrixx));
            int flow = 10;
            Assert.AreEqual(flow, a.FordFalkerson(3, 5)); // numeration from 1
        }

        [Test]
        public void CriticalPathTest()
        {
            int[][] matrixx = new int[5][];

            matrixx[0] = new int[] { 0, 4, 5, Int32.MaxValue, Int32.MaxValue };
            matrixx[1] = new int[] { Int32.MaxValue, 0, 3, Int32.MaxValue, Int32.MaxValue };
            matrixx[2] = new int[] { Int32.MaxValue, Int32.MaxValue, 0, 2, 4 };
            matrixx[3] = new int[] { Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, 0, 1 };
            matrixx[4] = new int[] { Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, 0 };

            FlowAlgorythms a = new FlowAlgorythms(new Graph(matrixx));
            int[] path = new int[] {1, 2, 3, 5 };
            int[] criticalTime = new int[] { 0, 4, 7, 9, 11 };

            Tuple<int[], int[]> res = a.CriticalPath();

            Assert.AreEqual(path, res.Item1); // numeration from 1
            Assert.AreEqual(criticalTime, res.Item2);
        }
    }
}
