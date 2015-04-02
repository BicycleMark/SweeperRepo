using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Sweeper.ViewModels
{
    public partial class SweeperViewModel : INotifyPropertyChanged, IDisposable
    {   private Timer tmr;
        readonly ObservableCollection<GamePiece> _cells = new ObservableCollection<GamePiece>();
        public event PropertyChangedEventHandler PropertyChanged = null;
        private IAdornGameWithSounds soundAdornment;
        private IDialogService dialogService;
#region CONSTRUCTORS
        public SweeperViewModel() : this (new RealDialogService(), new SoundAdornment())
        {
           
        }
        /// <summary>
        ///  This Constructor is called everytime to ensure consistency.  
        ///  This Constructor should be the one called DIRECTLY by all Test Harness applications.
        ///  Allows you to call with your own IDialogService or Adornment that will not leave a Dialog or 
        ///  Message box on the Screen.
        /// </summary>
        /// <param name="iDlg"> </param>
        /// <param name="iSnd"></param>
        public SweeperViewModel(IDialogService iDlg, IAdornGameWithSounds iSnd)
        {
            soundAdornment = iSnd;
            dialogService  = iDlg;
            tmr = new Timer(1000);
            tmr.Elapsed += tmr_Elapsed;
            RelayCommand.NewLogItemEvent += RelayCommand_NewLogItemEvent;

        }
        
       
        void RelayCommand_NewLogItemEvent(object sender, EventArgs e)
        {
            _cmdItems.Add((LogItem)e);
        }
         
#endregion

#region PROPERTIES
        GameConstants.GameStates gameState = GameConstants.GameStates.NOT_STARTED;
        public GameConstants.GameStates GameState
        {
            get { return gameState; }
            set
            {
                if (value != gameState)
                {
                    if (value == GameConstants.GameStates.IN_PLAY)
                    {
                        //if (gameState == GameConstants.GameStates.NOT_STARTED)
                        //    if (!tmr.Enabled)
                        //        tmr.Enabled = true;
                    }
                    else
                        tmr.Enabled = false;
                    if (value == GameConstants.GameStates.LOST ||
                        value == GameConstants.GameStates.WON)
                        GameBoardEnabled = false;

                    gameState = value;
                    switch(gameState)
                    {
                        case (GameConstants.GameStates.LOST):
                            this.soundAdornment.Lost();
                            break;

                        case (GameConstants.GameStates.WON):
                            break;
                    }
                    
                        
                    OnPropertyChanged("GameState");
                }
            }
        }

        GameConstants.FaceStates faceState = GameConstants.FaceStates.GRIN;

        public GameConstants.FaceStates FaceState
        {
            get { return faceState; }
            set { faceState = value; }
        }
        private ObservableCollection<LogItem> _cmdItems = null; 

        public ObservableCollection<LogItem> CmdItems
        {
            get
            {
                if (_cmdItems == null)
                    _cmdItems = new ObservableCollection<LogItem>(RelayCommand.Log);
                    
                    return _cmdItems; }
            set { _cmdItems = value; 
                  }
        }
        public IEnumerable<GamePiece> Board
        {
            get
            {
                return _cells;
            }
        }
        private string debugRow = "0";

        public string DebugRow
        {
            get { return debugRow; }
            set { debugRow = value;
            OnPropertyChanged("DebugRow");
            }
        }    
        int rows = 9;
        public int Rows
        {
            get { return rows; }
            private set
            {
                rows = value;
                OnPropertyChanged("Rows");
            }
        }

        int columns = 9;
        public int Columns
        {
            get { return columns; }
            private set
            {
                columns = value;
                OnPropertyChanged("Columns");
            }
        }
        int mines = 10;
        public int Mines 
        { 
            get { return mines; } 
            private set { mines = value; 
                          OnPropertyChanged("Mines"); } 
        }
        int time = 0;
        public int Time
        {
            get { return time; }
            private set
            {
                time = value; //TimeString = String.Format("{0}", time); 
                OnPropertyChanged("Time");
            }
        }

        int currCol = 0;
        public int CurrCol
        {
            get { return currCol; }
            private set
            {
                currCol = value;
                OnPropertyChanged("CurrCol");
            }
        }
        int currRow = 0;
        public int CurrRow { 
            get { return currRow; } 
            private set { currRow = value; 
                          OnPropertyChanged("CurrRow"); 
            } 
        }

        bool gameBoardEnabled = true;
        public bool GameBoardEnabled
        {
            get { return gameBoardEnabled; }
            private set
            {
                gameBoardEnabled = value;
                OnPropertyChanged("GameBoardEnabled");
            }
        }

        private int minWidth = 325;
        public int MinWidth
        {
            get { return minWidth; }
            set
            {
                minWidth = value;
                OnPropertyChanged("MinWidth");
            }
        }

        private int maxWidth = 450;
        public int MaxWidth
        {
            get { return maxWidth; }
            set
            {
                maxWidth = value;
                OnPropertyChanged("MaxWidth");
            }
        }

        private int minHeight = 325;
        public int MinHeight
        {
            get { return minHeight; }
            set
            {
                minHeight = value;
                OnPropertyChanged("MinHeight");
            }
        }

        private int maxHeight = 550;
        public int MaxHeight
        {
            get { return maxHeight; }
            set
            {
                maxHeight = value;
                OnPropertyChanged("MaxHeight");
            }
        }

        private int height = 475;
        public int Height
        {
            get { return height; }
            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
        }

        private int width = 400;
        public int Width
        {
            get { return width; }
            set
            {
                width = value;
                OnPropertyChanged("Width");
            }
        }

        string title = "Mark's Sweeper Game";
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged("Title"); }
        }
#endregion

#region METHODS
        #region PRIVATE
        void tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Time += 1;
        }
        private int thisGamesMines = 0;
        private void NewGame(int r, int c, int mines)
        {
            RelayCommand.ClearLog();
            GameBoardEnabled = false;
            
            tmr.Enabled = false;
            _cells.Clear();
            int maxSeed = r * c;
           
            Random ra = new Random();
            int n = 0;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    GameConstants.PieceValues pv = GameConstants.PieceValues.NOMINE;
                    _cells.Add(new GamePiece(this, n++, i, j, pv));
                }
            }
            // Plant the Mines
            int nMinesPlanted = 0;
            while (nMinesPlanted < mines)
            {
                int nNextMinePlace = ra.Next(0, maxSeed);
                GamePiece gp = (GamePiece)_cells[nNextMinePlace];
                while (gp.ActualValue == GameConstants.PieceValues.MINE)
                {
                    nNextMinePlace = ra.Next(0, maxSeed);
                    gp = (GamePiece)_cells[nNextMinePlace];
                }
                gp.ActualValue = GameConstants.PieceValues.MINE;
                ++nMinesPlanted;
            }

            //Set Neighbor Values
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (Item(i, j).ActualValue != GameConstants.PieceValues.MINE)
                    {
                        GameConstants.PieceValues pv = GameConstants.PieceValues.NOMINE;
                        List<GamePiece> Lst = (List<GamePiece>)Neighbors(i, j);

                        foreach (GamePiece gp in Lst)
                        {
                            if (gp.ActualValue == GameConstants.PieceValues.MINE)
                                ++pv;
                        }
                        GamePiece gItem = Item(i, j);
                        gItem.ActualValue = pv;
                    }
                }
            }
            Rows = r;
            Columns = c;
            Mines = thisGamesMines = mines;
            Time = 0;
            GameState = GameConstants.GameStates.NOT_STARTED;
            GameBoardEnabled = true;
            soundAdornment.NewGame();
        }

      
        private bool isNeighbor(GamePiece gp, int r, int c)
        {
            if (gp.R == r && gp.C == c)
                return false;    //self
            int[] ra = { r - 1, r, r + 1 };

            int[] ca = { c - 1, c, c + 1 };
            if (gp.R >= r - 1 && gp.R <= r + 1)
                if (gp.C >= c - 1 && gp.C <= c + 1)
                    return true;
            return false;
        }

        private IEnumerable<GamePiece> Neighbors(int r, int c)
        {
            List<GamePiece> retVal = new List<GamePiece>(8);
            foreach (GamePiece gp in _cells)
            {
                if (isNeighbor(gp, r, c))
                {
                    retVal.Add(gp);
                    if (retVal.Count >= 8)
                        break;
                }
            }
            return retVal;
        }

        private GamePiece Item(int r, int c)
        {
            var arow = GetRow(r);
            var retVal = from gp in arow
                         where gp.C == c
                         select gp;
            return retVal.First();
        }

        private IEnumerable<GamePiece> GetRow(int r)
        {

            var retVal = from gp in _cells
                         where gp.R == r
                         select gp;

            return retVal;
        }

        private IEnumerable<GamePiece> GetCol(int c)
        {
            var retVal = from gp in _cells
                         where gp.C == c
                         select gp;

            return retVal;
        }

        private void Play(int r, int c)
        {
            GamePiece gp = Item(r, c);
            if (!gp.IsPlayed)
            {
                if (gp.ActualValue == GameConstants.PieceValues.MINE)
                {
                    gp.Value = GameConstants.PieceValues.WRONGCHOICE;

                    Lost();
                }
                else
                {
                    StartGameIfNeeded();
                    gp.Value = gp.ActualValue;
                    gp.IsPlayed = true;
                    soundAdornment.ClickItemOK();
                    if (gp.Value == GameConstants.PieceValues.NOMINE)
                        PlayNeighbors(gp);
                }
            }
        }

        private void PlayNeighbors(GamePiece gp)
        {
            List<GamePiece> lst = (List<GamePiece>)(this.Neighbors(gp.R, gp.C));
            foreach (GamePiece gmPiece in lst)
            {
                Play(gmPiece.R, gmPiece.C);
                
            }
        }

        private void StartGameIfNeeded()
        {
            if (!tmr.Enabled)
            {
                GameState = GameConstants.GameStates.IN_PLAY;
                tmr.Enabled = true;
            }
        }

        private void Lost()
        {
            tmr.Enabled = false;
            GameState = GameConstants.GameStates.LOST;
            GameBoardEnabled = false;
        }

        private void Flag(int r, int c)
        {
            GamePiece gp = Item(r, c);
            if (gp.Value == GameConstants.PieceValues.BUTTON)
            {
                gp.Value = GameConstants.PieceValues.FLAGGED;
                Mines--;
                soundAdornment.ClickItemOK();

            }
            else if (gp.Value == GameConstants.PieceValues.FLAGGED)
            {
                gp.Value = GameConstants.PieceValues.BUTTON;
                Mines++;
                soundAdornment.ClickItemOK();
            }
            if (Mines == 0)
                if (EvaluateWin())
                    GameState = GameConstants.GameStates.WON;

        }

        private bool EvaluateWin()
        {
            //TODO  1) Evaluate entry conditions
            //      2) Optimize to linq
            bool allFlagsSetCorrectly = true;
            bool continueEval = true;
            for (int i = 0;
                 i < _cells.Count() && continueEval;
                 i++)
            {
                if (_cells[i].ActualValue == GameConstants.PieceValues.MINE)
                    if (_cells[i].Value != GameConstants.PieceValues.FLAGGED)
                    {
                        continueEval = allFlagsSetCorrectly = false;
                    }
            }

            return allFlagsSetCorrectly;
        }


        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        bool[] gameTypeBinding = { true, false, false, false };
        private void ShowGame()
        {

            int newW = this.width;
            int newH = this.height;

            Height = newH;
            Width = newW;

            MinWidth  = (int)0.75 * newW;
            MaxWidth  = (int)1.25 * newW;
            MinHeight = (int)0.75 * newH;
            MaxHeight = (int)1.25 * newH;

        }
        #endregion
        #region PUBLIC
        public void SetGameParms(GameConstants.GameTypes gType)
        {
            int ndx = (int)gType;
            rows    = GameConstants.GameTypeArray[ndx, GameConstants.NDX_ROW    ];
            columns = GameConstants.GameTypeArray[ndx, GameConstants.NDX_COL    ];
            mines   = GameConstants.GameTypeArray[ndx, GameConstants.NDX_MINE   ];
            width   = GameConstants.GameTypeArray[ndx, GameConstants.NDX_WIDTH  ];
            height  = GameConstants.GameTypeArray[ndx, GameConstants.NDX_HEIGHT ];

            for (GameConstants.GameTypes gt = GameConstants.GameTypes.BEGINNER;
                                         gt <= GameConstants.GameTypes.CUSTOM;
                                         gt++)
            {
                int itemIndex = (int)gt;
                if (ndx != itemIndex)
                    gameTypeBinding[itemIndex] = false;
                else
                    gameTypeBinding[itemIndex] = true;

            }
            gameType= gType;           
        }
        #endregion
#endregion

       
        #region IDSPOSABLE
        public void Dispose()
        {
          
        }
#endregion


        private GameConstants.GameTypes gameType;

        public GameConstants.GameTypes GameType
        {
            get { return gameType; }
            private set
            {
                gameType = value;
                OnPropertyChanged("gameType");
            }
        }

    }//END CLASS
}//END NAMESPACE
