using System;
using System.Collections.Generic;
using System.Drawing;
namespace GameOfLife
{
    public class Cell
    {
        public Point Position;

        public bool IsAlive { get; set; }

        public Cell(Point position,bool isalive)
        {
            Position = position;
            IsAlive = isalive;
        }
        
        }

    }

