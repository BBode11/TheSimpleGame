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
using TheSimpleGame.Models;

namespace TheSimpleGame.Presentation
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        GameViewModel _gameViewModel;
        public GameView(GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
            InitializeComponent();
        }
        /// <summary>
        /// Sets up the event handler for the buttons with the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameBoard_Click(object sender, RoutedEventArgs e)
        {
            Button boardPositionButton = sender as Button;
            int row = int.Parse(boardPositionButton.Tag.ToString().Substring(0, 1));
            int column = int.Parse(boardPositionButton.Tag.ToString().Substring(1, 1));

            _gameViewModel.PlayerMove(row, column);
        }
        /// <summary>
        /// Sets up the event handler for the window buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowButton_Click(object sender, RoutedEventArgs e)
        {
            Button windowButton = sender as Button;

            switch (windowButton.Name)
            {
                case "NewGame": 
                    _gameViewModel.GameCommand(windowButton.Name);
                    break;

                case "ResetGame":
                    _gameViewModel.GameCommand(windowButton.Name);
                    break;

                case "Help":
                    _gameViewModel.GameCommand(windowButton.Name);
                    break;

                case "Quit":
                    Close();
                    _gameViewModel.GameCommand(windowButton.Name);
                    break;
            }
        }
    }
}
