using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class FillBox
    {
        public int Height;

        public List<PathBox> Results;

        public int Width;

        private int blocks;

        private int diagnonalSize;

        public FillBox(int diagnonalSize)
        {
            this.diagnonalSize = diagnonalSize;
            this.Width = diagnonalSize;
            this.Height = diagnonalSize;
            this.blocks = diagnonalSize * diagnonalSize;
            this.Results = new List<PathBox>();
        }

        public List<PathBox> GetSolutions()
        {
            return this.Results.Where(o => o.Count() == this.blocks).ToList();
        }

        public void Start(uint x, uint y)
        {
            Console.Clear();
            PathBox paths = new PathBox();
            Walk(x, y, paths);
        }

        private void Walk(uint x, uint y, PathBox paths)
        {
            if (Results.Count() > 0)
                return;

            paths.Add(x, y);

            bool hasExit = false;

            // Go right
            if (x + 1 <= this.Width && paths.Exist(x + 1, y))
            {
                hasExit = true;
                Walk(x + 1, y, paths.Clone());
            }

            // Go down
            if (y + 1 <= this.Height && paths.Exist(x, y + 1))
            {
                hasExit = true;
                Walk(x, y + 1, paths.Clone());
            }

            // Go left
            if (x - 1 >= 1 && paths.Exist(x - 1, y))
            {
                hasExit = true;
                Walk(x - 1, y, paths.Clone());
            }

            // Go up
            if (y - 1 >= 1 && paths.Exist(x, y - 1))
            {
                hasExit = true;
                Walk(x, y - 1, paths.Clone());
            }

            if (!hasExit)
                if (paths.Count() == this.blocks)
                    Results.Add(paths);
        }

        public class PathBox
        {
            private List<System.Drawing.Point> paths;

            public PathBox()
            {
                this.paths = new List<System.Drawing.Point>();
            }

            public void Add(uint x, uint y)
            {
                this.paths.Add(new System.Drawing.Point((int)x, (int)y));
            }

            public PathBox Clone()
            {
                var pathBox = new PathBox();
                foreach (var item in this.paths.GetRange(0, paths.Count))
                {
                    pathBox.Add((uint)item.X, (uint)item.Y);
                }

                return pathBox;
            }

            public int Count()
            {
                return this.paths.Count;
            }

            public bool Exist(uint x, uint y)
            {
                return !this.paths.Any(w => w.X == x && w.Y == y);
            }

            public List<System.Drawing.Point> ToList()
            {
                return this.paths;
            }
        }
    }
}