using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculationsBL.Models
{
    public class Matrix
    {
        private object matrix { get; set; } = null;
        private uint R { get; set; } = 0;
        private uint C { get; set; } = 0;

        public Matrix(uint R, uint C)
        {
            if (R > 0 && C > 0)
            {
                matrix = new double[R, C];
                this.R = R;
                this.C = C;
            }
            else
                throw new Exception($"Incorrect matrix size! matrix[{R},{C}]");
        }

        public Matrix(double[,] values)
        {
            var r = (uint)values.GetUpperBound(0) + 1;
            var c = (uint)values.GetUpperBound(1) + 1;
            if (r <= 0 || c <= 0)
                throw new Exception($"Incorrect matrix size! values[{r},{c}]");
            else
            {
                matrix = values;
                R = r;
                C = c;
            }
        }

        public void SetValues(double[,] values)
        {
            var r = (uint)values.GetUpperBound(0) + 1;
            var c = (uint)values.GetUpperBound(1) + 1;
            if (r == R && c == C)
                matrix = values;
            else
                throw new Exception($"Incorrect matrix size! values[{r},{c}] but matrix[{R},{C}]");
        }

        public uint GetR() => R;
        public uint GetC() => C;

        public object GetMatrix() => matrix;

        public double this[int x_key, int y_key]
        {
            get
            {
                if (matrix is double[,] arr)
                    return arr[x_key, y_key];
                else
                    throw new Exception($"Matrix is incorrect!");
            }
            set
            {
                if (matrix is double[,] arr)
                    arr[x_key, y_key] = value;
                else
                    throw new Exception($"Matrix is incorrect!");
            }
        }

        public Matrix()
        {
            
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.GetC() != B.GetR())
                throw new Exception($"Impossible to multiply. " +
                    $"Incorrect matrix sizes specified A[{A.GetR()},{A.GetC()}] B[{B.GetR()},{B.GetC()}]");

            var res = new Matrix(A.GetR(), B.GetC());

            for (int i = 0; i < A.GetR(); i++)
            {
                for (int j = 0; j < B.GetC(); j++)
                {
                    for (int k = 0; k < A.GetC(); k++)
                    {
                        res[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            return res;
        }

        public static bool operator ==(Matrix A, Matrix B)
        {
            return A.CompareTo(B);
        }

        public static bool operator !=(Matrix A, Matrix B)
        {
            return !A.CompareTo(B);
        }

        public bool CompareTo(Matrix m)
        {
            if (this.R != m.GetR())
                return false;
            if (this.C != m.GetC())
                return false;

            if (matrix is double[,] A && m.GetMatrix() is double[,] B)
            {
                for (int i = 0; i < this.R; i++)
                {
                    for(int j = 0; j < this.C; j++)
                    {
                        if (A[i, j] != B[i, j])
                            return false;
                    }
                }
                return true;
            }
            else 
                return false;
        }

        public bool isNull() => matrix == null;

        public override string ToString()
        {
            string ret = string.Empty;
            if (matrix is double[,] arr)
            {
                for (int i = 0; i < R; i++)
                {
                    for (int j = 0; j < C; j++)
                    {
                        ret += $"{arr[i, j]}" + (C - j > 1 ? ", " : "");
                    }
                    ret += R - i > 1 ? "\n" : "";
                }
                return ret;
            }
            return $"{matrix}";
        }
    }
}
