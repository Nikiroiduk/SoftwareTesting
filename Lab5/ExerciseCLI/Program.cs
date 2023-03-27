using ExerciseWPF;
using System;

namespace ExerciseCLI
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            object mA = null, mB = null;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-help")
                {
                    ShowHelp();
                }
                if (args[i] == "-a")
                {
                    if (i + 1 >= args.Length)
                    {
                        Console.WriteLine("Wrong parameters");
                        break;
                    }
                    var text = args[i + 1];
                    var arr = text.Split('\\');
                    var x = arr.Length;
                    var y = arr[0].Split(',').Length;
                    var res = new double[x, y];
                    for (int k = 0; k < x; k++)
                    {
                        var tmp = arr[k].Split(',');
                        for (int j = 0; j < y; j++)
                        {
                            res[k, j] = double.Parse(tmp[j]);
                        }
                    }
                    mA = res;
                }
                if (args[i] == "-b")
                {
                    if (i + 1 >= args.Length)
                    {
                        Console.WriteLine("Wrong parameters");
                        break;
                    }
                    var text = args[i + 1];
                    var arr = text.Split('\\');
                    var x = arr.Length;
                    var y = arr[0].Split(',').Length;
                    var res = new double[x, y];
                    for (int k = 0; k < x; k++)
                    {
                        var tmp = arr[k].Split(',');
                        for (int j = 0; j < y; j++)
                        {
                            res[k, j] = double.Parse(tmp[j]);
                        }
                    }
                    mB = res;
                }
            }

            Console.WriteLine("Starting ExerciseWPF.exe...");
            var application = new App();
            if (mA is double[,] a && mB is double[,] b)
                application.Run(new MainWindow(isTesting: true, a, b));
            else
                application.Run(new MainWindow());
            Console.WriteLine("Exited.");
        }

        private static void ShowHelp()
        {
            Console.WriteLine($"help message");
        } 
    }
}
