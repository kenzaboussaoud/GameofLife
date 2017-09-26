using System;
namespace GameOfLife
{
    public class Game
    {
        public int Lignes { get; set; }
        public int Cellules{ get; set; }

        public Game(int lignes, int cellules)
        {
            Lignes = lignes;
            Cellules = cellules;
            if (lignes <= 0 || cellules <= 0) throw new ArgumentOutOfRangeException("Ligne et Colonne doit etre > que 0");
            //InputGrid = new Grid();//new Grid(lignes, cellules);
            //OutputGrid = new Grid();// new Grid(lignes, cellules);
        }

        // max number of gen L

    }
}
