using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweeper.ViewModels
{
    public class LogItem : EventArgs
    {

        public override String ToString()
        {
            return cmdText;
        }
        public LogItem(string txt, object parameter)
        {
            cmdText = txt;
            parm = parameter;
            timeStamp = DateTime.Now;

        }
        private DateTime timeStamp;

        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set
            {
                timeStamp = value;

            }
        }
        private string cmdText;

        public string CmdText
        {
            get { return cmdText; }
            set
            {
                cmdText = value;
                // OnPropertyChanged("CmdText");
            }
        }
        private object parm;

        public object Parm
        {
            get { return parm; }
            set
            {
                parm = value;
                //OnPropertyChanged("Parm");
            }
        }
        private GameConstants.GameStates gameState = GameConstants.GameStates.NOT_DETERMINED;

        public GameConstants.GameStates GameState
        {
            get { return gameState; }
            set { gameState = value; }
        }

        private int time;

        public int Time
        {
            get { return time; }
            set { time = value; }
        }

    }
}
