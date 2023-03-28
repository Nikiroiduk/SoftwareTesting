using ExerciseWPF.Model.Commands;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Matrix = MatrixCalculationsBL.Models.Matrix;

namespace ExerciseWPF.ViewModel
{
    public class MainWindowViewModel : ViewModel
    {
        private bool isTesting;

        public MainWindowViewModel()
        {
            #region Commands
            RandomValues = new LambdaCommand(OnRandomValues, CanRandomValues);
            CopyResult = new LambdaCommand(OnCopyResult, CanCopyResult);
            #endregion
        }

        public MainWindowViewModel(bool isTesting)
        {
            this.isTesting = isTesting;
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
        private Matrix _MatrixA = new Matrix();

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
        private Matrix _MatrixB = new Matrix();

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
        private Matrix _MatrixC = new Matrix();

        public Matrix MatrixC
        {
            get => _MatrixC;
            set 
            { 
                Set(ref _MatrixC, value);
                Title = $"{MatrixC?.GetR()}x{MatrixC?.GetC()}";
                if (isTesting)
                {
                    Console.WriteLine(MatrixC?.ToString());
                    Application.Current?.Shutdown();
                }
            } 
        }
        #endregion

        #region RandomValues
        public ICommand RandomValues { get; }

        private bool CanRandomValues(object p) => true;
        private void OnRandomValues(object p)
        {
            var rand = new Random();
            var x = rand.Next(2, 5);
            var y = rand.Next(2, 5);

            var a = new double[x, y];
            var b = new double[y, x];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    a[i, j] = rand.Next(-10, 10);
                    b[j, i] = rand.Next(-10, 10);
                }
            }

            //Konstantin
            isTesting = true;
            MatrixA = new Matrix(a);
            isTesting = false;
            MatrixB = new Matrix(b);
        }
        #endregion

        #region CopyResult
        public ICommand CopyResult { get; }

        private bool CanCopyResult(object p) => true;
        private void OnCopyResult(object p)
        {
            Clipboard.SetText(MatrixC.isNull() ? "Empty" : MatrixC.ToString());
        }
        #endregion
    }
}
