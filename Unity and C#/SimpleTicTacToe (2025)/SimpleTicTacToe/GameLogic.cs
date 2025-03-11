using static SimpleTicTacToe.PlayerLogic;

namespace SimpleTicTacToe
{
    /// <summary>
    /// Class that holds every logic behind the game itself
    /// </summary>
    public class GameLogic
    {
        private Player[,] fGrid; // 3x3 array to represent the game board
        private int GRID_SIZE = 3; // Size of the grid

        public GameLogic()
        {
            // Initialize the grid
            fGrid = new Player[GRID_SIZE, GRID_SIZE];
        }

        /// <summary>
        /// Method to set the symbol (cross or circle) on the grid
        /// </summary>
        /// <param name="xRow"></param>
        /// <param name="xColumn"></param>
        /// <param name="pPlayer"></param>
        public void SetSymbol(string pGrid, Player pPlayer)
        {
            // Get row and column from pGrid
            int xRow = int.Parse(pGrid.Substring(0, 1));
            int xColumn = int.Parse(pGrid.Substring(1, 1));

            // Ensure the position is valid and not already occupied
            if ((xRow >= 0 && xRow < GRID_SIZE) && (xColumn >= 0) && (xColumn < GRID_SIZE) && (fGrid[xRow, xColumn] != Player.Crosses && fGrid[xRow, xColumn] != Player.Circles))
                fGrid[xRow, xColumn] = pPlayer;
        }

        /// <summary>
        /// Method that checks if the game is won by a circles
        /// Saves the start and end point of the winning line
        /// </summary>
        /// <returns></returns>
        public bool IsWin(PlayerLogic playerLogic)
        {
            Player player = playerLogic.GetCurrentPlayer();

            // Check rows
            for (int i = 0; i < GRID_SIZE; i++)
            {
                if (fGrid[i, 0] == player && fGrid[i, 1] == player && fGrid[i, 2] == player)
                {
                    return true;
                }
            }

            // Check columns
            for (int j = 0; j < GRID_SIZE; j++)
            {
                if (fGrid[0, j] == player && fGrid[1, j] == player && fGrid[2, j] == player)
                {
                    return true;
                }
            }

            // Check main diagonal
            if (fGrid[0, 0] == player && fGrid[1, 1] == player && fGrid[2, 2] == player)
            {
                return true;
            }

            // Check anti-diagonal
            if (fGrid[0, 2] == player && fGrid[1, 1] == player && fGrid[2, 0] == player)
            {
                return true;
            }

            return false; // No win condition found
        }

        /// <summary>
        /// Method that checks if the game is tied
        /// </summary>
        /// <returns></returns>
        public bool IsGameTie()
        {
            // Check if all positions are occupied
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    if (fGrid[i, j] != Player.Crosses && fGrid[i, j] != Player.Circles)
                        return false; // Found empty position, game is not a tie yet
                }
            }

            return true; // All positions are occupied, game is a tie
        }

        public static void GetBestMove()
        {

        }

        /// <summary>
        /// Resseting grid back to 0
        /// </summary>
        public void ResetGrid()
        {
            fGrid = new Player[GRID_SIZE, GRID_SIZE];
        }
    }
}
