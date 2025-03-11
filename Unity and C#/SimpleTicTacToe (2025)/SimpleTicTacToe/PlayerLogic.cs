namespace SimpleTicTacToe
{
    /// <summary>
    /// Class that holds every logic behind the players
    /// </summary>
    public class PlayerLogic
    {
        /// <summary>
        /// Enum with the information which player is playing at the moment
        /// </summary>
        public enum Player
        {
            None,
            Crosses,
            Circles
        }

        private Player currentPlayer;

        /// <summary>
        /// Just 2 booleans to get which player is playing right
        /// </summary>
        public bool IsPlayingCross => currentPlayer == Player.Crosses;
        public bool IsPlayingCircles => currentPlayer == Player.Circles;

        public PlayerLogic(Player pDesiredPlayer)
        {
            // Set the initial player
            currentPlayer = pDesiredPlayer;
        }

        /// <summary>
        /// Method to get the current player
        /// </summary>
        /// <returns></returns>
        public Player GetCurrentPlayer()
        {
            return currentPlayer;
        }

        /// <summary>
        /// Method to SwitchPlayer
        /// </summary>
        public void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == Player.Crosses) ? Player.Circles : Player.Crosses;
        }
    }
}
