using Sweeper.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sweeper.ViewModels
{
    public partial class SweeperViewModel
    {
        #region GAME_COMMANDS
        const string CATEGORY = "GAME";
        #region NEW_GAME
        private RelayCommand _NewGameCommand;
        public RelayCommand NewGameCommand
        {
            get
            {
                if (_NewGameCommand == null)
                {
                    _NewGameCommand = new RelayCommand(param => ExecuteNewGame());
                    _NewGameCommand.DisplayText = "NewGameCommand";
                    _NewGameCommand.Category = CATEGORY;
                }
                return _NewGameCommand;
            }
            set { _NewGameCommand = value; }
        }

        private void ExecuteNewGame()
        {

            Debug.WriteLine("New Game : ");
            NewGame();
            ShowGame();
        }
        #endregion
        #region BEGINNER_GAME
        private RelayCommand _BeginnerCommand;
        public RelayCommand BeginnerCommand
        {
            get
            {
                if (_BeginnerCommand == null)
                {
                    _BeginnerCommand = new RelayCommand(param => ExecuteBeginner());
                    _BeginnerCommand.DisplayText = "BeginnerCommand";
                    _BeginnerCommand.Category = CATEGORY;
                }

                return _BeginnerCommand;
            }
            set { _BeginnerCommand = value; }
        }

        private void ExecuteBeginner()
        {
            Debug.WriteLine("Beginner : ");
            SetGameParms(GameConstants.GameTypes.BEGINNER);
            NewGame();

        }
        #endregion
        #region INTERMEDIATE_GAME
        private RelayCommand _IntermediateCommand;
        public RelayCommand IntermediateCommand
        {
            get
            {
                if (_IntermediateCommand == null)
                {
                    _IntermediateCommand = new RelayCommand(param => ExecuteIntermediate());
                    _IntermediateCommand.DisplayText = "IntermediateCommand";
                    _IntermediateCommand.Category = CATEGORY;
                }
                return _IntermediateCommand;
            }
            set { _IntermediateCommand = value; }
        }

        private void ExecuteIntermediate()
        {
            Debug.WriteLine("Intermediate : ");
            SetGameParms(GameConstants.GameTypes.INTERMEDIATE);
            NewGame();
            ShowGame();
        }
        #endregion
        #region ADVANCED_GAME
        private RelayCommand _AdvancedCommand;
        public RelayCommand AdvancedCommand
        {
            get
            {
                if (_AdvancedCommand == null)
                {
                    _AdvancedCommand = new RelayCommand(param => ExecuteAdvanced());
                    _AdvancedCommand.DisplayText = "AdvancedCommand";
                    _AdvancedCommand.Category = CATEGORY;
                }
                return _AdvancedCommand;
            }
            set { _AdvancedCommand = value; }
        }

        private void ExecuteAdvanced()
        {
            Debug.WriteLine("Advanced : ");
            SetGameParms(GameConstants.GameTypes.ADVANCED);
            NewGame();
        }
        #endregion
        #region CUSTOM_GAME
        private RelayCommand _CustomCommand;
        public RelayCommand CustomCommand
        {
            get
            {
                if (_CustomCommand == null)
                {
                    _CustomCommand = new RelayCommand(param => ExecuteCustom());
                    _CustomCommand.DisplayText = "CustomCommand";
                    _CustomCommand.Category = CATEGORY;
                }
                return _CustomCommand;
            }
            set { _CustomCommand = value; }
        }

        private void ExecuteCustom()
        {
            Debug.WriteLine("Custom : ");
            //SetGameParms(GameConstants.GameTypes.CUSTOM);
            //NewGame();
        }

        private RelayCommand _ToggleLogCommand;
        public RelayCommand ToggleLogCommand
        {
            get
            {
                if (_ToggleLogCommand == null)
                {
                    _ToggleLogCommand = new RelayCommand(param => ExecuteToggleLog());
                    _ToggleLogCommand.DisplayText = "ToggleLogCommand";
                    _ToggleLogCommand.Category = CATEGORY;
                }
                return _ToggleLogCommand;
            }
            set { _ToggleLogCommand = value; }
        }

        private void ExecuteToggleLog()
        {
            if (debugRow == "*")
                DebugRow = "0";
            else
                DebugRow = "*";

            Debug.WriteLine("ToggleLog : ");
        }

        private void NewGame()
        {
            SetGameParms(gameType);
            NewGame(Rows, Columns, Mines);
        }
        #endregion

        #region PLAY
        private RelayCommand _PlayCommand;
        public RelayCommand PlayCommand
        {
            get
            {
                if (_PlayCommand == null)
                {
                    _PlayCommand = new RelayCommand(param => ExecutePlay((Point)param));
                    _PlayCommand.DisplayText = "PlayCommand";
                    _PlayCommand.Category = CATEGORY;
                }
                return _PlayCommand;
            }
            set { _PlayCommand = value; }
        }

        private void ExecutePlay(Point pt)
        {
            //Debug.WriteLine("Play : ");
            Play((int)pt.X, (int)pt.Y);
        }
        #endregion
        #region FLAG
        private RelayCommand _FlagCommand;
        public RelayCommand FlagCommand
        {
            get
            {
                if (_FlagCommand == null)
                {
                    _FlagCommand = new RelayCommand(param => ExecuteFlag((Point)param));
                    _FlagCommand.DisplayText = "FlagCommand";
                    _FlagCommand.Category = CATEGORY;
                }
                return _FlagCommand;
            }
            set { _FlagCommand = value; }
        }

        private void ExecuteFlag(Point pt)
        {
            Flag((int)pt.X, (int)pt.Y);
        }

        #endregion
        #region GAME_ABOUT
        private RelayCommand _aboutCommand;
        public RelayCommand AboutCommand
        {
            get
            {
                if (_aboutCommand == null)
                {
                    _aboutCommand = new RelayCommand(param=>ExecuteAboutCommand())
                    {
                        DisplayText = "AboutCommand",
                        Category = CATEGORY
                    };
                }
                return _aboutCommand;
            }
            set { _aboutCommand = value; }
        }

        private void ExecuteAboutCommand()
        {
            Debug.WriteLine("About : ");
            Window w = new About();
            w.ShowDialog();          
        }
        #endregion
        #region PRESS_SMILEY
        private RelayCommand _pressSmileyCommand;
        public RelayCommand PressSmileyCommand
        {
            get
            {
                if (_pressSmileyCommand == null)
                {
                    _pressSmileyCommand = new RelayCommand(param => ExecutePressSmileyCommand())
                    {
                        DisplayText = "PressSmileyCommand",
                        Category = CATEGORY
                    };
                }
                return _pressSmileyCommand;
            }
            set { _pressSmileyCommand = value; }
        }

        private void ExecutePressSmileyCommand()
        {
            Debug.WriteLine("PressSmiley : ");
            GameState = GameConstants.GameStates.IN_DECISION;
            
        }

        #endregion
        #region UNPRESS_SMILEY
        private RelayCommand _unpressSmileyCommand;
        public RelayCommand UnPressSmileyCommand
        {
            get
            {
                if (_unpressSmileyCommand == null)
                {
                    _unpressSmileyCommand = new RelayCommand(param => ExecuteUnPressSmileyCommand())
                    {
                        DisplayText = "UnPressSmileyCommand",
                        Category = CATEGORY
                    };
                }
                return _unpressSmileyCommand;
            }
            set { _unpressSmileyCommand = value; }
        }

        private void ExecuteUnPressSmileyCommand()
        {
            Debug.WriteLine("UnPressSmiley : ");
            this.NewGameCommand.Execute(this);
        }

        #endregion
        #endregion

    }
}
