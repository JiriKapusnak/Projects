using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Formats.Asn1.AsnWriter;
using static SimpleTicTacToe.PlayerLogic;

namespace SimpleTicTacToe
{
    /// <summary>
    /// Class that holds every logic behind the design and interactions with it
    /// </summary>
    public class DesignLogic
    {
        // Constants
        const string CIRCLES_SCORE_CONTROLLER = "CircleScore";
        const string TIES_SCORE_CONTROLLER = "TiesScore";
        const string CROSSES_SCORE_CONTROLLER = "CrossesScore";

        /// <summary>
        /// Returns last 2 digits of name of the rectangle user clicked on
        /// Name may be for example: Grid01, Grid02, so this method return just "01" or "02"
        /// </summary>
        /// <param name="pSender"></param>
        /// <returns></returns>
        public static string? GetGrid(object pSender)
        {
            if (pSender is Rectangle clickedRectangle)
            {
                int row = int.Parse(clickedRectangle.Name.Substring(4, 1));
                int column = int.Parse(clickedRectangle.Name.Substring(5, 1));

                // returning row and column numbers
                return $"{row}{column}";
            }

            return null;
        }

        /// <summary>
        /// Sets a desired image (Cross or Circle) depending on which player is playing
        /// </summary>
        /// <param name="pGrid"></param>
        public static void SetImageToGridAndSwitchPlayer(string pGrid, PlayerLogic pPlayer, GameLogic pGame)
        {
            // Create the control name based on pGrid
            string xGridImage = "ImageOverlay" + pGrid;
            string xGridRectagle = "Grid" + pGrid;

            // Find the control with the generated name
            Image? xImage = Application.Current.MainWindow.FindName(xGridImage) as Image;
            Rectangle? xRectangle = Application.Current.MainWindow.FindName(xGridRectagle) as Rectangle;

            // Ensure the control is found and then set its properties
            if (xImage != null && xRectangle != null)
            {
                // Set the image source based on the current player
                if (pPlayer.IsPlayingCross)
                    xImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/cross.png"));
                else if (pPlayer.IsPlayingCircles)
                    ¨,0
                    xImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/circle.png"));

                // Set the image properties
                xImage.Stretch = Stretch.Fill;
                xImage.HorizontalAlignment = HorizontalAlignment.Left;
                xImage.VerticalAlignment = VerticalAlignment.Top;
                xImage.Width = xRectangle.ActualWidth - 30;
                xImage.Height = xRectangle.ActualHeight - 30;
                xImage.Margin = new Thickness(xRectangle.Margin.Left + 15, xRectangle.Margin.Top + 15, 0, 0);
                xImage.Visibility = Visibility.Visible;

                // Setting the symbol on the grid
                pGame.SetSymbol(pGrid, pPlayer.GetCurrentPlayer());
            }
        }

        /// <summary>
        /// Method that changed the visibility of "whoWon" containers
        /// </summary>
        public static void PrepareAndShowGridGameDoneContainer(Player player = Player.None)
        {
            // loading everything that needs to be change
            Grid? crossesGrid = Application.Current.MainWindow.FindName("gridGameDoneContainer") as Grid;
            Image? image = Application.Current.MainWindow.FindName("whoWonImage") as Image;
            TextBlock? textBlock = Application.Current.MainWindow.FindName("whoWonTextBox") as TextBlock;
            Button? button = Application.Current.MainWindow.FindName("nextGameButton") as Button;

            // Preparing grid depending on who won or if its tie
            if (player == Player.Crosses)
            {
                image.Source = new BitmapImage(new Uri("pack://application:,,,/images/cross.png", UriKind.Absolute));
                textBlock.Foreground = new SolidColorBrush(Colors.Crosses);
                textBlock.Text = "Won";
                button.Foreground = new SolidColorBrush(Colors.Crosses);
            }
            else if (player == Player.Circles)
            {
                image.Source = new BitmapImage(new Uri("pack://application:,,,/images/circle.png", UriKind.Absolute));
                textBlock.Foreground = new SolidColorBrush(Colors.Circles);
                textBlock.Text = "Won";
                button.Foreground = new SolidColorBrush(Colors.Circles);
            }
            else if (player == Player.None)
            {
                image.Source = new BitmapImage(new Uri("pack://application:,,,/images/tie.png", UriKind.Absolute));
                textBlock.Foreground = new SolidColorBrush(Colors.Tie);
                textBlock.Text = "Tie";
                button.Foreground = new SolidColorBrush(Colors.Tie);
            }
            crossesGrid.Visibility = Visibility.Visible;
        }

        public static void SwitchPlayer(PlayerLogic pPlayer, GameLogic pGame)
        {
            pPlayer.SwitchPlayer();
            ChangeTextTurn(pPlayer);
        }

        /// <summary>
        /// Starts a new game and add score to designated textBox -> Circles, Crosses or Ties
        /// </summary>
        /// <param name="game"></param>
        /// <param name="winningPlayer"></param>
        public static void CreateNewGameAndAddScore(GameLogic game, Player winningPlayer = Player.None)
        {
            // wiping mainGrid
            WipeGrid();

            // Making nextGameGrid not visible again
            CollapseGrid();

            // Reseting grid in GameLogic
            game.ResetGrid();
            AddScoreToDesiredTextBox(winningPlayer);
        }

        /// <summary>
        /// Method that fully restarts the game.
        /// </summary>
        /// <param name="game"></param>
        public static void FullyRestartGame(GameLogic game)
        {
            // wiping mainGrid
            WipeGrid();

            // resetting mainGrid in GameLogic
            game.ResetGrid();

            // setting score to 0
            string[] textBlocks = new string[3] { CIRCLES_SCORE_CONTROLLER,  CROSSES_SCORE_CONTROLLER, TIES_SCORE_CONTROLLER};
            foreach (string textBlock in textBlocks)
            {
                TextBlock? textContext = Application.Current.MainWindow.FindName(textBlock) as TextBlock;
                if (textContext != null)
                {
                    textContext.Text = "0";
                }
            }
        }

        /// <summary>
        /// Method that converts grid position to pixel position
        /// </summary>
        /// <param name="gridPos"></param>
        /// <returns></returns>
        public static Point ConvertGridToPixel(Point gridPos)
        {
            int cellSize = 100; // Assuming each cell is 100x100 pixels
            int x = (int)(gridPos.X * cellSize + cellSize / 2);
            int y = (int)(gridPos.Y * cellSize + cellSize / 2);
            return new Point(x, y);
        }

        /// <summary>
        /// Add +1 score to desired textbox
        /// </summary>
        private static void AddScoreToDesiredTextBox(Player winningPlayer)
        {
            string textBoxName = GetTextBoxNameFromWinningPlayer(winningPlayer);
            TextBlock? textContext = Application.Current.MainWindow.FindName(textBoxName) as TextBlock;

            if (textContext != null)
            {
                // Parse the text content as an integer
                if (int.TryParse(textContext.Text, out int score))
                {
                    // Increment the score by 1
                    score++;

                    // Update the Text property with the new score
                    textContext.Text = score.ToString();
                }
            }
        }

        /// <summary>
        /// Method that returns the name of the textbox based on the winning player
        /// </summary>
        /// <param name="winningPlayer"></param>
        /// <returns></returns>
        private static string GetTextBoxNameFromWinningPlayer(Player winningPlayer)
        {
            if (winningPlayer == Player.Crosses)
            {
                return CROSSES_SCORE_CONTROLLER;
            }
            else if (winningPlayer == Player.Circles)
            {
                return CIRCLES_SCORE_CONTROLLER;
            }
            else
            {
                return TIES_SCORE_CONTROLLER;
            }
        }

        /// <summary>
        /// Method that changes text in box above the game depending on which turn it is
        /// </summary>
        private static void ChangeTextTurn(PlayerLogic pPlayer)
        {
            TextBlock? xTextContent = Application.Current.MainWindow.FindName("WhichTurnText") as TextBlock;

            if (xTextContent != null)
            {
                if (pPlayer.IsPlayingCross)
                    xTextContent.Text = "X";

                else if (pPlayer.IsPlayingCircles)
                    xTextContent.Text = "O";
            }
        }

        /// <summary>
        /// Used for restarting the game, makes the grid not visible and hides it behind the game
        /// </summary>
        public static void CollapseGrid()
        {
            Grid? grid = Application.Current.MainWindow.FindName("gridGameDoneContainer") as Grid;

            if (grid != null)
                grid.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Wipes the gaming board.
        /// </summary>
        private static void WipeGrid()
        {
            // For every row in grid
            for (int i = 0; i < 3; i++)
            {
                // For every column in grid
                for (int j = 0; j < 3; j++)
                {
                    // We will set image back to not visible
                    string xGridImage = "ImageOverlay" + i + j;
                    Image? xImage = Application.Current.MainWindow.FindName(xGridImage) as Image;

                    if (xImage != null)
                        xImage.Visibility = Visibility.Collapsed;
                }
            }
        }
    }

    /// <summary>
    /// Class to save colours cause I cant simply create color constants
    /// </summary>
    public static class Colors
    {
        public static readonly Color Crosses = (Color)ColorConverter.ConvertFromString("#f5b133");
        public static readonly Color Circles = (Color)ColorConverter.ConvertFromString("#31c4be");
        public static readonly Color Tie = (Color)ColorConverter.ConvertFromString("#a8bec9");
    }
}
