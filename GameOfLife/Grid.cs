using System;
using System.Collections.Generic;
using System.Drawing;
namespace GameOfLife
{
    enum CellState { alive, dead };

    public class Grid
    {
        public Point Size { get; set; }
        public List<List<Cell>> cells { get; set; }

        public Grid(List<List<int>> cellArray)
        {
            Size = new Point(cellArray.Count, cellArray[cellArray.Count - 1].Count);

            cells = new List<List<Cell>>(Size.X);
            for (int i = 0; i < Size.X; i++)
            {
                cells.Add(new List<Cell>(Size.Y));
            }



            for (int i = 0; i < Size.X; i++) {
                for (int j = 0; j < Size.Y; j++) {
    				if (cellArray[i][j] == 0)
    				{
    					cells[i].Add(new Cell(new Point(i, j), false));
    				}
    				else
    				{
    					cells[i].Add(new Cell(new Point(i, j), true));
    				}
				}
			}
         }


        //Methode display 
        public void Display()
        {
            foreach (List<Cell> cellList in cells)
            {

				foreach (Cell cell in cellList)
				{

					if (cell.IsAlive)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
				Console.WriteLine();

			}



        }


        //ethode livingneighbors
        public int LivingNeighbors(int i, int j)
        {
            int count = 0;

            for (int x = i - 1; x < i + 1; x++)
            {
                for (int y = j - 1; y < j + 1;y++)
                {
                    if (cells[(x+Size.X)%Size.X][(y+Size.Y)% Size.Y].IsAlive)
                        count++;
                    
                }
            }
            return count;

        }
        //Methode evolve : rules of the game
        public void Evolve()
        {
            var newcells = new List<List<Cell>>(Size.X);
            for (int i = 0; i < Size.X; i++)
            {				
                newcells.Add(new List<Cell>(Size.Y));
                for (int j = 0; j < Size.Y; j++)
                {
                    bool living = cells[i][j].IsAlive; // cell's current state?
                    int count = LivingNeighbors(i, j);  //count cell's living neighbors
                    bool result = false;

                    if (living && count < 2)    //apply the rules
                        result = false;
                    if (living && (count == 2 || count == 3))
                        result = true;
                    if (living && count > 3)
                        result = false;
                    if (!living && count == 3)
                        result = true;

                    var cellule = new Cell(new Point(), result);
                    newcells[i].Add(cellule);
                  
                }
            }

			cells = newcells;
		}
        public bool AnyALive()
        {
            bool result = false;
            foreach (List<Cell> cellList in cells)
            {
                foreach (Cell cell in cellList)
                {
                    if (!cell.IsAlive)
                    {
                        continue;    
                    }
                    else
                    {
                        result = true;
                    }
            
                }
                }
            return result;

            }
        }
    }