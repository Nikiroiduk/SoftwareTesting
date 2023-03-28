using MatrixCalculationsBL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTesting
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void CreateEmptyMatrix_r3c3_True()
        {
            var tmp = new Matrix(3, 3);

            Assert.IsTrue(tmp.GetMatrix() is double[,]);
        }

        [TestMethod]
        public void CreateMatrixFromArray_arr_True()
        {
            var arr = new double[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            var tmp = new Matrix(arr);

            if (tmp.GetMatrix() is double[,] m)
                Assert.IsTrue(Equals(m, arr));
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void MultiplyMatrices_AB_True()
        {
            var a = new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
            var b = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });

            var c = a * b;
            var res = new Matrix(new double[,] { { 9, 12, 15 }, { 19, 26, 33 }, { 29, 40, 51 } });

            Assert.IsTrue(c == res);
        }
    }
}
