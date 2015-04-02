using Sweeper.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Sweeper.Views
{
    public class BrushConverter : System.Windows.Data.IValueConverter
    {
        DrawingBrush []PieceBrushes;
       
        public  BrushConverter()
        {
            int LastPiece   = (int)GameConstants.PieceValues.EIGHTMINE + 1;
            PieceBrushes    = new DrawingBrush[LastPiece];
            PieceBrushes[(int)GameConstants.PieceValues.BLANK       ] =     new DrawingBrush(null);
            PieceBrushes[(int)GameConstants.PieceValues.BUTTON      ] =     (DrawingBrush)Application.Current.FindResource("P_BUTTON" ); 
            PieceBrushes[(int)GameConstants.PieceValues.PRESSED     ] =     (DrawingBrush)Application.Current.FindResource("P_PRESSED");
            PieceBrushes[(int)GameConstants.PieceValues.FLAGGED     ] =     (DrawingBrush)Application.Current.FindResource("P_FLAGGED");//new DrawingBrush(null);// 
            PieceBrushes[(int)GameConstants.PieceValues.WRONGCHOICE ] =     (DrawingBrush)Application.Current.FindResource("P_MINESHADOW-WRONG");
            PieceBrushes[(int)GameConstants.PieceValues.MINE        ] =     (DrawingBrush)Application.Current.FindResource("P_MINE");
            PieceBrushes[(int)GameConstants.PieceValues.NOMINE      ] =     new DrawingBrush(null);
            PieceBrushes[(int)GameConstants.PieceValues.ONEMINE     ] =     (DrawingBrush)Application.Current.FindResource("P_ONE"    );  
            PieceBrushes[(int)GameConstants.PieceValues.TWOMINE     ] =     (DrawingBrush)Application.Current.FindResource("P_TWO"    );  
            PieceBrushes[(int)GameConstants.PieceValues.THREEMINE   ] =     (DrawingBrush)Application.Current.FindResource("P_THREE"  );  
            PieceBrushes[(int)GameConstants.PieceValues.FOURMINE    ] =     (DrawingBrush)Application.Current.FindResource("P_FOUR"   );  
            PieceBrushes[(int)GameConstants.PieceValues.FIVEMINE    ] =     (DrawingBrush)Application.Current.FindResource("P_FIVE"   );  
            PieceBrushes[(int)GameConstants.PieceValues.SIXMINE     ] =     (DrawingBrush)Application.Current.FindResource("P_SIX"    );
            PieceBrushes[(int)GameConstants.PieceValues.SEVENMINE   ] =     (DrawingBrush)Application.Current.FindResource("P_SEVEN");
            PieceBrushes[(int)GameConstants.PieceValues.EIGHTMINE   ] =     (DrawingBrush)Application.Current.FindResource("P_EIGHT");

        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DrawingBrush returnBrush = PieceBrushes[0];
            int n = (int)(GameConstants.PieceValues)value;
            return PieceBrushes[n];
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
