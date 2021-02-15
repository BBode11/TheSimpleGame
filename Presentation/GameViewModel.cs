using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSimpleGame.Models;

namespace TheSimpleGame.Presentation
{
    public class GameViewModel : ObservableObjects
    {
        private Gameboard _gameboard;
        //fileIO can be added to track wins and losses
        private Player _playerX;
        private Player _playerO;
        private string _messageBoxContent;

        public Gameboard Gameboard
        {
            get { return _gameboard; }
            set
            {
                _gameboard = value;
                OnPropertyChanged(nameof(Gameboard));
            }
        }
        public Player PlayerX
        {
            get { return _playerX; }
            set
            {
                _playerX = value;
                OnPropertyChanged(nameof(PlayerX));
            }
        }
        public Player PlayerO
        {
            get { return _playerO; }
            set
            {
                _playerO = value;
                OnPropertyChanged(nameof(PlayerO));
            }
        }

        public string MessageBoxContent
        {
            get { return _messageBoxContent; }
            set
            {
                _messageBoxContent = value;
                OnPropertyChanged(nameof(MessageBoxContent));
            }
        }
        public GameViewModel()
        {
            InitializeGame();
        }
        /// <summary>
        /// sets up the game board and game
        /// </summary>
        private void InitializeGame()
        {
            _gameboard = new Gameboard();

            _gameboard.CurrentRoundState = Gameboard.GameBoardState.PlayerXTurn;
            MessageBoxContent = "Player X Move";
        }
        /// <summary>
        /// Method used for which players turn it is and what game piece is being placed
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void PlayerMove(int row, int column)
        {
            if (_gameboard.GameboardPositionAvailability(new GameboardPosition(row, column)))
            {
                if (_gameboard.CurrentRoundState == Gameboard.GameBoardState.PlayerXTurn)
                {
                    Gameboard.CurrentBoard[row][column] = Gameboard.PLAYER_PIECE_X;
                    OnPropertyChanged(nameof(Gameboard));
                    _gameboard.CurrentRoundState = Gameboard.GameBoardState.PlayerOTurn;
                    MessageBoxContent = "Player O Move";
                }
                else
                {
                    Gameboard.CurrentBoard[row][column] = Gameboard.PLAYER_PIECE_O;
                    OnPropertyChanged(nameof(Gameboard));
                    _gameboard.CurrentRoundState = Gameboard.GameBoardState.PlayerXTurn;
                    MessageBoxContent = "Player X Move";
                }
                UpdateCurrentRoundState();
            }
        }
        /// <summary>
        /// Method to see if any player has won and returns a message
        /// </summary>
        public void UpdateCurrentRoundState()
        {
            _gameboard.UpdateGameBoardState();
            if (_gameboard.CurrentRoundState == Gameboard.GameBoardState.CatGame)
            {
                MessageBoxContent = "Cat Game";
            }
            else if (_gameboard.CurrentRoundState == Gameboard.GameBoardState.PlayerXWin)
            {
                MessageBoxContent = "Player X Wins!";
            }
            else if (_gameboard.CurrentRoundState == Gameboard.GameBoardState.PlayerOWin)
            {
                MessageBoxContent = "Player O Wins!";
            }
        }
        /// <summary>
        /// Method for the window button functionality
        /// </summary>
        /// <param name="commandName"></param>
        internal void GameCommand(string commandName)
        {
            switch (commandName)
            {
                case "NewGame":
                    
                    _gameboard.InitializeGameboard();
                    OnPropertyChanged(nameof(Gameboard));

                    _gameboard.CurrentRoundState = Gameboard.GameBoardState.PlayerXTurn;
                    MessageBoxContent = "Player X Move";
                    break;

                case "ResetGame":
                    _gameboard.InitializeGameboard();
                    OnPropertyChanged(nameof(Gameboard));

                    _gameboard.CurrentRoundState = Gameboard.GameBoardState.PlayerXTurn;
                    MessageBoxContent = "Player X Move";
                    break;

                case "Quit":
                    //System.Windows.Application.Current.Shutdown();
                    break;

                case "Help":
                    HelpWindow helpwindow = new HelpWindow();
                    helpwindow.ShowDialog();
                    break;

                default:
                    _gameboard.InitializeGameboard();
                    OnPropertyChanged(nameof(Gameboard));

                    _gameboard.CurrentRoundState = Gameboard.GameBoardState.PlayerXTurn;
                    MessageBoxContent = "Player X Move";
                    break;
            }
        }
    }
}
