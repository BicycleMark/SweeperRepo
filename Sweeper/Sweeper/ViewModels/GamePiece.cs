using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using Sweeper.ViewModels;

namespace Sweeper.ViewModels
{
    public partial class GamePiece : INotifyPropertyChanged

    {
        static Sweeper.ViewModels.SweeperViewModel gameBoard = null;
        public GamePiece(int nItem, GameConstants.PieceValues pv)
        {
            linearIndex = nItem;
            isPlayed    = false;
            value = pv;

        }

        public GamePiece(ViewModels.SweeperViewModel sweeperViewModel, int p, int r, int c, GameConstants.PieceValues actualValue)
        {
            // TODO: Complete member initialization
            this.sweeperViewModel = sweeperViewModel;
            linearIndex = p;
            this.r = r;
            this.c = c;
            value = GameConstants.PieceValues.BUTTON;
            if (gameBoard == null)
                gameBoard = sweeperViewModel;
        }
        private int linearIndex;

        public int LinearIndex
        {
            get { return linearIndex; }
            set { linearIndex = value; }
        }
        private bool isPlayed = false;

        public bool IsPlayed
        {
            get { return isPlayed; }
            set { isPlayed = value; }
        }
        private GameConstants.PieceValues value;

        public GameConstants.PieceValues Value
        {
          get { return this.value; }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged("Value");
                }

            }
        }
        private GameConstants.PieceValues actualValue;

        public GameConstants.PieceValues ActualValue
        {
            get { return actualValue; }
            set { actualValue = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
       
        private int r;

        public int R
        {
            get { return r; }
            set { r = value; }
        }
        private int c;

        public int C
        {
            get { return c; }
            set { c = value; }
        }
       
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #region COMMANDS
        const string CATEGORY = "MOUSE";
        #region MOUSE_LEFT_BUTTON_DOWN
        private RelayCommand _mouseLeftButtonDownCommand;
        public RelayCommand MouseLeftButtonDownCommand
        {
            get
            {
                if (_mouseLeftButtonDownCommand == null)
                {
                    _mouseLeftButtonDownCommand = new RelayCommand(param => ExecuteMouseLeftButtonDown((MouseEventArgs)param))
                    {
                        DisplayText = "MouseLeftButtonDownCommand",
                        Category = CATEGORY
                    };
                    
                }
                return _mouseLeftButtonDownCommand;
            }
            set { _mouseLeftButtonDownCommand = value; }
        }

        private void ExecuteMouseLeftButtonDown(MouseEventArgs e)
        {
            Debug.WriteLine("Mouse Down : " + e.GetPosition((IInputElement)e.Source));
            if (e.Source is Rectangle)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {

                    if (this.Value == GameConstants.PieceValues.BUTTON)
                    {
                        this.Value = GameConstants.PieceValues.PRESSED;
                        gameBoard.GameState = GameConstants.GameStates.IN_DECISION;
                    }else
                        if (gameBoard.GameState != GameConstants.GameStates.WON &&
                            gameBoard.GameState != GameConstants.GameStates.LOST)
                              gameBoard.GameState = GameConstants.GameStates.IN_PLAY;


                }
            }
        }
        #endregion

        #region MOUSE_LEFT_BUTTON_UP
        RelayCommand _mouseLeftButtonUpCommand;
        public RelayCommand MouseLeftButtonUpCommand
        {
            get
            {
                if (_mouseLeftButtonUpCommand == null)
                {
                    _mouseLeftButtonUpCommand = new RelayCommand(param => ExecuteMouseLeftButtonUp((MouseEventArgs)param))
                    {
                        DisplayText = "MouseLeftButtonUpCommand",
                        Category = CATEGORY
                    };
                }
                return _mouseLeftButtonUpCommand;
            }
            set { _mouseLeftButtonUpCommand = value; }
        }

        private void ExecuteMouseLeftButtonUp(MouseEventArgs e)
        {
            Debug.WriteLine("Mouse Left Button Up : " + e.GetPosition((IInputElement)e.Source));



            if (this.Value == GameConstants.PieceValues.PRESSED)
            {
                //gameBoard.Play(this.R, this.C);
                gameBoard.PlayCommand.Execute(new System.Windows.Point(this.R, this.C));
                //this.Value = GameConstants.PieceValues.BUTTON;
            }


        }

        #endregion

        #region MOUSE_ENTER
        private RelayCommand _mouseEnterCommand;
        public RelayCommand MouseEnterCommand
        {
            get
            {
                if (_mouseEnterCommand == null)
                {
                    _mouseEnterCommand = new RelayCommand(param => ExecuteMouseEnter((MouseEventArgs)param))
                    {
                        DisplayText = "MouseEnterCommand",

                        Category = CATEGORY
                    };
                }
                return _mouseEnterCommand;
            }
            set { _mouseEnterCommand = value; }
        }

        private void ExecuteMouseEnter(MouseEventArgs e)
        {
            Debug.WriteLine("Mouse Enter : " + e.GetPosition((IInputElement)e.Source));
            if (e.Source is Rectangle)
            {

                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    if (Value == GameConstants.PieceValues.BUTTON)
                    {
                        gameBoard.GameState = GameConstants.GameStates.IN_DECISION;
                        Value = GameConstants.PieceValues.PRESSED;

                    }else
                        if (gameBoard.GameState != GameConstants.GameStates.WON &&
                            gameBoard.GameState != GameConstants.GameStates.LOST)
                              gameBoard.GameState = GameConstants.GameStates.IN_PLAY;

                }
            }
        }

        private RelayCommand _mouseLeaveCommand;
        #endregion

        #region MOUSE_LEAVE
        public RelayCommand MouseLeaveCommand
        {
            get
            {
                if (_mouseLeaveCommand == null)
                {
                    _mouseLeaveCommand = new RelayCommand(param => ExecuteMouseLeave((MouseEventArgs)param))
                    {
                        DisplayText = "MouseLeaveCommand",

                        Category = CATEGORY
                    };
                }
                return _mouseLeaveCommand;
            }
            set { _mouseLeaveCommand = value; }
        }

        private void ExecuteMouseLeave(MouseEventArgs e)
        {

            Debug.WriteLine("Mouse Leave : " + e.GetPosition((IInputElement)e.Source));
            if (this.Value == GameConstants.PieceValues.PRESSED)
            {
                this.Value = GameConstants.PieceValues.BUTTON;
                
            }
            if (gameBoard.GameState != GameConstants.GameStates.WON  &&
                gameBoard.GameState != GameConstants.GameStates.LOST    )
                
                gameBoard.GameState = GameConstants.GameStates.IN_PLAY;


        }

        private RelayCommand _mouseRightButtonUpCommand;
        private ViewModels.SweeperViewModel sweeperViewModel;


        #endregion

        #region MOUSE_RB_UP
        public RelayCommand MouseRightButtonUpCommand
        {
            get
            {
                if (_mouseRightButtonUpCommand == null)
                {
                    _mouseRightButtonUpCommand = new RelayCommand(param => ExecuteMouseRightButtonUp((MouseEventArgs)param))
                    {
                        DisplayText = "MouseRightButtonUpCommand",
                        Category = CATEGORY
                    };
                }
                return _mouseRightButtonUpCommand;
            }
            set { _mouseRightButtonUpCommand = value; }
        }

        private void ExecuteMouseRightButtonUp(MouseEventArgs e)
        {

            Debug.WriteLine("Mouse RightButtonUp : " + e.GetPosition((IInputElement)e.Source));
            gameBoard.FlagCommand.Execute(new System.Windows.Point(this.R, this.C));
            //gameBoard.Flag(this.R, this.C);


        }

        #endregion


        #endregion
    }
}
