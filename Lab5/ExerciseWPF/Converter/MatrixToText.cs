using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using MatrixCalculationsBL.Models;
using System.Linq;

namespace ExerciseWPF.Converter
{
    public class MatrixToText : IValueConverter
    {
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            uint x = 0;
            uint y = 0;
            if (value is string k)
            {
                k.Trim();
                var tmp = k.Split('\n');
                var arr = tmp[0].Split(',');
                x = (uint)tmp.Length;
                y = (uint)arr.Length;
                double[,] res = new double[x, y];
                for (int i = 0; i < tmp.Length; i++)
                {
                    arr = tmp[i].Split(',');
                    for (int j = 0; j < y; j++)
                    {
                        res[i, j] = double.Parse(arr[j]);
                    }
                }
                return new Matrix(res);
            }
            return new Matrix(x, y);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Matrix m)
            {
                return m.ToString();
            }
            return "Enter an array";
        }
    }
}
