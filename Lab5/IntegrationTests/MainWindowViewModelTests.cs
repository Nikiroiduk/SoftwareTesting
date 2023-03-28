using ExerciseWPF.ViewModel;
using MatrixCalculationsBL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using System.Windows.Input;
using System.Security.Permissions;
using System.Windows.Controls;

namespace IntegrationTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void MatricesMultiplication_AB_True()
        {
            var vm = new MainWindowViewModel(isTesting: true);

            var A = new double[,] { { 1, 2 }, { 3, 4 } };
            var B = new double[,] { { 1, 2 }, { 3, 4 } };
            vm.MatrixA = new Matrix(A);
            vm.MatrixB = new Matrix(B);
            var C = vm.MatrixC;
            var res = vm.MatrixA * vm.MatrixB;

            Assert.IsTrue(C == res);
        }

        [TestMethod]
        public void CopyingResult_Empty_True()
        {
            var vm = new MainWindowViewModel(isTesting: true);

            vm.CopyResult.Execute(null);

            Assert.IsTrue(Clipboard.GetText() == "Empty");
        }

        [TestMethod]
        public void CopyingResult_Matrix_True()
        {
            var vm = new MainWindowViewModel(isTesting: true);

            vm.MatrixC = new Matrix(3, 3);

            vm.CopyResult.Execute(null);

            Assert.IsTrue(Clipboard.GetText() == new Matrix(3, 3).ToString());
        }

        [TestMethod]
        public void RandomValues_False()
        {
            var vm = new MainWindowViewModel(isTesting: true);

            vm.RandomValues.Execute(null);

            Assert.IsFalse(vm.MatrixA.isNull() && vm.MatrixB.isNull() && !vm.MatrixC.isNull());
        }
    }
}
