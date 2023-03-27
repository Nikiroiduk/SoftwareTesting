using ExerciseWPF.Model.Commands;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Matrix = MatrixCalculationsBL.Models.Matrix;

namespace ExerciseWPF.ViewModel
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly bool isTesting;

        public MainWindowViewModel()
        {
            #region Commands
            RandomValues = new LambdaCommand(OnRandomValues, CanRandomValues);
            CopyResult = new LambdaCommand(OnCopyResult, CanCopyResult);
            #endregion
        }

        public MainWindowViewModel(bool isTesting, double[,] A, double[,] B)
        {
            this.isTesting = isTesting;
            #region Commands
            RandomValues = new LambdaCommand(OnRandomValues, CanRandomValues);
            CopyResult = new LambdaCommand(OnCopyResult, CanCopyResult);
            #endregion
            MatrixA = new Matrix(A);
            MatrixB = new Matrix(B);
        }

        #region Title
        private string _Title = "Lab5";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

        #region MatrixA
        private Matrix _MatrixA;

        public Matrix MatrixA
        {
            get => _MatrixA;
            set
            {
                Set(ref _MatrixA, value);
                if (!isTesting)
                    MatrixC = MatrixA * MatrixB;
            }
        }
        #endregion

        #region MatrixB
        private Matrix _MatrixB;

        public Matrix MatrixB
        {
            get => _MatrixB;
            set
            {
                Set(ref _MatrixB, value);
                MatrixC = MatrixA * MatrixB;
            } 
        }
        #endregion

        #region MatrixC
        private Matrix _MatrixC;

        public Matrix MatrixC
        {
            get => _MatrixC;
            set 
            { 
                Set(ref _MatrixC, value);
                Title = $"{MatrixC.GetR()}x{MatrixC.GetC()}";
                if (isTesting)
                {
                    Console.WriteLine(MatrixC.ToString());
                    Application.Current.Shutdown();
                }
            } 
        }
        #endregion

        #region RandomValues
        public ICommand RandomValues { get; }

        private bool CanRandomValues(object p) => true;
        private void OnRandomValues(object p)
        {
            //TODO: Generate random matrices
        }
        #endregion

        #region CopyResult
        public ICommand CopyResult { get; }

        private bool CanCopyResult(object p) => true;
        private void OnCopyResult(object p)
        {
            Clipboard.SetText(MatrixC != null ? MatrixC.ToString() : "Empty");
        }
        #endregion
    }
}
