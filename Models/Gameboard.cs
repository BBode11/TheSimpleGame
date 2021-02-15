using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSimpleGame.Presentation;

namespace TheSimpleGame.Models
{
    public class Gameboard : ObservableObjects
    {
        #region ENUMS
        //game pieces
        public const string PLAYER_PIECE_X = "X";
        public const string PLAYER_PIECE_O = "O";
        public const string PLAYER_PIECE_NONE = "";

        public enum GameBoardState
        {
            // all of the possible outcomes of tic tac toe
            NewRound,
            PlayerOTurn,
            PlayerXTurn,
            PlayerOWin,
            PlayerXWin,
            CatGame
        }
        #endregion
        #region FIELDS
        //set the max number of rows and columns
        private const int MAX_NUMBER_OF_ROWS_COLUMNS = 4;
        private string[][] _currentBoard;
        #endregion

        #region PROPERTIES

        public int MaxNumberOfRowsColumns
        {
            get { return MAX_NUMBER_OF_ROWS_COLUMNS; }
        }

        public string[][] CurrentBoard
        {
            get { return _currentBoard; }
            set
            {
                _currentBoard = value;
                OnPropertyChanged(nameof(CurrentBoard));
            }
        }
        
        public GameBoardState CurrentRoundState { get; set; }
        #endregion

        #region CONSTRUCTORS

        public Gameboard()
        {
            CurrentBoard = new string[4][];
            CurrentBoard[0] = new string[4];
            CurrentBoard[1] = new string[4];
            CurrentBoard[2] = new string[4];
            CurrentBoard[3] = new string[4];

            InitializeGameboard();
        }
        #endregion
        #region METHODS
        /// <summary>
        /// Clear the board by setting enum values to an empty string
        /// </summary>
        public void InitializeGameboard()
        {
            CurrentRoundState = GameBoardState.NewRound;
            //clear off gameboard to start a game
            for (int row = 0; row < MAX_NUMBER_OF_ROWS_COLUMNS; row++)
            {
                for (int column = 0; column < MaxNumberOfRowsColumns; column++)
                {
                    CurrentBoard[row][column] = PLAYER_PIECE_NONE;
                    //sets all the gamebooard buttons to empty strings
                }
            }
        }

        /// <summary>
        /// method used to see if positions are taken on the gameboard
        /// </summary>
        /// <param name="gameboardPosition"></param>
        /// <returns>True if there are positions available on board</returns>
        public bool GameboardPositionAvailability(GameboardPosition gameboardPosition)
        {
            //check if board is empty
            if (CurrentBoard[gameboardPosition.Row][gameboardPosition.Column] == PLAYER_PIECE_NONE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Method to figure out who wins
        /// </summary>
        public void UpdateGameBoardState()
        {
            //player x wins
            if (FourInARow(PLAYER_PIECE_X))
            {
                CurrentRoundState = GameBoardState.PlayerXWin;
            }
            //player o wins
            else if (FourInARow(PLAYER_PIECE_O))
            {
                CurrentRoundState = GameBoardState.PlayerOWin;
            }
            //cat game
            else if (IsCat())
            {
                CurrentRoundState = GameBoardState.CatGame;
            }
        }
        /// <summary>
        /// Check for four in a row within columns, rows and diagonals
        /// </summary>
        /// <param name="playerPieceToCheck"></param>
        /// <returns></returns>
        private bool FourInARow(string playerPieceToCheck)
        {
            //loop through rows to find four in a row
            for (int row = 0; row < 4; row++)
            {
                if (CurrentBoard[row][0] == playerPieceToCheck &&
                    CurrentBoard[row][1] == playerPieceToCheck &&
                    CurrentBoard[row][2] == playerPieceToCheck &&
                    CurrentBoard[row][3] == playerPieceToCheck)
                {
                    return true;
                }
            }

            //loop through columns to find four in a row
            for (int column = 0; column < 4; column++)
            {
                if (CurrentBoard[0][column] == playerPieceToCheck &&
                    CurrentBoard[1][column] == playerPieceToCheck &&
                    CurrentBoard[2][column] == playerPieceToCheck &&
                    CurrentBoard[3][column] == playerPieceToCheck)
                {
                    return true;
                }
            }
            //check all diagonals for four in a row
            if ((CurrentBoard[0][0] == playerPieceToCheck &&
                CurrentBoard[1][1] == playerPieceToCheck &&
                CurrentBoard[2][2] == playerPieceToCheck &&
                CurrentBoard[3][3] == playerPieceToCheck)
                ||
                (CurrentBoard[0][3] == playerPieceToCheck &&
                CurrentBoard[1][2] == playerPieceToCheck &&
                CurrentBoard[2][1] == playerPieceToCheck &&
                CurrentBoard[3][0] == playerPieceToCheck)
                )
            {
                return true;
            }
            //check the four corners
            if (CurrentBoard[0][0] == playerPieceToCheck &&
                CurrentBoard[0][3] == playerPieceToCheck &&
                CurrentBoard[3][0] == playerPieceToCheck &&
                CurrentBoard[3][3] == playerPieceToCheck)
            {
                return true;
            }
            //when no one has won return false
            return false;
        }
        /// <summary>
        /// Checks for a cat game
        /// </summary>
        /// <returns></returns>
        public bool IsCat()
        {
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    if (CurrentBoard[row][column] == PLAYER_PIECE_NONE)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Add move to gameboard
        /// </summary>
        /// <param name="gameboardPosition"></param>
        /// <param name="PlayerPiece"></param>
        public void SetPlayerPiece(GameboardPosition gameboardPosition, string PlayerPiece)
        {
            //used to match array structure
            CurrentBoard[gameboardPosition.Row][gameboardPosition.Column] = PlayerPiece;

            //switch to the next player
            SetNextPlayer();
        }
        /// <summary>
        /// Method used to switch between players
        /// </summary>
        public void SetNextPlayer()
        {
            if (CurrentRoundState == GameBoardState.PlayerXTurn)
            {
                CurrentRoundState = GameBoardState.PlayerOTurn;
            }
            else
            {
                CurrentRoundState = GameBoardState.PlayerXTurn;
            }
        }


        #endregion
    }
}
