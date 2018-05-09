using System;
using System.Drawing;
using Console = Colorful.Console;

namespace FillBox
{
    internal class Program
    {
        public static void Print(int x, int y, string text, int pct)
        {
            Console.SetCursorPosition((int)x, (int)y);

            var factor = Convert.ToSingle(((Convert.ToDecimal(pct) / 100) * 2) - 1);
            var ori = Color.Red;
            var c = ColorHelper.ChangeColorBrightness(ori, factor);

            Console.Write(text, c);
        }

        private static void Main(string[] args)
        {
            Algorithm.FillBox board = new Algorithm.FillBox(8);
            board.Start(3, 4);

            var s = board.GetSolutions();
            foreach (var item in s)
            {
                var next = 0;
                var lastPosition = new System.Drawing.Point();

                var solutions = item.ToList();
                var pct = 0;
                foreach (var sol in solutions)
                {
                    next++;
                    pct = Convert.ToInt32((Convert.ToDecimal(100) / Convert.ToDecimal(16)) * next);

                    if (next == 1)
                    {
                        Print(sol.X, sol.Y, "@", pct);
                    }
                    else if (next == item.Count())
                    {
                        Print(sol.X, sol.Y, "*", pct);
                    }
                    else
                    {
                        if (sol.X + 1 == solutions[next].X)
                            Print(sol.X, sol.Y, "→", pct);
                        else if (sol.X - 1 == solutions[next].X)
                            Print(sol.X, sol.Y, "←", pct);
                        else if (sol.Y + 1 == solutions[next].Y)
                            Print(sol.X, sol.Y, "↓", pct);
                        else if (sol.Y - 1 == solutions[next].Y)

                            Print(sol.X, sol.Y, "↑", pct);
                    }

                    lastPosition = sol;
                }
            }

            Console.SetCursorPosition(0, board.Height + 1);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}