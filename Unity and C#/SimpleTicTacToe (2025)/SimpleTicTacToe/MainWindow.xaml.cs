using System.Security.Permissions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static SimpleTicTacToe.PlayerLogic;

namespace SimpleTicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Instances
        PlayerLogic playerLogic { get; set; }
        GameLogic game { get; set; }

        // Fields
        private bool _isWon { get; set; }
        private bool _isTied { get; set; }

        // Fields that are used only in case if playing vs machine
        private bool _againstMachine { get; set; }
        private Player _chosenSide { get; set; }

        public MainWindow(bool againstMachine = false, Player chosenSide = Player.Crosses)
        {
            InitializeComponent();
            playerLogic = new PlayerLogic(chosenSide);
            game = new GameLogic();
            _isWon = false;
            _isTied = false;
            _againstMachine = againstMachine;
            _chosenSide = chosenSide;    
        }

        /// <summary>
        /// Method that holds a logic behind what will happen when user clicks on rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickGrid(object sender, MouseButtonEventArgs e)
        {
            

            // checking if game is not already done (and waiting for restart)
            if (!_isWon && !_isTied) 
            {
                // if against the machine, check if correct side is chosen
                if (_againstMachine && _chosenSide != playerLogic.GetCurrentPlayer())
                {
                    return;
                }

                // Gets number of row and column user clicked on
                string? grid = DesignLogic.GetGrid(sender);

                // Checking if Grid is not null
                if (grid != null)
                {
                    DesignLogic.SetImageToGridAndSwitchPlayer(grid, playerLogic, game);

                    // Checking if the game is won or tied
                    if (game.IsWin(playerLogic))
                    {
                        _isWon = true;
                        DesignLogic.PrepareAndShowGridGameDoneContainer(playerLogic.GetCurrentPlayer());
                    }
                    else if (game.IsGameTie())
                    {
                        _isTied = true;
                        DesignLogic.PrepareAndShowGridGameDoneContainer();
                    }
                    if (_againstMachine)
                    {
                        GameLogic.MakeAIMove();
                    }
                    else
                    {
                        // Switching player as the last thing
                        DesignLogic.SwitchPlayer(playerLogic, game);
                    }
                }
            }
        }

        /// <summary>
        /// Handles AI's move if playing vs machine.
        /// </summary>
        private void MakeAIMove()
        {
            // Check if the game is still running before AI makes a move
            if (_isWon || _isTied) return;

            // AI selects a move (assuming you have some AI logic in GameLogic)
            string aiMove = game.GetBestMove(); // Implement AI logic in GameLogic

            if (!string.IsNullOrEmpty(aiMove))
            {
                DesignLogic.SetImageToGridAndSwitchPlayer(aiMove, playerLogic, game);

                // Check again if the AI won or tied the game
                if (game.IsWin(playerLogic))
                {
                    _isWon = true;
                    DesignLogic.PrepareAndShowGridGameDoneContainer(playerLogic.GetCurrentPlayer());
                }
                else if (game.IsGameTie())
                {
                    _isTied = true;
                    DesignLogic.PrepareAndShowGridGameDoneContainer();
                }
            }
        }

        /// <summary>
        /// Grey restart button in upper grey corner.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickRestartButton(object sender, MouseButtonEventArgs e)
        {
            DesignLogic.CollapseGrid();
            DesignLogic.FullyRestartGame(game);
            _isWon = false;
            _isTied = false;
        }

        /// <summary>
        /// Next game button that appears after each game player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextGameButton_Click(object sender, RoutedEventArgs e)
        {
            DesignLogic.CreateNewGameAndAddScore(game, _isWon ? playerLogic.GetCurrentPlayer() : PlayerLogic.Player.None);
            DesignLogic.SwitchPlayer(playerLogic, game);
            _isWon = false;
            _isTied = false;
        }
    }
}
