using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSimpleGame.Models
{
    /// <summary>
    /// Stores the location of a player's piece within the struct
    /// </summary>
    public struct GameboardPosition
    {
        // setting the rows and columns
        public int Row { get; set; }
        public int Column { get; set;}

        public GameboardPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
