using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {// initial state
            int[][] gridRepresentationArray =
            new int[][]{ new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[]{ 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
            new int[]{ 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[]{ 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
            new int[]{ 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
            new int[]{ 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            new int[]{ 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            // Instantiate arrays 
            var size = new Point(25, 60);
            var cellsLines = new List<List<int>>(size.X);

            //cellsBuffer = new Listt<bool>(360);

            var random = new Random();
			// Initialization of cells
            for (int x = 0; x < size.X; x++)
			{
                cellsLines.Add(new List<int>(size.Y));
                for (int y = 0; y < size.Y; y++)
				{
                    int state = random.Next(100);
					if (state > 15)
					{
						state = 0;
					}
					else
					{
						state = 1;
					}
                    cellsLines[x].Add(state); // Save state of each cell
				}
			}

			Grid grid = new Grid(cellsLines);//new Grid(gridRepresentationArray;

            int i = 1;
			Console.WriteLine("State before evolution");
            grid.Display();

			while (grid.AnyALive())
            {
                Console.WriteLine("State after {0} evolution",i);
				grid.Display();
				grid.Evolve();
                i++;

                Task.Delay(1000).Wait();

            }
                Console.Clear();
            grid.Display();
        }
    }
}