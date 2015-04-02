using Sweeper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Sweeper.Views
{
    public class FaceButtonConverter : System.Windows.Data.IValueConverter
    {
        
        public static  VisualBrush []FaceBrushes;
       
        public  FaceButtonConverter()
        {
            
            int LastPiece = (int)GameConstants.FaceStates.SAD_PRESSED + 1;
            FaceBrushes = new VisualBrush[LastPiece];
            FaceBrushes[(int)GameConstants.FaceStates.SMILE]            = (VisualBrush)Application.Current.FindResource("FSMILEUP");
            FaceBrushes[(int)GameConstants.FaceStates.SMILE_PRESSED]    = (VisualBrush)Application.Current.FindResource("FSMILEDN");
            FaceBrushes[(int)GameConstants.FaceStates.TENSE]            = (VisualBrush)Application.Current.FindResource("FSURPRISEUP");
            FaceBrushes[(int)GameConstants.FaceStates.TENSE_PRESSED]    = (VisualBrush)Application.Current.FindResource("FSURPRISEDN");
            FaceBrushes[(int)GameConstants.FaceStates.WINK]             = (VisualBrush)Application.Current.FindResource("FWINKUP");
            FaceBrushes[(int)GameConstants.FaceStates.WINK_PRESSED]     = (VisualBrush)Application.Current.FindResource("FWINKDN");
            FaceBrushes[(int)GameConstants.FaceStates.GRIN]             = (VisualBrush)Application.Current.FindResource("FGRINUP");
            FaceBrushes[(int)GameConstants.FaceStates.GRIN_PRESSED]     = (VisualBrush)Application.Current.FindResource("FGRINDN");
            FaceBrushes[(int)GameConstants.FaceStates.SAD]              = (VisualBrush)Application.Current.FindResource("FSADUP");
            FaceBrushes[(int)GameConstants.FaceStates.SAD_PRESSED]      = (VisualBrush)Application.Current.FindResource("FSADDN");  
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            VisualBrush returnBrush = null;
            GameConstants.GameStates gs = (GameConstants.GameStates)value;
            switch(gs)
            {
                case (GameConstants.GameStates.NOT_DETERMINED):
                    returnBrush = FaceBrushes[(int)GameConstants.FaceStates.SMILE];
                break;
                case (GameConstants.GameStates.NOT_STARTED):
                  returnBrush = FaceBrushes[(int)GameConstants.FaceStates.SMILE];
                break;
                case (GameConstants.GameStates.IN_DECISION):
                returnBrush = FaceBrushes[(int)GameConstants.FaceStates.TENSE_PRESSED];
                break;
                case (GameConstants.GameStates.IN_PLAY):
                    returnBrush = FaceBrushes[(int)GameConstants.FaceStates.SMILE];
                break;
                case (GameConstants.GameStates.WON):
                    returnBrush = FaceBrushes[(int)GameConstants.FaceStates.GRIN];
                break;
                case (GameConstants.GameStates.LOST):
                    returnBrush = FaceBrushes[(int)GameConstants.FaceStates.SAD];
                break;
            }
            

            
            return returnBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
