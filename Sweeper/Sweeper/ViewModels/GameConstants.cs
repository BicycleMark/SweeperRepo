using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweeper.ViewModels
{
    public class GameConstants
    {
        public enum GameTypes
        {
            BEGINNER,
            INTERMEDIATE,
            ADVANCED,
            CUSTOM

        }
        
        public static int [,]GameTypeArray = {
                                         {9,    9,      10,     300,    400}, //Beginner
                                         {16,   16,     40,     800,    800}, //Intermediate
                                         {16,   30,     99,     900,    800}, //Advanced
                                         {20,   30,     115,    950,    1100} //Custom
                                        };
        // Index Interpretations for above Columns
        public const int NDX_ROW    = 0;
        public const int NDX_COL    = 1;
        public const int NDX_MINE   = 2;
        public const int NDX_WIDTH  = 3;
        public const int NDX_HEIGHT = 4;

        
        public enum PieceValues
        {
            BLANK       ,
            BUTTON      ,
            PRESSED     ,
            FLAGGED     ,
            WRONGCHOICE ,
            MINE        ,           
            NOMINE      ,
            ONEMINE     ,
            TWOMINE     ,
            THREEMINE   ,
            FOURMINE    ,
            FIVEMINE    ,
            SIXMINE     ,
            SEVENMINE   ,
            EIGHTMINE
            
        }

        public enum GameStates
        {
            NOT_DETERMINED,
            NOT_STARTED,
            IN_DECISION,
            IN_PLAY,
            WON,
            LOST
        }
        public enum FaceStates
        {
            SMILE,
            SMILE_PRESSED,
            TENSE,
            TENSE_PRESSED,
            WINK,
            WINK_PRESSED,
            GRIN,
            GRIN_PRESSED,
            SAD,
            SAD_PRESSED
        }
       
    }
}
