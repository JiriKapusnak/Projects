using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleTicTacToe
{
    /// <summary>
    /// Interakční logika pro Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridCreditsContainer.Visibility = Visibility.Collapsed;
        }

        private void challengeFriendButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of MainWindow and set it as main
            MainWindow mainWindow = new MainWindow(againstMachine: false);
            Application.Current.MainWindow = mainWindow;

            // show, activate mainwindow and close menu
            mainWindow.Show();
            mainWindow.Activate();
            this.Close();
        }

        private void faceTheMachineButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of MainWindow and set it as main
            MainWindow mainWindow = new MainWindow(againstMachine: true);
            Application.Current.MainWindow = mainWindow;

            // show, activate mainwindow and close menu
            mainWindow.Show();
            mainWindow.Activate();
            this.Close();
        }

        private void creditsButton_Click(object sender, RoutedEventArgs e)
        {
            gridCreditsContainer.Visibility = Visibility.Visible;
        }
    }
}
